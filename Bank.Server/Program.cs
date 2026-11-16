using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank.Common;

namespace Bank.Server
{
    static class Program
    {
        private const int PORT = 8888;
        private static TcpListener? _server;

        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            // 1. Khởi động bộ quản lý mạng lưới ATM & nhịp tim (AtmManager)
            AtmManager.Initialize();

            // 2. Chạy Socket TCP Server trên một luồng nền độc lập
            Task.Run(() => StartSocketListener());

            // 3. Khởi chạy Giao diện Giám sát Trung tâm (Central Monitoring Dashboard)
            Application.Run(new FormServerDashboard());
        }

        private static void StartSocketListener()
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, PORT);
                _server.Start();

                AtmManager.Log($"[SERVER] Máy chủ Core Banking đang lắng nghe kết nối tại cổng {PORT}.", "SUCCESS");

                while (true)
                {
                    try
                    {
                        TcpClient client = _server.AcceptTcpClient();
                        Task.Run(() => HandleATMClient(client));
                    }
                    catch (Exception ex)
                    {
                        AtmManager.Log($"[LỖI TIẾP NHẬN]: {ex.Message}", "ERROR");
                    }
                }
            }
            catch (Exception ex)
            {
                AtmManager.Log($"[LỖI KHỞI ĐỘNG SERVER]: {ex.Message}", "ERROR");
            }
        }

        private static void HandleATMClient(TcpClient client)
        {
            string clientIP = client.Client.RemoteEndPoint?.ToString() ?? "Unknown";
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[2048];

            try
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Xử lý nghiệp vụ ngân hàng
                    string response = ProcessCommand(request, clientIP);

                    // Gửi kết quả ngược lại cho cây ATM
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
            catch (Exception)
            {
                // Khi client đóng kết nối (hoặc đứt mạng)
            }
            finally
            {
                client.Close();
            }
        }

        private static string ProcessCommand(string request, string clientIP)
        {
            string[] parts = request.Split('|');
            string action = parts[0].Trim();

            switch (action)
            {
                // LUỒNG 0: ĐĂNG KÝ CÂY ATM (Format: REGISTER_ATM|maAtm|tenTram)
                case "REGISTER_ATM":
                    {
                        string maAtm = parts.Length > 1 ? parts[1].Trim() : "ATM01";
                        string tenTram = parts.Length > 2 ? parts[2].Trim() : $"Cây ATM {maAtm}";
                        var reg = AtmManager.RegisterAtm(maAtm, clientIP, tenTram);
                        return $"REGISTER_SUCCESS|{maAtm}|{reg.CurrentStatus}";
                    }

                // LUỒNG 0B: NHỊP TIM ĐỊNH KỲ (Format: HEARTBEAT|maAtm)
                case "HEARTBEAT":
                    {
                        string maAtm = parts.Length > 1 ? parts[1].Trim() : "ATM01";
                        var hb = AtmManager.ProcessHeartbeat(maAtm, clientIP);
                        if (hb.CurrentStatus == "Bảo trì" || hb.CurrentStatus == "Maintenance")
                        {
                            return $"HEARTBEAT_ACK|{maAtm}|MAINTENANCE";
                        }
                        return $"HEARTBEAT_ACK|{maAtm}|OK";
                    }

                // LUỒNG 1: XÁC THỰC ĐĂNG NHẬP (Format: LOGIN|soThe|maPIN|[maAtm])
                case "LOGIN":
                    {
                        if (parts.Length < 3)
                        {
                            return "LOGIN_FAIL|Dữ liệu đăng nhập không hợp lệ!";
                        }

                        string soThe = parts[1].Trim();
                        string pin = parts[2].Trim();
                        string maAtm = parts.Length > 3 ? parts[3].Trim() : "ATM01";

                        // Kiểm tra xem cây ATM này có đang bảo trì không
                        var terminals = AtmManager.GetAllTerminals();
                        var thisAtm = terminals.Find(x => x.MaATM.Equals(maAtm, StringComparison.OrdinalIgnoreCase));
                        if (thisAtm != null && (thisAtm.TrangThai == "Bảo trì" || thisAtm.TrangThai == "Maintenance"))
                        {
                            AtmManager.Log($"Từ chối đăng nhập tại cây {maAtm}: Cây ATM đang BẢO TRÌ!", "WARN");
                            return "LOGIN_FAIL|Cây ATM này đang trong thời gian bảo trì kỹ thuật. Quý khách vui lòng giao dịch tại trạm khác!";
                        }

                        AccountDTO acc = DatabaseHelper.KiemTraDangNhap(soThe, pin);

                        if (acc.ThanhCong)
                        {
                            AtmManager.Log($"Đăng nhập thành công: {acc.HoTen} (STK: {acc.SoTaiKhoan}) tại trạm {maAtm}", "SUCCESS");
                            return $"LOGIN_SUCCESS|{acc.HoTen}|{acc.SoDu}|{acc.SoTaiKhoan}";
                        }
                        else
                        {
                            AtmManager.Log($"Đăng nhập thất bại thẻ {soThe}: {acc.ThongBao} tại trạm {maAtm}", "WARN");
                            return $"LOGIN_FAIL|{acc.ThongBao}";
                        }
                    }

                // LUỒNG 2: RÚT TIỀN MẶT (Format: WITHDRAW|soThe|soTien|[maAtm])
                case "WITHDRAW":
                    {
                        if (parts.Length < 3)
                        {
                            return "WITHDRAW_FAIL|Dữ liệu rút tiền không hợp lệ!";
                        }

                        string soTheRut = parts[1].Trim();
                        if (!decimal.TryParse(parts[2].Trim(), out decimal soTienRut))
                        {
                            return "WITHDRAW_FAIL|Số tiền rút không hợp lệ!";
                        }
                        string maAtm = parts.Length > 3 ? parts[3].Trim() : "ATM01";

                        // Gọi tầng CSDL với khóa dòng Pessimistic Row-Level Lock
                        var ketQuaRut = DatabaseHelper.RutTien(soTheRut, soTienRut, maAtm);
                        if (ketQuaRut.Success)
                        {
                            AtmManager.DeductAtmCash(maAtm, soTienRut);
                            AtmManager.Log($"Rút tiền thành công: -{soTienRut:N0} đ tại cây {maAtm} (Thẻ: {soTheRut}). Số dư mới: {ketQuaRut.SoDuMoi:N0} đ", "SUCCESS");
                            return $"WITHDRAW_SUCCESS|{soTienRut}|{ketQuaRut.SoDuMoi}";
                        }
                        else
                        {
                            AtmManager.Log($"Rút tiền thất bại thẻ {soTheRut}: {ketQuaRut.ThongBao}", "WARN");
                            return $"WITHDRAW_FAIL|{ketQuaRut.ThongBao}";
                        }
                    }

                // LUỒNG 3: TRUY VẤN LỊCH SỬ GIAO DỊCH (Format: HISTORY|soTaiKhoan)
                case "HISTORY":
                    {
                        if (parts.Length < 2)
                        {
                            return "HISTORY_FAIL|Thiếu số tài khoản!";
                        }

                        string stkHistory = parts[1].Trim();
                        var listGD = DatabaseHelper.LayLichSuGiaoDich(stkHistory);

                        if (listGD == null || listGD.Count == 0)
                        {
                            return "HISTORY_EMPTY";
                        }

                        var sbHistory = new StringBuilder("HISTORY_SUCCESS|");
                        for (int i = 0; i < listGD.Count; i++)
                        {
                            var gd = listGD[i];
                            sbHistory.Append($"{gd.ThoiGian}#{gd.LoaiGiaoDich}#{gd.SoTien}#{gd.TrangThai}");
                            if (i < listGD.Count - 1)
                            {
                                sbHistory.Append(";");
                            }
                        }
                        return sbHistory.ToString();
                    }

                // LUỒNG 4: KIỂM TRA TÊN NGƯỜI NHẬN (Format: CHECK_ACCOUNT|soTaiKhoan)
                case "CHECK_ACCOUNT":
                    {
                        if (parts.Length < 2)
                        {
                            return "CHECK_ACCOUNT_FAIL|Vui lòng nhập số tài khoản!";
                        }

                        string stkCheck = parts[1].Trim();
                        var checkResult = DatabaseHelper.KiemTraTaiKhoan(stkCheck);

                        if (checkResult.Success)
                        {
                            return $"CHECK_ACCOUNT_SUCCESS|{checkResult.HoTen}";
                        }
                        else
                        {
                            return $"CHECK_ACCOUNT_FAIL|{checkResult.ThongBao}";
                        }
                    }

                // LUỒNG 5: CHUYỂN KHOẢN (Format: TRANSFER|stkGui|stkNhan|soTien|noiDung|[maAtm])
                case "TRANSFER":
                    {
                        if (parts.Length < 5)
                        {
                            return "TRANSFER_FAIL|Dữ liệu chuyển khoản không hợp lệ!";
                        }

                        string stkGui = parts[1].Trim();
                        string stkNhan = parts[2].Trim();
                        if (!decimal.TryParse(parts[3].Trim(), out decimal soTienChuyen))
                        {
                            return "TRANSFER_FAIL|Số tiền chuyển không hợp lệ!";
                        }
                        string noiDung = parts[4].Trim();
                        string maAtm = parts.Length > 5 ? parts[5].Trim() : "ATM01";

                        var ketQuaChuyen = DatabaseHelper.ChuyenKhoan(stkGui, stkNhan, soTienChuyen, noiDung, maAtm);
                        if (ketQuaChuyen.Success)
                        {
                            AtmManager.Log($"Chuyển khoản thành công: {soTienChuyen:N0} đ từ TK {stkGui} sang TK {stkNhan} (Trạm: {maAtm})", "SUCCESS");
                            return $"TRANSFER_SUCCESS|{soTienChuyen}|{ketQuaChuyen.SoDuMoi}";
                        }
                        else
                        {
                            AtmManager.Log($"Chuyển khoản thất bại từ TK {stkGui}: {ketQuaChuyen.ThongBao}", "WARN");
                            return $"TRANSFER_FAIL|{ketQuaChuyen.ThongBao}";
                        }
                    }

                // LUỒNG 6: ĐỔI MÃ PIN (Format: CHANGE_PIN|soThe|oldPin|newPin)
                case "CHANGE_PIN":
                    {
                        if (parts.Length < 4)
                        {
                            return "CHANGE_PIN_FAIL|Dữ liệu đổi PIN không hợp lệ!";
                        }

                        string cardPin = parts[1].Trim();
                        string oldPin = parts[2].Trim();
                        string newPin = parts[3].Trim();

                        var resPin = DatabaseHelper.DoiMaPIN(cardPin, oldPin, newPin);
                        if (resPin.Success)
                        {
                            AtmManager.Log($"Đổi mã PIN thành công cho thẻ {cardPin}", "SUCCESS");
                            return $"CHANGE_PIN_SUCCESS|{resPin.ThongBao}";
                        }
                        else
                        {
                            return $"CHANGE_PIN_FAIL|{resPin.ThongBao}";
                        }
                    }

                default:
                    return "ERROR|Lệnh không hợp lệ!";
            }
        }
    }
}

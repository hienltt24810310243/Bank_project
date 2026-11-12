using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Bank.Common; // Kết nối tới tầng CSDL của Hiền

namespace Bank.Server
{
    class Program
    {
        // Cổng mạng Server lắng nghe (Port 8888)
        private const int PORT = 8888;

        // Đối tượng dùng để KHÓA LUỒNG chống Race Condition khi rút tiền sau này
        private static readonly object _accountLock = new object();

        static void Main(string[] args)
        {
            // Thiết lập font chữ tiếng Việt cho màn hình Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "CORE BANKING SERVER - HE THONG QUAN LY ATM [EPU]";

            // 1. Mở Socket lắng nghe trên tất cả các địa chỉ IP của máy, cổng 8888
            TcpListener server = new TcpListener(IPAddress.Any, PORT);
            server.Start();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================================================");
            Console.WriteLine("   HE THONG NGAN HANG DIEN LUC (EPU BANK) - CORE SERVER V2.4");
            Console.WriteLine($"   [SERVER] Dang lang nghe ket noi tren cong: {PORT}");
            Console.WriteLine("   [TRANG THAI] San sang tiep nhan cac cay ATM truc tuyen...");
            Console.WriteLine("====================================================================\n");
            Console.ResetColor();

            // 2. Vòng lặp liên tục đón nhận các cây ATM kết nối tới (Chạy 24/7)
            while (true)
            {
                try
                {
                    // Chờ khi có 1 cây ATM kết nối vào...
                    TcpClient client = server.AcceptTcpClient();

                    // ĐA LUỒNG (CONCURRENCY): Dùng Task.Run để đẩy cây ATM này sang 1 luồng riêng
                    // Nhờ vậy Server có thể phục vụ hàng chục cây ATM cùng lúc mà không bị nghẽn
                    Task.Run(() => HandleATMClient(client));
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[LOI SERVER]: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        // =================================================================
        // HÀM XỬ LÝ RIÊNG BIỆT CHO TỪNG CÂY ATM (CHẠY TRÊN 1 LUỒNG ĐỘC LẬP)
        // =================================================================
        private static void HandleATMClient(TcpClient client)
        {
            string clientIP = client.Client.RemoteEndPoint.ToString();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] [KET NOI MOI] Cay ATM tai dia chi [{clientIP}] da ket noi thanh cong!");
            Console.ResetColor();

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                int bytesRead;
                // Liên tục đọc các gói tin do cây ATM của An gửi sang
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n[>>> NHAN LENH tu {clientIP}]: {request}");
                    Console.ResetColor();

                    // Xử lý nghiệp vụ ngân hàng
                    string response = ProcessCommand(request);

                    // Bắn kết quả ngược lại cho cây ATM hiển thị
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[<<< PHAN HOI ve {clientIP}]: {response}");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[-] [NGAT KET NOI] Cay ATM [{clientIP}] da dong ket noi. ({ex.Message})");
                Console.ResetColor();
            }
            finally
            {
                client.Close();
            }
        }

        // =================================================================
        // BỘ NÃO PHÂN TÍCH VÀ XỬ LÝ LỆNH NGHIỆP VỤ (GIAO THỨC TỰ ĐỊNH NGHĨA)
        // =================================================================
        private static string ProcessCommand(string request)
        {
            // Các trường dữ liệu gửi sang được ngăn cách bởi dấu gạch đứng |
            string[] parts = request.Split('|');
            string action = parts[0];

            switch (action)
            {
                // LUỒNG 1: XÁC THỰC ĐĂNG NHẬP (Format: LOGIN|soThe|maPIN)
                case "LOGIN":
                    if (parts.Length < 3)
                    {
                        return "LOGIN_FAIL|Dữ liệu đăng nhập không hợp lệ!";
                    }

                    string soThe = parts[1];
                    string pin = parts[2];

                    // KẾT NỐI TẦNG CSDL CỦA HIỀN ĐỂ KIỂM TRA TRONG SQL SERVER THẬT
                    AccountDTO acc = DatabaseHelper.KiemTraDangNhap(soThe, pin);

                    if (acc.ThanhCong)
                    {
                        // Trả về: LOGIN_SUCCESS|Họ tên chủ thẻ|Số dư|Số tài khoản
                        return $"LOGIN_SUCCESS|{acc.HoTen}|{acc.SoDu}|{acc.SoTaiKhoan}";
                    }
                    else
                    {
                        // Trả về lý do thất bại (sai PIN, thẻ bị khóa, thẻ không tồn tại, ...)
                        return $"LOGIN_FAIL|{acc.ThongBao}";
                    }

                // LUỒNG 2: RÚT TIỀN MẶT (Format: WITHDRAW|soThe|soTien)
                case "WITHDRAW":
                    if (parts.Length < 3)
                    {
                        return "WITHDRAW_FAIL|Dữ liệu rút tiền không hợp lệ!";
                    }

                    lock (_accountLock)
                    {
                        string soTheRut = parts[1];
                        if (!decimal.TryParse(parts[2], out decimal soTienRut))
                        {
                            return "WITHDRAW_FAIL|Số tiền rút không hợp lệ!";
                        }

                        var ketQuaRut = DatabaseHelper.RutTien(soTheRut, soTienRut);
                        if (ketQuaRut.Success)
                        {
                            return $"WITHDRAW_SUCCESS|{soTienRut}|{ketQuaRut.SoDuMoi}";
                        }
                        else
                        {
                            return $"WITHDRAW_FAIL|{ketQuaRut.ThongBao}";
                        }
                    }

                // LUỒNG 3: TRUY VẤN LỊCH SỬ GIAO DỊCH (Format: HISTORY|soTaiKhoan)
                case "HISTORY":
                    if (parts.Length < 2)
                    {
                        return "HISTORY_FAIL|Thiếu số tài khoản!";
                    }

                    string stkHistory = parts[1];
                    var listGD = DatabaseHelper.LayLichSuGiaoDich(stkHistory);

                    if (listGD == null || listGD.Count == 0)
                    {
                        return "HISTORY_EMPTY";
                    }

                    // Format: HISTORY_SUCCESS|ThoiGian#LoaiGD#SoTien#TrangThai;ThoiGian#LoaiGD#...
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

                // LUỒNG 4: KIỂM TRA TÊN NGƯỜI NHẬN (Format: CHECK_ACCOUNT|soTaiKhoan)
                case "CHECK_ACCOUNT":
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

                // LUỒNG 5: CHUYỂN KHOẢN (Format: TRANSFER|stkGui|stkNhan|soTien|noiDung)
                case "TRANSFER":
                    if (parts.Length < 5)
                    {
                        return "TRANSFER_FAIL|Dữ liệu chuyển khoản không hợp lệ!";
                    }

                    lock (_accountLock)
                    {
                        string stkGui = parts[1].Trim();
                        string stkNhan = parts[2].Trim();
                        if (!decimal.TryParse(parts[3], out decimal soTienChuyen))
                        {
                            return "TRANSFER_FAIL|Số tiền chuyển không hợp lệ!";
                        }
                        string noiDung = parts[4].Trim();

                        var ketQuaChuyen = DatabaseHelper.ChuyenKhoan(stkGui, stkNhan, soTienChuyen, noiDung);
                        if (ketQuaChuyen.Success)
                        {
                            return $"TRANSFER_SUCCESS|{soTienChuyen}|{ketQuaChuyen.SoDuMoi}";
                        }
                        else
                        {
                            return $"TRANSFER_FAIL|{ketQuaChuyen.ThongBao}";
                        }
                    }

                // LUỒNG 6: ĐỔI MÃ PIN (Format: CHANGE_PIN|soThe|oldPin|newPin)
                case "CHANGE_PIN":
                    if (parts.Length < 4)
                    {
                        return "CHANGE_PIN_FAIL|Dữ liệu đổi PIN không hợp lệ!";
                    }

                    lock (_accountLock)
                    {
                        string cardPin = parts[1].Trim();
                        string oldPin = parts[2].Trim();
                        string newPin = parts[3].Trim();

                        var resPin = DatabaseHelper.DoiMaPIN(cardPin, oldPin, newPin);
                        if (resPin.Success)
                        {
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

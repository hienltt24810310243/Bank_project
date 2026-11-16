using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bank.Common;

namespace Bank.Server
{
    /// <summary>
    /// Bộ não quản lý trạng thái, nhịp tim (Heartbeat) và mạng lưới ATM phân tán tại Server
    /// </summary>
    public static class AtmManager
    {
        // Danh sách các cây ATM đang được quản lý trong bộ nhớ Server
        private static readonly ConcurrentDictionary<string, AtmTerminalDTO> _terminals = new();

        // Sự kiện thông báo khi trạng thái ATM thay đổi hoặc có log mới (để cập nhật Dashboard)
        public static event Action? OnAtmListChanged;
        public static event Action<string, string>? OnLogMessage; // (message, logType: INFO, WARN, ERROR, SUCCESS)

        // Timer kiểm tra ngắt kết nối Heartbeat định kỳ
        private static System.Threading.Timer? _watchdogTimer;

        public static void Initialize()
        {
            // 1. Tải danh sách các cây ATM từ CSDL SQL Server vào RAM
            LoadAtmFromDatabase();

            // 2. Kích hoạt Watchdog Timer chạy mỗi 3 giây kiểm tra mất kết nối Heartbeat
            _watchdogTimer = new System.Threading.Timer(WatchdogCheck, null, 3000, 3000);

            Log("Hệ thống quản lý trạng thái ATM (AtmManager) đã khởi động sẵn sàng.", "INFO");
        }

        public static void LoadAtmFromDatabase()
        {
            try
            {
                var listFromDb = DatabaseHelper.LayDanhSachMayATM();
                if (listFromDb.Count == 0)
                {
                    // Nếu DB chưa có dữ liệu mẫu, tạo 3 trạm chuẩn
                    _terminals["ATM01"] = new AtmTerminalDTO
                    {
                        MaATM = "ATM01",
                        TenTram = "ATM ĐH Điện Lực (EPU)",
                        ViTri = "235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội",
                        TongTienMat = 90000000,
                        TrangThai = "Mất kết nối"
                    };
                    _terminals["ATM02"] = new AtmTerminalDTO
                    {
                        MaATM = "ATM02",
                        TenTram = "ATM Chi nhánh Đống Đa",
                        ViTri = "100 Tây Sơn, Đống Đa, Hà Nội",
                        TongTienMat = 75000000,
                        TrangThai = "Mất kết nối"
                    };
                    _terminals["ATM03"] = new AtmTerminalDTO
                    {
                        MaATM = "ATM03",
                        TenTram = "ATM Chi nhánh Hà Đông",
                        ViTri = "10 Trần Phú, Hà Đông, Hà Nội",
                        TongTienMat = 60000000,
                        TrangThai = "Bảo trì"
                    };
                }
                else
                {
                    foreach (var atm in listFromDb)
                    {
                        // Khi server vừa bật, các cây chưa gửi heartbeat thì để "Mất kết nối" (hoặc giữ nguyên "Bảo trì")
                        if (atm.TrangThai != "Bảo trì")
                        {
                            atm.TrangThai = "Mất kết nối";
                        }
                        _terminals[atm.MaATM] = atm;
                    }

                    // Đảm bảo trạm ATM03 luôn hiện diện trên Dashboard
                    if (!_terminals.ContainsKey("ATM03"))
                    {
                        _terminals["ATM03"] = new AtmTerminalDTO
                        {
                            MaATM = "ATM03",
                            TenTram = "ATM Chi nhánh Hà Đông",
                            ViTri = "10 Trần Phú, Hà Đông, Hà Nội",
                            TongTienMat = 50000000,
                            TrangThai = "Mất kết nối"
                        };
                    }
                }
                OnAtmListChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Log("Lỗi nạp danh sách ATM: " + ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// Xử lý khi có một cây ATM gửi gói tin ĐĂNG KÝ hoặc KẾT NỐI LẠI
        /// </summary>
        public static (bool Success, string Message, string CurrentStatus) RegisterAtm(string maAtm, string clientIp, string? tenTram = null)
        {
            maAtm = maAtm.Trim().ToUpper();
            if (!_terminals.TryGetValue(maAtm, out var atm))
            {
                atm = new AtmTerminalDTO
                {
                    MaATM = maAtm,
                    TenTram = string.IsNullOrEmpty(tenTram) ? $"Cây ATM {maAtm}" : tenTram,
                    ViTri = "Trạm phân tán EPU Bank",
                    TongTienMat = 50000000,
                    TrangThai = "Online"
                };
                _terminals[maAtm] = atm;
            }

            atm.IpAddress = clientIp;
            atm.LastHeartbeat = DateTime.Now;

            // Nếu đang bị Admin đặt là "Bảo trì", giữ nguyên bảo trì
            if (atm.TrangThai != "Bảo trì")
            {
                atm.TrangThai = "Online";
                DatabaseHelper.CapNhatTrangThaiMayATM(maAtm, "Online");
            }

            Log($"Cây {atm.MaATM} ({atm.TenTram}) đã kết nối thành công từ IP: [{clientIp}]. Trạng thái: {atm.TrangThai}", "SUCCESS");
            OnAtmListChanged?.Invoke();

            return (true, "Đăng ký thành công", atm.TrangThai);
        }

        /// <summary>
        /// Xử lý gói tin NHỊP TIM (HEARTBEAT) do cây ATM gửi lên định kỳ
        /// </summary>
        public static (bool Success, string CurrentStatus) ProcessHeartbeat(string maAtm, string clientIp)
        {
            maAtm = maAtm.Trim().ToUpper();
            if (!_terminals.TryGetValue(maAtm, out var atm))
            {
                // Nếu chưa đăng ký, tự động đăng ký
                RegisterAtm(maAtm, clientIp);
                return (true, "Online");
            }

            atm.IpAddress = clientIp;
            atm.LastHeartbeat = DateTime.Now;

            bool stateChanged = false;
            // Nếu trước đó đang bị "Mất kết nối", nay nhận được heartbeat -> Tự phục hồi thành Online!
            if (atm.TrangThai == "Mất kết nối" || atm.TrangThai == "Offline")
            {
                atm.TrangThai = "Online";
                DatabaseHelper.CapNhatTrangThaiMayATM(maAtm, "Online");
                Log($"[TỰ PHỤC HỒI] Cây {atm.MaATM} ({atm.TenTram}) đã kết nối lại và hoạt động bình thường!", "SUCCESS");
                stateChanged = true;
            }

            if (stateChanged)
            {
                OnAtmListChanged?.Invoke();
            }
            return (true, atm.TrangThai);
        }

        /// <summary>
        /// Bộ quét Watchdog chạy mỗi 3s: Nếu cây ATM Online quá 10s không có nhịp tim -> Chuyển thành "Mất kết nối"
        /// </summary>
        private static void WatchdogCheck(object? state)
        {
            bool hasChanged = false;
            var now = DateTime.Now;

            foreach (var kvp in _terminals)
            {
                var atm = kvp.Value;

                // Chỉ kiểm tra các cây đang Online
                if (atm.TrangThai == "Online")
                {
                    var elapsed = (now - atm.LastHeartbeat).TotalSeconds;

                    // Quá 10 giây không có Heartbeat -> Đánh dấu Mất kết nối
                    if (elapsed > 10)
                    {
                        atm.TrangThai = "Mất kết nối";
                        DatabaseHelper.CapNhatTrangThaiMayATM(atm.MaATM, "Mất kết nối");
                        Log($"[CẢNH BÁO MẠNG] Cây {atm.MaATM} ({atm.TenTram}) mất tín hiệu Heartbeat ({elapsed:F0}s không phản hồi)!", "WARN");
                        hasChanged = true;
                    }
                }
            }

            if (hasChanged)
            {
                OnAtmListChanged?.Invoke();
            }
        }

        /// <summary>
        /// Admin đổi trạng thái thủ công trên Giao diện Giám sát (Ví dụ: Cho vào Bảo trì hoặc Bật lại)
        /// </summary>
        public static void SetAtmStatus(string maAtm, string newStatus)
        {
            if (_terminals.TryGetValue(maAtm, out var atm))
            {
                atm.TrangThai = newStatus;
                DatabaseHelper.CapNhatTrangThaiMayATM(maAtm, newStatus);
                Log($"[ADMIN] Đã chuyển trạng thái máy {maAtm} sang: [{newStatus}].", "INFO");
                OnAtmListChanged?.Invoke();
            }
        }

        /// <summary>
        /// Cập nhật quỹ tiền mặt khi có giao dịch rút tiền tại cây ATM
        /// </summary>
        public static void DeductAtmCash(string maAtm, decimal amount)
        {
            if (_terminals.TryGetValue(maAtm, out var atm))
            {
                if (atm.TongTienMat >= amount)
                {
                    atm.TongTienMat -= amount;
                }
                atm.TotalTransactions++;
                DatabaseHelper.CapNhatTienMatMayATM(maAtm, amount);
                OnAtmListChanged?.Invoke();
            }
        }

        public static List<AtmTerminalDTO> GetAllTerminals()
        {
            return _terminals.Values.OrderBy(x => x.MaATM).ToList();
        }

        public static void Log(string message, string logType = "INFO")
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string formatted = $"[{time}] [{logType}] {message}";
            OnLogMessage?.Invoke(formatted, logType);
        }
    }
}

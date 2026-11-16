using System;

namespace Bank.Common
{
    /// <summary>
    /// Thông tin giám sát Cây ATM trong mạng lưới phân tán
    /// </summary>
    public class AtmTerminalDTO
    {
        public string MaATM { get; set; } = "";
        public string TenTram { get; set; } = "";
        public string ViTri { get; set; } = "";
        public decimal TongTienMat { get; set; }
        public string TrangThai { get; set; } = "Offline"; // "Online", "Mất kết nối", "Bảo trì"
        public string IpAddress { get; set; } = "--";
        public DateTime LastHeartbeat { get; set; } = DateTime.MinValue;
        public int TotalTransactions { get; set; } = 0;

        public string DisplayStatus
        {
            get
            {
                return TrangThai switch
                {
                    "Online" => "🟢 Hoạt động",
                    "Mất kết nối" or "Offline" => "🔴 Mất kết nối",
                    "Bảo trì" or "Maintenance" => "🟡 Đang bảo trì",
                    _ => TrangThai
                };
            }
        }

        public string LastSeenText
        {
            get
            {
                if (LastHeartbeat == DateTime.MinValue) return "Chưa kết nối";
                var diff = (DateTime.Now - LastHeartbeat).TotalSeconds;
                if (diff < 5) return "Vừa xong";
                if (diff < 60) return $"{diff:F0}s trước";
                return LastHeartbeat.ToString("HH:mm:ss");
            }
        }
    }
}

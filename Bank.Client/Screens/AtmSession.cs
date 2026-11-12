using System.Collections.Generic;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public class TransactionItem
    {
        public string ThoiGian { get; set; } = "";
        public string LoaiGiaoDich { get; set; } = "";
        public decimal SoTien { get; set; }
        public string TrangThai { get; set; } = "";
    }

    /// <summary>
    /// Lưu trữ phiên đăng nhập và dữ liệu dùng chung giữa các màn hình ATM
    /// </summary>
    public static class AtmSession
    {
        public static string CurrentCard { get; set; } = "9704000000001001";
        public static string CurrentAccount { get; set; } = "1001";
        public static string CurrentName { get; set; } = "NGUYỄN VĂN AN";
        public static decimal CurrentBalance { get; set; } = 8500000;
        public static decimal SelectedWithdrawAmount { get; set; } = 500000;

        // Danh sách giao dịch thật lấy từ Server SQL
        public static List<TransactionItem> RecentTransactions { get; set; } = new();

        // Ô nhập liệu đang được trỏ tới (để bàn phím số PinPad gõ vào)
        public static TextBox? ActiveInput { get; set; }

        public static void SetActiveInput(TextBox? tb)
        {
            ActiveInput = tb;
        }

        public static void Clear()
        {
            CurrentCard = "";
            CurrentAccount = "";
            CurrentName = "";
            CurrentBalance = 0;
            ActiveInput = null;
            RecentTransactions.Clear();
        }
    }
}

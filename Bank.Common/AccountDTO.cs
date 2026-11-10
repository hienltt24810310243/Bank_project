using System;

namespace Bank.Common
{
    // Lớp chứa dữ liệu tài khoản trả về sau khi kiểm tra
    public class AccountDTO
    {
        public bool ThanhCong { get; set; }       // Đăng nhập thành công hay không
        public string ThongBao { get; set; }        // Lời nhắn (VD: "Đăng nhập thành công", "Sai mã PIN")
        public string SoThe { get; set; }          // Số thẻ ATM
        public string SoTaiKhoan { get; set; }     // Số tài khoản gắn với thẻ
        public string HoTen { get; set; }          // Họ và tên chủ thẻ
        public decimal SoDu { get; set; }          // Số dư hiện tại trong tài khoản
        public bool IsLocked { get; set; }         // Thẻ có bị khóa không
    }
}
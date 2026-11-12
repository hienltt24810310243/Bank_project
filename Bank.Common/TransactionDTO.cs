using System;

namespace Bank.Common
{
    public class TransactionDTO
    {
        public string MaGD { get; set; } = "";
        public string ThoiGian { get; set; } = "";
        public string LoaiGiaoDich { get; set; } = "";
        public decimal SoTien { get; set; }
        public string TrangThai { get; set; } = "";
    }
}

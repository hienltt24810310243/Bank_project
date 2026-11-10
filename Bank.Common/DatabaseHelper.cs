using System;
using Microsoft.Data.SqlClient;

namespace Bank.Common
{
    public static class DatabaseHelper
    {
        // Chuỗi kết nối tới SQL Server SQLEXPRESS trên máy của bạn
        private static readonly string ConnectionString =
            @"Server=localhost\SQLEXPRESS;Database=BankATM_DB;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Hàm kiểm tra đăng nhập Thẻ ATM & Mã PIN
        /// </summary>
        public static AccountDTO KiemTraDangNhap(string soThe, string pin)
        {
            var result = new AccountDTO();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Truy vấn kiểm tra Thẻ, Tài khoản và Khách hàng
                    string query = @"
                        SELECT t.SoThe, t.MaPIN, t.IsLocked, t.SoLanSaiPIN,
                               tk.SoTaiKhoan, tk.SoDu, kh.HoTen
                        FROM TheATM t
                        JOIN TaiKhoan tk ON t.SoTaiKhoan = tk.SoTaiKhoan
                        JOIN KhachHang kh ON tk.MaKH = kh.MaKH
                        WHERE t.SoThe = @SoThe";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoThe", soThe);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                result.ThanhCong = false;
                                result.ThongBao = "Số thẻ không tồn tại trong hệ thống!";
                                return result;
                            }

                            bool isLocked = Convert.ToBoolean(reader["IsLocked"]);
                            string correctPin = reader["MaPIN"].ToString();
                            string soTK = reader["SoTaiKhoan"].ToString();
                            string hoTen = reader["HoTen"].ToString();
                            decimal soDu = Convert.ToDecimal(reader["SoDu"]);

                            // 1. Kiểm tra thẻ có bị khóa không
                            if (isLocked)
                            {
                                result.ThanhCong = false;
                                result.ThongBao = "Thẻ đã bị khóa do nhập sai PIN quá 3 lần. Vui lòng liên hệ ngân hàng!";
                                return result;
                            }

                            // 2. Kiểm tra mã PIN
                            if (correctPin != pin)
                            {
                                reader.Close();
                                // Tăng số lần sai PIN trong DB
                                TangSoLanSaiPIN(conn, soThe);

                                result.ThanhCong = false;
                                result.ThongBao = "Mã PIN không chính xác! (Nhập sai 3 lần thẻ sẽ bị khóa)";
                                return result;
                            }

                            // 3. Đúng thẻ và đúng PIN -> Đăng nhập thành công!
                            reader.Close();
                            ResetSoLanSaiPIN(conn, soThe); // Đặt lại số lần sai về 0

                            result.ThanhCong = true;
                            result.ThongBao = "Đăng nhập thành công!";
                            result.SoThe = soThe;
                            result.SoTaiKhoan = soTK;
                            result.HoTen = hoTen;
                            result.SoDu = soDu;
                            result.IsLocked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ThanhCong = false;
                result.ThongBao = "Lỗi kết nối cơ sở dữ liệu: " + ex.Message;
            }

            return result;
        }

        // Tăng số lần sai PIN, nếu đạt 3 lần thì tự động khóa thẻ
        private static void TangSoLanSaiPIN(SqlConnection conn, string soThe)
        {
            string updateQuery = @"
                UPDATE TheATM 
                SET SoLanSaiPIN = SoLanSaiPIN + 1,
                    IsLocked = CASE WHEN SoLanSaiPIN + 1 >= 3 THEN 1 ELSE IsLocked END
                WHERE SoThe = @SoThe";

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@SoThe", soThe);
                cmd.ExecuteNonQuery();
            }
        }

        // Đặt lại số lần nhập sai PIN về 0 khi đăng nhập thành công
        private static void ResetSoLanSaiPIN(SqlConnection conn, string soThe)
        {
            string query = "UPDATE TheATM SET SoLanSaiPIN = 0 WHERE SoThe = @SoThe";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoThe", soThe);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Lấy tối đa 5 giao dịch gần nhất của số tài khoản trong CSDL
        /// </summary>
        public static List<TransactionDTO> LayLichSuGiaoDich(string soTaiKhoan)
        {
            var list = new List<TransactionDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 5
                            g.MaGD,
                            FORMAT(g.ThoiGian, 'dd/MM/yyyy HH:mm') AS ThoiGian,
                            CASE 
                                WHEN ct.SoTKNhan = @acc AND g.SoTaiKhoan <> @acc THEN N'Nhận chuyển khoản'
                                ELSE g.LoaiGD 
                            END AS LoaiGiaoDich,
                            CASE 
                                WHEN ct.SoTKNhan = @acc AND g.SoTaiKhoan <> @acc THEN g.SoTien
                                ELSE -g.SoTien 
                            END AS SoTien,
                            g.TrangThai
                        FROM GiaoDich g
                        LEFT JOIN ChiTietChuyenKhoan ct ON g.MaGD = ct.MaGD
                        WHERE g.SoTaiKhoan = @acc OR ct.SoTKNhan = @acc
                        ORDER BY g.ThoiGian DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@acc", soTaiKhoan);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new TransactionDTO
                                {
                                    MaGD = reader["MaGD"].ToString() ?? "",
                                    ThoiGian = reader["ThoiGian"].ToString() ?? "",
                                    LoaiGiaoDich = reader["LoaiGiaoDich"].ToString() ?? "",
                                    SoTien = Convert.ToDecimal(reader["SoTien"]),
                                    TrangThai = reader["TrangThai"].ToString() ?? ""
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi truy vấn lịch sử: " + ex.Message);
            }

            return list;
        }

        /// <summary>
        /// Kiểm tra thông tin tài khoản thụ hưởng khi chuyển khoản
        /// </summary>
        public static (bool Success, string HoTen, string ThongBao) KiemTraTaiKhoan(string soTK)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT kh.HoTen, tk.TrangThai 
                        FROM TaiKhoan tk
                        JOIN KhachHang kh ON tk.MaKH = kh.MaKH
                        WHERE tk.SoTaiKhoan = @soTK";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@soTK", soTK);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                return (false, "", "Số tài khoản người nhận không tồn tại trong hệ thống!");
                            }

                            string hoTen = reader["HoTen"].ToString() ?? "";
                            string trangThai = reader["TrangThai"].ToString() ?? "";

                            if (trangThai != "Hoạt động")
                            {
                                return (false, hoTen, "Tài khoản người nhận đang bị khóa tạm thời!");
                            }

                            return (true, hoTen, "Tài khoản hợp lệ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "", "Lỗi kiểm tra tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Thực hiện chuyển khoản giữa 2 tài khoản với Transaction và Row-level Lock
        /// </summary>
        public static (bool Success, string ThongBao, decimal SoDuMoi) ChuyenKhoan(string stkGui, string stkNhan, decimal soTien, string noiDung, string maATM = "ATM01")
        {
            if (stkGui == stkNhan)
            {
                return (false, "Không thể chuyển tiền cho chính tài khoản của bạn!", 0);
            }

            if (soTien <= 0)
            {
                return (false, "Số tiền chuyển phải lớn hơn 0 VNĐ!", 0);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Kiểm tra tài khoản gửi với UPDLOCK
                            string queryCheckSender = "SELECT SoDu, TrangThai FROM TaiKhoan WITH (UPDLOCK, ROWLOCK) WHERE SoTaiKhoan = @stkGui";
                            decimal soDuGui = 0;
                            string trangThaiGui = "";

                            using (SqlCommand cmdCheckSender = new SqlCommand(queryCheckSender, conn, trans))
                            {
                                cmdCheckSender.Parameters.AddWithValue("@stkGui", stkGui);
                                using (SqlDataReader r = cmdCheckSender.ExecuteReader())
                                {
                                    if (!r.Read())
                                    {
                                        trans.Rollback();
                                        return (false, "Tài khoản người gửi không tồn tại!", 0);
                                    }
                                    soDuGui = Convert.ToDecimal(r["SoDu"]);
                                    trangThaiGui = r["TrangThai"].ToString() ?? "";
                                }
                            }

                            if (trangThaiGui != "Hoạt động")
                            {
                                trans.Rollback();
                                return (false, "Tài khoản của bạn đang bị khóa!", soDuGui);
                            }

                            if (soDuGui < soTien)
                            {
                                trans.Rollback();
                                return (false, "Số dư tài khoản không đủ để thực hiện giao dịch!", soDuGui);
                            }

                            // 2. Kiểm tra tài khoản người nhận
                            string queryCheckReceiver = "SELECT SoDu, TrangThai FROM TaiKhoan WITH (UPDLOCK, ROWLOCK) WHERE SoTaiKhoan = @stkNhan";
                            string trangThaiNhan = "";
                            using (SqlCommand cmdCheckReceiver = new SqlCommand(queryCheckReceiver, conn, trans))
                            {
                                cmdCheckReceiver.Parameters.AddWithValue("@stkNhan", stkNhan);
                                using (SqlDataReader r = cmdCheckReceiver.ExecuteReader())
                                {
                                    if (!r.Read())
                                    {
                                        trans.Rollback();
                                        return (false, "Tài khoản người nhận không tồn tại!", soDuGui);
                                    }
                                    trangThaiNhan = r["TrangThai"].ToString() ?? "";
                                }
                            }

                            if (trangThaiNhan != "Hoạt động")
                            {
                                trans.Rollback();
                                return (false, "Tài khoản người nhận đang bị khóa tạm thời!", soDuGui);
                            }

                            // 3. Trừ tiền người gửi
                            decimal soDuMoiGui = soDuGui - soTien;
                            string queryDeduct = "UPDATE TaiKhoan SET SoDu = @soDuMoi WHERE SoTaiKhoan = @stkGui";
                            using (SqlCommand cmdDeduct = new SqlCommand(queryDeduct, conn, trans))
                            {
                                cmdDeduct.Parameters.AddWithValue("@soDuMoi", soDuMoiGui);
                                cmdDeduct.Parameters.AddWithValue("@stkGui", stkGui);
                                cmdDeduct.ExecuteNonQuery();
                            }

                            // 4. Cộng tiền người nhận
                            string queryAdd = "UPDATE TaiKhoan SET SoDu = SoDu + @soTien WHERE SoTaiKhoan = @stkNhan";
                            using (SqlCommand cmdAdd = new SqlCommand(queryAdd, conn, trans))
                            {
                                cmdAdd.Parameters.AddWithValue("@soTien", soTien);
                                cmdAdd.Parameters.AddWithValue("@stkNhan", stkNhan);
                                cmdAdd.ExecuteNonQuery();
                            }

                            // 5. Ghi lịch sử giao dịch vào GiaoDich (MaGD <= 20 ký tự)
                            string maGD = "GD" + DateTime.Now.ToString("yyMMddHHmmss") + (new Random().Next(10, 99)).ToString();
                            string queryGD = @"
                                INSERT INTO GiaoDich (MaGD, SoTaiKhoan, MaATM, LoaiGD, SoTien, SoDuSauGD, ThoiGian, TrangThai)
                                VALUES (@MaGD, @SoTaiKhoan, @MaATM, N'Chuyển khoản', @SoTien, @SoDuSauGD, GETDATE(), N'Thành công')";
                            using (SqlCommand cmdGD = new SqlCommand(queryGD, conn, trans))
                            {
                                cmdGD.Parameters.AddWithValue("@MaGD", maGD);
                                cmdGD.Parameters.AddWithValue("@SoTaiKhoan", stkGui);
                                cmdGD.Parameters.AddWithValue("@MaATM", maATM);
                                cmdGD.Parameters.AddWithValue("@SoTien", soTien);
                                cmdGD.Parameters.AddWithValue("@SoDuSauGD", soDuMoiGui);
                                cmdGD.ExecuteNonQuery();
                            }

                            // 6. Ghi chi tiết chuyển khoản vào ChiTietChuyenKhoan
                            string queryCT = @"
                                INSERT INTO ChiTietChuyenKhoan (MaGD, SoTKNhan, NoiDung)
                                VALUES (@MaGD, @SoTKNhan, @NoiDung)";
                            using (SqlCommand cmdCT = new SqlCommand(queryCT, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaGD", maGD);
                                cmdCT.Parameters.AddWithValue("@SoTKNhan", stkNhan);
                                cmdCT.Parameters.AddWithValue("@NoiDung", string.IsNullOrWhiteSpace(noiDung) ? "Chuyen tien ATM" : noiDung);
                                cmdCT.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return (true, "Chuyển khoản thành công!", soDuMoiGui);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return (false, "Lỗi khi xử lý chuyển tiền: " + ex.Message, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối cơ sở dữ liệu: " + ex.Message, 0);
            }
        }

        /// <summary>
        /// Thực hiện rút tiền mặt tại cây ATM với Transaction và Row-level Lock
        /// </summary>
        public static (bool Success, string ThongBao, decimal SoDuMoi) RutTien(string soThe, decimal soTien, string maATM = "ATM01")
        {
            if (soTien <= 0)
            {
                return (false, "Số tiền rút phải lớn hơn 0 VNĐ!", 0);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Tìm tài khoản gắn với thẻ (Khóa dòng chống Race Condition)
                            string queryFind = @"
                                SELECT t.SoTaiKhoan, tk.SoDu, tk.TrangThai 
                                FROM TheATM t WITH (UPDLOCK, ROWLOCK)
                                JOIN TaiKhoan tk WITH (UPDLOCK, ROWLOCK) ON t.SoTaiKhoan = tk.SoTaiKhoan
                                WHERE t.SoThe = @soThe";

                            string soTK = "";
                            decimal soDu = 0;
                            string trangThai = "";

                            using (SqlCommand cmdFind = new SqlCommand(queryFind, conn, trans))
                            {
                                cmdFind.Parameters.AddWithValue("@soThe", soThe);
                                using (SqlDataReader r = cmdFind.ExecuteReader())
                                {
                                    if (!r.Read())
                                    {
                                        trans.Rollback();
                                        return (false, "Thẻ ATM không hợp lệ!", 0);
                                    }
                                    soTK = r["SoTaiKhoan"].ToString() ?? "";
                                    soDu = Convert.ToDecimal(r["SoDu"]);
                                    trangThai = r["TrangThai"].ToString() ?? "";
                                }
                            }

                            if (trangThai != "Hoạt động")
                            {
                                trans.Rollback();
                                return (false, "Tài khoản đang bị khóa tạm thời!", soDu);
                            }

                            if (soDu < soTien)
                            {
                                trans.Rollback();
                                return (false, "Số dư tài khoản không đủ để rút tiền!", soDu);
                            }

                            // 2. Trừ tiền tài khoản
                            decimal soDuMoi = soDu - soTien;
                            string queryDeduct = "UPDATE TaiKhoan SET SoDu = @soDuMoi WHERE SoTaiKhoan = @soTK";
                            using (SqlCommand cmdDeduct = new SqlCommand(queryDeduct, conn, trans))
                            {
                                cmdDeduct.Parameters.AddWithValue("@soDuMoi", soDuMoi);
                                cmdDeduct.Parameters.AddWithValue("@soTK", soTK);
                                cmdDeduct.ExecuteNonQuery();
                            }

                            // 3. Ghi lịch sử giao dịch vào GiaoDich
                            string maGD = "GD" + DateTime.Now.ToString("yyMMddHHmmss") + (new Random().Next(10, 99)).ToString();
                            string queryGD = @"
                                INSERT INTO GiaoDich (MaGD, SoTaiKhoan, MaATM, LoaiGD, SoTien, SoDuSauGD, ThoiGian, TrangThai)
                                VALUES (@MaGD, @SoTaiKhoan, @MaATM, N'Rút tiền', @SoTien, @SoDuSauGD, GETDATE(), N'Thành công')";
                            using (SqlCommand cmdGD = new SqlCommand(queryGD, conn, trans))
                            {
                                cmdGD.Parameters.AddWithValue("@MaGD", maGD);
                                cmdGD.Parameters.AddWithValue("@SoTaiKhoan", soTK);
                                cmdGD.Parameters.AddWithValue("@MaATM", maATM);
                                cmdGD.Parameters.AddWithValue("@SoTien", soTien);
                                cmdGD.Parameters.AddWithValue("@SoDuSauGD", soDuMoi);
                                cmdGD.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return (true, "Rút tiền thành công!", soDuMoi);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return (false, "Lỗi khi xử lý rút tiền: " + ex.Message, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối cơ sở dữ liệu: " + ex.Message, 0);
            }
        }

        /// <summary>
        /// Thực hiện đổi mã PIN thẻ ATM trong SQL Server
        /// </summary>
        public static (bool Success, string ThongBao) DoiMaPIN(string soThe, string pinCu, string pinMoi)
        {
            if (pinMoi.Length != 6 || !decimal.TryParse(pinMoi, out _))
            {
                return (false, "Mã PIN mới phải gồm đúng 6 chữ số!");
            }

            if (pinCu == pinMoi)
            {
                return (false, "Mã PIN mới không được trùng với mã PIN cũ!");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    // 1. Kiểm tra PIN cũ
                    string checkQuery = "SELECT MaPIN, IsLocked FROM TheATM WHERE SoThe = @soThe";
                    using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@soThe", soThe);
                        using (SqlDataReader r = cmdCheck.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                return (false, "Thẻ ATM không tồn tại!");
                            }

                            bool isLocked = Convert.ToBoolean(r["IsLocked"]);
                            string correctPin = r["MaPIN"].ToString() ?? "";

                            if (isLocked)
                            {
                                return (false, "Thẻ đang bị khóa tạm thời!");
                            }

                            if (correctPin != pinCu)
                            {
                                return (false, "Mã PIN hiện tại không chính xác!");
                            }
                        }
                    }

                    // 2. Cập nhật PIN mới
                    string updateQuery = "UPDATE TheATM SET MaPIN = @newPin WHERE SoThe = @soThe";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@newPin", pinMoi);
                        cmdUpdate.Parameters.AddWithValue("@soThe", soThe);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    return (true, "Đổi mã PIN thành công!");
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách toàn bộ các cây ATM từ bảng MayATM để phục vụ màn hình giám sát trung tâm
        /// </summary>
        public static List<AtmTerminalDTO> LayDanhSachMayATM()
        {
            var list = new List<AtmTerminalDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT MaATM, TenTram, ViTri, TongTienMat, TrangThai FROM MayATM ORDER BY MaATM";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new AtmTerminalDTO
                            {
                                MaATM = r["MaATM"].ToString() ?? "",
                                TenTram = r["TenTram"].ToString() ?? "",
                                ViTri = r["ViTri"].ToString() ?? "",
                                TongTienMat = Convert.ToDecimal(r["TongTienMat"]),
                                TrangThai = r["TrangThai"].ToString() ?? "Offline"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi truy vấn danh sách MayATM: " + ex.Message);
            }
            return list;
        }

        /// <summary>
        /// Cập nhật trạng thái hoạt động của cây ATM trong CSDL (Online, Mất kết nối, Bảo trì)
        /// </summary>
        public static bool CapNhatTrangThaiMayATM(string maAtm, string trangThai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE MayATM SET TrangThai = @trangThai WHERE MaATM = @maAtm";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@trangThai", trangThai);
                        cmd.Parameters.AddWithValue("@maAtm", maAtm);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật trạng thái ATM {maAtm}: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Trừ tiền mặt vật lý trong cây ATM khi khách hàng rút tiền
        /// </summary>
        public static bool CapNhatTienMatMayATM(string maAtm, decimal soTienTru)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE MayATM 
                        SET TongTienMat = CASE WHEN TongTienMat >= @soTienTru THEN TongTienMat - @soTienTru ELSE TongTienMat END 
                        WHERE MaATM = @maAtm";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@soTienTru", soTienTru);
                        cmd.Parameters.AddWithValue("@maAtm", maAtm);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật quỹ tiền mặt ATM {maAtm}: " + ex.Message);
                return false;
            }
        }
    }
}
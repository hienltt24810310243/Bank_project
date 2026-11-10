using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
                    string soThe = parts[1];
                    string pin = parts[2];

                    // TẠM THỜI MOCK DATA ĐỂ TEST SOCKET (Khớp với dữ liệu mẫu trong CSDL của Hiền)
                    // Sau này khi Hiền viết xong DatabaseHelper, chỉ cần đổi 1 dòng gọi CSDL là xong
                    if (soThe == "9704000000001001" && pin == "123456")
                    {
                        return "LOGIN_SUCCESS|Nguyễn Văn A|5000000";
                    }
                    else if (soThe == "9704000000001002" && pin == "654321")
                    {
                        return "LOGIN_SUCCESS|Trần Thị B|12000000";
                    }
                    else
                    {
                        return "LOGIN_FAIL|Mã PIN không chính xác hoặc thẻ không tồn tại!";
                    }

                // LUỒNG 2: RÚT TIỀN MẶT (Chuẩn bị sẵn cho buổi tiếp theo)
                case "WITHDRAW":
                    // Format: WITHDRAW|soThe|soTien
                    // Đoạn này dùng lock (_accountLock) để chống Race Condition khi 2 cây cùng rút
                    lock (_accountLock)
                    {
                        decimal soTienRut = decimal.Parse(parts[2]);
                        // Xử lý trừ tiền...
                        return $"WITHDRAW_SUCCESS|{soTienRut}|SoDuMoi";
                    }

                default:
                    return "ERROR|Lệnh không hợp lệ!";
            }
        }
    }
}
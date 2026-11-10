# CẨM NANG HƯỚNG DẪN CÔNG VIỆC DÀNH CHO BẠN ĐỨC (CHI TIẾT 100%)
**Học phần:** Lập trình .NET & Phân tích Thiết kế Hướng đối tượng (EPU)  
**Đề tài:** Hệ thống Giao dịch Ngân hàng & Mạng lưới ATM Phân tán  
**Người thực hiện:** ĐỨC (Phụ trách Server Socket, Đa luồng Concurrency & Biểu đồ Kiến trúc Hệ thống)

---

## MỤC LỤC
1. [Phần 1: Đức hiểu bản chất vai trò của mình trong dự án](#phần-1-đức-hiểu-bản-chất-vai-trò-của-mình-trong-dự-án)
2. [Phần 2: Chuẩn bị công cụ & Lấy code về máy (10 phút)](#phần-2-chuẩn-bị-công-cụ--lấy-code-về-máy-10-phút)
3. [Phần 3: Lập trình Máy chủ Core Banking (Socket Đa luồng) trong Bank.Server](#phần-3-lập-trình-máy-chủ-core-banking-socket-đa-luồng-trong-bankserver)
4. [Phần 4: Hướng dẫn vẽ Hệ thống Biểu đồ trên Draw.io (Chuẩn EPU)](#phần-4-hướng-dẫn-vẽ-hệ-thống-biểu-đồ-trên-drawio-chuẩn-epu)
5. [Phần 5: Kịch bản chạy thử nghiệm ghép nối cùng An và Hiền lúc 22h00](#phần-5-kịch-bản-chạy-thử-nghiệm-ghép-nối-cùng-an-và-hiền-lúc-22h00)

---

## PHẦN 1: ĐỨC HIỂU BẢN CHẤT VAI TRÒ CỦA MÌNH TRONG DỰ ÁN

Trong một hệ thống ngân hàng thực tế:
* Cây ATM của An **không có dữ liệu tiền hay tài khoản**, nó chỉ là "mặt tiền" để người dùng bấm nút.
* **Server của Đức chính là "bộ não trung tâm" (Core Banking Server)**:
  1. Mở sẵn một cổng mạng (Port `8888`) để các cây ATM kết nối vào qua giao thức TCP Socket.
  2. **Xử lý Đa luồng (Multithreading):** Khi có 2, 3 hoặc 10 cây ATM cùng kết nối và gửi lệnh một lúc, Server của Đức phải tạo ra các luồng xử lý riêng biệt (`Task.Run`) để không cây nào bị đơ máy.
  3. Đọc dữ liệu từ gói tin Client gửi sang (dạng chuỗi `LOGIN|soThe|pin`), gọi hàm kiểm tra cơ sở dữ liệu của Hiền, rồi bắn kết quả ngược lại cho cây ATM của An.
  4. Chuẩn bị cơ chế khóa luồng (`lock`) để giải quyết bài toán cốt lõi của đồ án: **Chống rút tiền trùng khi 2 máy ATM cùng rút 1 tài khoản tại cùng một giây**.

---

## PHẦN 2: CHUẨN BỊ CÔNG CỤ & LẤY CODE VỀ MÁY (10 PHÚT)

1. **Ứng dụng cần có:** Visual Studio 2022 Community (đã tích gói *.NET desktop development*) và GitHub Desktop.
2. **Lấy code từ Hiền về máy:**
   * Mở GitHub Desktop $\rightarrow$ Bấm **File $\rightarrow$ Clone Repository...**
   * Chọn repo **`Bank_project`** của Hiền (hoặc dán link: `https://github.com/hienltt24810310243/Bank_project.git`).
   * Bấm **Clone**. Sau đó bấm nút **Open in Visual Studio** để mở Solution `EPU_BankSystem`.
3. Bấm tổ hợp phím **`Ctrl + Shift + B`** kiểm tra xem máy báo `Build succeeded (0 errors)` là sẵn sàng code!

---

## PHẦN 3: LẬP TRÌNH MÁY CHỦ CORE BANKING (SOCKET ĐA LUỒNG) TRONG BANK.SERVER

Đức nhìn sang cột bên phải (Solution Explorer) $\rightarrow$ mở thư mục project **`Bank.Server`** $\rightarrow$ bấm đúp chuột vào file **`Program.cs`**.

Xóa toàn bộ nội dung cũ trong `Program.cs` và thay bằng toàn bộ đoạn mã nguồn hoàn chỉnh dưới đây:

```csharp
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
```

---

## PHẦN 4: HƯỚNG DẪN VẼ HỆ THỐNG BIỂU ĐỒ TRÊN DRAW.IO (CHUẨN EPU)

Đức mở trình duyệt web truy cập: [app.diagrams.net](https://app.diagrams.net/) (Draw.io), nhìn vào file mẫu `BaoCao_Mau_EPU_LaptopTCC.pdf` để vẽ 3 biểu đồ sau:

---

### 1. Biểu đồ Use case tổng quát (Hình 2.1 - Mục 2.1, Trang 9 & 19 file mẫu)
* Kéo 1 khung chữ nhật to (System Boundary), đặt tiêu đề: **`HỆ THỐNG GIAO DỊCH NGÂN HÀNG & MẠNG LƯỚI ATM PHÂN TÁN`**.
* **Vẽ 4 Actor (Hình người):**
  * **Khách (Guest):** Nối với Use case `Đăng nhập thẻ & PIN`.
  * **Khách hàng (Customer):** Vẽ mũi tên kế thừa (tam giác rỗng) trỏ về `Khách`. Nối tới: `Vấn tin số dư`, `Rút tiền mặt`, `Chuyển khoản`, `Đổi mã PIN`, `Xem lịch sử giao dịch`.
  * **Quản trị viên (Admin):** Nối tới `Quản lý tài khoản khách hàng`, `Xem báo cáo & Audit Log`, `Chạy Stress Test đa luồng`.
  * **Kỹ thuật viên ATM:** Nối tới `Tiếp quỹ tiền mặt ATM`, `Kiểm kê tiền mặt tồn trong máy`.

---

### 2. Biểu đồ Triển khai (Deployment Diagram - Hình 2.73, Trang 59 file mẫu)
* Vẽ 3 khối lập phương 3D (Node):
  * **Node 1: `<<device>> Trạm Cây ATM (Client)`**
    * Bên trong chứa: `<<execution environment>> Windows 10/11` chứa thành phần `ATM_Client.exe`.
  * **Node 2: `<<device>> Máy chủ Ngân hàng (Core Server)`**
    * Bên trong chứa thành phần: `Bank_Server.exe` (Socket Server đa luồng).
  * **Node 3: `<<device>> Máy chủ CSDL (Database Server)`**
    * Chứa: `Microsoft SQL Server 2022 (BankATM_DB)`.
  * **Đường nối mạng:**
    * Nối giữa Node 1 và Node 2: Đường truyền mạng LAN / Internet (Giao thức TCP/IP - Port 8888).
    * Nối giữa Node 2 và Node 3: Kết nối ADO.NET nội bộ.

---

### 3. Biểu đồ Thành phần (Component Diagram - Hình 2.72, Trang 58 file mẫu)
* Vẽ 4 khối `<<component>>` (hình chữ nhật có 2 mấu nhỏ bên trái):
  * `<<component>> Giao diện ATM Client (WinForms)`
  * `<<component>> Bộ điều khiển Socket (Socket Controller)`
  * `<<component>> Quản lý Khóa Tranh Chấp (Concurrency Lock Manager)`
  * `<<component>> Tầng Truy xuất Dữ liệu (Data Access Layer - DAL)`
* Nối các đường phụ thuộc `<<use>>` giữa chúng (Client dùng Socket, Socket dùng Lock Manager, Lock Manager dùng DAL).

---

### 4. Bộ 4 Biểu đồ cho Chức năng Đăng nhập (Mục 2.2.1, Trang 21 – 25 file mẫu)
* **Hình 2.2 (Use case con Đăng nhập):** Oval `Đăng nhập` include `Xác thực PIN`, extend `Khóa thẻ (sai 3 lần)`.
* **Hình 2.3 (Activity Diagram):** 2 làn bơi (*Người dùng* và *Hệ thống*): Nhập thẻ/PIN $\rightarrow$ Kiểm tra CSDL $\rightarrow$ Nhánh đúng (mở Menu chính) / Nhánh sai (kiểm tra nếu sai 3 lần thì khóa thẻ, nếu < 3 lần thì báo nhập lại).
* **Hình 2.4 (Sequence Diagram BCE chuẩn EPU):**
  * Kéo 3 icon tròn đặc trưng: Actor `Khách hàng` $\rightarrow$ Boundary `frmDangNhap` $\rightarrow$ Control `ctrDangNhap` $\rightarrow$ Entity `TaiKhoan` và `TheATM`.
  * Đánh số thông điệp: `1: Nhập thông tin`, `2: Gửi xác thực`, `3: Kiểm tra DB`, `4: Trả kết quả`.
* **Hình 2.5 (Collaboration Diagram):** Vẽ lại 4 đối tượng trên ở dạng sơ đồ mạng tròn có mũi tên đánh số thứ tự $1, 2, 3...$.

*👉 Vẽ xong Đức bấm **File $\rightarrow$ Export as $\rightarrow$ PNG** và lưu lại cả file **`.drawio`**.*

---

## PHẦN 5: KỊCH BẢN CHẠY THỬ NGHIỆM GHÉP NỐI CÙNG AN VÀ HIỀN LÚC 22H00

1. **Đức mở Visual Studio:**
   * Chuột phải vào project `Bank.Server` $\rightarrow$ chọn **Set as Startup Project**.
   * Bấm nút **Start (F5)** để chạy Server lên.
   * Cửa sổ màu đen hiện lên dòng chữ xanh:  
     👉 `[SERVER] Dang lang nghe ket noi tren cong: 8888...`
2. **Bảo An bật cây ATM:**
   * An bấm Start chạy `Bank.Client` $\rightarrow$ Nhập số thẻ `9704000000001001`, mã PIN `123456` $\rightarrow$ Bấm nút **ĐĂNG NHẬP**.
3. **Đức nhìn màn hình Console của mình:**
   * Console lập tức nhảy dòng chữ vàng:  
     👉 `[+] [KET NOI MOI] Cay ATM tai [127.0.0.1:...] da ket noi thanh cong!`  
     👉 `[>>> NHAN LENH]: LOGIN|9704000000001001|123456`  
     👉 `[<<< PHAN HOI]: LOGIN_SUCCESS|Nguyễn Văn A|5000000`
4. Màn hình cây ATM của An lập tức mở bung Menu chính hiển thị: **"Xin chào: Nguyễn Văn A - Số dư: 5.000.000 VNĐ"**!

$\rightarrow$ **Chúc mừng Đức! Toàn bộ hạ tầng mạng Socket và máy chủ của bạn đã thông luồng thành công 100%!**

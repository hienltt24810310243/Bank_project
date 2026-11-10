# CẨM NANG HƯỚNG DẪN CÔNG VIỆC DÀNH CHO BẠN AN (CHI TIẾT 100%)
**Học phần:** Lập trình .NET & Phân tích Thiết kế Hướng đối tượng (EPU)  
**Đề tài:** Hệ thống Giao dịch Ngân hàng & Mạng lưới ATM Phân tán  
**Người thực hiện:** AN (Phụ trách Giao diện WinForms & Biểu đồ Rút tiền mặt)

---

## MỤC LỤC
1. [Phần 1: Chuẩn bị công cụ & Lấy code về máy](#phần-1-chuẩn-bị-công-cụ--lấy-code-về-máy)
2. [Phần 2: Kéo - Thả Giao diện WinForms cây ATM (Chi tiết từng Pixel)](#phần-2-kéo---thả-giao-diện-winforms-cây-atm-chi-tiết-từng-pixel)
3. [Phần 3: Toàn bộ Mã nguồn C# Xử lý Sự kiện & Giao tiếp Socket](#phần-3-toàn-bộ-mã-nguồn-c-xử-lý-sự-kiện--giao-tiếp-socket)
4. [Phần 4: Hướng dẫn vẽ Bộ 4 Biểu đồ Rút tiền trên Draw.io (Chuẩn EPU)](#phần-4-hướng-dẫn-vẽ-bộ-4-biểu-đồ-rút-tiền-trên-drawio-chuẩn-epu)
5. [Phần 5: Kịch bản kiểm thử kết nối cùng Hiền và Đức lúc 22h00](#phần-5-kịch-bản-kiểm-thử-kết-nối-cùng-hiền-và-đức-lúc-22h00)

---

## PHẦN 1: CHUẨN BỊ CÔNG CỤ & LẤY CODE VỀ MÁY

1. **Ứng dụng cần có:** Visual Studio 2022 Community (đã tích gói *.NET desktop development*) và GitHub Desktop.
2. **Lấy code từ Hiền về máy:**
   * Mở GitHub Desktop $\rightarrow$ Bấm **File $\rightarrow$ Clone Repository...**
   * Chọn repo **`Bank_project`** của Hiền (hoặc dán URL repo).
   * Bấm nút **Clone**. Sau đó bấm **Open in Visual Studio** để mở Solution `EPU_BankSystem`.
3. **Mở file giao diện mẫu:**
   * Mở file **`ATM_UI_PROTOTYPE.html`** (Hiền đã gửi qua Telegram) bằng trình duyệt web (Chrome/Edge) và để cạnh màn hình để nhìn trực quan vị trí các nút bấm.

---

## PHẦN 2: KÉO - THẢ GIAO DIỆN WINFORMS CÂY ATM (CHI TIẾT TỪNG PIXEL)

An mở project **`Bank.Client`** $\rightarrow$ bấm đúp chuột vào file **`Form1.cs`** để vào chế độ Design.

### 1. Mở sẵn 3 cửa sổ công cụ trong Visual Studio:
* **Toolbox:** Bấm `Ctrl + Alt + X` (nhớ bấm hình cái đinh ghim 📌 để cố định thanh bên trái).
* **Properties:** Bấm `F4` (góc dưới bên phải).
* **Document Outline (Rất quan trọng để tránh lỗi đè Panel):** Vào menu **View $\rightarrow$ Other Windows $\rightarrow$ Document Outline** (hoặc `Ctrl + Alt + T`).

---

### 2. Cấu hình Form1 chuẩn kích thước màn hình cây ATM:
Click chuột vào nền Form1, mở bảng **Properties (F4)** và chỉnh các dòng:
* `(Name)`: `frmATM`
* `Text`: `EPU BANK - HE THONG ATM`
* `Size`: `650, 750`
* `StartPosition`: `CenterScreen` *(để cửa sổ luôn hiện giữa màn hình)*
* `FormBorderStyle`: `FixedSingle` *(không cho người dùng kéo dãn mép form)*
* `MaximizeBox`: `False` *(tắt nút phóng to full màn hình)*
* `BackColor`: Chọn tab **Custom** $\rightarrow$ gõ mã màu: `3; 43; 67` *(màu xanh navy sẫm ATM)*

---

### 3. Kỹ thuật 3 tấm Panel đè lên nhau (Mượt mà như ATM cảm ứng thật):

#### 🔹 PANEL 1: Màn hình Đăng nhập (panelLogin)
Kéo 1 cái `Panel` từ Toolbox thả vào Form:
* `(Name)`: **`panelLogin`**
* `Dock`: Chọn **`Fill`** *(Panel tự nở to phủ kín Form)*
* `BackColor`: `Transparent` (hoặc `3; 43; 67`)

Kéo các nút vào bên trong `panelLogin`:
1. **Tiêu đề:** `Label` $\rightarrow$ Text: `NGÂN HÀNG ĐIỆN LỰC - EPU BANK`, Font: Segoe UI, **16pt, Bold**, ForeColor: **Cyan**, Location: `130, 30`.
2. **Dòng phụ:** `Label` $\rightarrow$ Text: `VUI LÒNG ĐĂNG NHẬP ĐỂ GIAO DỊCH`, Font: 9pt, ForeColor: White, Location: `180, 70`.
3. **Ô Số thẻ:**
   * `Label` $\rightarrow$ Text: `SỐ THẺ / TÀI KHOẢN:`, Font: 9pt Bold, ForeColor: White, Location: `140, 120`.
   * `TextBox` $\rightarrow$ `(Name)`: **`txtSoThe`**, Text: `9704000000001001`, Font: 12pt, Size: `350, 30`, Location: `140, 145`.
4. **Ô Mã PIN:**
   * `Label` $\rightarrow$ Text: `MÃ PIN BẢO MẬT (6 SỐ):`, Font: 9pt Bold, ForeColor: White, Location: `140, 190`.
   * `TextBox` $\rightarrow$ `(Name)`: **`txtPIN`**, Font: 12pt Bold, Size: `350, 30`, Location: `140, 215`.  
     ⚠️ **Bắt buộc:** Trong bảng Properties chỉnh **`PasswordChar = '*'`**.
5. **Hai nút Đăng nhập & Hủy:**
   * `Button` $\rightarrow$ `(Name)`: **`btnDangNhap`**, Text: `ĐĂNG NHẬP`, BackColor: **SeaGreen** (Xanh lá), ForeColor: White, Font: 10pt Bold, Size: `170, 42`, Location: `140, 260`.
   * `Button` $\rightarrow$ `(Name)`: **`btnHuy`**, Text: `HỦY BỎ`, BackColor: **Crimson** (Đỏ), ForeColor: White, Font: 10pt Bold, Size: `170, 42`, Location: `320, 260`.
6. **Bàn phím số cây ATM (PinPad):**
   * Kéo 1 `GroupBox` $\rightarrow$ Text: `BÀN PHÍM CÂY ATM`, ForeColor: LightGray, Size: `350, 240`, Location: `140, 320`.
   * Bên trong GroupBox, kéo 12 cái `Button` (kích thước `80 x 45 px`):
     * Hàng 1: Nút 1, Nút 2, Nút 3
     * Hàng 2: Nút 4, Nút 5, Nút 6
     * Hàng 3: Nút 7, Nút 8, Nút 9
     * Hàng 4: Nút `CLEAR` (Màu vàng), Nút `0`, Nút `ENTER` (Màu xanh lá).

---

#### 🔹 PANEL 2: Menu Chức năng Chính (panelMenu)
*Mẹo: Bấm chọn `panelLogin` $\rightarrow$ Properties chỉnh tạm `Visible = False` để có màn hình trống vẽ Panel 2.*

Kéo 1 cái `Panel` mới thả vào Form:
* `(Name)`: **`panelMenu`**
* `Dock`: Chọn **`Fill`**
* `BackColor`: `3; 43; 67`
* `Visible`: Đổi thành **`False`** *(để khi mới mở app nó ẩn đi)*

Kéo các nút vào bên trong `panelMenu`:
1. **Khung thông tin chủ thẻ:** Kéo 1 Panel nhỏ lên phía trên (Size: `580, 80`, Location: `30, 30`, BackColor: `10, 25, 47`):
   * `Label` $\rightarrow$ `(Name)`: **`lblXinChao`**, Text: `XIN CHÀO: NGUYỄN VĂN A (STK: 1001)`, Font: 12pt Bold, ForeColor: White, Location: `20, 15`.
   * `Label` $\rightarrow$ `(Name)`: **`lblSoDu`**, Text: `SỐ DƯ: 5.000.000 VNĐ`, Font: 14pt Bold, ForeColor: **LimeGreen** (Xanh nõn chuối), Location: `20, 45`.
2. **4 Nút chức năng lớn (2 cột x 2 hàng):**
   * Cột trái:
     * `Button` $\rightarrow$ `(Name)`: **`btnRutTien`**, Text: `[1] RÚT TIỀN MẶT`, Size: `260, 85`, BackColor: `SteelBlue`, Font: 11pt Bold, ForeColor: White, Location: `30, 140`.
     * `Button` $\rightarrow$ `(Name)`: **`btnDoiPIN`**, Text: `[3] ĐỔI MÃ PIN`, Size: `260, 85`, BackColor: `SteelBlue`, Font: 11pt Bold, ForeColor: White, Location: `30, 250`.
   * Cột phải:
     * `Button` $\rightarrow$ `(Name)`: **`btnChuyenKhoan`**, Text: `[2] CHUYỂN KHOẢN`, Size: `260, 85`, BackColor: `SteelBlue`, Font: 11pt Bold, ForeColor: White, Location: `340, 140`.
     * `Button` $\rightarrow$ `(Name)`: **`btnLichSu`**, Text: `[4] LỊCH SỬ GIAO DỊCH`, Size: `260, 85`, BackColor: `SteelBlue`, Font: 11pt Bold, ForeColor: White, Location: `340, 250`.
3. **Nút Đăng xuất ở dưới cùng:**
   * `Button` $\rightarrow$ `(Name)`: **`btnDangXuat`**, Text: `[5] ĐĂNG XUẤT / TRẢ THẺ`, Size: `570, 48`, BackColor: `Firebrick` (Đỏ), Font: 11pt Bold, ForeColor: White, Location: `30, 370`.

---

#### 🔹 PANEL 3: Màn hình Rút tiền mặt (panelRutTien)
Kéo tiếp 1 cái `Panel` thứ 3 thả vào Form:
* `(Name)`: **`panelRutTien`**
* `Dock`: Chọn **`Fill`**
* `BackColor`: `3; 43; 67`
* `Visible`: Đổi thành **`False`**

Kéo các nút vào bên trong `panelRutTien`:
1. `Label` tiêu đề: Text = `CHỌN MỆNH GIÁ CẦN RÚT`, Font: 14pt Bold, ForeColor: Cyan, Location: `190, 40`.
2. **6 Nút mệnh giá tiền (Size: `220, 55` mỗi nút):**
   * Nút 1: `btn100k` (Text: `100.000 VNĐ`), Location: `80, 110`
   * Nút 2: `btn200k` (Text: `200.000 VNĐ`), Location: `340, 110`
   * Nút 3: `btn500k` (Text: `500.000 VNĐ`), Location: `80, 190`
   * Nút 4: `btn1tr` (Text: `1.000.000 VNĐ`), Location: `340, 190`
   * Nút 5: `btn2tr` (Text: `2.000.000 VNĐ`), Location: `80, 270`
   * Nút 6: `btnSoKhac` (Text: `NHẬP SỐ KHÁC...`), BackColor: `CadetBlue`, Location: `340, 270`
3. **Nút quay lại menu:**
   * `Button` $\rightarrow$ `(Name)`: **`btnQuayLai`**, Text: `◀ QUAY LẠI MENU CHÍNH`, Size: `480, 45`, BackColor: `DimGray`, Font: 10pt Bold, ForeColor: White, Location: `80, 360`.

---

### 4. Đặt lại trạng thái ban đầu:
* Trong cửa sổ **Document Outline (`Ctrl + Alt + T`)**, bấm chọn `panelLogin` $\rightarrow$ chỉnh lại **`Visible = True`**.
* Đảm bảo `panelMenu` và `panelRutTien` có **`Visible = False`**.

---

## PHẦN 3: TOÀN BỘ MÃ NGUỒN C# XỬ LÝ SỰ KIỆN & GIAO TIẾP SOCKET

An bấm phím **F7** trên màn hình Design để chuyển sang cửa sổ code `Form1.cs`. Copy toàn bộ nội dung dưới đây dán vào:

```csharp
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Bank.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ban đầu chỉ hiển thị màn hình Đăng nhập
            panelLogin.Visible = true;
            panelMenu.Visible = false;
            panelRutTien.Visible = false;
        }

        // =========================================================
        // SỰ KIỆN 1: BẤM NÚT "ĐĂNG NHẬP" -> GỬI SOCKET SANG SERVER
        // =========================================================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string soThe = txtSoThe.Text.Trim();
            string pin = txtPIN.Text.Trim();

            if (string.IsNullOrEmpty(soThe) || string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Số thẻ và Mã PIN!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Kết nối đến Server Socket của Đức (Cổng 8888)
                TcpClient client = new TcpClient("127.0.0.1", 8888);
                NetworkStream stream = client.GetStream();

                // 2. Gửi chuỗi lệnh: LOGIN|soThe|pin
                string request = $"LOGIN|{soThe}|{pin}";
                byte[] data = Encoding.UTF8.GetBytes(request);
                stream.Write(data, 0, data.Length);

                // 3. Đọc phản hồi từ Server
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // 4. Xử lý kết quả trả về
                string[] parts = response.Split('|');
                if (parts[0] == "LOGIN_SUCCESS")
                {
                    // Đăng nhập thành công -> Mở Menu chính
                    panelLogin.Visible = false;
                    panelMenu.Visible = true;
                    panelRutTien.Visible = false;

                    lblXinChao.Text = "Xin chào: " + parts[1];
                    lblSoDu.Text = "Số dư: " + decimal.Parse(parts[2]).ToString("N0") + " VNĐ";
                }
                else
                {
                    // Đăng nhập thất bại (Sai PIN hoặc Thẻ bị khóa)
                    MessageBox.Show(parts[1], "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPIN.Clear();
                    txtPIN.Focus();
                }

                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ Core Banking!\nHãy bảo Đức bấm Start chạy Bank.Server trước nhé.\nLỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SỰ KIỆN 2: BẤM NÚT "RÚT TIỀN MẶT" TRÊN MENU CHÍNH
        // =========================================================
        private void btnRutTien_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelRutTien.Visible = true;
        }

        // =========================================================
        // SỰ KIỆN 3: BẤM NÚT "QUAY LẠI MENU CHÍNH" Ở MÀN HÌNH RÚT TIỀN
        // =========================================================
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            panelRutTien.Visible = false;
            panelMenu.Visible = true;
        }

        // =========================================================
        // SỰ KIỆN 4: BẤM NÚT "ĐĂNG XUẤT / TRẢ THẺ"
        // =========================================================
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn kết thúc giao dịch và lấy lại thẻ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                panelMenu.Visible = false;
                panelRutTien.Visible = false;
                panelLogin.Visible = true;

                txtPIN.Clear();
                txtSoThe.Focus();
            }
        }

        // =========================================================
        // SỰ KIỆN 5: BẤM NÚT "HỦY BỎ" Ở MÀN HÌNH ĐĂNG NHẬP
        // =========================================================
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtPIN.Clear();
            txtSoThe.Clear();
        }
    }
}
```

---

## PHẦN 4: HƯỚNG DẪN VẼ BỘ 4 BIỂU ĐỒ RÚT TIỀN TRÊN DRAW.IO (CHUẨN EPU)

An mở trình duyệt truy cập: [app.diagrams.net](https://app.diagrams.net/), nhìn vào trang 21 – 25 của file mẫu EPU để vẽ bộ biểu đồ cho **Mục 2.2.3: Chức năng Rút tiền mặt**:

### 1. Biểu đồ Use case con Rút tiền mặt (Mục 2.2.3)
* Kéo hình Oval to: **`Rút tiền mặt`**.
* Mũi tên nét đứt `<<include>>` trỏ tới: **`Kiểm tra số dư & Khóa luồng Lock`**.
* Mũi tên nét đứt `<<include>>` trỏ tới: **`Ghi nhận lịch sử giao dịch`**.
* Mũi tên nét đứt `<<extend>>` trỏ tới: **`In hóa đơn / biên lai`**.

### 2. Biểu đồ Hoạt động (Activity Diagram)
* Vẽ 2 làn bơi (Swimlanes): **Khách hàng** (bên trái) và **Hệ thống** (bên phải):
  * *Làn Khách hàng:* Bắt đầu $\rightarrow$ Chọn chức năng rút tiền $\rightarrow$ Chọn mệnh giá tiền $\rightarrow$ Bấm xác nhận rút.
  * *Làn Hệ thống:* Nhận yêu cầu $\rightarrow$ Kích hoạt khóa luồng tài khoản (`LockAccount`) $\rightarrow$ Kiểm tra số dư:
    * Nhánh [Số dư không đủ]: Báo lỗi ra màn hình $\rightarrow$ Kết thúc.
    * Nhánh [Số dư đủ]: Trừ tiền trong CSDL $\rightarrow$ Nhả tiền mặt $\rightarrow$ In thông báo thành công $\rightarrow$ Nhả khóa luồng $\rightarrow$ Kết thúc.

### 3. Biểu đồ Trình tự (Sequence Diagram - có 3 icon tròn BCE chuẩn EPU)
* Kéo 3 icon tròn trong mục *UML / Robustness*:
  * Actor `Khách hàng`
  * Boundary `frmRutTien` (Hình tròn có thanh đứng bên trái)
  * Control `ctrRutTien` (Hình tròn có mũi tên tròn trên đầu)
  * Entity `TaiKhoan` và `MayATM` (Hình tròn có thanh gạch chân)
* Luồng thông điệp đánh số:
  1. `1: Chọn mệnh giá tiền cần rút` (Khách hàng $\rightarrow$ `frmRutTien`)
  2. `2: Gửi yêu cầu rút tiền` (`frmRutTien` $\rightarrow$ `ctrRutTien`)
  3. `3: LockAccount()` (`ctrRutTien` $\rightarrow$ `TaiKhoan`)
  4. `4: KiemTraSoDu()` (`ctrRutTien` $\rightarrow$ `TaiKhoan`)
  5. `5: TruTien()` (`ctrRutTien` $\rightarrow$ `TaiKhoan`)
  6. `6: NhaTienMat()` (`ctrRutTien` $\rightarrow$ `MayATM`)
  7. `7: Thông báo rút tiền thành công` (`ctrRutTien` $\rightarrow$ `frmRutTien` $\rightarrow$ Khách hàng).

### 4. Biểu đồ Cộng tác (Collaboration Diagram)
* Vẽ lại 4 đối tượng BCE trên theo dạng mạng lưới tròn, có các mũi tên kèm số thứ tự thông điệp $1, 2, 3, 4, 5, 6, 7$ (hệt như trang 22 và trang 25 của file mẫu EPU).

*👉 Xuất ảnh `.png` và lưu file `.drawio` gửi lại cho Hiền tổng hợp.*

---

## PHẦN 5: KỊCH BẢN KIỂM THỬ KẾT NỐI CÙNG HIỀN VÀ ĐỨC LÚC 22H00

1. **Hiền** xác nhận Database SQL Server đã chạy.
2. **Đức** bấm Start chạy `Bank.Server` (màn hình đen in ra: `[SERVER] San sang tiep nhan...`).
3. **An** bấm Start (F5) chạy `Bank.Client` (màn hình cây ATM hiện lên).
4. **An** nhập:
   * Số thẻ: `9704000000001001`
   * Mã PIN: `123456`
   * Bấm nút 👉 **ĐĂNG NHẬP**.
5. Màn hình ATM tự động chuyển sang Menu chính và in ra dòng chữ màu xanh lá cây:  
   👉 **"Xin chào: Nguyễn Văn A - Số dư: 5.000.000 VNĐ"**!
6. An thử bấm nút **`[1] RÚT TIỀN MẶT`** $\rightarrow$ Màn hình nhảy sang chọn mệnh giá $\rightarrow$ Bấm **`◀ QUAY LẠI MENU CHÍNH`** $\rightarrow$ Menu chính hiện lại!

$\rightarrow$ **Chúc mừng An, bạn đã hoàn thành xuất sắc 100% nhiệm vụ của mình!**

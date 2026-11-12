using System;
using System.Drawing;
using System.Windows.Forms;
using Bank.Client.Screens;

namespace Bank.Client
{
    public partial class Form1 : Form
    {
        // Cho phép các UserControl bên trong dễ dàng gọi Form1 để chuyển màn hình
        public static Form1 Instance { get; private set; } = null!;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            InitializeKeypadEvents();

            // Khởi động vào màn hình Đăng nhập đầu tiên
            ShowScreen(new UcScreenLogin());
        }

        // ====================================================================
        // ĐIỀU HƯỚNG MÀN HÌNH CHUYỂN ĐỔI (CHUYÊN NGHIỆP QUA USERCONTROL)
        // ====================================================================
        public void ShowScreen(UserControl uc)
        {
            pnlScreenContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlScreenContainer.Controls.Add(uc);
            uc.BringToFront();

            // Màn hình Đăng nhập (Login): Hiện bàn phím số phần cứng PinPad bên phải
            // Các màn hình Menu / Giao dịch: Tự động bung rộng toàn bộ Kiosk
            pnlHardwareKeypad.Visible = (uc is UcScreenLogin);

            // Đồng bộ cấu hình IP & Port socket
            SyncSocketConfig();
        }

        public void SyncSocketConfig()
        {
            AtmClientSocket.ServerIp = txtServerIp.Text.Trim();
            if (int.TryParse(txtServerPort.Text.Trim(), out int port))
            {
                AtmClientSocket.ServerPort = port;
            }
        }

        // ====================================================================
        // GẮN SỰ KIỆN BÀN PHÍM SỐ CÂY ATM (HARDWARE PINPAD)
        // ====================================================================
        private void InitializeKeypadEvents()
        {
            // 10 phím số 0 - 9
            btnKey1.Click += KeypadNumber_Click;
            btnKey2.Click += KeypadNumber_Click;
            btnKey3.Click += KeypadNumber_Click;
            btnKey4.Click += KeypadNumber_Click;
            btnKey5.Click += KeypadNumber_Click;
            btnKey6.Click += KeypadNumber_Click;
            btnKey7.Click += KeypadNumber_Click;
            btnKey8.Click += KeypadNumber_Click;
            btnKey9.Click += KeypadNumber_Click;
            btnKey0.Click += KeypadNumber_Click;

            // Phím CLEAR (Xóa ký tự cuối)
            btnKeyClear.Click += btnKeyClear_Click;

            // Phím ENTER (Gửi xác nhận)
            btnKeyEnter.Click += btnKeyEnter_Click;

            // Khe cắm thẻ ATM
            pnlCardSlot.Click += pnlCardSlot_Click;
            lblCardSlot.Click += pnlCardSlot_Click;

            // Thay đổi cấu hình Server
            txtServerIp.TextChanged += (s, e) => SyncSocketConfig();
            txtServerPort.TextChanged += (s, e) => SyncSocketConfig();
        }

        private void KeypadNumber_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && AtmSession.ActiveInput != null)
            {
                AtmSession.ActiveInput.Text += btn.Text;
                AtmSession.ActiveInput.SelectionStart = AtmSession.ActiveInput.Text.Length;
            }
        }

        private void btnKeyClear_Click(object? sender, EventArgs e)
        {
            if (AtmSession.ActiveInput != null && AtmSession.ActiveInput.Text.Length > 0)
            {
                AtmSession.ActiveInput.Text = AtmSession.ActiveInput.Text.Substring(0, AtmSession.ActiveInput.Text.Length - 1);
                AtmSession.ActiveInput.SelectionStart = AtmSession.ActiveInput.Text.Length;
            }
        }

        private void btnKeyEnter_Click(object? sender, EventArgs e)
        {
            // Bấm ENTER trên bàn phím cứng kích hoạt nút xác nhận tương ứng
            if (pnlScreenContainer.Controls.Count > 0)
            {
                var currentUc = pnlScreenContainer.Controls[0];
                if (currentUc is UcScreenLogin login)
                {
                    login.PerformLogin();
                }
            }
        }

        public void NotifyCashDispensed(decimal amount)
        {
            lblCashTray.Text = $"💵 VUI LÒNG NHẬN {amount:N0} VNĐ 💵";
            lblCashTray.ForeColor = Color.Yellow;
        }

        private void pnlCardSlot_Click(object? sender, EventArgs e)
        {
            if (pnlScreenContainer.Controls.Count > 0 && pnlScreenContainer.Controls[0] is UcScreenLogin login)
            {
                if (login.txtCardNumber.Text == "9704000000001001" || login.txtCardNumber.Text == "1001")
                {
                    login.LoadSampleCard("9704000000001002", "654321", "Trần Thị Bình");
                }
                else
                {
                    login.LoadSampleCard("9704000000001001", "123456", "Nguyễn Văn An");
                }
            }
        }
    }
}

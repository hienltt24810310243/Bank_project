using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public partial class UcScreenLogin : UserControl
    {
        public UcScreenLogin()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Focus vào ô nhập liệu để bàn phím số ATM gõ được
            txtCardNumber.Enter += (s, e) => AtmSession.SetActiveInput(txtCardNumber);
            txtPin.Enter += (s, e) => AtmSession.SetActiveInput(txtPin);
            pnlPinWrapper.Click += (s, e) => txtPin.Focus();

            // Xử lý phím Enter trên bàn phím máy tính
            txtCardNumber.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    txtPin.Focus();
                }
            };
            txtPin.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    PerformLogin();
                }
            };

            // Nút đăng nhập & Hủy bỏ
            btnLogin.Click += btnLogin_Click;
            btnCancelLogin.Click += btnCancelLogin_Click;

            // Nút con mắt ẩn/hiện mã PIN
            btnToggleLoginPin.Click += (s, e) =>
            {
                if (txtPin.PasswordChar != '\0')
                {
                    txtPin.PasswordChar = '\0';
                    btnToggleLoginPin.Text = "🙈";
                    btnToggleLoginPin.ForeColor = Color.FromArgb(34, 211, 238);
                }
                else
                {
                    txtPin.PasswordChar = '●';
                    btnToggleLoginPin.Text = "👁";
                    btnToggleLoginPin.ForeColor = Color.FromArgb(148, 163, 184);
                }
            };

            // Tự động căn giữa khung đăng nhập khi kích thước thay đổi (High-DPI / Resize)
            this.Resize += (s, e) => CenterLoginCard();
            this.Load += (s, e) =>
            {
                AtmSession.SetActiveInput(txtCardNumber);
                CenterLoginCard();
            };
        }

        private void CenterLoginCard()
        {
            if (this.ClientSize.Width > pnlLoginCard.Width)
            {
                pnlLoginCard.Left = (this.ClientSize.Width - pnlLoginCard.Width) / 2;
                pnlLoginCard.Top = Math.Max(10, (this.ClientSize.Height - pnlLoginCard.Height - pnlScreen1Footer.Height) / 2);
            }
        }

        public void PerformLogin()
        {
            btnLogin_Click(btnLogin, EventArgs.Empty);
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string soThe = txtCardNumber.Text.Trim();
            string pin = txtPin.Text.Trim();

            if (string.IsNullOrEmpty(soThe) || string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Số thẻ và Mã PIN!", "Thông báo ATM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblWarning.Text = "⏳ Đang xác thực thẻ với Core Banking Server...";
            lblWarning.ForeColor = Color.FromArgb(250, 204, 21);
            Application.DoEvents();

            // Gửi lệnh Socket TCP lên Server kèm mã trạm ATM
            string response = AtmClientSocket.SendCommand($"LOGIN|{soThe}|{pin}|{AtmSession.CurrentAtmId}");
            string[] parts = response.Split('|');

            if (parts[0] == "LOGIN_SUCCESS")
            {
                // Lưu dữ liệu tài khoản vào phiên làm việc
                AtmSession.CurrentCard = soThe;
                AtmSession.CurrentName = parts.Length > 1 ? parts[1] : "Nguyễn Văn An";
                AtmSession.CurrentBalance = parts.Length > 2 && decimal.TryParse(parts[2], out decimal bal) ? bal : 8500000;
                AtmSession.CurrentAccount = parts.Length > 3 ? parts[3] : "1001";

                // Chuyển sang Màn hình Menu Chính (Screen 2)
                Form1.Instance.ShowScreen(new UcScreenMenu());
            }
            else
            {
                string errMsg = parts.Length > 1 ? parts[1] : response;
                lblWarning.Text = "❌ " + errMsg;
                lblWarning.ForeColor = Color.FromArgb(248, 113, 113);
                MessageBox.Show(errMsg, "Lỗi đăng nhập ATM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelLogin_Click(object? sender, EventArgs e)
        {
            txtCardNumber.Text = "";
            txtPin.Text = "";
            lblWarning.Text = "▲ Quý khách đã hủy thao tác đút thẻ.";
            lblWarning.ForeColor = Color.FromArgb(251, 191, 36);
        }

        public void LoadSampleCard(string card, string pin, string name)
        {
            txtCardNumber.Text = card;
            txtPin.Text = pin;
            lblWarning.Text = $"ℹ Đã nạp Thẻ mẫu: {name}";
            lblWarning.ForeColor = Color.FromArgb(103, 232, 249);
        }
    }
}

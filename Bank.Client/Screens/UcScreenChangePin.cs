using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public partial class UcScreenChangePin : UserControl
    {
        public UcScreenChangePin()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Focus để bàn phím số PinPad gõ được
            txtOldPin.Enter += (s, e) => AtmSession.SetActiveInput(txtOldPin);
            txtNewPin.Enter += (s, e) => AtmSession.SetActiveInput(txtNewPin);
            txtConfirmNewPin.Enter += (s, e) => AtmSession.SetActiveInput(txtConfirmNewPin);

            // Click vào khung viền tự động focus vào ô nhập
            pnlOldPinWrapper.Click += (s, e) => txtOldPin.Focus();
            pnlNewPinWrapper.Click += (s, e) => txtNewPin.Focus();
            pnlConfirmPinWrapper.Click += (s, e) => txtConfirmNewPin.Focus();

            // Phím Enter chuyển ô và xác nhận
            txtOldPin.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    txtNewPin.Focus();
                }
            };
            txtNewPin.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    txtConfirmNewPin.Focus();
                }
            };
            txtConfirmNewPin.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnChangePinConfirm_Click(btnChangePinConfirm, EventArgs.Empty);
                }
            };

            // Nút bấm
            btnChangePinBack.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenMenu());
            btnChangePinConfirm.Click += btnChangePinConfirm_Click;

            // Nút con mắt ẩn/hiện mã PIN
            btnToggleOldPin.Click += (s, e) => TogglePasswordVisibility(txtOldPin, btnToggleOldPin);
            btnToggleNewPin.Click += (s, e) => TogglePasswordVisibility(txtNewPin, btnToggleNewPin);
            btnToggleConfirmPin.Click += (s, e) => TogglePasswordVisibility(txtConfirmNewPin, btnToggleConfirmPin);

            // Căn giữa card khi resize
            this.Resize += (s, e) => CenterChangePinCard();
            this.Load += (s, e) =>
            {
                AtmSession.SetActiveInput(txtOldPin);
                CenterChangePinCard();
            };
        }

        private void CenterChangePinCard()
        {
            if (this.ClientSize.Width > pnlChangePinCard.Width)
            {
                pnlChangePinCard.Left = (this.ClientSize.Width - pnlChangePinCard.Width) / 2;
                pnlChangePinCard.Top = Math.Max(50, (this.ClientSize.Height - pnlChangePinCard.Height) / 2);
            }
        }

        private void TogglePasswordVisibility(TextBox tb, Button btn)
        {
            if (tb.PasswordChar != '\0')
            {
                tb.PasswordChar = '\0';
                btn.Text = "🙈";
                btn.ForeColor = Color.FromArgb(34, 211, 238); // Cyan sáng
            }
            else
            {
                tb.PasswordChar = '●';
                btn.Text = "👁";
                btn.ForeColor = Color.FromArgb(148, 163, 184); // Xám bạc
            }
        }

        private void btnChangePinConfirm_Click(object? sender, EventArgs e)
        {
            string oldPin = txtOldPin.Text.Trim();
            string newPin = txtNewPin.Text.Trim();
            string confirmPin = txtConfirmNewPin.Text.Trim();

            if (string.IsNullOrEmpty(oldPin))
            {
                MessageBox.Show("Vui lòng nhập mã PIN hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPin.Length != 6 || !decimal.TryParse(newPin, out _))
            {
                MessageBox.Show("Mã PIN mới phải gồm đúng 6 chữ số!", "Lỗi đổi PIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPin != confirmPin)
            {
                MessageBox.Show("Xác nhận mã PIN mới không trùng khớp!", "Lỗi đổi PIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (oldPin == newPin)
            {
                MessageBox.Show("Mã PIN mới không được trùng với mã PIN hiện tại!", "Lỗi đổi PIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gửi lệnh Socket TCP lên Server để cập nhật SQL Server
            string response = AtmClientSocket.SendCommand($"CHANGE_PIN|{AtmSession.CurrentCard}|{oldPin}|{newPin}");
            string[] parts = response.Split('|');

            if (parts[0] == "CHANGE_PIN_SUCCESS")
            {
                MessageBox.Show("ĐỔI MÃ PIN THÀNH CÔNG!\n\nQuý khách vui lòng ghi nhớ mã PIN mới để đăng nhập cho các lần giao dịch tiếp theo.", 
                    "Bảo mật EPU Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOldPin.Text = "";
                txtNewPin.Text = "";
                txtConfirmNewPin.Text = "";
                Form1.Instance.ShowScreen(new UcScreenMenu());
            }
            else
            {
                string errorMsg = parts.Length >= 2 ? parts[1] : "Đổi mã PIN thất bại!";
                MessageBox.Show($"ĐỔI PIN THẤT BẠI!\n\nLý do: {errorMsg}", "Lỗi đổi PIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

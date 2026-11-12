using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public partial class UcScreenTransfer : UserControl
    {
        public UcScreenTransfer()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // Focus để bàn phím số PinPad gõ được
            txtDestAccount.Enter += (s, e) => AtmSession.SetActiveInput(txtDestAccount);
            txtTransferAmount.Enter += (s, e) => AtmSession.SetActiveInput(txtTransferAmount);
            txtTransferDesc.Enter += (s, e) => AtmSession.SetActiveInput(txtTransferDesc);

            // Nút bấm
            btnCheckReceiver.Click += btnCheckReceiver_Click;
            btnTransferBack.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenMenu());
            btnTransferConfirm.Click += btnTransferConfirm_Click;

            // Căn giữa card khi resize
            this.Resize += (s, e) => CenterTransferCard();
            this.Load += (s, e) =>
            {
                AtmSession.SetActiveInput(txtDestAccount);
                CenterTransferCard();
            };
        }

        private void CenterTransferCard()
        {
            if (this.ClientSize.Width > pnlTransferCard.Width)
            {
                pnlTransferCard.Left = (this.ClientSize.Width - pnlTransferCard.Width) / 2;
                pnlTransferCard.Top = Math.Max(50, (this.ClientSize.Height - pnlTransferCard.Height) / 2);
            }
        }

        private void btnCheckReceiver_Click(object? sender, EventArgs e)
        {
            string dest = txtDestAccount.Text.Trim();
            if (string.IsNullOrEmpty(dest))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dest == AtmSession.CurrentAccount)
            {
                lblReceiverBadge.Text = "⚠️ KHÔNG THỂ TỰ CHUYỂN KHOẢN CHO CHÍNH MÌNH!";
                lblReceiverBadge.BackColor = Color.FromArgb(127, 29, 29);
                lblReceiverBadge.ForeColor = Color.FromArgb(248, 113, 113);
                return;
            }

            lblReceiverBadge.Text = "⏳ Đang kiểm tra tài khoản...";
            lblReceiverBadge.BackColor = Color.FromArgb(30, 41, 59);
            lblReceiverBadge.ForeColor = Color.FromArgb(250, 204, 21);
            Application.DoEvents();

            // Gửi lệnh Socket TCP lên Server để kiểm tra tên trong SQL Server thật
            string res = AtmClientSocket.SendCommand($"CHECK_ACCOUNT|{dest}");
            string[] parts = res.Split('|');

            if (parts[0] == "CHECK_ACCOUNT_SUCCESS" && parts.Length >= 2)
            {
                string hoTen = parts[1];
                lblReceiverBadge.Text = $"TÊN NGƯỜI NHẬN:   {hoTen.ToUpper()} (EPU BANK)";
                lblReceiverBadge.BackColor = Color.FromArgb(6, 78, 59);
                lblReceiverBadge.ForeColor = Color.FromArgb(52, 211, 153);
            }
            else
            {
                string errorMsg = parts.Length >= 2 ? parts[1] : "Số tài khoản không tồn tại!";
                lblReceiverBadge.Text = $"⚠️ {errorMsg}";
                lblReceiverBadge.BackColor = Color.FromArgb(127, 29, 29);
                lblReceiverBadge.ForeColor = Color.FromArgb(248, 113, 113);
            }
        }

        private void btnTransferConfirm_Click(object? sender, EventArgs e)
        {
            string dest = txtDestAccount.Text.Trim();
            string amountStr = txtTransferAmount.Text.Trim();
            string desc = txtTransferDesc.Text.Trim();

            if (string.IsNullOrEmpty(dest))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dest == AtmSession.CurrentAccount)
            {
                MessageBox.Show("Không thể tự chuyển tiền cho chính mình!", "Lỗi chuyển tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountStr, out decimal transferAmt) || transferAmt <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền chuyển hợp lệ (lớn hơn 0 VNĐ)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (transferAmt > AtmSession.CurrentBalance)
            {
                MessageBox.Show("Số dư tài khoản không đủ để chuyển khoản!", "Lỗi chuyển tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(desc))
            {
                desc = "Chuyen tien ATM";
            }

            // Gửi lệnh Socket TCP lên Server để thực hiện chuyển khoản và cập nhật SQL Server
            string response = AtmClientSocket.SendCommand($"TRANSFER|{AtmSession.CurrentAccount}|{dest}|{transferAmt}|{desc}");
            string[] parts = response.Split('|');

            if (parts[0] == "TRANSFER_SUCCESS")
            {
                decimal newBalance = parts.Length >= 3 && decimal.TryParse(parts[2], out decimal bal) ? bal : AtmSession.CurrentBalance - transferAmt;
                AtmSession.CurrentBalance = newBalance;

                MessageBox.Show($"CHUYỂN KHOẢN THÀNH CÔNG!\n\n" +
                    $"Người nhận: {lblReceiverBadge.Text}\n" +
                    $"Số tiền: {transferAmt:N0} VNĐ\n" +
                    $"Nội dung: {desc}\n" +
                    $"Số dư mới: {AtmSession.CurrentBalance:N0} VNĐ", "EPU Bank 24/7", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1.Instance.ShowScreen(new UcScreenMenu());
            }
            else
            {
                string errorMsg = parts.Length >= 2 ? parts[1] : "Chuyển tiền thất bại!";
                MessageBox.Show($"GIAO DỊCH THẤT BẠI!\n\nLý do: {errorMsg}", "Lỗi chuyển tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

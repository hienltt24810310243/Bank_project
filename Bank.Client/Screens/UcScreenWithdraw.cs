using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public partial class UcScreenWithdraw : UserControl
    {
        public UcScreenWithdraw()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateBalanceDisplay();
        }

        private void InitializeEvents()
        {
            // Nút chọn mệnh giá
            btnDenom100k.Click += DenomButton_Click;
            btnDenom200k.Click += DenomButton_Click;
            btnDenom500k.Click += DenomButton_Click;
            btnDenom1m.Click += DenomButton_Click;
            btnDenom2m.Click += DenomButton_Click;
            btnDenomCustom.Click += btnDenomCustom_Click;

            // Nút quay lại & xác nhận
            btnWithdrawBack.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenMenu());
            btnWithdrawConfirm.Click += btnWithdrawConfirm_Click;
        }

        public void UpdateBalanceDisplay()
        {
            lblWithdrawBalance.Text = $"Số dư hiện tại: {AtmSession.CurrentBalance:N0} VNĐ";
        }

        private void DenomButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Reset màu các nút
                ResetDenomButtonColors();
                btn.BackColor = Color.FromArgb(6, 182, 212); // Cyan sáng

                if (btn == btnDenom100k) AtmSession.SelectedWithdrawAmount = 100000;
                else if (btn == btnDenom200k) AtmSession.SelectedWithdrawAmount = 200000;
                else if (btn == btnDenom500k) AtmSession.SelectedWithdrawAmount = 500000;
                else if (btn == btnDenom1m) AtmSession.SelectedWithdrawAmount = 1000000;
                else if (btn == btnDenom2m) AtmSession.SelectedWithdrawAmount = 2000000;
            }
        }

        private void ResetDenomButtonColors()
        {
            Color normalBg = Color.FromArgb(30, 41, 59);
            btnDenom100k.BackColor = normalBg;
            btnDenom200k.BackColor = normalBg;
            btnDenom500k.BackColor = normalBg;
            btnDenom1m.BackColor = normalBg;
            btnDenom2m.BackColor = normalBg;
            btnDenomCustom.BackColor = Color.FromArgb(14, 116, 144);
        }

        private void btnDenomCustom_Click(object? sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập số tiền bạn muốn rút (bội số của 50.000 VNĐ, tối đa 5.000.000 VNĐ):", 
                "Nhập số tiền khác", "500000");

            if (decimal.TryParse(input, out decimal customAmt) && customAmt >= 50000 && customAmt % 50000 == 0)
            {
                AtmSession.SelectedWithdrawAmount = customAmt;
                ResetDenomButtonColors();
                btnDenomCustom.BackColor = Color.FromArgb(6, 182, 212);
                btnDenomCustom.Text = $"{customAmt:N0} VNĐ";
            }
            else if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Số tiền rút phải là bội số của 50.000 VNĐ và tối thiểu 50.000 VNĐ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnWithdrawConfirm_Click(object? sender, EventArgs e)
        {
            if (AtmSession.SelectedWithdrawAmount > AtmSession.CurrentBalance)
            {
                MessageBox.Show("Số dư trong tài khoản không đủ để thực hiện giao dịch!", "Lỗi rút tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gửi lệnh Socket TCP rút tiền lên Server để cập nhật SQL Server
            string response = AtmClientSocket.SendCommand($"WITHDRAW|{AtmSession.CurrentCard}|{AtmSession.SelectedWithdrawAmount}");
            string[] parts = response.Split('|');

            if (parts[0] == "WITHDRAW_SUCCESS")
            {
                decimal newBalance = parts.Length >= 3 && decimal.TryParse(parts[2], out decimal bal) ? bal : AtmSession.CurrentBalance - AtmSession.SelectedWithdrawAmount;
                AtmSession.CurrentBalance = newBalance;
                UpdateBalanceDisplay();

                Form1.Instance.NotifyCashDispensed(AtmSession.SelectedWithdrawAmount);

                MessageBox.Show($"GIAO DỊCH RÚT TIỀN THÀNH CÔNG!\n\n" +
                    $"Số tiền đã rút: {AtmSession.SelectedWithdrawAmount:N0} VNĐ\n" +
                    $"Số dư mới: {AtmSession.CurrentBalance:N0} VNĐ\n\n" +
                    $"Vui lòng nhận tiền tại khay tiền bên dưới!", "Thông báo từ EPU Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1.Instance.ShowScreen(new UcScreenMenu());
            }
            else
            {
                string errorMsg = parts.Length >= 2 ? parts[1] : "Rút tiền thất bại!";
                MessageBox.Show($"GIAO DỊCH THẤT BẠI!\n\nLý do: {errorMsg}", "Lỗi rút tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

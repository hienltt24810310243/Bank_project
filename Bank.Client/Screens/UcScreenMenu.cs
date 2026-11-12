using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public partial class UcScreenMenu : UserControl
    {
        public UcScreenMenu()
        {
            InitializeComponent();
            InitializeEvents();
            LoadUserData();
        }

        private void InitializeEvents()
        {
            // Các nút chức năng
            btnMenuWithdraw.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenWithdraw());
            btnMenuTransfer.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenTransfer());
            btnMenuChangePin.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenChangePin());
            btnMenuHistory.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenHistory());
            btnMenuLogout.Click += btnMenuLogout_Click;

            // Tự động căn chỉnh nhãn Số Dư Khả Dụng và Số Tiền luôn dính sát lề phải
            pnlUserBanner.Resize += (s, e) => AlignBalanceToRight();
            this.Load += (s, e) => AlignBalanceToRight();
        }

        private void AlignBalanceToRight()
        {
            if (pnlUserBanner.ClientSize.Width > 0)
            {
                lblBalanceLabel.Left = pnlUserBanner.ClientSize.Width - lblBalanceLabel.Width - 30;
                lblUserBalance.Left = pnlUserBanner.ClientSize.Width - lblUserBalance.Width - 30;
            }
        }

        public void LoadUserData()
        {
            lblWelcomeUser.Text = "XIN CHÀO CHỦ THẺ:";
            lblUserAccount.Text = $"{AtmSession.CurrentName.ToUpper()} (STK: {AtmSession.CurrentAccount})";
            lblUserBalance.Text = $"{AtmSession.CurrentBalance:N0} VNĐ";
            AlignBalanceToRight();
        }

        private void btnMenuLogout_Click(object? sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Quý khách có chắc muốn kết thúc phiên giao dịch và nhận lại thẻ?", 
                "Xác nhận trả thẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                AtmSession.Clear();
                Form1.Instance.ShowScreen(new UcScreenLogin());
            }
        }
    }
}

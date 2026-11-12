using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bank.Client.Screens
{
    public partial class UcScreenHistory : UserControl
    {
        public UcScreenHistory()
        {
            InitializeComponent();
            InitializeEvents();
            LoadHistoryData();
        }

        private void InitializeEvents()
        {
            btnHistoryBack.Click += (s, e) => Form1.Instance.ShowScreen(new UcScreenMenu());
            btnPrintReceipt.Click += btnPrintReceipt_Click;
        }

        public void LoadHistoryData()
        {
            lblHistoryAcc.Text = $"Chủ tài khoản: {AtmSession.CurrentName.ToUpper()} (STK: {AtmSession.CurrentAccount})";

            dgvHistory.Rows.Clear();
            AtmSession.RecentTransactions.Clear();

            try
            {
                // Gửi lệnh Socket TCP lên Server để lấy lịch sử thật từ SQL Server
                string response = AtmClientSocket.SendCommand($"HISTORY|{AtmSession.CurrentAccount}");

                if (response.StartsWith("HISTORY_SUCCESS|"))
                {
                    string data = response.Substring("HISTORY_SUCCESS|".Length);
                    string[] rows = data.Split(';');

                    foreach (var row in rows)
                    {
                        if (string.IsNullOrWhiteSpace(row)) continue;
                        string[] cols = row.Split('#');
                        if (cols.Length >= 4)
                        {
                            string thoiGian = cols[0];
                            string loaiGD = cols[1];
                            decimal soTien = decimal.TryParse(cols[2], out decimal val) ? val : 0;
                            string trangThai = cols[3];

                            // Lưu vào Session để dùng cho in biên lai
                            AtmSession.RecentTransactions.Add(new TransactionItem
                            {
                                ThoiGian = thoiGian,
                                LoaiGiaoDich = loaiGD,
                                SoTien = soTien,
                                TrangThai = trangThai
                            });

                            // Định dạng số tiền có dấu + hoặc -
                            string strTien = soTien > 0 ? $"+{soTien:N0}đ" : (soTien < 0 ? $"-{Math.Abs(soTien):N0}đ" : "0đ");

                            int rowIndex = dgvHistory.Rows.Add(thoiGian, loaiGD, strTien, trangThai);

                            // Đổi màu số tiền: Tiền vào màu xanh lá, tiền ra màu đỏ
                            if (soTien > 0)
                            {
                                dgvHistory.Rows[rowIndex].Cells[2].Style.ForeColor = Color.FromArgb(52, 211, 153);
                            }
                            else if (soTien < 0)
                            {
                                dgvHistory.Rows[rowIndex].Cells[2].Style.ForeColor = Color.FromArgb(248, 113, 113);
                            }
                        }
                    }
                }
                else if (response == "HISTORY_EMPTY")
                {
                    dgvHistory.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "Chưa có giao dịch phát sinh", "0đ", "Thành công");
                }
                else
                {
                    // Dự phòng nếu mất kết nối Server
                    dgvHistory.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "Mở tài khoản EPU", "0đ", "Thành công");
                }
            }
            catch
            {
                dgvHistory.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "Mở tài khoản EPU", "0đ", "Thành công");
            }
        }

        private void btnPrintReceipt_Click(object? sender, EventArgs e)
        {
            // Mở Biên Lai In Giấy Nhiệt ATM
            using (var receiptForm = new FormReceipt())
            {
                receiptForm.ShowDialog(this);
            }
        }
    }
}

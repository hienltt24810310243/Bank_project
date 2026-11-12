using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Bank.Client.Screens;

namespace Bank.Client
{
    public class FormReceipt : Form
    {
        private Panel pnlPaper = null!;
        private Label lblBankName = null!;
        private Label lblReceiptType = null!;
        private Label lblDivider1 = null!;
        private TableLayoutPanel tblMeta = null!;
        private Label lblDivider2 = null!;
        private TableLayoutPanel tblHistory = null!;
        private Label lblDivider3 = null!;
        private Label lblBalanceText = null!;
        private Label lblBarcode = null!;
        private Label lblFooterNote = null!;
        private Button btnExportFile = null!;
        private Button btnClose = null!;

        public FormReceipt()
        {
            InitializeComponent();
            LoadReceiptData();
        }

        private void InitializeComponent()
        {
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 720);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(15, 23, 42); // Dark slate sang trọng
            this.Text = "HÓA ĐƠN BIÊN LAI ATM - EPU BANK";

            // 1. Khung cuộn giấy in nhiệt màu trắng
            pnlPaper = new Panel
            {
                Location = new Point(25, 20),
                Size = new Size(450, 620),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20, 16, 20, 16)
            };

            // Tiêu đề ngân hàng
            lblBankName = new Label
            {
                Text = "🏛 NGÂN HÀNG ĐIỆN LỰC - EPU BANK",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 43, 67),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 32
            };

            lblReceiptType = new Label
            {
                Text = "BIÊN LAI SAO KÊ GIAO DỊCH ATM",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 22
            };

            lblDivider1 = new Label
            {
                Text = "--------------------------------------------------------------------------------",
                Font = new Font("Consolas", 8.5F),
                ForeColor = Color.FromArgb(148, 163, 184),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 14
            };

            // Bảng Metadata 2 cột
            tblMeta = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 110,
                ColumnCount = 2,
                RowCount = 5,
                BackColor = Color.Transparent
            };
            tblMeta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tblMeta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            for (int i = 0; i < 5; i++)
            {
                tblMeta.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            }

            lblDivider2 = new Label
            {
                Text = "--------------------------------------------------------------------------------",
                Font = new Font("Consolas", 8.5F),
                ForeColor = Color.FromArgb(148, 163, 184),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 14
            };

            // Bảng 5 Giao dịch (TableLayoutPanel căn lề thẳng hàng 100%)
            tblHistory = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 180,
                ColumnCount = 3,
                RowCount = 6,
                BackColor = Color.Transparent
            };
            tblHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 6; i++)
            {
                tblHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            }

            lblDivider3 = new Label
            {
                Text = "--------------------------------------------------------------------------------",
                Font = new Font("Consolas", 8.5F),
                ForeColor = Color.FromArgb(148, 163, 184),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 14
            };

            // Số dư cuối
            lblBalanceText = new Label
            {
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(5, 150, 105),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Mã vạch Barcode mô phỏng
            lblBarcode = new Label
            {
                Text = "||| | ||||| || |||| ||| ||||| || ||| ||||| |||| ||",
                Font = new Font("Consolas", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };

            // Lời cảm ơn & Hotline
            lblFooterNote = new Label
            {
                Text = "CẢM ƠN QUÝ KHÁCH ĐÃ SỬ DỤNG DỊCH VỤ EPU BANK!\nTổng đài hỗ trợ 24/7: 1900 123 456 - www.epu.edu.vn",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 40
            };

            pnlPaper.Controls.Add(lblFooterNote);
            pnlPaper.Controls.Add(lblBarcode);
            pnlPaper.Controls.Add(lblBalanceText);
            pnlPaper.Controls.Add(lblDivider3);
            pnlPaper.Controls.Add(tblHistory);
            pnlPaper.Controls.Add(lblDivider2);
            pnlPaper.Controls.Add(tblMeta);
            pnlPaper.Controls.Add(lblDivider1);
            pnlPaper.Controls.Add(lblReceiptType);
            pnlPaper.Controls.Add(lblBankName);

            // Nút bấm bên dưới
            btnExportFile = new Button
            {
                Text = "🖨 IN RA FILE TEXT (NOTEPAD)",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(14, 116, 144),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(25, 655),
                Size = new Size(270, 45),
                Cursor = Cursors.Hand
            };
            btnExportFile.FlatAppearance.BorderSize = 0;
            btnExportFile.Click += BtnExportFile_Click;

            btnClose = new Button
            {
                Text = "ĐÓNG",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(51, 65, 85),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(310, 655),
                Size = new Size(165, 45),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(btnExportFile);
            this.Controls.Add(btnClose);
            this.Controls.Add(pnlPaper);
        }

        private void LoadReceiptData()
        {
            string maskedCard = AtmSession.CurrentCard.Length >= 8
                ? AtmSession.CurrentCard.Substring(0, 4) + " **** **** " + AtmSession.CurrentCard.Substring(AtmSession.CurrentCard.Length - 4)
                : AtmSession.CurrentCard;

            // Điền thông tin Metadata
            AddMetaRow("MÃ GIAO DỊCH:", $"TXN-{DateTime.Now:yyyyMMdd}-{DateTime.Now.Millisecond:D4}");
            AddMetaRow("THỜI GIAN IN:", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            AddMetaRow("TRẠM ATM:", "ATM #01 (CẦU GIẤY, HÀ NỘI)");
            AddMetaRow("CHỦ TÀI KHOẢN:", AtmSession.CurrentName.ToUpper());
            AddMetaRow("SỐ TÀI KHOẢN:", $"{AtmSession.CurrentAccount} ({maskedCard})");

            // Tiêu đề bảng lịch sử
            tblHistory.Controls.Add(CreateHeaderCell("Thời gian"), 0, 0);
            tblHistory.Controls.Add(CreateHeaderCell("Loại giao dịch"), 1, 0);
            tblHistory.Controls.Add(CreateHeaderCell("Số tiền", ContentAlignment.MiddleRight), 2, 0);

            // Hiển thị các giao dịch thật từ SQL Server
            if (AtmSession.RecentTransactions != null && AtmSession.RecentTransactions.Count > 0)
            {
                int row = 1;
                foreach (var tx in AtmSession.RecentTransactions)
                {
                    if (row > 5) break;

                    string strTien = tx.SoTien > 0 ? $"+{tx.SoTien:N0}đ" : (tx.SoTien < 0 ? $"-{Math.Abs(tx.SoTien):N0}đ" : "0đ");
                    Color colorTien = tx.SoTien > 0 ? Color.FromArgb(5, 150, 105) : (tx.SoTien < 0 ? Color.FromArgb(220, 38, 38) : Color.FromArgb(71, 85, 105));

                    AddHistoryRow(tx.ThoiGian, tx.LoaiGiaoDich, strTien, colorTien, row);
                    row++;
                }
            }
            else
            {
                AddHistoryRow(DateTime.Now.ToString("dd/MM/yyyy"), "Chưa có giao dịch phát sinh", "0đ", Color.FromArgb(71, 85, 105), 1);
            }

            // Số dư
            lblBalanceText.Text = $"SỐ DƯ KHẢ DỤNG: {AtmSession.CurrentBalance:N0} VNĐ\nPHÍ DỊCH VỤ: 0 VNĐ (MIỄN PHÍ)";
        }

        private void AddMetaRow(string label, string val)
        {
            int row = tblMeta.Controls.Count / 2;
            var lblL = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var lblR = new Label
            {
                Text = val,
                Font = new Font("Consolas", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tblMeta.Controls.Add(lblL, 0, row);
            tblMeta.Controls.Add(lblR, 1, row);
        }

        private Label CreateHeaderCell(string text, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 43, 67),
                Dock = DockStyle.Fill,
                TextAlign = align
            };
        }

        private void AddHistoryRow(string time, string type, string amount, Color amtColor, int row)
        {
            var lbl1 = new Label { Text = time, Font = new Font("Consolas", 8.5F), ForeColor = Color.FromArgb(51, 65, 85), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            var lbl2 = new Label { Text = type, Font = new Font("Segoe UI", 8.5F), ForeColor = Color.FromArgb(15, 23, 42), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            var lbl3 = new Label { Text = amount, Font = new Font("Consolas", 9F, FontStyle.Bold), ForeColor = amtColor, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight };

            tblHistory.Controls.Add(lbl1, 0, row);
            tblHistory.Controls.Add(lbl2, 1, row);
            tblHistory.Controls.Add(lbl3, 2, row);
        }

        private void BtnExportFile_Click(object? sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"BienLai_ATM_{AtmSession.CurrentAccount}.txt");
                var sb = new StringBuilder();
                sb.AppendLine("==========================================================");
                sb.AppendLine("              NGÂN HÀNG ĐIỆN LỰC - EPU BANK               ");
                sb.AppendLine("              BIÊN LAI SAO KÊ GIAO DỊCH ATM               ");
                sb.AppendLine("==========================================================");
                sb.AppendLine($"MÃ GIAO DỊCH : TXN-{DateTime.Now:yyyyMMdd}-{DateTime.Now.Millisecond:D4}");
                sb.AppendLine($"THỜI GIAN    : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"TRẠM ATM     : CÂY ATM #01 (CẦU GIẤY, HÀ NỘI)");
                sb.AppendLine($"CHỦ TÀI KHOẢN: {AtmSession.CurrentName.ToUpper()}");
                sb.AppendLine($"SỐ TÀI KHOẢN : {AtmSession.CurrentAccount}");
                sb.AppendLine("----------------------------------------------------------");
                sb.AppendLine("DANH SÁCH 5 GIAO DỊCH GẦN NHẤT:");

                if (AtmSession.RecentTransactions != null && AtmSession.RecentTransactions.Count > 0)
                {
                    for (int i = 0; i < AtmSession.RecentTransactions.Count; i++)
                    {
                        var tx = AtmSession.RecentTransactions[i];
                        string strTien = tx.SoTien > 0 ? $"+{tx.SoTien:N0} VNĐ" : (tx.SoTien < 0 ? $"-{Math.Abs(tx.SoTien):N0} VNĐ" : "0 VNĐ");
                        sb.AppendLine($" {i + 1}. {tx.ThoiGian,-16} | {tx.LoaiGiaoDich,-20} | {strTien,14}");
                    }
                }
                else
                {
                    sb.AppendLine("  (Chưa có giao dịch phát sinh)");
                }

                sb.AppendLine("----------------------------------------------------------");
                sb.AppendLine($"SỐ DƯ HIỆN TẠI : {AtmSession.CurrentBalance:N0} VNĐ");
                sb.AppendLine($"LỆ PHÍ DỊCH VỤ : 0 VNĐ (MIỄN PHÍ)");
                sb.AppendLine("==========================================================");
                sb.AppendLine("         CẢM ƠN QUÝ KHÁCH ĐÃ SỬ DỤNG DỊCH VỤ!             ");
                sb.AppendLine("             HOTLINE CSKH: 1900 123 456                   ");
                sb.AppendLine("==========================================================");

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                // Mở file bằng Notepad
                Process.Start(new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = $"\"{filePath}\"",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất biên lai: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

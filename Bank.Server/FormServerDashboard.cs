using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bank.Common;

namespace Bank.Server
{
    public partial class FormServerDashboard : Form
    {
        public FormServerDashboard()
        {
            InitializeComponent();
            HookEvents();
            RefreshData();
        }

        private void HookEvents()
        {
            // Tự động căn chỉnh nút Server Badge và Đồng hồ khi kích thước Form thay đổi
            void RepositionHeaderRightElements()
            {
                lblServerBadge.Location = new Point(pnlHeader.Width - lblServerBadge.Width - 25, 16);
                lblClock.Location = new Point(pnlHeader.Width - lblClock.Width - 25, 52);
            }

            pnlHeader.Resize += (s, e) => RepositionHeaderRightElements();
            this.Shown += (s, e) => RepositionHeaderRightElements();

            // Xử lý CellFormatting để giữ đúng màu trạng thái xanh/đỏ/vàng DÙ ĐANG ĐƯỢC CHỌN (SELECT)
            dgvAtmList.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvAtmList.Columns[e.ColumnIndex].Name == "TrangThai")
                {
                    string? val = e.Value?.ToString();
                    if (val != null && val.Contains("Hoạt động"))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(52, 211, 153); // Xanh lá sáng
                        e.CellStyle.SelectionForeColor = Color.FromArgb(52, 211, 153);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else if (val != null && val.Contains("Bảo trì"))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(251, 191, 36); // Vàng cam
                        e.CellStyle.SelectionForeColor = Color.FromArgb(251, 191, 36);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(248, 113, 113); // Đỏ cảnh báo
                        e.CellStyle.SelectionForeColor = Color.FromArgb(248, 113, 113);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }
                else if (e.RowIndex >= 0 && dgvAtmList.Columns[e.ColumnIndex].Name == "MaATM")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(103, 232, 249); // Cyan
                    e.CellStyle.SelectionForeColor = Color.FromArgb(103, 232, 249);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            };

            // Lắng nghe sự kiện từ AtmManager
            AtmManager.OnAtmListChanged += () =>
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.BeginInvoke(new Action(RefreshData));
                }
            };

            AtmManager.OnLogMessage += (msg, type) =>
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.BeginInvoke(new Action(() => AppendLog(msg, type)));
                }
            };

            // Nút bấm tương tác
            btnSetMaintenance.Click += (s, e) =>
            {
                ShowSetMaintenanceDialog();
            };

            btnSetOnline.Click += (s, e) =>
            {
                ShowSetOnlineDialog();
            };

            btnAddCash.Click += (s, e) =>
            {
                ShowAddCashDialog();
            };

            btnRefresh.Click += (s, e) =>
            {
                AtmManager.LoadAtmFromDatabase();
                RefreshData();
            };

            // Timer cập nhật đồng hồ và nhịp tim UI mỗi giây
            _refreshTimer.Interval = 1000;
            _refreshTimer.Tick += (s, e) =>
            {
                lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                UpdateGridHeartbeats();
            };
            _refreshTimer.Start();
        }

        private string? GetSelectedAtmId()
        {
            if (dgvAtmList.SelectedRows.Count > 0)
            {
                return dgvAtmList.SelectedRows[0].Cells["MaATM"].Value?.ToString();
            }
            MessageBox.Show("Vui lòng chọn một cây ATM trong bảng để thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        private void ShowSetMaintenanceDialog()
        {
            var list = AtmManager.GetAllTerminals();
            if (list.Count == 0) return;

            string? preSelectAtm = dgvAtmList.SelectedRows.Count > 0 ? dgvAtmList.SelectedRows[0].Cells["MaATM"].Value?.ToString() : null;

            using (Form dlg = new Form())
            {
                dlg.Text = "CHUYỂN CÂY ATM SANG CHẾ ĐỘ BẢO TRÌ";
                dlg.Size = new Size(460, 260);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.BackColor = Color.FromArgb(17, 24, 39);
                dlg.ForeColor = Color.White;
                dlg.Font = new Font("Segoe UI", 9.5F);

                Label lblAtm = new Label
                {
                    Text = "Chọn Cây ATM cần chuyển sang chế độ Bảo trì:",
                    Location = new Point(30, 20),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(148, 163, 184)
                };

                ComboBox cboAtm = new ComboBox
                {
                    Location = new Point(30, 48),
                    Size = new Size(385, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.FromArgb(30, 41, 59),
                    ForeColor = Color.FromArgb(251, 191, 36),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                foreach (var item in list)
                {
                    cboAtm.Items.Add($"{item.MaATM} - {item.TenTram} (Trạng thái: {item.DisplayStatus})");
                }

                int selectIdx = 0;
                if (!string.IsNullOrEmpty(preSelectAtm))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].MaATM == preSelectAtm) { selectIdx = i; break; }
                    }
                }
                cboAtm.SelectedIndex = selectIdx;

                Label lblNote = new Label
                {
                    Text = "⚠️ Cây ATM sau khi bảo trì sẽ từ chối giao dịch khách hàng.",
                    Location = new Point(30, 92),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(251, 191, 36),
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic)
                };

                Button btnConfirm = new Button
                {
                    Text = "🛠️ Đặt Bảo trì",
                    Location = new Point(30, 135),
                    Size = new Size(190, 42),
                    BackColor = Color.FromArgb(180, 83, 9),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnConfirm.FlatAppearance.BorderSize = 0;

                Button btnCancel = new Button
                {
                    Text = "Hủy bỏ",
                    Location = new Point(235, 135),
                    Size = new Size(180, 42),
                    BackColor = Color.FromArgb(71, 85, 105),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                btnConfirm.Click += (btnS, btnE) =>
                {
                    int selectedAtmIndex = cboAtm.SelectedIndex;
                    if (selectedAtmIndex < 0 || selectedAtmIndex >= list.Count) return;
                    string targetAtmId = list[selectedAtmIndex].MaATM;

                    AtmManager.SetAtmStatus(targetAtmId, "Bảo trì");
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();

                    MessageBox.Show($"Đã chuyển cây {targetAtmId} ({list[selectedAtmIndex].TenTram}) sang chế độ BẢO TRÌ!\nCây ATM sẽ từ chối giao dịch cho tới khi được kích hoạt lại.", "Thông báo NOC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                btnCancel.Click += (btnS, btnE) => dlg.Close();

                dlg.Controls.AddRange(new Control[] { lblAtm, cboAtm, lblNote, btnConfirm, btnCancel });
                dlg.ShowDialog(this);
            }
        }

        private void ShowSetOnlineDialog()
        {
            var list = AtmManager.GetAllTerminals();
            if (list.Count == 0) return;

            string? preSelectAtm = dgvAtmList.SelectedRows.Count > 0 ? dgvAtmList.SelectedRows[0].Cells["MaATM"].Value?.ToString() : null;

            using (Form dlg = new Form())
            {
                dlg.Text = "KÍCH HOẠT CÂY ATM HOẠT ĐỘNG (ONLINE)";
                dlg.Size = new Size(460, 260);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.BackColor = Color.FromArgb(17, 24, 39);
                dlg.ForeColor = Color.White;
                dlg.Font = new Font("Segoe UI", 9.5F);

                Label lblAtm = new Label
                {
                    Text = "Chọn Cây ATM cần Kích hoạt Hoạt động lại:",
                    Location = new Point(30, 20),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(148, 163, 184)
                };

                ComboBox cboAtm = new ComboBox
                {
                    Location = new Point(30, 48),
                    Size = new Size(385, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.FromArgb(30, 41, 59),
                    ForeColor = Color.FromArgb(52, 211, 153),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                foreach (var item in list)
                {
                    cboAtm.Items.Add($"{item.MaATM} - {item.TenTram} (Trạng thái: {item.DisplayStatus})");
                }

                int selectIdx = 0;
                if (!string.IsNullOrEmpty(preSelectAtm))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].MaATM == preSelectAtm) { selectIdx = i; break; }
                    }
                }
                cboAtm.SelectedIndex = selectIdx;

                Label lblNote = new Label
                {
                    Text = "🟢 Khôi phục cây ATM về trạng thái Online sẵn sàng phục vụ.",
                    Location = new Point(30, 92),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(52, 211, 153),
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic)
                };

                Button btnConfirm = new Button
                {
                    Text = "🟢 Kích hoạt Online",
                    Location = new Point(30, 135),
                    Size = new Size(190, 42),
                    BackColor = Color.FromArgb(5, 150, 105),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnConfirm.FlatAppearance.BorderSize = 0;

                Button btnCancel = new Button
                {
                    Text = "Hủy bỏ",
                    Location = new Point(235, 135),
                    Size = new Size(180, 42),
                    BackColor = Color.FromArgb(71, 85, 105),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                btnConfirm.Click += (btnS, btnE) =>
                {
                    int selectedAtmIndex = cboAtm.SelectedIndex;
                    if (selectedAtmIndex < 0 || selectedAtmIndex >= list.Count) return;
                    string targetAtmId = list[selectedAtmIndex].MaATM;

                    AtmManager.SetAtmStatus(targetAtmId, "Online");
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();

                    MessageBox.Show($"Đã khôi phục cây {targetAtmId} ({list[selectedAtmIndex].TenTram}) về trạng thái HOẠT ĐỘNG (ONLINE)!", "Thông báo NOC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                btnCancel.Click += (btnS, btnE) => dlg.Close();

                dlg.Controls.AddRange(new Control[] { lblAtm, cboAtm, lblNote, btnConfirm, btnCancel });
                dlg.ShowDialog(this);
            }
        }

        private void ShowAddCashDialog()
        {
            var list = AtmManager.GetAllTerminals();
            if (list.Count == 0) return;

            string? preSelectAtm = dgvAtmList.SelectedRows.Count > 0 ? dgvAtmList.SelectedRows[0].Cells["MaATM"].Value?.ToString() : null;

            using (Form dlg = new Form())
            {
                dlg.Text = "NẠP TIỀN QUỸ VÀO KHAY MÁY ATM";
                dlg.Size = new Size(460, 310);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.BackColor = Color.FromArgb(17, 24, 39);
                dlg.ForeColor = Color.White;
                dlg.Font = new Font("Segoe UI", 9.5F);

                Label lblAtm = new Label
                {
                    Text = "Chọn Cây ATM cần nạp tiền:",
                    Location = new Point(30, 20),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(148, 163, 184)
                };

                ComboBox cboAtm = new ComboBox
                {
                    Location = new Point(30, 48),
                    Size = new Size(385, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.FromArgb(30, 41, 59),
                    ForeColor = Color.FromArgb(103, 232, 249),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                foreach (var item in list)
                {
                    cboAtm.Items.Add($"{item.MaATM} - {item.TenTram} (Hiện có: {item.TongTienMat:N0} đ)");
                }

                int selectIdx = 0;
                if (!string.IsNullOrEmpty(preSelectAtm))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].MaATM == preSelectAtm) { selectIdx = i; break; }
                    }
                }
                cboAtm.SelectedIndex = selectIdx;

                Label lblAmount = new Label
                {
                    Text = "Chọn Số tiền nạp vào khay máy:",
                    Location = new Point(30, 95),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(148, 163, 184)
                };

                ComboBox cboAmount = new ComboBox
                {
                    Location = new Point(30, 122),
                    Size = new Size(385, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.FromArgb(30, 41, 59),
                    ForeColor = Color.FromArgb(52, 211, 153),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                cboAmount.Items.Add("20,000,000 VNĐ (+20 Triệu)");
                cboAmount.Items.Add("50,000,000 VNĐ (+50 Triệu)");
                cboAmount.Items.Add("100,000,000 VNĐ (+100 Triệu)");
                cboAmount.Items.Add("200,000,000 VNĐ (+200 Triệu)");
                cboAmount.SelectedIndex = 1; // Mặc định 50M

                Button btnConfirm = new Button
                {
                    Text = "💵 Xác nhận Nạp tiền",
                    Location = new Point(30, 190),
                    Size = new Size(190, 42),
                    BackColor = Color.FromArgb(5, 150, 105),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnConfirm.FlatAppearance.BorderSize = 0;

                Button btnCancel = new Button
                {
                    Text = "Hủy bỏ",
                    Location = new Point(235, 190),
                    Size = new Size(180, 42),
                    BackColor = Color.FromArgb(71, 85, 105),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                btnConfirm.Click += (btnS, btnE) =>
                {
                    int selectedAtmIndex = cboAtm.SelectedIndex;
                    if (selectedAtmIndex < 0 || selectedAtmIndex >= list.Count) return;
                    string targetAtmId = list[selectedAtmIndex].MaATM;

                    decimal addAmount = cboAmount.SelectedIndex switch
                    {
                        0 => 20000000m,
                        1 => 50000000m,
                        2 => 100000000m,
                        3 => 200000000m,
                        _ => 50000000m
                    };

                    DatabaseHelper.CapNhatTienMatMayATM(targetAtmId, -addAmount);
                    AtmManager.LoadAtmFromDatabase();
                    AtmManager.Log($"[QUỸ TIỀN MẶT] Đã nạp thêm +{addAmount:N0} VNĐ vào khay tiền cây {targetAtmId}.", "SUCCESS");
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();

                    MessageBox.Show($"Đã nạp thêm {addAmount:N0} VNĐ tiền mặt vào cây {targetAtmId} ({list[selectedAtmIndex].TenTram}) thành công!", "Nạp tiền ATM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                btnCancel.Click += (btnS, btnE) => dlg.Close();

                dlg.Controls.AddRange(new Control[] { lblAtm, cboAtm, lblAmount, cboAmount, btnConfirm, btnCancel });
                dlg.ShowDialog(this);
            }
        }

        public void RefreshData()
        {
            var list = AtmManager.GetAllTerminals();

            // Cập nhật thẻ KPI
            int total = list.Count;
            int online = list.Count(x => x.TrangThai == "Online");
            int offline = list.Count(x => x.TrangThai == "Mất kết nối" || x.TrangThai == "Offline");
            int maint = list.Count(x => x.TrangThai == "Bảo trì" || x.TrangThai == "Maintenance");

            lblTotalAtmVal.Text = $"{total} TRẠM";
            lblOnlineVal.Text = $"{online} ONLINE";
            lblOfflineVal.Text = $"{offline} OFFLINE";
            lblMaintenanceVal.Text = $"{maint} BẢO TRÌ";

            // Cập nhật Grid
            string? selectedAtmId = dgvAtmList.SelectedRows.Count > 0 ? dgvAtmList.SelectedRows[0].Cells["MaATM"].Value?.ToString() : null;

            dgvAtmList.Rows.Clear();
            foreach (var atm in list)
            {
                int rowIndex = dgvAtmList.Rows.Add(
                    atm.MaATM,
                    atm.TenTram,
                    atm.ViTri,
                    atm.DisplayStatus,
                    atm.IpAddress,
                    atm.LastSeenText,
                    atm.TongTienMat.ToString("N0") + " đ",
                    atm.TotalTransactions
                );

                var row = dgvAtmList.Rows[rowIndex];

                if (atm.MaATM == selectedAtmId)
                {
                    row.Selected = true;
                }
            }

            // Nếu người dùng chưa bấm chọn dòng nào, bỏ chọn mặc định để không bị bôi sáng dòng 1
            if (selectedAtmId == null)
            {
                dgvAtmList.ClearSelection();
            }
        }

        private void UpdateGridHeartbeats()
        {
            var list = AtmManager.GetAllTerminals();
            foreach (DataGridViewRow row in dgvAtmList.Rows)
            {
                string? maAtm = row.Cells["MaATM"].Value?.ToString();
                var atm = list.FirstOrDefault(x => x.MaATM == maAtm);
                if (atm != null)
                {
                    row.Cells["LastSeen"].Value = atm.LastSeenText;
                    row.Cells["IpAddress"].Value = atm.IpAddress;
                    row.Cells["TongTienMat"].Value = atm.TongTienMat.ToString("N0") + " đ";
                    row.Cells["TotalTrans"].Value = atm.TotalTransactions;
                }
            }
        }

        private void AppendLog(string message, string logType)
        {
            Color logColor = logType switch
            {
                "SUCCESS" => Color.FromArgb(52, 211, 153), // Xanh lá
                "WARN" => Color.FromArgb(251, 191, 36),     // Vàng hổ phách
                "ERROR" => Color.FromArgb(248, 113, 113),   // Đỏ
                _ => Color.FromArgb(203, 213, 225)          // Trắng bạc
            };

            rtbEventLog.SelectionStart = rtbEventLog.TextLength;
            rtbEventLog.SelectionLength = 0;
            rtbEventLog.SelectionColor = logColor;
            rtbEventLog.AppendText(message + Environment.NewLine);
            rtbEventLog.SelectionColor = rtbEventLog.ForeColor;
            rtbEventLog.ScrollToCaret();
        }
    }
}

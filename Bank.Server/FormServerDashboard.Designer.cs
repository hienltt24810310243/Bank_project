namespace Bank.Server
{
    partial class FormServerDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.tlpMaster = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblServerBadge = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();

            this.pnlStatsContainer = new System.Windows.Forms.Panel();
            this.tlpStats = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardTotal = new System.Windows.Forms.Panel();
            this.lblCardTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalAtmVal = new System.Windows.Forms.Label();
            this.pnlCardOnline = new System.Windows.Forms.Panel();
            this.lblCardOnlineTitle = new System.Windows.Forms.Label();
            this.lblOnlineVal = new System.Windows.Forms.Label();
            this.pnlCardOffline = new System.Windows.Forms.Panel();
            this.lblCardOfflineTitle = new System.Windows.Forms.Label();
            this.lblOfflineVal = new System.Windows.Forms.Label();
            this.pnlCardMaint = new System.Windows.Forms.Panel();
            this.lblCardMaintTitle = new System.Windows.Forms.Label();
            this.lblMaintenanceVal = new System.Windows.Forms.Label();

            this.pnlToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSetMaintenance = new System.Windows.Forms.Button();
            this.btnSetOnline = new System.Windows.Forms.Button();
            this.btnAddCash = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvAtmList = new System.Windows.Forms.DataGridView();
            this.colMaATM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTienMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlLogContainer = new System.Windows.Forms.Panel();
            this.lblLogHeader = new System.Windows.Forms.Label();
            this.rtbEventLog = new System.Windows.Forms.RichTextBox();

            this._refreshTimer = new System.Windows.Forms.Timer(this.components);

            this.tlpMaster.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlStatsContainer.SuspendLayout();
            this.tlpStats.SuspendLayout();
            this.pnlCardTotal.SuspendLayout();
            this.pnlCardOnline.SuspendLayout();
            this.pnlCardOffline.SuspendLayout();
            this.pnlCardMaint.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtmList)).BeginInit();
            this.pnlLogContainer.SuspendLayout();
            this.SuspendLayout();

            // 
            // tlpMaster
            // 
            this.tlpMaster.BackColor = System.Drawing.Color.FromArgb(11, 15, 25);
            this.tlpMaster.ColumnCount = 1;
            this.tlpMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMaster.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpMaster.Controls.Add(this.pnlStatsContainer, 0, 1);
            this.tlpMaster.Controls.Add(this.pnlToolbar, 0, 2);
            this.tlpMaster.Controls.Add(this.splitMain, 0, 3);
            this.tlpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMaster.Location = new System.Drawing.Point(0, 0);
            this.tlpMaster.Name = "tlpMaster";
            this.tlpMaster.RowCount = 4;
            this.tlpMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlpMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMaster.Size = new System.Drawing.Size(1220, 800);
            this.tlpMaster.TabIndex = 0;

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Controls.Add(this.lblServerBadge);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1220, 95);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(103, 232, 249);
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(650, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EPU BANK NOC • TRUNG TÂM GIÁM SÁT MẠNG LƯỚI ATM";

            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubTitle.Location = new System.Drawing.Point(20, 52);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(780, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Hội sở chính Ngân hàng Điện Lực (EPU) • Socket TCP Port 8888 • Đa luồng Multithreading & Row-Level Lock";

            // 
            // lblServerBadge
            // 
            this.lblServerBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerBadge.AutoSize = true;
            this.lblServerBadge.BackColor = System.Drawing.Color.FromArgb(6, 78, 59);
            this.lblServerBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblServerBadge.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            this.lblServerBadge.Location = new System.Drawing.Point(940, 16);
            this.lblServerBadge.Name = "lblServerBadge";
            this.lblServerBadge.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.lblServerBadge.Size = new System.Drawing.Size(260, 29);
            this.lblServerBadge.TabIndex = 2;
            this.lblServerBadge.Text = "🟢 SERVER: LISTENING (PORT 8888)";

            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblClock.Location = new System.Drawing.Point(940, 52);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(160, 18);
            this.lblClock.TabIndex = 3;
            this.lblClock.Text = "dd/MM/yyyy HH:mm:ss";

            // 
            // pnlStatsContainer
            // 
            this.pnlStatsContainer.BackColor = System.Drawing.Color.FromArgb(11, 15, 25);
            this.pnlStatsContainer.Controls.Add(this.tlpStats);
            this.pnlStatsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatsContainer.Location = new System.Drawing.Point(0, 95);
            this.pnlStatsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatsContainer.Name = "pnlStatsContainer";
            this.pnlStatsContainer.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlStatsContainer.Size = new System.Drawing.Size(1220, 120);
            this.pnlStatsContainer.TabIndex = 1;

            // 
            // tlpStats
            // 
            this.tlpStats.ColumnCount = 4;
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.Controls.Add(this.pnlCardTotal, 0, 0);
            this.tlpStats.Controls.Add(this.pnlCardOnline, 1, 0);
            this.tlpStats.Controls.Add(this.pnlCardOffline, 2, 0);
            this.tlpStats.Controls.Add(this.pnlCardMaint, 3, 0);
            this.tlpStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStats.Location = new System.Drawing.Point(16, 8);
            this.tlpStats.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStats.Name = "tlpStats";
            this.tlpStats.RowCount = 1;
            this.tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStats.Size = new System.Drawing.Size(1188, 104);
            this.tlpStats.TabIndex = 0;

            // 
            // pnlCardTotal
            // 
            this.pnlCardTotal.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlCardTotal.Controls.Add(this.lblTotalAtmVal);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalTitle);
            this.pnlCardTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardTotal.Location = new System.Drawing.Point(8, 6);
            this.pnlCardTotal.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlCardTotal.Name = "pnlCardTotal";
            this.pnlCardTotal.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardTotal.Size = new System.Drawing.Size(281, 92);
            this.pnlCardTotal.TabIndex = 0;

            // 
            // lblCardTotalTitle
            // 
            this.lblCardTotalTitle.AutoSize = true;
            this.lblCardTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTotalTitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblCardTotalTitle.Location = new System.Drawing.Point(14, 14);
            this.lblCardTotalTitle.Name = "lblCardTotalTitle";
            this.lblCardTotalTitle.Size = new System.Drawing.Size(130, 17);
            this.lblCardTotalTitle.TabIndex = 0;
            this.lblCardTotalTitle.Text = "TỔNG SỐ TRẠM ATM";

            // 
            // lblTotalAtmVal
            // 
            this.lblTotalAtmVal.AutoSize = true;
            this.lblTotalAtmVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalAtmVal.ForeColor = System.Drawing.Color.FromArgb(56, 189, 248);
            this.lblTotalAtmVal.Location = new System.Drawing.Point(14, 46);
            this.lblTotalAtmVal.Name = "lblTotalAtmVal";
            this.lblTotalAtmVal.Size = new System.Drawing.Size(110, 37);
            this.lblTotalAtmVal.TabIndex = 1;
            this.lblTotalAtmVal.Text = "3 TRẠM";

            // 
            // pnlCardOnline
            // 
            this.pnlCardOnline.BackColor = System.Drawing.Color.FromArgb(6, 78, 59);
            this.pnlCardOnline.Controls.Add(this.lblOnlineVal);
            this.pnlCardOnline.Controls.Add(this.lblCardOnlineTitle);
            this.pnlCardOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardOnline.Location = new System.Drawing.Point(305, 6);
            this.pnlCardOnline.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlCardOnline.Name = "pnlCardOnline";
            this.pnlCardOnline.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardOnline.Size = new System.Drawing.Size(281, 92);
            this.pnlCardOnline.TabIndex = 1;

            // 
            // lblCardOnlineTitle
            // 
            this.lblCardOnlineTitle.AutoSize = true;
            this.lblCardOnlineTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardOnlineTitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblCardOnlineTitle.Location = new System.Drawing.Point(14, 14);
            this.lblCardOnlineTitle.Name = "lblCardOnlineTitle";
            this.lblCardOnlineTitle.Size = new System.Drawing.Size(185, 17);
            this.lblCardOnlineTitle.TabIndex = 0;
            this.lblCardOnlineTitle.Text = "ĐANG HOẠT ĐỘNG (ONLINE)";

            // 
            // lblOnlineVal
            // 
            this.lblOnlineVal.AutoSize = true;
            this.lblOnlineVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblOnlineVal.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            this.lblOnlineVal.Location = new System.Drawing.Point(14, 46);
            this.lblOnlineVal.Name = "lblOnlineVal";
            this.lblOnlineVal.Size = new System.Drawing.Size(130, 37);
            this.lblOnlineVal.TabIndex = 1;
            this.lblOnlineVal.Text = "0 ONLINE";

            // 
            // pnlCardOffline
            // 
            this.pnlCardOffline.BackColor = System.Drawing.Color.FromArgb(127, 29, 29);
            this.pnlCardOffline.Controls.Add(this.lblOfflineVal);
            this.pnlCardOffline.Controls.Add(this.lblCardOfflineTitle);
            this.pnlCardOffline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardOffline.Location = new System.Drawing.Point(602, 6);
            this.pnlCardOffline.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlCardOffline.Name = "pnlCardOffline";
            this.pnlCardOffline.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardOffline.Size = new System.Drawing.Size(281, 92);
            this.pnlCardOffline.TabIndex = 2;

            // 
            // lblCardOfflineTitle
            // 
            this.lblCardOfflineTitle.AutoSize = true;
            this.lblCardOfflineTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardOfflineTitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblCardOfflineTitle.Location = new System.Drawing.Point(14, 14);
            this.lblCardOfflineTitle.Name = "lblCardOfflineTitle";
            this.lblCardOfflineTitle.Size = new System.Drawing.Size(155, 17);
            this.lblCardOfflineTitle.TabIndex = 0;
            this.lblCardOfflineTitle.Text = "MẤT KẾT NỐI (OFFLINE)";

            // 
            // lblOfflineVal
            // 
            this.lblOfflineVal.AutoSize = true;
            this.lblOfflineVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblOfflineVal.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblOfflineVal.Location = new System.Drawing.Point(14, 46);
            this.lblOfflineVal.Name = "lblOfflineVal";
            this.lblOfflineVal.Size = new System.Drawing.Size(135, 37);
            this.lblOfflineVal.TabIndex = 1;
            this.lblOfflineVal.Text = "0 OFFLINE";

            // 
            // pnlCardMaint
            // 
            this.pnlCardMaint.BackColor = System.Drawing.Color.FromArgb(120, 53, 15);
            this.pnlCardMaint.Controls.Add(this.lblMaintenanceVal);
            this.pnlCardMaint.Controls.Add(this.lblCardMaintTitle);
            this.pnlCardMaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardMaint.Location = new System.Drawing.Point(899, 6);
            this.pnlCardMaint.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlCardMaint.Name = "pnlCardMaint";
            this.pnlCardMaint.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlCardMaint.Size = new System.Drawing.Size(281, 92);
            this.pnlCardMaint.TabIndex = 3;

            // 
            // lblCardMaintTitle
            // 
            this.lblCardMaintTitle.AutoSize = true;
            this.lblCardMaintTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardMaintTitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblCardMaintTitle.Location = new System.Drawing.Point(14, 14);
            this.lblCardMaintTitle.Name = "lblCardMaintTitle";
            this.lblCardMaintTitle.Size = new System.Drawing.Size(100, 17);
            this.lblCardMaintTitle.TabIndex = 0;
            this.lblCardMaintTitle.Text = "ĐANG BẢO TRÌ";

            // 
            // lblMaintenanceVal
            // 
            this.lblMaintenanceVal.AutoSize = true;
            this.lblMaintenanceVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblMaintenanceVal.ForeColor = System.Drawing.Color.FromArgb(251, 191, 36);
            this.lblMaintenanceVal.Location = new System.Drawing.Point(14, 46);
            this.lblMaintenanceVal.Name = "lblMaintenanceVal";
            this.lblMaintenanceVal.Size = new System.Drawing.Size(130, 37);
            this.lblMaintenanceVal.TabIndex = 1;
            this.lblMaintenanceVal.Text = "0 BẢO TRÌ";

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.pnlToolbar.Controls.Add(this.btnSetMaintenance);
            this.pnlToolbar.Controls.Add(this.btnSetOnline);
            this.pnlToolbar.Controls.Add(this.btnAddCash);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 215);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlToolbar.Size = new System.Drawing.Size(1220, 56);
            this.pnlToolbar.TabIndex = 2;

            // 
            // btnSetMaintenance
            // 
            this.btnSetMaintenance.AutoSize = true;
            this.btnSetMaintenance.BackColor = System.Drawing.Color.FromArgb(180, 83, 9);
            this.btnSetMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetMaintenance.FlatAppearance.BorderSize = 0;
            this.btnSetMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMaintenance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSetMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnSetMaintenance.Location = new System.Drawing.Point(20, 10);
            this.btnSetMaintenance.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.btnSetMaintenance.Name = "btnSetMaintenance";
            this.btnSetMaintenance.Padding = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.btnSetMaintenance.Size = new System.Drawing.Size(185, 36);
            this.btnSetMaintenance.TabIndex = 0;
            this.btnSetMaintenance.Text = "🛠️ Đặt Chế độ Bảo trì";
            this.btnSetMaintenance.UseVisualStyleBackColor = false;

            // 
            // btnSetOnline
            // 
            this.btnSetOnline.AutoSize = true;
            this.btnSetOnline.BackColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnSetOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetOnline.FlatAppearance.BorderSize = 0;
            this.btnSetOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOnline.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSetOnline.ForeColor = System.Drawing.Color.White;
            this.btnSetOnline.Location = new System.Drawing.Point(219, 10);
            this.btnSetOnline.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.btnSetOnline.Name = "btnSetOnline";
            this.btnSetOnline.Padding = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.btnSetOnline.Size = new System.Drawing.Size(185, 36);
            this.btnSetOnline.TabIndex = 1;
            this.btnSetOnline.Text = "🟢 Kích hoạt Hoạt động";
            this.btnSetOnline.UseVisualStyleBackColor = false;

            // 
            // btnAddCash
            // 
            this.btnAddCash.AutoSize = true;
            this.btnAddCash.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnAddCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCash.FlatAppearance.BorderSize = 0;
            this.btnAddCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCash.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddCash.ForeColor = System.Drawing.Color.White;
            this.btnAddCash.Location = new System.Drawing.Point(418, 10);
            this.btnAddCash.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.btnAddCash.Name = "btnAddCash";
            this.btnAddCash.Padding = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.btnAddCash.Size = new System.Drawing.Size(230, 36);
            this.btnAddCash.TabIndex = 2;
            this.btnAddCash.Text = "💵 Nạp quỹ tiền mặt (+50 Triệu)";
            this.btnAddCash.UseVisualStyleBackColor = false;

            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(662, 10);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.btnRefresh.Size = new System.Drawing.Size(185, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới danh sách";
            this.btnRefresh.UseVisualStyleBackColor = false;

            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 271);
            this.splitMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvAtmList);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlLogContainer);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.splitMain.Size = new System.Drawing.Size(1220, 529);
            this.splitMain.SplitterDistance = 290;
            this.splitMain.TabIndex = 3;

            // 
            // dgvAtmList
            // 
            this.dgvAtmList.AllowUserToAddRows = false;
            this.dgvAtmList.AllowUserToDeleteRows = false;
            this.dgvAtmList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAtmList.BackgroundColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.dgvAtmList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(103, 232, 249);
            dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAtmList.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvAtmList.ColumnHeadersHeight = 42;
            this.dgvAtmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAtmList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaATM,
            this.colTenTram,
            this.colViTri,
            this.colTrangThai,
            this.colIpAddress,
            this.colLastSeen,
            this.colTongTienMat,
            this.colTotalTrans});
            dgvCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            dgvCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvCellStyle.ForeColor = System.Drawing.Color.White;
            dgvCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            dgvCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAtmList.DefaultCellStyle = dgvCellStyle;
            this.dgvAtmList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAtmList.EnableHeadersVisualStyles = false;
            this.dgvAtmList.Location = new System.Drawing.Point(16, 8);
            this.dgvAtmList.MultiSelect = false;
            this.dgvAtmList.Name = "dgvAtmList";
            this.dgvAtmList.ReadOnly = true;
            this.dgvAtmList.RowHeadersVisible = false;
            this.dgvAtmList.RowTemplate.Height = 40;
            this.dgvAtmList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtmList.Size = new System.Drawing.Size(1188, 274);
            this.dgvAtmList.TabIndex = 0;

            // 
            // colMaATM
            // 
            this.colMaATM.FillWeight = 10F;
            this.colMaATM.HeaderText = "Mã ATM";
            this.colMaATM.Name = "MaATM";
            this.colMaATM.ReadOnly = true;

            // 
            // colTenTram
            // 
            this.colTenTram.FillWeight = 22F;
            this.colTenTram.HeaderText = "Tên Trạm ATM";
            this.colTenTram.Name = "TenTram";
            this.colTenTram.ReadOnly = true;

            // 
            // colViTri
            // 
            this.colViTri.FillWeight = 26F;
            this.colViTri.HeaderText = "Vị Trí Đặt Máy";
            this.colViTri.Name = "ViTri";
            this.colViTri.ReadOnly = true;

            // 
            // colTrangThai
            // 
            this.colTrangThai.FillWeight = 16F;
            this.colTrangThai.HeaderText = "Trạng Thái Kết Nối";
            this.colTrangThai.Name = "TrangThai";
            this.colTrangThai.ReadOnly = true;

            // 
            // colIpAddress
            // 
            this.colIpAddress.FillWeight = 14F;
            this.colIpAddress.HeaderText = "Địa Chỉ IP";
            this.colIpAddress.Name = "IpAddress";
            this.colIpAddress.ReadOnly = true;

            // 
            // colLastSeen
            // 
            this.colLastSeen.FillWeight = 14F;
            this.colLastSeen.HeaderText = "Nhịp Tim (Heartbeat)";
            this.colLastSeen.Name = "LastSeen";
            this.colLastSeen.ReadOnly = true;

            // 
            // colTongTienMat
            // 
            this.colTongTienMat.FillWeight = 17F;
            this.colTongTienMat.HeaderText = "Quỹ Tiền Mặt";
            this.colTongTienMat.Name = "TongTienMat";
            this.colTongTienMat.ReadOnly = true;

            // 
            // colTotalTrans
            // 
            this.colTotalTrans.FillWeight = 10F;
            this.colTotalTrans.HeaderText = "Số Lệnh GD";
            this.colTotalTrans.Name = "TotalTrans";
            this.colTotalTrans.ReadOnly = true;

            // 
            // pnlLogContainer
            // 
            this.pnlLogContainer.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.pnlLogContainer.Controls.Add(this.rtbEventLog);
            this.pnlLogContainer.Controls.Add(this.lblLogHeader);
            this.pnlLogContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogContainer.Location = new System.Drawing.Point(16, 8);
            this.pnlLogContainer.Name = "pnlLogContainer";
            this.pnlLogContainer.Padding = new System.Windows.Forms.Padding(12);
            this.pnlLogContainer.Size = new System.Drawing.Size(1188, 219);
            this.pnlLogContainer.TabIndex = 0;

            // 
            // lblLogHeader
            // 
            this.lblLogHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLogHeader.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLogHeader.Location = new System.Drawing.Point(12, 12);
            this.lblLogHeader.Name = "lblLogHeader";
            this.lblLogHeader.Size = new System.Drawing.Size(1164, 28);
            this.lblLogHeader.TabIndex = 0;
            this.lblLogHeader.Text = "📋 NHẬT KÝ SỰ KIỆN MẠNG LƯỚI THỜI GIAN THỰC (LIVE NETWORK EVENT LOG)";

            // 
            // rtbEventLog
            // 
            this.rtbEventLog.BackColor = System.Drawing.Color.FromArgb(11, 15, 25);
            this.rtbEventLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEventLog.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbEventLog.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rtbEventLog.Location = new System.Drawing.Point(12, 40);
            this.rtbEventLog.Name = "rtbEventLog";
            this.rtbEventLog.ReadOnly = true;
            this.rtbEventLog.Size = new System.Drawing.Size(1164, 167);
            this.rtbEventLog.TabIndex = 1;
            this.rtbEventLog.Text = "";

            // 
            // FormServerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(11, 15, 25);
            this.ClientSize = new System.Drawing.Size(1220, 800);
            this.Controls.Add(this.tlpMaster);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormServerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPU BANK - HỆ THỐNG GIÁM SÁT MẠNG LƯỚI ATM TRUNG TÂM (CENTRAL MONITORING NOC)";

            this.tlpMaster.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStatsContainer.ResumeLayout(false);
            this.tlpStats.ResumeLayout(false);
            this.pnlCardTotal.ResumeLayout(false);
            this.pnlCardTotal.PerformLayout();
            this.pnlCardOnline.ResumeLayout(false);
            this.pnlCardOnline.PerformLayout();
            this.pnlCardOffline.ResumeLayout(false);
            this.pnlCardOffline.PerformLayout();
            this.pnlCardMaint.ResumeLayout(false);
            this.pnlCardMaint.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtmList)).EndInit();
            this.pnlLogContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMaster;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblServerBadge;
        private System.Windows.Forms.Label lblClock;

        private System.Windows.Forms.Panel pnlStatsContainer;
        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblCardTotalTitle;
        public System.Windows.Forms.Label lblTotalAtmVal;
        private System.Windows.Forms.Panel pnlCardOnline;
        private System.Windows.Forms.Label lblCardOnlineTitle;
        public System.Windows.Forms.Label lblOnlineVal;
        private System.Windows.Forms.Panel pnlCardOffline;
        private System.Windows.Forms.Label lblCardOfflineTitle;
        public System.Windows.Forms.Label lblOfflineVal;
        private System.Windows.Forms.Panel pnlCardMaint;
        private System.Windows.Forms.Label lblCardMaintTitle;
        public System.Windows.Forms.Label lblMaintenanceVal;

        private System.Windows.Forms.FlowLayoutPanel pnlToolbar;
        public System.Windows.Forms.Button btnSetMaintenance;
        public System.Windows.Forms.Button btnSetOnline;
        public System.Windows.Forms.Button btnAddCash;
        public System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.SplitContainer splitMain;
        public System.Windows.Forms.DataGridView dgvAtmList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaATM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTienMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalTrans;

        private System.Windows.Forms.Panel pnlLogContainer;
        private System.Windows.Forms.Label lblLogHeader;
        public System.Windows.Forms.RichTextBox rtbEventLog;

        private System.Windows.Forms.Timer _refreshTimer;
    }
}

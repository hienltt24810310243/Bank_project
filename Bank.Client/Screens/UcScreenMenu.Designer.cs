namespace Bank.Client.Screens
{
    partial class UcScreenMenu
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlUserBanner = new System.Windows.Forms.Panel();
            this.lblUserBalance = new System.Windows.Forms.Label();
            this.lblBalanceLabel = new System.Windows.Forms.Label();
            this.lblUserAccount = new System.Windows.Forms.Label();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.tblMenuGrid = new System.Windows.Forms.TableLayoutPanel();
            this.btnMenuWithdraw = new System.Windows.Forms.Button();
            this.btnMenuTransfer = new System.Windows.Forms.Button();
            this.btnMenuChangePin = new System.Windows.Forms.Button();
            this.btnMenuHistory = new System.Windows.Forms.Button();
            this.pnlMenuFooter = new System.Windows.Forms.Panel();
            this.btnMenuLogout = new System.Windows.Forms.Button();
            this.lblStationInfo = new System.Windows.Forms.Label();
            this.pnlUserBanner.SuspendLayout();
            this.tblMenuGrid.SuspendLayout();
            this.pnlMenuFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserBanner
            // 
            this.pnlUserBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(51)))), ((int)(((byte)(68)))));
            this.pnlUserBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserBanner.Controls.Add(this.lblUserBalance);
            this.pnlUserBanner.Controls.Add(this.lblBalanceLabel);
            this.pnlUserBanner.Controls.Add(this.lblUserAccount);
            this.pnlUserBanner.Controls.Add(this.lblWelcomeUser);
            this.pnlUserBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlUserBanner.Name = "pnlUserBanner";
            this.pnlUserBanner.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlUserBanner.Size = new System.Drawing.Size(622, 85);
            this.pnlUserBanner.TabIndex = 0;
            // 
            // lblUserBalance
            // 
            this.lblUserBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserBalance.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUserBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblUserBalance.Location = new System.Drawing.Point(320, 35);
            this.lblUserBalance.Name = "lblUserBalance";
            this.lblUserBalance.Size = new System.Drawing.Size(285, 35);
            this.lblUserBalance.TabIndex = 3;
            this.lblUserBalance.Text = "8.500.000 VNĐ";
            this.lblUserBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBalanceLabel
            // 
            this.lblBalanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalanceLabel.AutoSize = true;
            this.lblBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblBalanceLabel.Location = new System.Drawing.Point(475, 12);
            this.lblBalanceLabel.Name = "lblBalanceLabel";
            this.lblBalanceLabel.Size = new System.Drawing.Size(128, 17);
            this.lblBalanceLabel.TabIndex = 2;
            this.lblBalanceLabel.Text = "SỐ DƯ KHẢ DỤNG:";
            this.lblBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.AutoSize = true;
            this.lblUserAccount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUserAccount.ForeColor = System.Drawing.Color.White;
            this.lblUserAccount.Location = new System.Drawing.Point(16, 38);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.Size = new System.Drawing.Size(280, 25);
            this.lblUserAccount.TabIndex = 1;
            this.lblUserAccount.Text = "NGUYỄN VĂN AN (STK: 1001)";
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcomeUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblWelcomeUser.Location = new System.Drawing.Point(16, 12);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(134, 17);
            this.lblWelcomeUser.TabIndex = 0;
            this.lblWelcomeUser.Text = "XIN CHÀO CHỦ THẺ:";
            // 
            // tblMenuGrid
            // 
            this.tblMenuGrid.ColumnCount = 2;
            this.tblMenuGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMenuGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMenuGrid.Controls.Add(this.btnMenuWithdraw, 0, 0);
            this.tblMenuGrid.Controls.Add(this.btnMenuTransfer, 1, 0);
            this.tblMenuGrid.Controls.Add(this.btnMenuChangePin, 0, 1);
            this.tblMenuGrid.Controls.Add(this.btnMenuHistory, 1, 1);
            this.tblMenuGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMenuGrid.Location = new System.Drawing.Point(0, 85);
            this.tblMenuGrid.Name = "tblMenuGrid";
            this.tblMenuGrid.Padding = new System.Windows.Forms.Padding(16, 20, 16, 20);
            this.tblMenuGrid.RowCount = 2;
            this.tblMenuGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMenuGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMenuGrid.Size = new System.Drawing.Size(622, 397);
            this.tblMenuGrid.TabIndex = 1;
            // 
            // btnMenuWithdraw
            // 
            this.btnMenuWithdraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnMenuWithdraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuWithdraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuWithdraw.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.btnMenuWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuWithdraw.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuWithdraw.ForeColor = System.Drawing.Color.White;
            this.btnMenuWithdraw.Location = new System.Drawing.Point(26, 30);
            this.btnMenuWithdraw.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenuWithdraw.Name = "btnMenuWithdraw";
            this.btnMenuWithdraw.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.btnMenuWithdraw.Size = new System.Drawing.Size(275, 158);
            this.btnMenuWithdraw.TabIndex = 0;
            this.btnMenuWithdraw.Text = "1. RÚT TIỀN MẶT\r\nNhanh chóng & bảo mật";
            this.btnMenuWithdraw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuWithdraw.UseMnemonic = false;
            this.btnMenuWithdraw.UseVisualStyleBackColor = false;
            // 
            // btnMenuTransfer
            // 
            this.btnMenuTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnMenuTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuTransfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.btnMenuTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTransfer.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuTransfer.ForeColor = System.Drawing.Color.White;
            this.btnMenuTransfer.Location = new System.Drawing.Point(321, 30);
            this.btnMenuTransfer.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenuTransfer.Name = "btnMenuTransfer";
            this.btnMenuTransfer.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.btnMenuTransfer.Size = new System.Drawing.Size(275, 158);
            this.btnMenuTransfer.TabIndex = 1;
            this.btnMenuTransfer.Text = "2. CHUYỂN KHOẢN\r\nChuyển tiền 24/7 tức thì";
            this.btnMenuTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTransfer.UseMnemonic = false;
            this.btnMenuTransfer.UseVisualStyleBackColor = false;
            // 
            // btnMenuChangePin
            // 
            this.btnMenuChangePin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnMenuChangePin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuChangePin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuChangePin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.btnMenuChangePin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuChangePin.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuChangePin.ForeColor = System.Drawing.Color.White;
            this.btnMenuChangePin.Location = new System.Drawing.Point(26, 208);
            this.btnMenuChangePin.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenuChangePin.Name = "btnMenuChangePin";
            this.btnMenuChangePin.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.btnMenuChangePin.Size = new System.Drawing.Size(275, 159);
            this.btnMenuChangePin.TabIndex = 2;
            this.btnMenuChangePin.Text = "3. ĐỔI MÃ PIN\r\nTăng cường bảo mật";
            this.btnMenuChangePin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuChangePin.UseMnemonic = false;
            this.btnMenuChangePin.UseVisualStyleBackColor = false;
            // 
            // btnMenuHistory
            // 
            this.btnMenuHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnMenuHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.btnMenuHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHistory.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuHistory.ForeColor = System.Drawing.Color.White;
            this.btnMenuHistory.Location = new System.Drawing.Point(321, 208);
            this.btnMenuHistory.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenuHistory.Name = "btnMenuHistory";
            this.btnMenuHistory.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.btnMenuHistory.Size = new System.Drawing.Size(275, 159);
            this.btnMenuHistory.TabIndex = 3;
            this.btnMenuHistory.Text = "4. LỊCH SỬ & SAO KÊ\r\nXem 5 GD gần nhất";
            this.btnMenuHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuHistory.UseMnemonic = false;
            this.btnMenuHistory.UseVisualStyleBackColor = false;
            // 
            // pnlMenuFooter
            // 
            this.pnlMenuFooter.Controls.Add(this.btnMenuLogout);
            this.pnlMenuFooter.Controls.Add(this.lblStationInfo);
            this.pnlMenuFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenuFooter.Location = new System.Drawing.Point(0, 482);
            this.pnlMenuFooter.Name = "pnlMenuFooter";
            this.pnlMenuFooter.Size = new System.Drawing.Size(622, 50);
            this.pnlMenuFooter.TabIndex = 2;
            // 
            // btnMenuLogout
            // 
            this.btnMenuLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnMenuLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuLogout.FlatAppearance.BorderSize = 0;
            this.btnMenuLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLogout.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuLogout.ForeColor = System.Drawing.Color.White;
            this.btnMenuLogout.Location = new System.Drawing.Point(380, 5);
            this.btnMenuLogout.Name = "btnMenuLogout";
            this.btnMenuLogout.Size = new System.Drawing.Size(235, 40);
            this.btnMenuLogout.TabIndex = 1;
            this.btnMenuLogout.Text = "[5] ĐĂNG XUẤT / TRẢ THẺ";
            this.btnMenuLogout.UseMnemonic = false;
            this.btnMenuLogout.UseVisualStyleBackColor = false;
            // 
            // lblStationInfo
            // 
            this.lblStationInfo.AutoSize = true;
            this.lblStationInfo.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStationInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.lblStationInfo.Location = new System.Drawing.Point(10, 16);
            this.lblStationInfo.Name = "lblStationInfo";
            this.lblStationInfo.Size = new System.Drawing.Size(184, 17);
            this.lblStationInfo.TabIndex = 0;
            this.lblStationInfo.Text = "TRẠM ATM: 01 (CẦU GIẤY)";
            // 
            // UcScreenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.tblMenuGrid);
            this.Controls.Add(this.pnlMenuFooter);
            this.Controls.Add(this.pnlUserBanner);
            this.Name = "UcScreenMenu";
            this.Size = new System.Drawing.Size(622, 532);
            this.pnlUserBanner.ResumeLayout(false);
            this.pnlUserBanner.PerformLayout();
            this.tblMenuGrid.ResumeLayout(false);
            this.pnlMenuFooter.ResumeLayout(false);
            this.pnlMenuFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserBanner;
        private System.Windows.Forms.Label lblWelcomeUser;
        public System.Windows.Forms.Label lblUserAccount;
        private System.Windows.Forms.Label lblBalanceLabel;
        public System.Windows.Forms.Label lblUserBalance;
        private System.Windows.Forms.TableLayoutPanel tblMenuGrid;
        private System.Windows.Forms.Button btnMenuWithdraw;
        private System.Windows.Forms.Button btnMenuTransfer;
        private System.Windows.Forms.Button btnMenuChangePin;
        private System.Windows.Forms.Button btnMenuHistory;
        private System.Windows.Forms.Panel pnlMenuFooter;
        private System.Windows.Forms.Label lblStationInfo;
        private System.Windows.Forms.Button btnMenuLogout;
    }
}

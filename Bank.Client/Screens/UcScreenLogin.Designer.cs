namespace Bank.Client.Screens
{
    partial class UcScreenLogin
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
            this.pnlLoginCard = new System.Windows.Forms.Panel();
            this.btnCancelLogin = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pnlPinWrapper = new System.Windows.Forms.Panel();
            this.btnToggleLoginPin = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblScreen1Subtitle = new System.Windows.Forms.Label();
            this.lblScreen1Title = new System.Windows.Forms.Label();
            this.pnlScreen1Footer = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblHotline = new System.Windows.Forms.Label();
            this.pnlLoginCard.SuspendLayout();
            this.pnlPinWrapper.SuspendLayout();
            this.pnlScreen1Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLoginCard
            // 
            this.pnlLoginCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoginCard.Controls.Add(this.btnCancelLogin);
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Controls.Add(this.lblWarning);
            this.pnlLoginCard.Controls.Add(this.pnlPinWrapper);
            this.pnlLoginCard.Controls.Add(this.lblPin);
            this.pnlLoginCard.Controls.Add(this.txtCardNumber);
            this.pnlLoginCard.Controls.Add(this.lblCardNumber);
            this.pnlLoginCard.Controls.Add(this.lblScreen1Subtitle);
            this.pnlLoginCard.Controls.Add(this.lblScreen1Title);
            this.pnlLoginCard.Location = new System.Drawing.Point(36, 40);
            this.pnlLoginCard.Name = "pnlLoginCard";
            this.pnlLoginCard.Size = new System.Drawing.Size(550, 420);
            this.pnlLoginCard.TabIndex = 0;
            // 
            // btnCancelLogin
            // 
            this.btnCancelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnCancelLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelLogin.FlatAppearance.BorderSize = 0;
            this.btnCancelLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelLogin.ForeColor = System.Drawing.Color.White;
            this.btnCancelLogin.Location = new System.Drawing.Point(285, 330);
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.Size = new System.Drawing.Size(210, 48);
            this.btnCancelLogin.TabIndex = 8;
            this.btnCancelLogin.Text = "HỦY BỎ";
            this.btnCancelLogin.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(55, 330);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(210, 48);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.lblWarning.Location = new System.Drawing.Point(55, 280);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(440, 25);
            this.lblWarning.TabIndex = 6;
            this.lblWarning.Text = "▲ Nhập sai 3 lần thẻ sẽ tự động bị khóa";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPinWrapper
            // 
            this.pnlPinWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlPinWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPinWrapper.Controls.Add(this.btnToggleLoginPin);
            this.pnlPinWrapper.Controls.Add(this.txtPin);
            this.pnlPinWrapper.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlPinWrapper.Location = new System.Drawing.Point(55, 230);
            this.pnlPinWrapper.Name = "pnlPinWrapper";
            this.pnlPinWrapper.Size = new System.Drawing.Size(440, 38);
            this.pnlPinWrapper.TabIndex = 5;
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPin.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.txtPin.Location = new System.Drawing.Point(10, 7);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '●';
            this.txtPin.Size = new System.Drawing.Size(385, 24);
            this.txtPin.TabIndex = 0;
            this.txtPin.Text = "123456";
            this.txtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnToggleLoginPin
            // 
            this.btnToggleLoginPin.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleLoginPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleLoginPin.FlatAppearance.BorderSize = 0;
            this.btnToggleLoginPin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnToggleLoginPin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnToggleLoginPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLoginPin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnToggleLoginPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnToggleLoginPin.Location = new System.Drawing.Point(398, 3);
            this.btnToggleLoginPin.Name = "btnToggleLoginPin";
            this.btnToggleLoginPin.Size = new System.Drawing.Size(36, 30);
            this.btnToggleLoginPin.TabIndex = 1;
            this.btnToggleLoginPin.TabStop = false;
            this.btnToggleLoginPin.Text = "👁";
            this.btnToggleLoginPin.UseVisualStyleBackColor = false;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblPin.Location = new System.Drawing.Point(55, 200);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(163, 19);
            this.lblPin.TabIndex = 4;
            this.lblPin.Text = "MÃ PIN BẢO MẬT (6 SỐ):";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNumber.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.txtCardNumber.Location = new System.Drawing.Point(55, 140);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(440, 29);
            this.txtCardNumber.TabIndex = 3;
            this.txtCardNumber.Text = "9704000000001001";
            this.txtCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblCardNumber.Location = new System.Drawing.Point(55, 110);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(176, 19);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "SỐ TÀI KHOẢN / MÃ THẺ:";
            // 
            // lblScreen1Subtitle
            // 
            this.lblScreen1Subtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScreen1Subtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScreen1Subtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblScreen1Subtitle.Location = new System.Drawing.Point(0, 40);
            this.lblScreen1Subtitle.Name = "lblScreen1Subtitle";
            this.lblScreen1Subtitle.Size = new System.Drawing.Size(550, 25);
            this.lblScreen1Subtitle.TabIndex = 1;
            this.lblScreen1Subtitle.Text = "VUI LÒNG ĐĂNG NHẬP ĐỂ GIAO DỊCH";
            this.lblScreen1Subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScreen1Title
            // 
            this.lblScreen1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScreen1Title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScreen1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblScreen1Title.Location = new System.Drawing.Point(0, 0);
            this.lblScreen1Title.Name = "lblScreen1Title";
            this.lblScreen1Title.Size = new System.Drawing.Size(550, 40);
            this.lblScreen1Title.TabIndex = 0;
            this.lblScreen1Title.Text = "NGÂN HÀNG ĐIỆN LỰC - EPU BANK";
            this.lblScreen1Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlScreen1Footer
            // 
            this.pnlScreen1Footer.Controls.Add(this.lblVersion);
            this.pnlScreen1Footer.Controls.Add(this.lblHotline);
            this.pnlScreen1Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlScreen1Footer.Location = new System.Drawing.Point(0, 497);
            this.pnlScreen1Footer.Name = "pnlScreen1Footer";
            this.pnlScreen1Footer.Size = new System.Drawing.Size(622, 35);
            this.pnlScreen1Footer.TabIndex = 1;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblVersion.Location = new System.Drawing.Point(440, 10);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(164, 15);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Phiên bản: v2.4 (Socket TCP)";
            // 
            // lblHotline
            // 
            this.lblHotline.AutoSize = true;
            this.lblHotline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHotline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblHotline.Location = new System.Drawing.Point(5, 10);
            this.lblHotline.Name = "lblHotline";
            this.lblHotline.Size = new System.Drawing.Size(162, 15);
            this.lblHotline.TabIndex = 0;
            this.lblHotline.Text = "Hotline khẩn cấp: 1900 123 456";
            // 
            // UcScreenLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.pnlScreen1Footer);
            this.Name = "UcScreenLogin";
            this.Size = new System.Drawing.Size(622, 532);
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.pnlPinWrapper.ResumeLayout(false);
            this.pnlPinWrapper.PerformLayout();
            this.pnlScreen1Footer.ResumeLayout(false);
            this.pnlScreen1Footer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginCard;
        private System.Windows.Forms.Label lblScreen1Title;
        private System.Windows.Forms.Label lblScreen1Subtitle;
        private System.Windows.Forms.Label lblCardNumber;
        public System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label lblPin;
        public System.Windows.Forms.Panel pnlPinWrapper;
        public System.Windows.Forms.TextBox txtPin;
        public System.Windows.Forms.Button btnToggleLoginPin;
        public System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancelLogin;
        private System.Windows.Forms.Panel pnlScreen1Footer;
        private System.Windows.Forms.Label lblHotline;
        private System.Windows.Forms.Label lblVersion;
    }
}

namespace Bank.Client.Screens
{
    partial class UcScreenTransfer
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
            this.lblTransferTitle = new System.Windows.Forms.Label();
            this.pnlTransferCard = new System.Windows.Forms.Panel();
            this.btnTransferConfirm = new System.Windows.Forms.Button();
            this.btnTransferBack = new System.Windows.Forms.Button();
            this.txtTransferDesc = new System.Windows.Forms.TextBox();
            this.lblTransferDesc = new System.Windows.Forms.Label();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.lblTransferAmount = new System.Windows.Forms.Label();
            this.pnlReceiverBadge = new System.Windows.Forms.Panel();
            this.lblReceiverBadge = new System.Windows.Forms.Label();
            this.btnCheckReceiver = new System.Windows.Forms.Button();
            this.txtDestAccount = new System.Windows.Forms.TextBox();
            this.lblDestAccount = new System.Windows.Forms.Label();
            this.pnlTransferCard.SuspendLayout();
            this.pnlReceiverBadge.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransferTitle
            // 
            this.lblTransferTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTransferTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTransferTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblTransferTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTransferTitle.Name = "lblTransferTitle";
            this.lblTransferTitle.Size = new System.Drawing.Size(622, 45);
            this.lblTransferTitle.TabIndex = 0;
            this.lblTransferTitle.Text = "CHUYỂN KHOẢN LIÊN TÀI KHOẢN (24/7)";
            this.lblTransferTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTransferCard
            // 
            this.pnlTransferCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlTransferCard.Controls.Add(this.btnTransferConfirm);
            this.pnlTransferCard.Controls.Add(this.btnTransferBack);
            this.pnlTransferCard.Controls.Add(this.txtTransferDesc);
            this.pnlTransferCard.Controls.Add(this.lblTransferDesc);
            this.pnlTransferCard.Controls.Add(this.txtTransferAmount);
            this.pnlTransferCard.Controls.Add(this.lblTransferAmount);
            this.pnlTransferCard.Controls.Add(this.pnlReceiverBadge);
            this.pnlTransferCard.Controls.Add(this.btnCheckReceiver);
            this.pnlTransferCard.Controls.Add(this.txtDestAccount);
            this.pnlTransferCard.Controls.Add(this.lblDestAccount);
            this.pnlTransferCard.Location = new System.Drawing.Point(51, 60);
            this.pnlTransferCard.Name = "pnlTransferCard";
            this.pnlTransferCard.Size = new System.Drawing.Size(520, 420);
            this.pnlTransferCard.TabIndex = 1;
            // 
            // btnTransferConfirm
            // 
            this.btnTransferConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnTransferConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferConfirm.FlatAppearance.BorderSize = 0;
            this.btnTransferConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTransferConfirm.ForeColor = System.Drawing.Color.White;
            this.btnTransferConfirm.Location = new System.Drawing.Point(260, 360);
            this.btnTransferConfirm.Name = "btnTransferConfirm";
            this.btnTransferConfirm.Size = new System.Drawing.Size(240, 48);
            this.btnTransferConfirm.TabIndex = 9;
            this.btnTransferConfirm.Text = "XÁC NHẬN CHUYỂN TIỀN";
            this.btnTransferConfirm.UseVisualStyleBackColor = false;
            // 
            // btnTransferBack
            // 
            this.btnTransferBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnTransferBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferBack.FlatAppearance.BorderSize = 0;
            this.btnTransferBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTransferBack.ForeColor = System.Drawing.Color.White;
            this.btnTransferBack.Location = new System.Drawing.Point(20, 360);
            this.btnTransferBack.Name = "btnTransferBack";
            this.btnTransferBack.Size = new System.Drawing.Size(180, 48);
            this.btnTransferBack.TabIndex = 8;
            this.btnTransferBack.Text = "◀ HỦY BỎ";
            this.btnTransferBack.UseVisualStyleBackColor = false;
            // 
            // txtTransferDesc
            // 
            this.txtTransferDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtTransferDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferDesc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTransferDesc.ForeColor = System.Drawing.Color.White;
            this.txtTransferDesc.Location = new System.Drawing.Point(20, 290);
            this.txtTransferDesc.Name = "txtTransferDesc";
            this.txtTransferDesc.Size = new System.Drawing.Size(480, 27);
            this.txtTransferDesc.TabIndex = 7;
            this.txtTransferDesc.Text = "Nguyen Van An chuyen tien hoc phi";
            // 
            // lblTransferDesc
            // 
            this.lblTransferDesc.AutoSize = true;
            this.lblTransferDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTransferDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblTransferDesc.Location = new System.Drawing.Point(20, 260);
            this.lblTransferDesc.Name = "lblTransferDesc";
            this.lblTransferDesc.Size = new System.Drawing.Size(175, 19);
            this.lblTransferDesc.TabIndex = 6;
            this.lblTransferDesc.Text = "NỘI DUNG CHUYỂN KHOẢN:";
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtTransferAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferAmount.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTransferAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.txtTransferAmount.Location = new System.Drawing.Point(20, 210);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(480, 29);
            this.txtTransferAmount.TabIndex = 5;
            this.txtTransferAmount.Text = "500000";
            // 
            // lblTransferAmount
            // 
            this.lblTransferAmount.AutoSize = true;
            this.lblTransferAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTransferAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblTransferAmount.Location = new System.Drawing.Point(20, 180);
            this.lblTransferAmount.Name = "lblTransferAmount";
            this.lblTransferAmount.Size = new System.Drawing.Size(188, 19);
            this.lblTransferAmount.TabIndex = 4;
            this.lblTransferAmount.Text = "SỐ TIỀN CẦN CHUYỂN (VNĐ):";
            // 
            // pnlReceiverBadge
            // 
            this.pnlReceiverBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(78)))), ((int)(((byte)(59)))));
            this.pnlReceiverBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReceiverBadge.Controls.Add(this.lblReceiverBadge);
            this.pnlReceiverBadge.Location = new System.Drawing.Point(20, 110);
            this.pnlReceiverBadge.Name = "pnlReceiverBadge";
            this.pnlReceiverBadge.Size = new System.Drawing.Size(480, 50);
            this.pnlReceiverBadge.TabIndex = 3;
            // 
            // lblReceiverBadge
            // 
            this.lblReceiverBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverBadge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReceiverBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(231)))), ((int)(((byte)(183)))));
            this.lblReceiverBadge.Location = new System.Drawing.Point(0, 0);
            this.lblReceiverBadge.Name = "lblReceiverBadge";
            this.lblReceiverBadge.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblReceiverBadge.Size = new System.Drawing.Size(478, 48);
            this.lblReceiverBadge.TabIndex = 0;
            this.lblReceiverBadge.Text = "TÊN NGƯỜI NHẬN:   TRẦN THỊ BÌNH (EPU BANK)";
            this.lblReceiverBadge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCheckReceiver
            // 
            this.btnCheckReceiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnCheckReceiver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckReceiver.FlatAppearance.BorderSize = 0;
            this.btnCheckReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckReceiver.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckReceiver.ForeColor = System.Drawing.Color.White;
            this.btnCheckReceiver.Location = new System.Drawing.Point(350, 50);
            this.btnCheckReceiver.Name = "btnCheckReceiver";
            this.btnCheckReceiver.Size = new System.Drawing.Size(150, 36);
            this.btnCheckReceiver.TabIndex = 2;
            this.btnCheckReceiver.Text = "Kiểm tra tên";
            this.btnCheckReceiver.UseVisualStyleBackColor = false;
            // 
            // txtDestAccount
            // 
            this.txtDestAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDestAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestAccount.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDestAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.txtDestAccount.Location = new System.Drawing.Point(20, 52);
            this.txtDestAccount.Name = "txtDestAccount";
            this.txtDestAccount.Size = new System.Drawing.Size(320, 29);
            this.txtDestAccount.TabIndex = 1;
            this.txtDestAccount.Text = "1002";
            // 
            // lblDestAccount
            // 
            this.lblDestAccount.AutoSize = true;
            this.lblDestAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDestAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblDestAccount.Location = new System.Drawing.Point(20, 20);
            this.lblDestAccount.Name = "lblDestAccount";
            this.lblDestAccount.Size = new System.Drawing.Size(287, 19);
            this.lblDestAccount.TabIndex = 0;
            this.lblDestAccount.Text = "SỐ TÀI KHOẢN THỤ HƯỞNG (NGƯỜI NHẬN):";
            // 
            // UcScreenTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.pnlTransferCard);
            this.Controls.Add(this.lblTransferTitle);
            this.Name = "UcScreenTransfer";
            this.Size = new System.Drawing.Size(622, 532);
            this.pnlTransferCard.ResumeLayout(false);
            this.pnlTransferCard.PerformLayout();
            this.pnlReceiverBadge.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTransferTitle;
        private System.Windows.Forms.Panel pnlTransferCard;
        private System.Windows.Forms.Label lblDestAccount;
        public System.Windows.Forms.TextBox txtDestAccount;
        private System.Windows.Forms.Button btnCheckReceiver;
        private System.Windows.Forms.Panel pnlReceiverBadge;
        private System.Windows.Forms.Label lblReceiverBadge;
        private System.Windows.Forms.Label lblTransferAmount;
        public System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Label lblTransferDesc;
        public System.Windows.Forms.TextBox txtTransferDesc;
        private System.Windows.Forms.Button btnTransferBack;
        private System.Windows.Forms.Button btnTransferConfirm;
    }
}

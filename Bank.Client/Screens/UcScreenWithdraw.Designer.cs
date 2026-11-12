namespace Bank.Client.Screens
{
    partial class UcScreenWithdraw
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
            this.lblWithdrawTitle = new System.Windows.Forms.Label();
            this.lblWithdrawBalance = new System.Windows.Forms.Label();
            this.tblWithdrawGrid = new System.Windows.Forms.TableLayoutPanel();
            this.btnDenom100k = new System.Windows.Forms.Button();
            this.btnDenom200k = new System.Windows.Forms.Button();
            this.btnDenom500k = new System.Windows.Forms.Button();
            this.btnDenom1m = new System.Windows.Forms.Button();
            this.btnDenom2m = new System.Windows.Forms.Button();
            this.btnDenomCustom = new System.Windows.Forms.Button();
            this.lblWithdrawLockNote = new System.Windows.Forms.Label();
            this.btnWithdrawBack = new System.Windows.Forms.Button();
            this.btnWithdrawConfirm = new System.Windows.Forms.Button();
            this.tblWithdrawGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWithdrawTitle
            // 
            this.lblWithdrawTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWithdrawTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWithdrawTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblWithdrawTitle.Location = new System.Drawing.Point(0, 0);
            this.lblWithdrawTitle.Name = "lblWithdrawTitle";
            this.lblWithdrawTitle.Size = new System.Drawing.Size(622, 45);
            this.lblWithdrawTitle.TabIndex = 0;
            this.lblWithdrawTitle.Text = "CHỌN MỆNH GIÁ CẦN RÚT";
            this.lblWithdrawTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWithdrawBalance
            // 
            this.lblWithdrawBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWithdrawBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWithdrawBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblWithdrawBalance.Location = new System.Drawing.Point(0, 45);
            this.lblWithdrawBalance.Name = "lblWithdrawBalance";
            this.lblWithdrawBalance.Size = new System.Drawing.Size(622, 35);
            this.lblWithdrawBalance.TabIndex = 1;
            this.lblWithdrawBalance.Text = "Số dư hiện tại: 8.500.000 VNĐ";
            this.lblWithdrawBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblWithdrawGrid
            // 
            this.tblWithdrawGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblWithdrawGrid.ColumnCount = 2;
            this.tblWithdrawGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWithdrawGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWithdrawGrid.Controls.Add(this.btnDenom100k, 0, 0);
            this.tblWithdrawGrid.Controls.Add(this.btnDenom200k, 1, 0);
            this.tblWithdrawGrid.Controls.Add(this.btnDenom500k, 0, 1);
            this.tblWithdrawGrid.Controls.Add(this.btnDenom1m, 1, 1);
            this.tblWithdrawGrid.Controls.Add(this.btnDenom2m, 0, 2);
            this.tblWithdrawGrid.Controls.Add(this.btnDenomCustom, 1, 2);
            this.tblWithdrawGrid.Location = new System.Drawing.Point(20, 95);
            this.tblWithdrawGrid.Name = "tblWithdrawGrid";
            this.tblWithdrawGrid.RowCount = 3;
            this.tblWithdrawGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblWithdrawGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblWithdrawGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tblWithdrawGrid.Size = new System.Drawing.Size(582, 305);
            this.tblWithdrawGrid.TabIndex = 2;
            // 
            // btnDenom100k
            // 
            this.btnDenom100k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDenom100k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDenom100k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDenom100k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnDenom100k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenom100k.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenom100k.ForeColor = System.Drawing.Color.White;
            this.btnDenom100k.Location = new System.Drawing.Point(8, 8);
            this.btnDenom100k.Margin = new System.Windows.Forms.Padding(8);
            this.btnDenom100k.Name = "btnDenom100k";
            this.btnDenom100k.Size = new System.Drawing.Size(275, 85);
            this.btnDenom100k.TabIndex = 0;
            this.btnDenom100k.Text = "100.000 VNĐ";
            this.btnDenom100k.UseVisualStyleBackColor = false;
            // 
            // btnDenom200k
            // 
            this.btnDenom200k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDenom200k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDenom200k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDenom200k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnDenom200k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenom200k.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenom200k.ForeColor = System.Drawing.Color.White;
            this.btnDenom200k.Location = new System.Drawing.Point(299, 8);
            this.btnDenom200k.Margin = new System.Windows.Forms.Padding(8);
            this.btnDenom200k.Name = "btnDenom200k";
            this.btnDenom200k.Size = new System.Drawing.Size(275, 85);
            this.btnDenom200k.TabIndex = 1;
            this.btnDenom200k.Text = "200.000 VNĐ";
            this.btnDenom200k.UseVisualStyleBackColor = false;
            // 
            // btnDenom500k
            // 
            this.btnDenom500k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnDenom500k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDenom500k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDenom500k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.btnDenom500k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenom500k.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenom500k.ForeColor = System.Drawing.Color.White;
            this.btnDenom500k.Location = new System.Drawing.Point(8, 109);
            this.btnDenom500k.Margin = new System.Windows.Forms.Padding(8);
            this.btnDenom500k.Name = "btnDenom500k";
            this.btnDenom500k.Size = new System.Drawing.Size(275, 85);
            this.btnDenom500k.TabIndex = 2;
            this.btnDenom500k.Text = "500.000 VNĐ";
            this.btnDenom500k.UseVisualStyleBackColor = false;
            // 
            // btnDenom1m
            // 
            this.btnDenom1m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDenom1m.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDenom1m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDenom1m.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnDenom1m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenom1m.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenom1m.ForeColor = System.Drawing.Color.White;
            this.btnDenom1m.Location = new System.Drawing.Point(299, 109);
            this.btnDenom1m.Margin = new System.Windows.Forms.Padding(8);
            this.btnDenom1m.Name = "btnDenom1m";
            this.btnDenom1m.Size = new System.Drawing.Size(275, 85);
            this.btnDenom1m.TabIndex = 3;
            this.btnDenom1m.Text = "1.000.000 VNĐ";
            this.btnDenom1m.UseVisualStyleBackColor = false;
            // 
            // btnDenom2m
            // 
            this.btnDenom2m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDenom2m.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDenom2m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDenom2m.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnDenom2m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenom2m.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenom2m.ForeColor = System.Drawing.Color.White;
            this.btnDenom2m.Location = new System.Drawing.Point(8, 210);
            this.btnDenom2m.Margin = new System.Windows.Forms.Padding(8);
            this.btnDenom2m.Name = "btnDenom2m";
            this.btnDenom2m.Size = new System.Drawing.Size(275, 87);
            this.btnDenom2m.TabIndex = 4;
            this.btnDenom2m.Text = "2.000.000 VNĐ";
            this.btnDenom2m.UseVisualStyleBackColor = false;
            // 
            // btnDenomCustom
            // 
            this.btnDenomCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnDenomCustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDenomCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDenomCustom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.btnDenomCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenomCustom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenomCustom.ForeColor = System.Drawing.Color.White;
            this.btnDenomCustom.Location = new System.Drawing.Point(299, 210);
            this.btnDenomCustom.Margin = new System.Windows.Forms.Padding(8);
            this.btnDenomCustom.Name = "btnDenomCustom";
            this.btnDenomCustom.Size = new System.Drawing.Size(275, 87);
            this.btnDenomCustom.TabIndex = 5;
            this.btnDenomCustom.Text = "NHẬP SỐ KHÁC...";
            this.btnDenomCustom.UseVisualStyleBackColor = false;
            // 
            // lblWithdrawLockNote
            // 
            this.lblWithdrawLockNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWithdrawLockNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(51)))), ((int)(((byte)(68)))));
            this.lblWithdrawLockNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWithdrawLockNote.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWithdrawLockNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblWithdrawLockNote.Location = new System.Drawing.Point(20, 415);
            this.lblWithdrawLockNote.Name = "lblWithdrawLockNote";
            this.lblWithdrawLockNote.Size = new System.Drawing.Size(582, 35);
            this.lblWithdrawLockNote.TabIndex = 3;
            this.lblWithdrawLockNote.Text = "🛡 Yêu cầu rút tiền được bảo vệ bằng cơ chế Thread Lock trên Server để chống Race Condition.";
            this.lblWithdrawLockNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWithdrawBack
            // 
            this.btnWithdrawBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWithdrawBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnWithdrawBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWithdrawBack.FlatAppearance.BorderSize = 0;
            this.btnWithdrawBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdrawBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnWithdrawBack.ForeColor = System.Drawing.Color.White;
            this.btnWithdrawBack.Location = new System.Drawing.Point(20, 465);
            this.btnWithdrawBack.Name = "btnWithdrawBack";
            this.btnWithdrawBack.Size = new System.Drawing.Size(180, 48);
            this.btnWithdrawBack.TabIndex = 4;
            this.btnWithdrawBack.Text = "◀ QUAY LẠI MENU";
            this.btnWithdrawBack.UseVisualStyleBackColor = false;
            // 
            // btnWithdrawConfirm
            // 
            this.btnWithdrawConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWithdrawConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnWithdrawConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWithdrawConfirm.FlatAppearance.BorderSize = 0;
            this.btnWithdrawConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdrawConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnWithdrawConfirm.ForeColor = System.Drawing.Color.White;
            this.btnWithdrawConfirm.Location = new System.Drawing.Point(400, 465);
            this.btnWithdrawConfirm.Name = "btnWithdrawConfirm";
            this.btnWithdrawConfirm.Size = new System.Drawing.Size(200, 48);
            this.btnWithdrawConfirm.TabIndex = 5;
            this.btnWithdrawConfirm.Text = "XÁC NHẬN RÚT";
            this.btnWithdrawConfirm.UseVisualStyleBackColor = false;
            // 
            // UcScreenWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.btnWithdrawConfirm);
            this.Controls.Add(this.btnWithdrawBack);
            this.Controls.Add(this.lblWithdrawLockNote);
            this.Controls.Add(this.tblWithdrawGrid);
            this.Controls.Add(this.lblWithdrawBalance);
            this.Controls.Add(this.lblWithdrawTitle);
            this.Name = "UcScreenWithdraw";
            this.Size = new System.Drawing.Size(622, 532);
            this.tblWithdrawGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWithdrawTitle;
        private System.Windows.Forms.Label lblWithdrawBalance;
        private System.Windows.Forms.TableLayoutPanel tblWithdrawGrid;
        private System.Windows.Forms.Button btnDenom100k;
        private System.Windows.Forms.Button btnDenom200k;
        private System.Windows.Forms.Button btnDenom500k;
        private System.Windows.Forms.Button btnDenom1m;
        private System.Windows.Forms.Button btnDenom2m;
        private System.Windows.Forms.Button btnDenomCustom;
        private System.Windows.Forms.Label lblWithdrawLockNote;
        private System.Windows.Forms.Button btnWithdrawBack;
        private System.Windows.Forms.Button btnWithdrawConfirm;
    }
}

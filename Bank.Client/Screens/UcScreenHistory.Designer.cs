namespace Bank.Client.Screens
{
    partial class UcScreenHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.lblHistoryAcc = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHistoryBack = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(0, 0);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(622, 40);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "LỊCH SỬ 5 GIAO DỊCH GẦN NHẤT";
            this.lblHistoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHistoryAcc
            // 
            this.lblHistoryAcc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistoryAcc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHistoryAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblHistoryAcc.Location = new System.Drawing.Point(0, 40);
            this.lblHistoryAcc.Name = "lblHistoryAcc";
            this.lblHistoryAcc.Size = new System.Drawing.Size(622, 30);
            this.lblHistoryAcc.TabIndex = 1;
            this.lblHistoryAcc.Text = "Chủ tài khoản: NGUYỄN VĂN AN (1001)";
            this.lblHistoryAcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(51)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.ColumnHeadersHeight = 35;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colType,
            this.colAmount,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.Location = new System.Drawing.Point(20, 85);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 32;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(582, 360);
            this.dgvHistory.TabIndex = 2;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Thời gian";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.HeaderText = "Loại giao dịch";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Số tiền";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // btnHistoryBack
            // 
            this.btnHistoryBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHistoryBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnHistoryBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoryBack.FlatAppearance.BorderSize = 0;
            this.btnHistoryBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHistoryBack.ForeColor = System.Drawing.Color.White;
            this.btnHistoryBack.Location = new System.Drawing.Point(20, 465);
            this.btnHistoryBack.Name = "btnHistoryBack";
            this.btnHistoryBack.Size = new System.Drawing.Size(180, 48);
            this.btnHistoryBack.TabIndex = 3;
            this.btnHistoryBack.Text = "◀ QUAY LẠI MENU";
            this.btnHistoryBack.UseVisualStyleBackColor = false;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintReceipt.FlatAppearance.BorderSize = 0;
            this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.White;
            this.btnPrintReceipt.Location = new System.Drawing.Point(380, 465);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(220, 48);
            this.btnPrintReceipt.TabIndex = 4;
            this.btnPrintReceipt.Text = "🖨 IN BIÊN LAI / SAO KÊ";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            // 
            // UcScreenHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.btnHistoryBack);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lblHistoryAcc);
            this.Controls.Add(this.lblHistoryTitle);
            this.Name = "UcScreenHistory";
            this.Size = new System.Drawing.Size(622, 532);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Label lblHistoryAcc;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnHistoryBack;
        private System.Windows.Forms.Button btnPrintReceipt;
    }
}

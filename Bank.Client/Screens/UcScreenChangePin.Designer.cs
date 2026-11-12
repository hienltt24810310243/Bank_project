namespace Bank.Client.Screens
{
    partial class UcScreenChangePin
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
            this.lblChangePinTitle = new System.Windows.Forms.Label();
            this.pnlChangePinCard = new System.Windows.Forms.Panel();
            this.btnChangePinConfirm = new System.Windows.Forms.Button();
            this.btnChangePinBack = new System.Windows.Forms.Button();
            this.pnlConfirmPinWrapper = new System.Windows.Forms.Panel();
            this.btnToggleConfirmPin = new System.Windows.Forms.Button();
            this.txtConfirmNewPin = new System.Windows.Forms.TextBox();
            this.lblConfirmNewPin = new System.Windows.Forms.Label();
            this.pnlNewPinWrapper = new System.Windows.Forms.Panel();
            this.btnToggleNewPin = new System.Windows.Forms.Button();
            this.txtNewPin = new System.Windows.Forms.TextBox();
            this.lblNewPin = new System.Windows.Forms.Label();
            this.pnlOldPinWrapper = new System.Windows.Forms.Panel();
            this.btnToggleOldPin = new System.Windows.Forms.Button();
            this.txtOldPin = new System.Windows.Forms.TextBox();
            this.lblOldPin = new System.Windows.Forms.Label();
            this.pnlChangePinCard.SuspendLayout();
            this.pnlOldPinWrapper.SuspendLayout();
            this.pnlNewPinWrapper.SuspendLayout();
            this.pnlConfirmPinWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChangePinTitle
            // 
            this.lblChangePinTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChangePinTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChangePinTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.lblChangePinTitle.Location = new System.Drawing.Point(0, 0);
            this.lblChangePinTitle.Name = "lblChangePinTitle";
            this.lblChangePinTitle.Size = new System.Drawing.Size(622, 45);
            this.lblChangePinTitle.TabIndex = 0;
            this.lblChangePinTitle.Text = "THAY ĐỔI MÃ PIN BẢO MẬT";
            this.lblChangePinTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlChangePinCard
            // 
            this.pnlChangePinCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlChangePinCard.Controls.Add(this.btnChangePinConfirm);
            this.pnlChangePinCard.Controls.Add(this.btnChangePinBack);
            this.pnlChangePinCard.Controls.Add(this.pnlConfirmPinWrapper);
            this.pnlChangePinCard.Controls.Add(this.lblConfirmNewPin);
            this.pnlChangePinCard.Controls.Add(this.pnlNewPinWrapper);
            this.pnlChangePinCard.Controls.Add(this.lblNewPin);
            this.pnlChangePinCard.Controls.Add(this.pnlOldPinWrapper);
            this.pnlChangePinCard.Controls.Add(this.lblOldPin);
            this.pnlChangePinCard.Location = new System.Drawing.Point(51, 60);
            this.pnlChangePinCard.Name = "pnlChangePinCard";
            this.pnlChangePinCard.Size = new System.Drawing.Size(520, 360);
            this.pnlChangePinCard.TabIndex = 1;
            // 
            // lblOldPin
            // 
            this.lblOldPin.AutoSize = true;
            this.lblOldPin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOldPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblOldPin.Location = new System.Drawing.Point(30, 15);
            this.lblOldPin.Name = "lblOldPin";
            this.lblOldPin.Size = new System.Drawing.Size(161, 19);
            this.lblOldPin.TabIndex = 0;
            this.lblOldPin.Text = "NHẬP MÃ PIN HIỆN TẠI:";
            // 
            // pnlOldPinWrapper
            // 
            this.pnlOldPinWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlOldPinWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOldPinWrapper.Controls.Add(this.btnToggleOldPin);
            this.pnlOldPinWrapper.Controls.Add(this.txtOldPin);
            this.pnlOldPinWrapper.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlOldPinWrapper.Location = new System.Drawing.Point(30, 42);
            this.pnlOldPinWrapper.Name = "pnlOldPinWrapper";
            this.pnlOldPinWrapper.Size = new System.Drawing.Size(460, 38);
            this.pnlOldPinWrapper.TabIndex = 1;
            // 
            // txtOldPin
            // 
            this.txtOldPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtOldPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOldPin.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtOldPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.txtOldPin.Location = new System.Drawing.Point(10, 7);
            this.txtOldPin.Name = "txtOldPin";
            this.txtOldPin.PasswordChar = '●';
            this.txtOldPin.Size = new System.Drawing.Size(400, 24);
            this.txtOldPin.TabIndex = 0;
            this.txtOldPin.Text = "123456";
            this.txtOldPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnToggleOldPin
            // 
            this.btnToggleOldPin.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleOldPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleOldPin.FlatAppearance.BorderSize = 0;
            this.btnToggleOldPin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnToggleOldPin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnToggleOldPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleOldPin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToggleOldPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnToggleOldPin.Location = new System.Drawing.Point(418, 3);
            this.btnToggleOldPin.Name = "btnToggleOldPin";
            this.btnToggleOldPin.Size = new System.Drawing.Size(36, 30);
            this.btnToggleOldPin.TabIndex = 1;
            this.btnToggleOldPin.TabStop = false;
            this.btnToggleOldPin.Text = "👁";
            this.btnToggleOldPin.UseVisualStyleBackColor = false;
            // 
            // lblNewPin
            // 
            this.lblNewPin.AutoSize = true;
            this.lblNewPin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNewPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblNewPin.Location = new System.Drawing.Point(30, 95);
            this.lblNewPin.Name = "lblNewPin";
            this.lblNewPin.Size = new System.Drawing.Size(175, 19);
            this.lblNewPin.TabIndex = 2;
            this.lblNewPin.Text = "NHẬP MÃ PIN MỚI (6 SỐ):";
            // 
            // pnlNewPinWrapper
            // 
            this.pnlNewPinWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlNewPinWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNewPinWrapper.Controls.Add(this.btnToggleNewPin);
            this.pnlNewPinWrapper.Controls.Add(this.txtNewPin);
            this.pnlNewPinWrapper.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlNewPinWrapper.Location = new System.Drawing.Point(30, 122);
            this.pnlNewPinWrapper.Name = "pnlNewPinWrapper";
            this.pnlNewPinWrapper.Size = new System.Drawing.Size(460, 38);
            this.pnlNewPinWrapper.TabIndex = 3;
            // 
            // txtNewPin
            // 
            this.txtNewPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtNewPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPin.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNewPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.txtNewPin.Location = new System.Drawing.Point(10, 7);
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.PasswordChar = '●';
            this.txtNewPin.Size = new System.Drawing.Size(400, 24);
            this.txtNewPin.TabIndex = 0;
            this.txtNewPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnToggleNewPin
            // 
            this.btnToggleNewPin.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleNewPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleNewPin.FlatAppearance.BorderSize = 0;
            this.btnToggleNewPin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnToggleNewPin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnToggleNewPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleNewPin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToggleNewPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnToggleNewPin.Location = new System.Drawing.Point(418, 3);
            this.btnToggleNewPin.Name = "btnToggleNewPin";
            this.btnToggleNewPin.Size = new System.Drawing.Size(36, 30);
            this.btnToggleNewPin.TabIndex = 1;
            this.btnToggleNewPin.TabStop = false;
            this.btnToggleNewPin.Text = "👁";
            this.btnToggleNewPin.UseVisualStyleBackColor = false;
            // 
            // lblConfirmNewPin
            // 
            this.lblConfirmNewPin.AutoSize = true;
            this.lblConfirmNewPin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmNewPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.lblConfirmNewPin.Location = new System.Drawing.Point(30, 175);
            this.lblConfirmNewPin.Name = "lblConfirmNewPin";
            this.lblConfirmNewPin.Size = new System.Drawing.Size(189, 19);
            this.lblConfirmNewPin.TabIndex = 4;
            this.lblConfirmNewPin.Text = "XÁC NHẬN LẠI MÃ PIN MỚI:";
            // 
            // pnlConfirmPinWrapper
            // 
            this.pnlConfirmPinWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlConfirmPinWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfirmPinWrapper.Controls.Add(this.btnToggleConfirmPin);
            this.pnlConfirmPinWrapper.Controls.Add(this.txtConfirmNewPin);
            this.pnlConfirmPinWrapper.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlConfirmPinWrapper.Location = new System.Drawing.Point(30, 202);
            this.pnlConfirmPinWrapper.Name = "pnlConfirmPinWrapper";
            this.pnlConfirmPinWrapper.Size = new System.Drawing.Size(460, 38);
            this.pnlConfirmPinWrapper.TabIndex = 5;
            // 
            // txtConfirmNewPin
            // 
            this.txtConfirmNewPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtConfirmNewPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmNewPin.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtConfirmNewPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.txtConfirmNewPin.Location = new System.Drawing.Point(10, 7);
            this.txtConfirmNewPin.Name = "txtConfirmNewPin";
            this.txtConfirmNewPin.PasswordChar = '●';
            this.txtConfirmNewPin.Size = new System.Drawing.Size(400, 24);
            this.txtConfirmNewPin.TabIndex = 0;
            this.txtConfirmNewPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnToggleConfirmPin
            // 
            this.btnToggleConfirmPin.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleConfirmPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleConfirmPin.FlatAppearance.BorderSize = 0;
            this.btnToggleConfirmPin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnToggleConfirmPin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnToggleConfirmPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleConfirmPin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToggleConfirmPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnToggleConfirmPin.Location = new System.Drawing.Point(418, 3);
            this.btnToggleConfirmPin.Name = "btnToggleConfirmPin";
            this.btnToggleConfirmPin.Size = new System.Drawing.Size(36, 30);
            this.btnToggleConfirmPin.TabIndex = 1;
            this.btnToggleConfirmPin.TabStop = false;
            this.btnToggleConfirmPin.Text = "👁";
            this.btnToggleConfirmPin.UseVisualStyleBackColor = false;
            // 
            // btnChangePinBack
            // 
            this.btnChangePinBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnChangePinBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePinBack.FlatAppearance.BorderSize = 0;
            this.btnChangePinBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePinBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangePinBack.ForeColor = System.Drawing.Color.White;
            this.btnChangePinBack.Location = new System.Drawing.Point(30, 280);
            this.btnChangePinBack.Name = "btnChangePinBack";
            this.btnChangePinBack.Size = new System.Drawing.Size(210, 48);
            this.btnChangePinBack.TabIndex = 6;
            this.btnChangePinBack.Text = "◀ HỦY BỎ";
            this.btnChangePinBack.UseVisualStyleBackColor = false;
            // 
            // btnChangePinConfirm
            // 
            this.btnChangePinConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnChangePinConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePinConfirm.FlatAppearance.BorderSize = 0;
            this.btnChangePinConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePinConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangePinConfirm.ForeColor = System.Drawing.Color.White;
            this.btnChangePinConfirm.Location = new System.Drawing.Point(260, 280);
            this.btnChangePinConfirm.Name = "btnChangePinConfirm";
            this.btnChangePinConfirm.Size = new System.Drawing.Size(230, 48);
            this.btnChangePinConfirm.TabIndex = 7;
            this.btnChangePinConfirm.Text = "XÁC NHẬN ĐỔI";
            this.btnChangePinConfirm.UseVisualStyleBackColor = false;
            // 
            // UcScreenChangePin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.pnlChangePinCard);
            this.Controls.Add(this.lblChangePinTitle);
            this.Name = "UcScreenChangePin";
            this.Size = new System.Drawing.Size(622, 532);
            this.pnlChangePinCard.ResumeLayout(false);
            this.pnlChangePinCard.PerformLayout();
            this.pnlOldPinWrapper.ResumeLayout(false);
            this.pnlOldPinWrapper.PerformLayout();
            this.pnlNewPinWrapper.ResumeLayout(false);
            this.pnlNewPinWrapper.PerformLayout();
            this.pnlConfirmPinWrapper.ResumeLayout(false);
            this.pnlConfirmPinWrapper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChangePinTitle;
        private System.Windows.Forms.Panel pnlChangePinCard;
        private System.Windows.Forms.Label lblOldPin;
        public System.Windows.Forms.Panel pnlOldPinWrapper;
        public System.Windows.Forms.TextBox txtOldPin;
        public System.Windows.Forms.Button btnToggleOldPin;
        private System.Windows.Forms.Label lblNewPin;
        public System.Windows.Forms.Panel pnlNewPinWrapper;
        public System.Windows.Forms.TextBox txtNewPin;
        public System.Windows.Forms.Button btnToggleNewPin;
        private System.Windows.Forms.Label lblConfirmNewPin;
        public System.Windows.Forms.Panel pnlConfirmPinWrapper;
        public System.Windows.Forms.TextBox txtConfirmNewPin;
        public System.Windows.Forms.Button btnToggleConfirmPin;
        private System.Windows.Forms.Button btnChangePinBack;
        private System.Windows.Forms.Button btnChangePinConfirm;
    }
}

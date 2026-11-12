namespace Bank.Client
{
    partial class Form1
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
            this.pnlKioskBezel = new System.Windows.Forms.Panel();
            this.pnlKioskBody = new System.Windows.Forms.Panel();
            this.pnlScreenContainer = new System.Windows.Forms.Panel();
            this.pnlHardwareKeypad = new System.Windows.Forms.Panel();
            this.pnlCashTray = new System.Windows.Forms.Panel();
            this.lblCashTray = new System.Windows.Forms.Label();
            this.pnlCardSlot = new System.Windows.Forms.Panel();
            this.lblCardSlot = new System.Windows.Forms.Label();
            this.pnlKeypadGrid = new System.Windows.Forms.Panel();
            this.btnKeyEnter = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnKeyClear = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.lblKeypadHeader = new System.Windows.Forms.Label();
            this.pnlKioskHeader = new System.Windows.Forms.Panel();
            this.lblStatusBadge = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.lblServerConfig = new System.Windows.Forms.Label();
            this.lblKioskTitle = new System.Windows.Forms.Label();
            this.lblDotGreen = new System.Windows.Forms.Label();
            this.lblDotYellow = new System.Windows.Forms.Label();
            this.lblDotRed = new System.Windows.Forms.Label();
            this.pnlKioskBezel.SuspendLayout();
            this.pnlKioskBody.SuspendLayout();
            this.pnlHardwareKeypad.SuspendLayout();
            this.pnlCashTray.SuspendLayout();
            this.pnlCardSlot.SuspendLayout();
            this.pnlKeypadGrid.SuspendLayout();
            this.pnlKioskHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKioskBezel
            // 
            this.pnlKioskBezel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlKioskBezel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKioskBezel.Controls.Add(this.pnlKioskBody);
            this.pnlKioskBezel.Controls.Add(this.pnlKioskHeader);
            this.pnlKioskBezel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKioskBezel.Location = new System.Drawing.Point(12, 12);
            this.pnlKioskBezel.Name = "pnlKioskBezel";
            this.pnlKioskBezel.Padding = new System.Windows.Forms.Padding(16);
            this.pnlKioskBezel.Size = new System.Drawing.Size(1020, 636);
            this.pnlKioskBezel.TabIndex = 0;
            // 
            // pnlKioskBody
            // 
            this.pnlKioskBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlKioskBody.Controls.Add(this.pnlScreenContainer);
            this.pnlKioskBody.Controls.Add(this.pnlHardwareKeypad);
            this.pnlKioskBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKioskBody.Location = new System.Drawing.Point(16, 52);
            this.pnlKioskBody.Name = "pnlKioskBody";
            this.pnlKioskBody.Size = new System.Drawing.Size(986, 566);
            this.pnlKioskBody.TabIndex = 1;
            // 
            // pnlScreenContainer
            // 
            this.pnlScreenContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.pnlScreenContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScreenContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreenContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlScreenContainer.Name = "pnlScreenContainer";
            this.pnlScreenContainer.Size = new System.Drawing.Size(656, 566);
            this.pnlScreenContainer.TabIndex = 0;
            // 
            // pnlHardwareKeypad
            // 
            this.pnlHardwareKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHardwareKeypad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHardwareKeypad.Controls.Add(this.pnlCashTray);
            this.pnlHardwareKeypad.Controls.Add(this.pnlCardSlot);
            this.pnlHardwareKeypad.Controls.Add(this.pnlKeypadGrid);
            this.pnlHardwareKeypad.Controls.Add(this.lblKeypadHeader);
            this.pnlHardwareKeypad.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHardwareKeypad.Location = new System.Drawing.Point(656, 0);
            this.pnlHardwareKeypad.Name = "pnlHardwareKeypad";
            this.pnlHardwareKeypad.Padding = new System.Windows.Forms.Padding(12);
            this.pnlHardwareKeypad.Size = new System.Drawing.Size(330, 566);
            this.pnlHardwareKeypad.TabIndex = 1;
            // 
            // pnlCashTray
            // 
            this.pnlCashTray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCashTray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlCashTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCashTray.Controls.Add(this.lblCashTray);
            this.pnlCashTray.Location = new System.Drawing.Point(15, 480);
            this.pnlCashTray.Name = "pnlCashTray";
            this.pnlCashTray.Size = new System.Drawing.Size(298, 60);
            this.pnlCashTray.TabIndex = 3;
            // 
            // lblCashTray
            // 
            this.lblCashTray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCashTray.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCashTray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblCashTray.Location = new System.Drawing.Point(0, 0);
            this.lblCashTray.Name = "lblCashTray";
            this.lblCashTray.Size = new System.Drawing.Size(296, 58);
            this.lblCashTray.TabIndex = 0;
            this.lblCashTray.Text = "▼ KHAY NHẢ TIỀN MẶT ▼";
            this.lblCashTray.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardSlot
            // 
            this.pnlCardSlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCardSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlCardSlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSlot.Controls.Add(this.lblCardSlot);
            this.pnlCardSlot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCardSlot.Location = new System.Drawing.Point(15, 415);
            this.pnlCardSlot.Name = "pnlCardSlot";
            this.pnlCardSlot.Size = new System.Drawing.Size(298, 50);
            this.pnlCardSlot.TabIndex = 2;
            // 
            // lblCardSlot
            // 
            this.lblCardSlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCardSlot.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCardSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCardSlot.Location = new System.Drawing.Point(0, 0);
            this.lblCardSlot.Name = "lblCardSlot";
            this.lblCardSlot.Size = new System.Drawing.Size(296, 48);
            this.lblCardSlot.TabIndex = 0;
            this.lblCardSlot.Text = "=== KHE CẮM THẺ ATM ===";
            this.lblCardSlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKeypadGrid
            // 
            this.pnlKeypadGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKeypadGrid.Controls.Add(this.btnKeyEnter);
            this.pnlKeypadGrid.Controls.Add(this.btnKey0);
            this.pnlKeypadGrid.Controls.Add(this.btnKeyClear);
            this.pnlKeypadGrid.Controls.Add(this.btnKey9);
            this.pnlKeypadGrid.Controls.Add(this.btnKey8);
            this.pnlKeypadGrid.Controls.Add(this.btnKey7);
            this.pnlKeypadGrid.Controls.Add(this.btnKey6);
            this.pnlKeypadGrid.Controls.Add(this.btnKey5);
            this.pnlKeypadGrid.Controls.Add(this.btnKey4);
            this.pnlKeypadGrid.Controls.Add(this.btnKey3);
            this.pnlKeypadGrid.Controls.Add(this.btnKey2);
            this.pnlKeypadGrid.Controls.Add(this.btnKey1);
            this.pnlKeypadGrid.Location = new System.Drawing.Point(15, 50);
            this.pnlKeypadGrid.Name = "pnlKeypadGrid";
            this.pnlKeypadGrid.Size = new System.Drawing.Size(298, 345);
            this.pnlKeypadGrid.TabIndex = 1;
            // 
            // btnKeyEnter
            // 
            this.btnKeyEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnKeyEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeyEnter.FlatAppearance.BorderSize = 0;
            this.btnKeyEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyEnter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKeyEnter.ForeColor = System.Drawing.Color.White;
            this.btnKeyEnter.Location = new System.Drawing.Point(205, 260);
            this.btnKeyEnter.Name = "btnKeyEnter";
            this.btnKeyEnter.Size = new System.Drawing.Size(85, 65);
            this.btnKeyEnter.TabIndex = 11;
            this.btnKeyEnter.Text = "ENTER";
            this.btnKeyEnter.UseVisualStyleBackColor = false;
            // 
            // btnKey0
            // 
            this.btnKey0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey0.FlatAppearance.BorderSize = 0;
            this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey0.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey0.Location = new System.Drawing.Point(105, 260);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(85, 65);
            this.btnKey0.TabIndex = 10;
            this.btnKey0.Text = "0";
            this.btnKey0.UseVisualStyleBackColor = false;
            // 
            // btnKeyClear
            // 
            this.btnKeyClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.btnKeyClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeyClear.FlatAppearance.BorderSize = 0;
            this.btnKeyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKeyClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKeyClear.Location = new System.Drawing.Point(5, 260);
            this.btnKeyClear.Name = "btnKeyClear";
            this.btnKeyClear.Size = new System.Drawing.Size(85, 65);
            this.btnKeyClear.TabIndex = 9;
            this.btnKeyClear.Text = "CLEAR";
            this.btnKeyClear.UseVisualStyleBackColor = false;
            // 
            // btnKey9
            // 
            this.btnKey9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey9.FlatAppearance.BorderSize = 0;
            this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey9.Location = new System.Drawing.Point(205, 175);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(85, 65);
            this.btnKey9.TabIndex = 8;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = false;
            // 
            // btnKey8
            // 
            this.btnKey8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey8.FlatAppearance.BorderSize = 0;
            this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey8.Location = new System.Drawing.Point(105, 175);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(85, 65);
            this.btnKey8.TabIndex = 7;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = false;
            // 
            // btnKey7
            // 
            this.btnKey7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey7.FlatAppearance.BorderSize = 0;
            this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey7.Location = new System.Drawing.Point(5, 175);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(85, 65);
            this.btnKey7.TabIndex = 6;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = false;
            // 
            // btnKey6
            // 
            this.btnKey6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey6.FlatAppearance.BorderSize = 0;
            this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey6.Location = new System.Drawing.Point(205, 90);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(85, 65);
            this.btnKey6.TabIndex = 5;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = false;
            // 
            // btnKey5
            // 
            this.btnKey5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey5.FlatAppearance.BorderSize = 0;
            this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey5.Location = new System.Drawing.Point(105, 90);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(85, 65);
            this.btnKey5.TabIndex = 4;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = false;
            // 
            // btnKey4
            // 
            this.btnKey4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey4.FlatAppearance.BorderSize = 0;
            this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey4.Location = new System.Drawing.Point(5, 90);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(85, 65);
            this.btnKey4.TabIndex = 3;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = false;
            // 
            // btnKey3
            // 
            this.btnKey3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey3.FlatAppearance.BorderSize = 0;
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey3.Location = new System.Drawing.Point(205, 5);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(85, 65);
            this.btnKey3.TabIndex = 2;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = false;
            // 
            // btnKey2
            // 
            this.btnKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey2.FlatAppearance.BorderSize = 0;
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey2.Location = new System.Drawing.Point(105, 5);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(85, 65);
            this.btnKey2.TabIndex = 1;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = false;
            // 
            // btnKey1
            // 
            this.btnKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnKey1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKey1.FlatAppearance.BorderSize = 0;
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKey1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKey1.Location = new System.Drawing.Point(5, 5);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(85, 65);
            this.btnKey1.TabIndex = 0;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = false;
            // 
            // lblKeypadHeader
            // 
            this.lblKeypadHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeypadHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKeypadHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblKeypadHeader.Location = new System.Drawing.Point(12, 12);
            this.lblKeypadHeader.Name = "lblKeypadHeader";
            this.lblKeypadHeader.Size = new System.Drawing.Size(304, 25);
            this.lblKeypadHeader.TabIndex = 0;
            this.lblKeypadHeader.Text = "BÀN PHÍM SỐ CÂY ATM";
            this.lblKeypadHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKioskHeader
            // 
            this.pnlKioskHeader.Controls.Add(this.lblStatusBadge);
            this.pnlKioskHeader.Controls.Add(this.txtServerPort);
            this.pnlKioskHeader.Controls.Add(this.txtServerIp);
            this.pnlKioskHeader.Controls.Add(this.lblServerConfig);
            this.pnlKioskHeader.Controls.Add(this.lblKioskTitle);
            this.pnlKioskHeader.Controls.Add(this.lblDotGreen);
            this.pnlKioskHeader.Controls.Add(this.lblDotYellow);
            this.pnlKioskHeader.Controls.Add(this.lblDotRed);
            this.pnlKioskHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKioskHeader.Location = new System.Drawing.Point(16, 16);
            this.pnlKioskHeader.Name = "pnlKioskHeader";
            this.pnlKioskHeader.Size = new System.Drawing.Size(986, 36);
            this.pnlKioskHeader.TabIndex = 0;
            // 
            // lblStatusBadge
            // 
            this.lblStatusBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(78)))), ((int)(((byte)(59)))));
            this.lblStatusBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusBadge.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatusBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblStatusBadge.Location = new System.Drawing.Point(810, 5);
            this.lblStatusBadge.Name = "lblStatusBadge";
            this.lblStatusBadge.Size = new System.Drawing.Size(170, 26);
            this.lblStatusBadge.TabIndex = 7;
            this.lblStatusBadge.Text = "STATUS: CONNECTED";
            this.lblStatusBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServerPort
            // 
            this.txtServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServerPort.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtServerPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.txtServerPort.Location = new System.Drawing.Point(745, 7);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(45, 22);
            this.txtServerPort.TabIndex = 6;
            this.txtServerPort.Text = "8888";
            this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtServerIp
            // 
            this.txtServerIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtServerIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServerIp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtServerIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.txtServerIp.Location = new System.Drawing.Point(625, 7);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(110, 22);
            this.txtServerIp.TabIndex = 5;
            this.txtServerIp.Text = "127.0.0.1";
            this.txtServerIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblServerConfig
            // 
            this.lblServerConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerConfig.AutoSize = true;
            this.lblServerConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblServerConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblServerConfig.Location = new System.Drawing.Point(545, 10);
            this.lblServerConfig.Name = "lblServerConfig";
            this.lblServerConfig.Size = new System.Drawing.Size(70, 15);
            this.lblServerConfig.TabIndex = 4;
            this.lblServerConfig.Text = "Server Host:";
            // 
            // lblKioskTitle
            // 
            this.lblKioskTitle.AutoSize = true;
            this.lblKioskTitle.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKioskTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblKioskTitle.Location = new System.Drawing.Point(65, 9);
            this.lblKioskTitle.Name = "lblKioskTitle";
            this.lblKioskTitle.Size = new System.Drawing.Size(320, 17);
            this.lblKioskTitle.TabIndex = 3;
            this.lblKioskTitle.Text = "EPU BANK • ATM TERMINAL #01 (CAU GIAY)";
            // 
            // lblDotGreen
            // 
            this.lblDotGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblDotGreen.Location = new System.Drawing.Point(44, 11);
            this.lblDotGreen.Name = "lblDotGreen";
            this.lblDotGreen.Size = new System.Drawing.Size(12, 12);
            this.lblDotGreen.TabIndex = 2;
            // 
            // lblDotYellow
            // 
            this.lblDotYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.lblDotYellow.Location = new System.Drawing.Point(26, 11);
            this.lblDotYellow.Name = "lblDotYellow";
            this.lblDotYellow.Size = new System.Drawing.Size(12, 12);
            this.lblDotYellow.TabIndex = 1;
            // 
            // lblDotRed
            // 
            this.lblDotRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblDotRed.Location = new System.Drawing.Point(8, 11);
            this.lblDotRed.Name = "lblDotRed";
            this.lblDotRed.Size = new System.Drawing.Size(12, 12);
            this.lblDotRed.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1044, 660);
            this.Controls.Add(this.pnlKioskBezel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPU BANK - HỆ THỐNG CÂY ATM GIAO DỊCH TỰ ĐỘNG";
            this.pnlKioskBezel.ResumeLayout(false);
            this.pnlKioskBody.ResumeLayout(false);
            this.pnlHardwareKeypad.ResumeLayout(false);
            this.pnlCashTray.ResumeLayout(false);
            this.pnlCardSlot.ResumeLayout(false);
            this.pnlKeypadGrid.ResumeLayout(false);
            this.pnlKioskHeader.ResumeLayout(false);
            this.pnlKioskHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlKioskBezel;
        private System.Windows.Forms.Panel pnlKioskHeader;
        private System.Windows.Forms.Label lblDotRed;
        private System.Windows.Forms.Label lblDotYellow;
        private System.Windows.Forms.Label lblDotGreen;
        private System.Windows.Forms.Label lblKioskTitle;
        private System.Windows.Forms.Label lblServerConfig;
        public System.Windows.Forms.TextBox txtServerIp;
        public System.Windows.Forms.TextBox txtServerPort;
        public System.Windows.Forms.Label lblStatusBadge;
        private System.Windows.Forms.Panel pnlKioskBody;
        public System.Windows.Forms.Panel pnlScreenContainer;
        public System.Windows.Forms.Panel pnlHardwareKeypad;
        private System.Windows.Forms.Label lblKeypadHeader;
        private System.Windows.Forms.Panel pnlKeypadGrid;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKeyClear;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKeyEnter;
        private System.Windows.Forms.Panel pnlCardSlot;
        private System.Windows.Forms.Label lblCardSlot;
        private System.Windows.Forms.Panel pnlCashTray;
        public System.Windows.Forms.Label lblCashTray;
    }
}

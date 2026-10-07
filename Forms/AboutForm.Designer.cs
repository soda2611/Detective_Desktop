namespace _2611_WIN_B3.Forms
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnClose = new Button();
            lblHeader = new Label();
            pnlBottom = new Panel();
            btnResetLog = new Button();
            btnCredits = new Button();
            btnOpenGuide = new Button();
            btnOK = new Button();
            pnlMain = new Panel();
            grpAbout = new GroupBox();
            txtAboutContent = new RichTextBox();
            lblSubTitle = new Label();
            lblGameTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlMain.SuspendLayout();
            grpAbout.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(784, 52);
            pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(226, 232, 240);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.FromArgb(30, 41, 59);
            btnClose.Location = new Point(686, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(15, 30, 60);
            lblHeader.Location = new Point(14, 13);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(393, 25);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "ℹ️ GIỚI THIỆU TRÒ CHƠI — ABOUT GAME";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(btnResetLog);
            pnlBottom.Controls.Add(btnCredits);
            pnlBottom.Controls.Add(btnOpenGuide);
            pnlBottom.Controls.Add(btnOK);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 509);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(784, 52);
            pnlBottom.TabIndex = 2;
            // 
            // btnResetLog
            // 
            btnResetLog.BackColor = Color.FromArgb(220, 38, 38);
            btnResetLog.Cursor = Cursors.Hand;
            btnResetLog.FlatAppearance.BorderColor = Color.FromArgb(248, 113, 113);
            btnResetLog.FlatStyle = FlatStyle.Flat;
            btnResetLog.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetLog.ForeColor = Color.White;
            btnResetLog.Location = new Point(14, 10);
            btnResetLog.Name = "btnResetLog";
            btnResetLog.Size = new Size(220, 32);
            btnResetLog.TabIndex = 3;
            btnResetLog.Text = "🗑 Xóa file log & chơi lại từ đầu";
            btnResetLog.UseVisualStyleBackColor = false;
            btnResetLog.Click += btnResetLog_Click;
            // 
            // btnCredits
            // 
            btnCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCredits.BackColor = Color.FromArgb(235, 242, 250);
            btnCredits.Cursor = Cursors.Hand;
            btnCredits.FlatAppearance.BorderColor = Color.FromArgb(170, 195, 225);
            btnCredits.FlatStyle = FlatStyle.Flat;
            btnCredits.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnCredits.ForeColor = Color.FromArgb(180, 83, 9);
            btnCredits.Location = new Point(340, 10);
            btnCredits.Name = "btnCredits";
            btnCredits.Size = new Size(140, 32);
            btnCredits.TabIndex = 2;
            btnCredits.Text = "🎖️ Đội ngũ / Credits";
            btnCredits.UseVisualStyleBackColor = false;
            btnCredits.Click += btnCredits_Click;
            // 
            // btnOpenGuide
            // 
            btnOpenGuide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenGuide.BackColor = Color.FromArgb(235, 242, 250);
            btnOpenGuide.Cursor = Cursors.Hand;
            btnOpenGuide.FlatAppearance.BorderColor = Color.FromArgb(170, 195, 225);
            btnOpenGuide.FlatStyle = FlatStyle.Flat;
            btnOpenGuide.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnOpenGuide.ForeColor = Color.FromArgb(15, 45, 85);
            btnOpenGuide.Location = new Point(490, 10);
            btnOpenGuide.Name = "btnOpenGuide";
            btnOpenGuide.Size = new Size(160, 32);
            btnOpenGuide.TabIndex = 1;
            btnOpenGuide.Text = "📖 Mở Cẩm Nang";
            btnOpenGuide.UseVisualStyleBackColor = false;
            btnOpenGuide.Click += btnOpenGuide_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOK.BackColor = Color.FromArgb(22, 101, 52);
            btnOK.Cursor = Cursors.Hand;
            btnOK.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(660, 10);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(110, 32);
            btnOK.TabIndex = 0;
            btnOK.Text = "✓ Đóng";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(grpAbout);
            pnlMain.Controls.Add(lblSubTitle);
            pnlMain.Controls.Add(lblGameTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 52);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(14);
            pnlMain.Size = new Size(784, 457);
            pnlMain.TabIndex = 1;
            // 
            // grpAbout
            // 
            grpAbout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpAbout.BackColor = Color.White;
            grpAbout.Controls.Add(txtAboutContent);
            grpAbout.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpAbout.ForeColor = Color.FromArgb(15, 30, 60);
            grpAbout.Location = new Point(14, 75);
            grpAbout.Name = "grpAbout";
            grpAbout.Padding = new Padding(10);
            grpAbout.Size = new Size(756, 368);
            grpAbout.TabIndex = 2;
            grpAbout.TabStop = false;
            grpAbout.Text = "  THÔNG TIN DỰ ÁN & KIẾN THỨC LẬP TRÌNH WINDOWS  ";
            // 
            // txtAboutContent
            // 
            txtAboutContent.BackColor = Color.FromArgb(248, 250, 252);
            txtAboutContent.BorderStyle = BorderStyle.None;
            txtAboutContent.Dock = DockStyle.Fill;
            txtAboutContent.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtAboutContent.ForeColor = Color.FromArgb(30, 41, 59);
            txtAboutContent.Location = new Point(10, 25);
            txtAboutContent.Name = "txtAboutContent";
            txtAboutContent.ReadOnly = true;
            txtAboutContent.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtAboutContent.Size = new Size(736, 333);
            txtAboutContent.TabIndex = 0;
            txtAboutContent.Text = "";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubTitle.Location = new Point(14, 44);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(540, 21);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Case #001 — The Missing File | Version 1.0 (Windows Forms .NET 10 Edition)";
            // 
            // lblGameTitle
            // 
            lblGameTitle.AutoSize = true;
            lblGameTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblGameTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblGameTitle.Location = new Point(12, 10);
            lblGameTitle.Name = "lblGameTitle";
            lblGameTitle.Size = new Size(295, 35);
            lblGameTitle.TabIndex = 0;
            lblGameTitle.Text = "DESKTOP DETECTIVE";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(784, 561);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(680, 460);
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Giới Thiệu Trò Chơi — Desktop Detective";
            Load += AboutForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            grpAbout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Button btnClose;
        private Panel pnlBottom;
        private Button btnOK;
        private Button btnOpenGuide;
        private Button btnCredits;
        private Button btnResetLog;
        private Panel pnlMain;
        private Label lblGameTitle;
        private Label lblSubTitle;
        private GroupBox grpAbout;
        private RichTextBox txtAboutContent;
    }
}


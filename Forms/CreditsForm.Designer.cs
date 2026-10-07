namespace _2611_WIN_B3.Forms
{
    partial class CreditsForm
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
            lblHeader = new Label();
            pnlBottom = new Panel();
            btnOK = new Button();
            pnlMain = new Panel();
            grpCredits = new GroupBox();
            txtCredits = new RichTextBox();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlMain.SuspendLayout();
            grpCredits.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(740, 50);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(180, 83, 9);
            lblHeader.Location = new Point(14, 12);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(300, 25);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🎖️ ĐỘI NGŨ PHÁT TRIỂN & CREDITS";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(btnOK);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 480);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(740, 50);
            pnlBottom.TabIndex = 2;
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
            btnOK.Location = new Point(625, 9);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 32);
            btnOK.TabIndex = 0;
            btnOK.Text = "✓ Đóng";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnClose_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(grpCredits);
            pnlMain.Controls.Add(lblSubtitle);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 50);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(15);
            pnlMain.Size = new Size(740, 430);
            pnlMain.TabIndex = 1;
            // 
            // grpCredits
            // 
            grpCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpCredits.Controls.Add(txtCredits);
            grpCredits.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpCredits.ForeColor = Color.FromArgb(15, 30, 60);
            grpCredits.Location = new Point(15, 65);
            grpCredits.Name = "grpCredits";
            grpCredits.Padding = new Padding(10);
            grpCredits.Size = new Size(710, 350);
            grpCredits.TabIndex = 2;
            grpCredits.TabStop = false;
            grpCredits.Text = " THÔNG TIN DỰ ÁN & ĐỘI NGŨ THỰC HIỆN ";
            // 
            // txtCredits
            // 
            txtCredits.BackColor = Color.FromArgb(248, 250, 252);
            txtCredits.BorderStyle = BorderStyle.None;
            txtCredits.Dock = DockStyle.Fill;
            txtCredits.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCredits.ForeColor = Color.FromArgb(30, 41, 59);
            txtCredits.Location = new Point(10, 30);
            txtCredits.Name = "txtCredits";
            txtCredits.ReadOnly = true;
            txtCredits.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtCredits.Size = new Size(690, 310);
            txtCredits.TabIndex = 0;
            txtCredits.Text = "";
            txtCredits.WordWrap = true;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(15, 38);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(410, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Đồ án môn học: Lập trình Windows & Lập trình Hướng đối tượng";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(15, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(427, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DESKTOP DETECTIVE: THE MISSING FILE";
            // 
            // CreditsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(740, 530);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreditsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đội ngũ phát triển & Credits";
            Load += CreditsForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            grpCredits.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlBottom;
        private Button btnOK;
        private Panel pnlMain;
        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpCredits;
        private RichTextBox txtCredits;
    }
}


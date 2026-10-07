namespace _2611_WIN_B3.Forms
{
    partial class GuideForm
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
            lblTitle = new Label();
            pnlMain = new Panel();
            tabGuide = new TabControl();
            tabOverview = new TabPage();
            txtOverview = new RichTextBox();
            tabApps = new TabPage();
            txtApps = new RichTextBox();
            tabEvidence = new TabPage();
            txtEvidence = new RichTextBox();
            tabEndings = new TabPage();
            txtEndings = new RichTextBox();
            pnlBottom = new Panel();
            btnGotIt = new Button();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            tabGuide.SuspendLayout();
            tabOverview.SuspendLayout();
            tabApps.SuspendLayout();
            tabEvidence.SuspendLayout();
            tabEndings.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(840, 52);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(14, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(396, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📖 CẨM NANG ĐIỀU TRA — HƯỚNG DẪN CHƠI";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(tabGuide);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 52);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(12);
            pnlMain.Size = new Size(840, 480);
            pnlMain.TabIndex = 1;
            // 
            // tabGuide
            // 
            tabGuide.Controls.Add(tabOverview);
            tabGuide.Controls.Add(tabApps);
            tabGuide.Controls.Add(tabEvidence);
            tabGuide.Controls.Add(tabEndings);
            tabGuide.Dock = DockStyle.Fill;
            tabGuide.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabGuide.Location = new Point(12, 12);
            tabGuide.Name = "tabGuide";
            tabGuide.SelectedIndex = 0;
            tabGuide.Size = new Size(816, 456);
            tabGuide.TabIndex = 0;
            // 
            // tabOverview
            // 
            tabOverview.BackColor = Color.White;
            tabOverview.Controls.Add(txtOverview);
            tabOverview.Location = new Point(4, 29);
            tabOverview.Name = "tabOverview";
            tabOverview.Padding = new Padding(10);
            tabOverview.Size = new Size(808, 423);
            tabOverview.TabIndex = 0;
            tabOverview.Text = "1. Tổng Quan Vụ Án";
            // 
            // txtOverview
            // 
            txtOverview.BackColor = Color.FromArgb(248, 250, 252);
            txtOverview.BorderStyle = BorderStyle.None;
            txtOverview.Dock = DockStyle.Fill;
            txtOverview.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtOverview.ForeColor = Color.FromArgb(30, 41, 59);
            txtOverview.Location = new Point(10, 10);
            txtOverview.Name = "txtOverview";
            txtOverview.ReadOnly = true;
            txtOverview.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtOverview.Size = new Size(788, 403);
            txtOverview.TabIndex = 0;
            txtOverview.Text = "";
            // 
            // tabApps
            // 
            tabApps.BackColor = Color.White;
            tabApps.Controls.Add(txtApps);
            tabApps.Location = new Point(4, 29);
            tabApps.Name = "tabApps";
            tabApps.Padding = new Padding(10);
            tabApps.Size = new Size(808, 423);
            tabApps.TabIndex = 1;
            tabApps.Text = "2. Khám Phá Ứng Dụng";
            // 
            // txtApps
            // 
            txtApps.BackColor = Color.FromArgb(248, 250, 252);
            txtApps.BorderStyle = BorderStyle.None;
            txtApps.Dock = DockStyle.Fill;
            txtApps.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtApps.ForeColor = Color.FromArgb(30, 41, 59);
            txtApps.Location = new Point(10, 10);
            txtApps.Name = "txtApps";
            txtApps.ReadOnly = true;
            txtApps.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtApps.Size = new Size(788, 403);
            txtApps.TabIndex = 0;
            txtApps.Text = "";
            // 
            // tabEvidence
            // 
            tabEvidence.BackColor = Color.White;
            tabEvidence.Controls.Add(txtEvidence);
            tabEvidence.Location = new Point(4, 29);
            tabEvidence.Name = "tabEvidence";
            tabEvidence.Padding = new Padding(10);
            tabEvidence.Size = new Size(808, 423);
            tabEvidence.TabIndex = 2;
            tabEvidence.Text = "3. Evidence Board & Timeline";
            // 
            // txtEvidence
            // 
            txtEvidence.BackColor = Color.FromArgb(248, 250, 252);
            txtEvidence.BorderStyle = BorderStyle.None;
            txtEvidence.Dock = DockStyle.Fill;
            txtEvidence.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtEvidence.ForeColor = Color.FromArgb(30, 41, 59);
            txtEvidence.Location = new Point(10, 10);
            txtEvidence.Name = "txtEvidence";
            txtEvidence.ReadOnly = true;
            txtEvidence.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtEvidence.Size = new Size(788, 403);
            txtEvidence.TabIndex = 0;
            txtEvidence.Text = "";
            // 
            // tabEndings
            // 
            tabEndings.BackColor = Color.White;
            tabEndings.Controls.Add(txtEndings);
            tabEndings.Location = new Point(4, 29);
            tabEndings.Name = "tabEndings";
            tabEndings.Padding = new Padding(10);
            tabEndings.Size = new Size(808, 423);
            tabEndings.TabIndex = 3;
            tabEndings.Text = "4. Báo Cáo & 5 Kết Thúc (Endings)";
            // 
            // txtEndings
            // 
            txtEndings.BackColor = Color.FromArgb(248, 250, 252);
            txtEndings.BorderStyle = BorderStyle.None;
            txtEndings.Dock = DockStyle.Fill;
            txtEndings.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtEndings.ForeColor = Color.FromArgb(30, 41, 59);
            txtEndings.Location = new Point(10, 10);
            txtEndings.Name = "txtEndings";
            txtEndings.ReadOnly = true;
            txtEndings.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtEndings.Size = new Size(788, 403);
            txtEndings.TabIndex = 0;
            txtEndings.Text = "";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(btnGotIt);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 532);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(840, 50);
            pnlBottom.TabIndex = 2;
            // 
            // btnGotIt
            // 
            btnGotIt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGotIt.BackColor = Color.FromArgb(22, 101, 52);
            btnGotIt.Cursor = Cursors.Hand;
            btnGotIt.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnGotIt.FlatStyle = FlatStyle.Flat;
            btnGotIt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGotIt.ForeColor = Color.White;
            btnGotIt.Location = new Point(640, 9);
            btnGotIt.Name = "btnGotIt";
            btnGotIt.Size = new Size(188, 32);
            btnGotIt.TabIndex = 0;
            btnGotIt.Text = "✓ Đã hiểu, bắt đầu phá án";
            btnGotIt.UseVisualStyleBackColor = false;
            btnGotIt.Click += btnGotIt_Click;
            // 
            // GuideForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(840, 582);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(720, 480);
            Name = "GuideForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cẩm Nang Thám Tử — Hướng Dẫn Điều Tra";
            Load += GuideForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            tabGuide.ResumeLayout(false);
            tabOverview.ResumeLayout(false);
            tabApps.ResumeLayout(false);
            tabEvidence.ResumeLayout(false);
            tabEndings.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlMain;
        private TabControl tabGuide;
        private TabPage tabOverview;
        private RichTextBox txtOverview;
        private TabPage tabApps;
        private RichTextBox txtApps;
        private TabPage tabEvidence;
        private RichTextBox txtEvidence;
        private TabPage tabEndings;
        private RichTextBox txtEndings;
        private Panel pnlBottom;
        private Button btnGotIt;
    }
}


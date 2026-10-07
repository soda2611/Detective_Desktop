namespace _2611_WIN_B3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlDesktop = new Panel();
            pnlIconGuide = new Panel();
            lblGuide = new Label();
            picGuide = new PictureBox();
            grpCaseBrief = new GroupBox();
            btnStartInvestigation = new Button();
            cmsInvestigation = new ContextMenuStrip(components);
            tsmiPauseResume = new ToolStripMenuItem();
            tsmiSepInvest1 = new ToolStripSeparator();
            tsmiRestartCase = new ToolStripMenuItem();
            tsmiSepInvest2 = new ToolStripSeparator();
            tsmiHighScores = new ToolStripMenuItem();
            tsmiSelectCase = new ToolStripMenuItem();
            btnHighScores = new Button();
            btnSelectCase = new Button();
            txtCaseOverview = new RichTextBox();
            pnlIconCaseReport = new Panel();
            lblCaseReport = new Label();
            picCaseReport = new PictureBox();
            pnlIconEvidenceBoard = new Panel();
            lblEvidenceBoard = new Label();
            picEvidenceBoard = new PictureBox();
            pnlIconNotes = new Panel();
            lblNotes = new Label();
            picNotes = new PictureBox();
            pnlIconSearch = new Panel();
            lblSearch = new Label();
            picSearch = new PictureBox();
            pnlIconRecycleBin = new Panel();
            lblRecycleBin = new Label();
            picRecycleBin = new PictureBox();
            pnlIconMail = new Panel();
            lblMail = new Label();
            picMail = new PictureBox();
            pnlIconBrowser = new Panel();
            lblBrowser = new Label();
            picBrowser = new PictureBox();
            pnlIconDocuments = new Panel();
            lblDocuments = new Label();
            picDocuments = new PictureBox();
            desktopContextMenu = new ContextMenuStrip(components);
            tsRefresh = new ToolStripMenuItem();
            tsRestartCase = new ToolStripMenuItem();
            tsSep1 = new ToolStripSeparator();
            tsSelectCase = new ToolStripMenuItem();
            tsHighScores = new ToolStripMenuItem();
            tsOpenGuide = new ToolStripMenuItem();
            tsSep2 = new ToolStripSeparator();
            tsSaveGame = new ToolStripMenuItem();
            tsLoadGame = new ToolStripMenuItem();
            tsSep3 = new ToolStripSeparator();
            tsCredits = new ToolStripMenuItem();
            pnlTaskbar = new Panel();
            btnSoundToggle = new Button();
            lblCaseTimer = new Label();
            lblClock = new Label();
            lblNotification = new Label();
            pbEvidenceProgress = new ProgressBar();
            lblEvidenceCounter = new Label();
            lblVictimInfo = new Label();
            lblCaseTitle = new Label();
            systemTimer = new System.Windows.Forms.Timer(components);
            pnlDesktop.SuspendLayout();
            pnlIconGuide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGuide).BeginInit();
            grpCaseBrief.SuspendLayout();
            pnlIconCaseReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCaseReport).BeginInit();
            pnlIconEvidenceBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEvidenceBoard).BeginInit();
            pnlIconNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNotes).BeginInit();
            pnlIconSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlIconRecycleBin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRecycleBin).BeginInit();
            pnlIconMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMail).BeginInit();
            pnlIconBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBrowser).BeginInit();
            pnlIconDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDocuments).BeginInit();
            desktopContextMenu.SuspendLayout();
            pnlTaskbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDesktop
            // 
            pnlDesktop.BackColor = Color.FromArgb(232, 238, 245);
            pnlDesktop.ContextMenuStrip = desktopContextMenu;
            pnlDesktop.Controls.Add(pnlIconGuide);
            pnlDesktop.Controls.Add(grpCaseBrief);
            pnlDesktop.Controls.Add(pnlIconCaseReport);
            pnlDesktop.Controls.Add(pnlIconEvidenceBoard);
            pnlDesktop.Controls.Add(pnlIconNotes);
            pnlDesktop.Controls.Add(pnlIconSearch);
            pnlDesktop.Controls.Add(pnlIconRecycleBin);
            pnlDesktop.Controls.Add(pnlIconMail);
            pnlDesktop.Controls.Add(pnlIconBrowser);
            pnlDesktop.Controls.Add(pnlIconDocuments);
            pnlDesktop.Dock = DockStyle.Fill;
            pnlDesktop.Location = new Point(0, 0);
            pnlDesktop.Name = "pnlDesktop";
            pnlDesktop.Size = new Size(1004, 606);
            pnlDesktop.TabIndex = 0;
            // 
            // pnlIconGuide
            // 
            pnlIconGuide.BackColor = Color.Transparent;
            pnlIconGuide.Controls.Add(lblGuide);
            pnlIconGuide.Controls.Add(picGuide);
            pnlIconGuide.Cursor = Cursors.Hand;
            pnlIconGuide.Location = new Point(325, 295);
            pnlIconGuide.Name = "pnlIconGuide";
            pnlIconGuide.Size = new Size(125, 115);
            pnlIconGuide.TabIndex = 8;
            pnlIconGuide.DoubleClick += OpenGuide_Click;
            // 
            // lblGuide
            // 
            lblGuide.BackColor = Color.Transparent;
            lblGuide.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblGuide.ForeColor = Color.FromArgb(20, 60, 110);
            lblGuide.Location = new Point(0, 70);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(125, 38);
            lblGuide.TabIndex = 1;
            lblGuide.Text = "Cẩm Nang";
            lblGuide.TextAlign = ContentAlignment.TopCenter;
            lblGuide.DoubleClick += OpenGuide_Click;
            // 
            // picGuide
            // 
            picGuide.Image = (Image)resources.GetObject("picGuide.Image");
            picGuide.Location = new Point(34, 10);
            picGuide.Name = "picGuide";
            picGuide.Size = new Size(56, 56);
            picGuide.SizeMode = PictureBoxSizeMode.Zoom;
            picGuide.TabIndex = 0;
            picGuide.TabStop = false;
            picGuide.DoubleClick += OpenGuide_Click;
            // 
            // grpCaseBrief
            // 
            grpCaseBrief.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpCaseBrief.BackColor = Color.White;
            grpCaseBrief.Controls.Add(btnStartInvestigation);
            grpCaseBrief.Controls.Add(btnHighScores);
            grpCaseBrief.Controls.Add(btnSelectCase);
            grpCaseBrief.Controls.Add(txtCaseOverview);
            grpCaseBrief.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            grpCaseBrief.ForeColor = Color.FromArgb(15, 45, 80);
            grpCaseBrief.Location = new Point(480, 25);
            grpCaseBrief.Name = "grpCaseBrief";
            grpCaseBrief.Size = new Size(770, 530);
            grpCaseBrief.TabIndex = 10;
            grpCaseBrief.TabStop = false;
            grpCaseBrief.Text = "  HỒ SƠ VỤ ÁN / NHIỆM VỤ ĐIỀU TRA  ";
            // 
            // btnStartInvestigation
            // 
            btnStartInvestigation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStartInvestigation.BackColor = Color.FromArgb(22, 163, 74);
            btnStartInvestigation.Cursor = Cursors.Hand;
            btnStartInvestigation.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            btnStartInvestigation.FlatStyle = FlatStyle.Flat;
            btnStartInvestigation.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartInvestigation.ForeColor = Color.White;
            btnStartInvestigation.Location = new Point(25, 470);
            btnStartInvestigation.Name = "btnStartInvestigation";
            btnStartInvestigation.Size = new Size(185, 44);
            btnStartInvestigation.TabIndex = 4;
            btnStartInvestigation.Text = "▶ BẮT ĐẦU";
            btnStartInvestigation.UseVisualStyleBackColor = false;
            btnStartInvestigation.Click += btnStartInvestigation_Click;
            // 
            // cmsInvestigation
            // 
            cmsInvestigation.ImageScalingSize = new Size(20, 20);
            cmsInvestigation.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            cmsInvestigation.Items.AddRange(new ToolStripItem[] {
                tsmiPauseResume,
                tsmiSepInvest1,
                tsmiRestartCase,
                tsmiSepInvest2,
                tsmiHighScores,
                tsmiSelectCase
            });
            cmsInvestigation.Name = "cmsInvestigation";
            cmsInvestigation.Size = new Size(270, 160);
            // 
            // tsmiPauseResume
            // 
            tsmiPauseResume.Name = "tsmiPauseResume";
            tsmiPauseResume.Size = new Size(269, 28);
            tsmiPauseResume.Text = "⏸ Tạm dừng điều tra";
            tsmiPauseResume.Click += tsmiPauseResume_Click;
            // 
            // tsmiSepInvest1
            // 
            tsmiSepInvest1.Name = "tsmiSepInvest1";
            tsmiSepInvest1.Size = new Size(266, 6);
            // 
            // tsmiRestartCase
            // 
            tsmiRestartCase.Name = "tsmiRestartCase";
            tsmiRestartCase.Size = new Size(269, 28);
            tsmiRestartCase.Text = "🔄 Chơi lại vụ án từ đầu";
            tsmiRestartCase.Click += btnRestartCase_Click;
            // 
            // tsmiSepInvest2
            // 
            tsmiSepInvest2.Name = "tsmiSepInvest2";
            tsmiSepInvest2.Size = new Size(266, 6);
            // 
            // tsmiHighScores
            // 
            tsmiHighScores.Name = "tsmiHighScores";
            tsmiHighScores.Size = new Size(269, 28);
            tsmiHighScores.Text = "🏆 Bảng vàng thành tích";
            tsmiHighScores.Click += OpenHighScores_Click;
            // 
            // tsmiSelectCase
            // 
            tsmiSelectCase.Name = "tsmiSelectCase";
            tsmiSelectCase.Size = new Size(269, 28);
            tsmiSelectCase.Text = "📂 Chọn / Đổi màn chơi khác";
            tsmiSelectCase.Click += OpenCaseSelect_Click;
            // 
            // btnHighScores
            // 
            btnHighScores.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHighScores.BackColor = Color.FromArgb(224, 238, 255);
            btnHighScores.Cursor = Cursors.Hand;
            btnHighScores.FlatAppearance.BorderColor = Color.FromArgb(170, 205, 245);
            btnHighScores.FlatStyle = FlatStyle.Flat;
            btnHighScores.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnHighScores.ForeColor = Color.FromArgb(10, 65, 140);
            btnHighScores.Location = new Point(335, 470);
            btnHighScores.Name = "btnHighScores";
            btnHighScores.Size = new Size(205, 44);
            btnHighScores.TabIndex = 2;
            btnHighScores.Text = "🏆 Bảng thành tích";
            btnHighScores.UseVisualStyleBackColor = false;
            btnHighScores.Click += OpenHighScores_Click;
            // 
            // btnSelectCase
            // 
            btnSelectCase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectCase.BackColor = Color.FromArgb(235, 242, 250);
            btnSelectCase.Cursor = Cursors.Hand;
            btnSelectCase.FlatAppearance.BorderColor = Color.FromArgb(170, 195, 225);
            btnSelectCase.FlatStyle = FlatStyle.Flat;
            btnSelectCase.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnSelectCase.ForeColor = Color.FromArgb(15, 45, 85);
            btnSelectCase.Location = new Point(550, 470);
            btnSelectCase.Name = "btnSelectCase";
            btnSelectCase.Size = new Size(205, 44);
            btnSelectCase.TabIndex = 1;
            btnSelectCase.Text = "📂 Chọn / Đổi vụ án";
            btnSelectCase.UseVisualStyleBackColor = false;
            btnSelectCase.Click += OpenCaseSelect_Click;
            // 
            // txtCaseOverview
            // 
            txtCaseOverview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCaseOverview.BackColor = Color.FromArgb(248, 250, 252);
            txtCaseOverview.BorderStyle = BorderStyle.None;
            txtCaseOverview.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtCaseOverview.ForeColor = Color.FromArgb(30, 41, 59);
            txtCaseOverview.Location = new Point(18, 34);
            txtCaseOverview.Name = "txtCaseOverview";
            txtCaseOverview.ReadOnly = true;
            txtCaseOverview.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtCaseOverview.WordWrap = true;
            txtCaseOverview.Size = new Size(736, 420);
            txtCaseOverview.TabIndex = 0;
            txtCaseOverview.Text = "";
            // 
            // pnlIconCaseReport
            // 
            pnlIconCaseReport.BackColor = Color.Transparent;
            pnlIconCaseReport.Controls.Add(lblCaseReport);
            pnlIconCaseReport.Controls.Add(picCaseReport);
            pnlIconCaseReport.Cursor = Cursors.Hand;
            pnlIconCaseReport.Location = new Point(180, 295);
            pnlIconCaseReport.Name = "pnlIconCaseReport";
            pnlIconCaseReport.Size = new Size(125, 115);
            pnlIconCaseReport.TabIndex = 7;
            pnlIconCaseReport.DoubleClick += OpenCaseReport_Click;
            // 
            // lblCaseReport
            // 
            lblCaseReport.BackColor = Color.Transparent;
            lblCaseReport.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaseReport.ForeColor = Color.FromArgb(15, 30, 60);
            lblCaseReport.Location = new Point(0, 70);
            lblCaseReport.Name = "lblCaseReport";
            lblCaseReport.Size = new Size(125, 38);
            lblCaseReport.TabIndex = 1;
            lblCaseReport.Text = "Case Report";
            lblCaseReport.TextAlign = ContentAlignment.TopCenter;
            lblCaseReport.DoubleClick += OpenCaseReport_Click;
            // 
            // picCaseReport
            // 
            picCaseReport.Image = (Image)resources.GetObject("picCaseReport.Image");
            picCaseReport.Location = new Point(34, 10);
            picCaseReport.Name = "picCaseReport";
            picCaseReport.Size = new Size(56, 56);
            picCaseReport.SizeMode = PictureBoxSizeMode.Zoom;
            picCaseReport.TabIndex = 0;
            picCaseReport.TabStop = false;
            picCaseReport.DoubleClick += OpenCaseReport_Click;
            // 
            // pnlIconEvidenceBoard
            // 
            pnlIconEvidenceBoard.BackColor = Color.Transparent;
            pnlIconEvidenceBoard.Controls.Add(lblEvidenceBoard);
            pnlIconEvidenceBoard.Controls.Add(picEvidenceBoard);
            pnlIconEvidenceBoard.Cursor = Cursors.Hand;
            pnlIconEvidenceBoard.Location = new Point(35, 295);
            pnlIconEvidenceBoard.Name = "pnlIconEvidenceBoard";
            pnlIconEvidenceBoard.Size = new Size(125, 115);
            pnlIconEvidenceBoard.TabIndex = 6;
            pnlIconEvidenceBoard.DoubleClick += OpenEvidenceBoard_Click;
            // 
            // lblEvidenceBoard
            // 
            lblEvidenceBoard.BackColor = Color.Transparent;
            lblEvidenceBoard.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblEvidenceBoard.ForeColor = Color.FromArgb(15, 30, 60);
            lblEvidenceBoard.Location = new Point(0, 70);
            lblEvidenceBoard.Name = "lblEvidenceBoard";
            lblEvidenceBoard.Size = new Size(125, 38);
            lblEvidenceBoard.TabIndex = 1;
            lblEvidenceBoard.Text = "Evidence Board";
            lblEvidenceBoard.TextAlign = ContentAlignment.TopCenter;
            lblEvidenceBoard.DoubleClick += OpenEvidenceBoard_Click;
            // 
            // picEvidenceBoard
            // 
            picEvidenceBoard.Image = (Image)resources.GetObject("picEvidenceBoard.Image");
            picEvidenceBoard.Location = new Point(34, 10);
            picEvidenceBoard.Name = "picEvidenceBoard";
            picEvidenceBoard.Size = new Size(56, 56);
            picEvidenceBoard.SizeMode = PictureBoxSizeMode.Zoom;
            picEvidenceBoard.TabIndex = 0;
            picEvidenceBoard.TabStop = false;
            picEvidenceBoard.DoubleClick += OpenEvidenceBoard_Click;
            // 
            // pnlIconNotes
            // 
            pnlIconNotes.BackColor = Color.Transparent;
            pnlIconNotes.Controls.Add(lblNotes);
            pnlIconNotes.Controls.Add(picNotes);
            pnlIconNotes.Cursor = Cursors.Hand;
            pnlIconNotes.Location = new Point(325, 160);
            pnlIconNotes.Name = "pnlIconNotes";
            pnlIconNotes.Size = new Size(125, 115);
            pnlIconNotes.TabIndex = 5;
            pnlIconNotes.DoubleClick += OpenNotes_Click;
            // 
            // lblNotes
            // 
            lblNotes.BackColor = Color.Transparent;
            lblNotes.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblNotes.ForeColor = Color.FromArgb(15, 30, 60);
            lblNotes.Location = new Point(0, 70);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(125, 38);
            lblNotes.TabIndex = 1;
            lblNotes.Text = "Notes";
            lblNotes.TextAlign = ContentAlignment.TopCenter;
            lblNotes.DoubleClick += OpenNotes_Click;
            // 
            // picNotes
            // 
            picNotes.Image = (Image)resources.GetObject("picNotes.Image");
            picNotes.Location = new Point(34, 10);
            picNotes.Name = "picNotes";
            picNotes.Size = new Size(56, 56);
            picNotes.SizeMode = PictureBoxSizeMode.Zoom;
            picNotes.TabIndex = 0;
            picNotes.TabStop = false;
            picNotes.DoubleClick += OpenNotes_Click;
            // 
            // pnlIconSearch
            // 
            pnlIconSearch.BackColor = Color.Transparent;
            pnlIconSearch.Controls.Add(lblSearch);
            pnlIconSearch.Controls.Add(picSearch);
            pnlIconSearch.Cursor = Cursors.Hand;
            pnlIconSearch.Location = new Point(180, 160);
            pnlIconSearch.Name = "pnlIconSearch";
            pnlIconSearch.Size = new Size(125, 115);
            pnlIconSearch.TabIndex = 4;
            pnlIconSearch.DoubleClick += OpenSearch_Click;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblSearch.ForeColor = Color.FromArgb(15, 30, 60);
            lblSearch.Location = new Point(0, 70);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(125, 38);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            lblSearch.TextAlign = ContentAlignment.TopCenter;
            lblSearch.DoubleClick += OpenSearch_Click;
            // 
            // picSearch
            // 
            picSearch.Image = (Image)resources.GetObject("picSearch.Image");
            picSearch.Location = new Point(34, 10);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(56, 56);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 0;
            picSearch.TabStop = false;
            picSearch.DoubleClick += OpenSearch_Click;
            // 
            // pnlIconRecycleBin
            // 
            pnlIconRecycleBin.BackColor = Color.Transparent;
            pnlIconRecycleBin.Controls.Add(lblRecycleBin);
            pnlIconRecycleBin.Controls.Add(picRecycleBin);
            pnlIconRecycleBin.Cursor = Cursors.Hand;
            pnlIconRecycleBin.Location = new Point(35, 160);
            pnlIconRecycleBin.Name = "pnlIconRecycleBin";
            pnlIconRecycleBin.Size = new Size(125, 115);
            pnlIconRecycleBin.TabIndex = 3;
            pnlIconRecycleBin.DoubleClick += OpenRecycleBin_Click;
            // 
            // lblRecycleBin
            // 
            lblRecycleBin.BackColor = Color.Transparent;
            lblRecycleBin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecycleBin.ForeColor = Color.FromArgb(15, 30, 60);
            lblRecycleBin.Location = new Point(0, 70);
            lblRecycleBin.Name = "lblRecycleBin";
            lblRecycleBin.Size = new Size(125, 38);
            lblRecycleBin.TabIndex = 1;
            lblRecycleBin.Text = "Recycle Bin";
            lblRecycleBin.TextAlign = ContentAlignment.TopCenter;
            lblRecycleBin.DoubleClick += OpenRecycleBin_Click;
            // 
            // picRecycleBin
            // 
            picRecycleBin.Image = (Image)resources.GetObject("picRecycleBin.Image");
            picRecycleBin.Location = new Point(34, 10);
            picRecycleBin.Name = "picRecycleBin";
            picRecycleBin.Size = new Size(56, 56);
            picRecycleBin.SizeMode = PictureBoxSizeMode.Zoom;
            picRecycleBin.TabIndex = 0;
            picRecycleBin.TabStop = false;
            picRecycleBin.DoubleClick += OpenRecycleBin_Click;
            // 
            // pnlIconMail
            // 
            pnlIconMail.BackColor = Color.Transparent;
            pnlIconMail.Controls.Add(lblMail);
            pnlIconMail.Controls.Add(picMail);
            pnlIconMail.Cursor = Cursors.Hand;
            pnlIconMail.Location = new Point(325, 25);
            pnlIconMail.Name = "pnlIconMail";
            pnlIconMail.Size = new Size(125, 115);
            pnlIconMail.TabIndex = 2;
            pnlIconMail.DoubleClick += OpenMail_Click;
            // 
            // lblMail
            // 
            lblMail.BackColor = Color.Transparent;
            lblMail.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblMail.ForeColor = Color.FromArgb(15, 30, 60);
            lblMail.Location = new Point(0, 70);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(125, 38);
            lblMail.TabIndex = 1;
            lblMail.Text = "Mail";
            lblMail.TextAlign = ContentAlignment.TopCenter;
            lblMail.DoubleClick += OpenMail_Click;
            // 
            // picMail
            // 
            picMail.Image = (Image)resources.GetObject("picMail.Image");
            picMail.Location = new Point(34, 10);
            picMail.Name = "picMail";
            picMail.Size = new Size(56, 56);
            picMail.SizeMode = PictureBoxSizeMode.Zoom;
            picMail.TabIndex = 0;
            picMail.TabStop = false;
            picMail.DoubleClick += OpenMail_Click;
            // 
            // pnlIconBrowser
            // 
            pnlIconBrowser.BackColor = Color.Transparent;
            pnlIconBrowser.Controls.Add(lblBrowser);
            pnlIconBrowser.Controls.Add(picBrowser);
            pnlIconBrowser.Cursor = Cursors.Hand;
            pnlIconBrowser.Location = new Point(180, 25);
            pnlIconBrowser.Name = "pnlIconBrowser";
            pnlIconBrowser.Size = new Size(125, 115);
            pnlIconBrowser.TabIndex = 1;
            pnlIconBrowser.DoubleClick += OpenBrowser_Click;
            // 
            // lblBrowser
            // 
            lblBrowser.BackColor = Color.Transparent;
            lblBrowser.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblBrowser.ForeColor = Color.FromArgb(15, 30, 60);
            lblBrowser.Location = new Point(0, 70);
            lblBrowser.Name = "lblBrowser";
            lblBrowser.Size = new Size(125, 38);
            lblBrowser.TabIndex = 1;
            lblBrowser.Text = "Browser";
            lblBrowser.TextAlign = ContentAlignment.TopCenter;
            lblBrowser.DoubleClick += OpenBrowser_Click;
            // 
            // picBrowser
            // 
            picBrowser.Image = (Image)resources.GetObject("picBrowser.Image");
            picBrowser.Location = new Point(34, 10);
            picBrowser.Name = "picBrowser";
            picBrowser.Size = new Size(56, 56);
            picBrowser.SizeMode = PictureBoxSizeMode.Zoom;
            picBrowser.TabIndex = 0;
            picBrowser.TabStop = false;
            picBrowser.DoubleClick += OpenBrowser_Click;
            // 
            // pnlIconDocuments
            // 
            pnlIconDocuments.BackColor = Color.Transparent;
            pnlIconDocuments.Controls.Add(lblDocuments);
            pnlIconDocuments.Controls.Add(picDocuments);
            pnlIconDocuments.Cursor = Cursors.Hand;
            pnlIconDocuments.Location = new Point(35, 25);
            pnlIconDocuments.Name = "pnlIconDocuments";
            pnlIconDocuments.Size = new Size(125, 115);
            pnlIconDocuments.TabIndex = 0;
            pnlIconDocuments.DoubleClick += OpenDocuments_Click;
            // 
            // lblDocuments
            // 
            lblDocuments.BackColor = Color.Transparent;
            lblDocuments.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblDocuments.ForeColor = Color.FromArgb(15, 30, 60);
            lblDocuments.Location = new Point(0, 70);
            lblDocuments.Name = "lblDocuments";
            lblDocuments.Size = new Size(125, 38);
            lblDocuments.TabIndex = 1;
            lblDocuments.Text = "Documents";
            lblDocuments.TextAlign = ContentAlignment.TopCenter;
            lblDocuments.DoubleClick += OpenDocuments_Click;
            // 
            // picDocuments
            // 
            picDocuments.Image = (Image)resources.GetObject("picDocuments.Image");
            picDocuments.Location = new Point(34, 10);
            picDocuments.Name = "picDocuments";
            picDocuments.Size = new Size(56, 56);
            picDocuments.SizeMode = PictureBoxSizeMode.Zoom;
            picDocuments.TabIndex = 0;
            picDocuments.TabStop = false;
            picDocuments.DoubleClick += OpenDocuments_Click;
            // 
            // desktopContextMenu
            // 
            desktopContextMenu.ImageScalingSize = new Size(20, 20);
            desktopContextMenu.Items.AddRange(new ToolStripItem[] {
                tsRefresh,
                tsRestartCase,
                tsSep1,
                tsSelectCase,
                tsHighScores,
                tsOpenGuide,
                tsSep2,
                tsSaveGame,
                tsLoadGame,
                tsSep3,
                tsCredits
            });
            desktopContextMenu.Name = "desktopContextMenu";
            desktopContextMenu.Size = new Size(255, 290);
            // 
            // tsRefresh
            // 
            tsRefresh.Name = "tsRefresh";
            tsRefresh.Size = new Size(254, 24);
            tsRefresh.Text = "🔄 Làm mới màn hình";
            tsRefresh.Click += tsRefresh_Click;
            // 
            // tsRestartCase
            // 
            tsRestartCase.Name = "tsRestartCase";
            tsRestartCase.Size = new Size(254, 24);
            tsRestartCase.Text = "🔄 Chơi lại vụ án này";
            tsRestartCase.Click += btnRestartCase_Click;
            // 
            // tsSep1
            // 
            tsSep1.Name = "tsSep1";
            tsSep1.Size = new Size(251, 6);
            // 
            // tsSelectCase
            // 
            tsSelectCase.Name = "tsSelectCase";
            tsSelectCase.Size = new Size(254, 24);
            tsSelectCase.Text = "📂 Chọn / Đổi màn chơi vụ án";
            tsSelectCase.Click += OpenCaseSelect_Click;
            // 
            // tsHighScores
            // 
            tsHighScores.Name = "tsHighScores";
            tsHighScores.Size = new Size(254, 24);
            tsHighScores.Text = "🏆 Bảng vàng thành tích (High Scores)";
            tsHighScores.Click += OpenHighScores_Click;
            // 
            // tsOpenGuide
            // 
            tsOpenGuide.Name = "tsOpenGuide";
            tsOpenGuide.Size = new Size(254, 24);
            tsOpenGuide.Text = "📖 Hướng dẫn chơi game";
            tsOpenGuide.Click += OpenGuide_Click;
            // 
            // tsSep2
            // 
            tsSep2.Name = "tsSep2";
            tsSep2.Size = new Size(251, 6);
            // 
            // tsSaveGame
            // 
            tsSaveGame.Name = "tsSaveGame";
            tsSaveGame.Size = new Size(254, 24);
            tsSaveGame.Text = "💾 Lưu tiến trình (Save Game)";
            tsSaveGame.Click += tsSaveGame_Click;
            // 
            // tsLoadGame
            // 
            tsLoadGame.Name = "tsLoadGame";
            tsLoadGame.Size = new Size(254, 24);
            tsLoadGame.Text = "📂 Tải tiến trình (Load Game)";
            tsLoadGame.Click += tsLoadGame_Click;
            // 
            // tsSep3
            // 
            tsSep3.Name = "tsSep3";
            tsSep3.Size = new Size(251, 6);
            // 
            // tsCredits
            // 
            tsCredits.Name = "tsCredits";
            tsCredits.Size = new Size(254, 24);
            tsCredits.Text = "🎖️ Đội ngũ phát triển (Credits)";
            tsCredits.Click += tsCredits_Click;
            // 
            // pnlTaskbar
            // 
            pnlTaskbar.BackColor = Color.FromArgb(240, 244, 250);
            pnlTaskbar.Controls.Add(btnSoundToggle);
            pnlTaskbar.Controls.Add(lblCaseTimer);
            pnlTaskbar.Controls.Add(lblClock);
            pnlTaskbar.Controls.Add(lblNotification);
            pnlTaskbar.Controls.Add(pbEvidenceProgress);
            pnlTaskbar.Controls.Add(lblEvidenceCounter);
            pnlTaskbar.Controls.Add(lblVictimInfo);
            pnlTaskbar.Controls.Add(lblCaseTitle);
            pnlTaskbar.Dock = DockStyle.Bottom;
            pnlTaskbar.Location = new Point(0, 642);
            pnlTaskbar.Name = "pnlTaskbar";
            pnlTaskbar.Size = new Size(1280, 118);
            pnlTaskbar.TabIndex = 1;
            // 
            // btnSoundToggle
            // 
            btnSoundToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSoundToggle.BackColor = Color.FromArgb(235, 242, 250);
            btnSoundToggle.Cursor = Cursors.Hand;
            btnSoundToggle.FlatAppearance.BorderColor = Color.FromArgb(170, 195, 225);
            btnSoundToggle.FlatStyle = FlatStyle.Flat;
            btnSoundToggle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnSoundToggle.ForeColor = Color.FromArgb(20, 60, 110);
            btnSoundToggle.Location = new Point(1005, 17);
            btnSoundToggle.Name = "btnSoundToggle";
            btnSoundToggle.Size = new Size(125, 40);
            btnSoundToggle.TabIndex = 6;
            btnSoundToggle.Text = "🔊 Âm: Bật";
            btnSoundToggle.UseVisualStyleBackColor = false;
            btnSoundToggle.Click += btnSoundToggle_Click;
            // 
            // lblCaseTimer
            // 
            lblCaseTimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaseTimer.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaseTimer.ForeColor = Color.FromArgb(16, 95, 175);
            lblCaseTimer.Location = new Point(1135, 38);
            lblCaseTimer.Name = "lblCaseTimer";
            lblCaseTimer.Size = new Size(140, 28);
            lblCaseTimer.TabIndex = 7;
            lblCaseTimer.Text = "⏱ 00:00";
            lblCaseTimer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblClock
            // 
            lblClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClock.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblClock.ForeColor = Color.FromArgb(20, 35, 60);
            lblClock.Location = new Point(1135, 10);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(140, 26);
            lblClock.TabIndex = 5;
            lblClock.Text = "21:00:00";
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNotification
            // 
            lblNotification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNotification.AutoEllipsis = true;
            lblNotification.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNotification.ForeColor = Color.FromArgb(40, 55, 75);
            lblNotification.Location = new Point(490, 10);
            lblNotification.Name = "lblNotification";
            lblNotification.Size = new Size(505, 52);
            lblNotification.TabIndex = 4;
            lblNotification.Text = "";
            lblNotification.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbEvidenceProgress
            // 
            pbEvidenceProgress.Location = new Point(16, 10);
            pbEvidenceProgress.Maximum = 8;
            pbEvidenceProgress.Name = "pbEvidenceProgress";
            pbEvidenceProgress.Size = new Size(260, 14);
            pbEvidenceProgress.TabIndex = 3;
            // 
            // lblEvidenceCounter
            // 
            lblEvidenceCounter.AutoSize = true;
            lblEvidenceCounter.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblEvidenceCounter.ForeColor = Color.FromArgb(16, 95, 175);
            lblEvidenceCounter.Location = new Point(285, 5);
            lblEvidenceCounter.Name = "lblEvidenceCounter";
            lblEvidenceCounter.Size = new Size(200, 25);
            lblEvidenceCounter.TabIndex = 2;
            lblEvidenceCounter.Text = "Bằng chứng: 0 / 8 (0%)";
            // 
            // lblCaseTitle
            // 
            lblCaseTitle.AutoSize = true;
            lblCaseTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaseTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblCaseTitle.Location = new Point(16, 26);
            lblCaseTitle.Name = "lblCaseTitle";
            lblCaseTitle.Size = new Size(239, 28);
            lblCaseTitle.TabIndex = 0;
            lblCaseTitle.Text = "Đang tải hồ sơ vụ án...";
            // 
            // lblVictimInfo
            // 
            lblVictimInfo.AutoSize = true;
            lblVictimInfo.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblVictimInfo.ForeColor = Color.FromArgb(80, 95, 115);
            lblVictimInfo.Location = new Point(16, 49);
            lblVictimInfo.Name = "lblVictimInfo";
            lblVictimInfo.Size = new Size(244, 24);
            lblVictimInfo.TabIndex = 1;
            lblVictimInfo.Text = "Nạn nhân: Đang nạp... | Mục tiêu: Đang nạp...";
            // 
            // systemTimer
            // 
            systemTimer.Enabled = true;
            systemTimer.Interval = 1000;
            systemTimer.Tick += systemTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 238, 245);
            ClientSize = new Size(1280, 760);
            Controls.Add(pnlDesktop);
            Controls.Add(pnlTaskbar);
            MinimumSize = new Size(1024, 680);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Desktop Detective — Case #001: The Missing File";
            Load += Form1_Load;
            pnlDesktop.ResumeLayout(false);
            pnlIconGuide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGuide).EndInit();
            grpCaseBrief.ResumeLayout(false);
            pnlIconCaseReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCaseReport).EndInit();
            pnlIconEvidenceBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picEvidenceBoard).EndInit();
            pnlIconNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNotes).EndInit();
            pnlIconSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlIconRecycleBin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRecycleBin).EndInit();
            pnlIconMail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMail).EndInit();
            pnlIconBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBrowser).EndInit();
            pnlIconDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDocuments).EndInit();
            desktopContextMenu.ResumeLayout(false);
            pnlTaskbar.ResumeLayout(false);
            pnlTaskbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDesktop;
        private Panel pnlTaskbar;
        private Label lblCaseTitle;
        private Label lblVictimInfo;
        private Label lblEvidenceCounter;
        private ProgressBar pbEvidenceProgress;
        private Label lblNotification;
        private Label lblClock;
        private System.Windows.Forms.Timer systemTimer;
        private Panel pnlIconDocuments;
        private PictureBox picDocuments;
        private Label lblDocuments;
        private Panel pnlIconBrowser;
        private PictureBox picBrowser;
        private Label lblBrowser;
        private Panel pnlIconMail;
        private PictureBox picMail;
        private Label lblMail;
        private Panel pnlIconRecycleBin;
        private PictureBox picRecycleBin;
        private Label lblRecycleBin;
        private Panel pnlIconSearch;
        private PictureBox picSearch;
        private Label lblSearch;
        private Panel pnlIconNotes;
        private PictureBox picNotes;
        private Label lblNotes;
        private Panel pnlIconEvidenceBoard;
        private PictureBox picEvidenceBoard;
        private Label lblEvidenceBoard;
        private Panel pnlIconCaseReport;
        private PictureBox picCaseReport;
        private Label lblCaseReport;
        private Panel pnlIconGuide;
        private PictureBox picGuide;
        private Label lblGuide;
        private GroupBox grpCaseBrief;
        private RichTextBox txtCaseOverview;
        private Button btnStartInvestigation;
        private Button btnSelectCase;
        private Button btnHighScores;
        private ContextMenuStrip cmsInvestigation;
        private ToolStripMenuItem tsmiPauseResume;
        private ToolStripSeparator tsmiSepInvest1;
        private ToolStripMenuItem tsmiRestartCase;
        private ToolStripSeparator tsmiSepInvest2;
        private ToolStripMenuItem tsmiHighScores;
        private ToolStripMenuItem tsmiSelectCase;
        private ContextMenuStrip desktopContextMenu;
        private ToolStripMenuItem tsRefresh;
        private ToolStripMenuItem tsRestartCase;
        private ToolStripSeparator tsSep1;
        private ToolStripMenuItem tsSelectCase;
        private ToolStripMenuItem tsHighScores;
        private ToolStripMenuItem tsOpenGuide;
        private ToolStripSeparator tsSep2;
        private ToolStripMenuItem tsSaveGame;
        private ToolStripMenuItem tsLoadGame;
        private ToolStripSeparator tsSep3;
        private ToolStripMenuItem tsCredits;
        private Label lblCaseTimer;
        private Button btnSoundToggle;
    }
}


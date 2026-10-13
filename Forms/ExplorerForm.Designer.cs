namespace _2611_WIN_B3.Forms
{
    partial class ExplorerForm
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
            txtPath = new TextBox();
            lblPath = new Label();
            lblTitle = new Label();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            tvFolders = new TreeView();
            lblFoldersHeader = new Label();
            splitContainerPreview = new SplitContainer();
            lvFiles = new ListView();
            colName = new ColumnHeader();
            colFolder = new ColumnHeader();
            colSize = new ColumnHeader();
            colModified = new ColumnHeader();
            grpPreview = new GroupBox();
            lblFileClue = new Label();
            txtFilePreview = new RichTextBox();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPreview).BeginInit();
            splitContainerPreview.Panel1.SuspendLayout();
            splitContainerPreview.Panel2.SuspendLayout();
            splitContainerPreview.SuspendLayout();
            grpPreview.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(txtPath);
            pnlHeader.Controls.Add(lblPath);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1060, 68);
            pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(226, 232, 240);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(30, 41, 59);
            btnClose.Location = new Point(955, 12);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(92, 34);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.BackColor = Color.White;
            txtPath.BorderStyle = BorderStyle.FixedSingle;
            txtPath.Font = new Font("Segoe UI", 10.5F);
            txtPath.ForeColor = Color.FromArgb(15, 23, 42);
            txtPath.Location = new Point(105, 36);
            txtPath.Margin = new Padding(3, 2, 3, 2);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(835, 27);
            txtPath.TabIndex = 2;
            txtPath.Text = "C:\\Users\\DavidMiller\\Documents";
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPath.ForeColor = Color.FromArgb(100, 116, 139);
            lblPath.Location = new Point(12, 38);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(85, 20);
            lblPath.TabIndex = 1;
            lblPath.Text = "Đường dẫn:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(12, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(410, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📁 FILE EXPLORER — QUẢN LÝ TẬP TIN MÁY TÍNH";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 56);
            pnlMain.Margin = new Padding(3, 2, 3, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(9, 8, 9, 8);
            pnlMain.Size = new Size(805, 365);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(9, 8);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvFolders);
            splitContainer1.Panel1.Controls.Add(lblFoldersHeader);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainerPreview);
            splitContainer1.Size = new Size(1042, 576);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // tvFolders
            // 
            tvFolders.BackColor = Color.White;
            tvFolders.BorderStyle = BorderStyle.FixedSingle;
            tvFolders.Dock = DockStyle.Fill;
            tvFolders.ForeColor = Color.FromArgb(30, 41, 59);
            tvFolders.LineColor = Color.FromArgb(148, 163, 184);
            tvFolders.Location = new Point(0, 22);
            tvFolders.Margin = new Padding(3, 2, 3, 2);
            tvFolders.Name = "tvFolders";
            tvFolders.Size = new Size(250, 554);
            tvFolders.TabIndex = 1;
            tvFolders.AfterSelect += tvFolders_AfterSelect;
            // 
            // lblFoldersHeader
            // 
            lblFoldersHeader.Dock = DockStyle.Top;
            lblFoldersHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFoldersHeader.ForeColor = Color.FromArgb(51, 65, 85);
            lblFoldersHeader.Location = new Point(0, 0);
            lblFoldersHeader.Name = "lblFoldersHeader";
            lblFoldersHeader.Size = new Size(250, 22);
            lblFoldersHeader.TabIndex = 0;
            lblFoldersHeader.Text = "Thư mục hệ thống";
            lblFoldersHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainerPreview
            // 
            splitContainerPreview.Dock = DockStyle.Fill;
            splitContainerPreview.Location = new Point(0, 0);
            splitContainerPreview.Margin = new Padding(3, 2, 3, 2);
            splitContainerPreview.Name = "splitContainerPreview";
            splitContainerPreview.Orientation = Orientation.Horizontal;
            // 
            // splitContainerPreview.Panel1
            // 
            splitContainerPreview.Panel1.Controls.Add(lvFiles);
            // 
            // splitContainerPreview.Panel2
            // 
            splitContainerPreview.Panel2.Controls.Add(grpPreview);
            splitContainerPreview.Size = new Size(788, 576);
            splitContainerPreview.SplitterDistance = 280;
            splitContainerPreview.SplitterWidth = 3;
            splitContainerPreview.TabIndex = 0;
            // 
            // lvFiles
            // 
            lvFiles.BackColor = Color.White;
            lvFiles.BorderStyle = BorderStyle.FixedSingle;
            lvFiles.Columns.AddRange(new ColumnHeader[] { colName, colFolder, colSize, colModified });
            lvFiles.Dock = DockStyle.Fill;
            lvFiles.ForeColor = Color.FromArgb(30, 41, 59);
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.Location = new Point(0, 0);
            lvFiles.Margin = new Padding(3, 2, 3, 2);
            lvFiles.MultiSelect = false;
            lvFiles.Name = "lvFiles";
            lvFiles.Size = new Size(574, 164);
            lvFiles.TabIndex = 0;
            lvFiles.UseCompatibleStateImageBehavior = false;
            lvFiles.View = View.Details;
            lvFiles.SelectedIndexChanged += lvFiles_SelectedIndexChanged;
            lvFiles.DoubleClick += lvFiles_DoubleClick;
            // 
            // colName
            // 
            colName.Text = "Tên tệp / Thư mục";
            colName.Width = 280;
            // 
            // colFolder
            // 
            colFolder.Text = "Thư mục";
            colFolder.Width = 190;
            // 
            // colSize
            // 
            colSize.Text = "Kích thước";
            colSize.Width = 110;
            // 
            // colModified
            // 
            colModified.Text = "Thời gian sửa đổi";
            colModified.Width = 180;
            // 
            // grpPreview
            // 
            grpPreview.BackColor = Color.White;
            grpPreview.Controls.Add(lblFileClue);
            grpPreview.Controls.Add(txtFilePreview);
            grpPreview.Dock = DockStyle.Fill;
            grpPreview.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpPreview.ForeColor = Color.FromArgb(15, 30, 60);
            grpPreview.Location = new Point(0, 0);
            grpPreview.Margin = new Padding(3, 2, 3, 2);
            grpPreview.Name = "grpPreview";
            grpPreview.Padding = new Padding(9, 8, 9, 8);
            grpPreview.Size = new Size(574, 182);
            grpPreview.TabIndex = 0;
            grpPreview.TabStop = false;
            grpPreview.Text = "  XEM TRƯỚC NỘI DUNG TẬP TIN  ";
            // 
            // lblFileClue
            // 
            lblFileClue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFileClue.BackColor = Color.FromArgb(240, 253, 244);
            lblFileClue.BorderStyle = BorderStyle.FixedSingle;
            lblFileClue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFileClue.ForeColor = Color.FromArgb(22, 101, 52);
            lblFileClue.Location = new Point(9, 152);
            lblFileClue.Name = "lblFileClue";
            lblFileClue.Size = new Size(557, 23);
            lblFileClue.TabIndex = 1;
            lblFileClue.Text = "🔍 PHÁT HIỆN MANH MỐI TỪ TẬP TIN NÀY";
            lblFileClue.TextAlign = ContentAlignment.MiddleCenter;
            lblFileClue.Visible = false;
            // 
            // txtFilePreview
            // 
            txtFilePreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFilePreview.BackColor = Color.FromArgb(248, 250, 252);
            txtFilePreview.BorderStyle = BorderStyle.None;
            txtFilePreview.Font = new Font("Consolas", 9.5F);
            txtFilePreview.ForeColor = Color.FromArgb(30, 41, 59);
            txtFilePreview.Location = new Point(9, 20);
            txtFilePreview.Margin = new Padding(3, 2, 3, 2);
            txtFilePreview.Name = "txtFilePreview";
            txtFilePreview.ReadOnly = true;
            txtFilePreview.Size = new Size(556, 128);
            txtFilePreview.TabIndex = 0;
            txtFilePreview.Text = "Chọn một tập tin ở trên để đọc nội dung...";
            // 
            // ExplorerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(880, 520);
            Name = "ExplorerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "File Explorer — Khám phá tập tin hệ thống";
            Load += ExplorerForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainerPreview.Panel1.ResumeLayout(false);
            splitContainerPreview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerPreview).EndInit();
            splitContainerPreview.ResumeLayout(false);
            grpPreview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblPath;
        private TextBox txtPath;
        private Button btnClose;
        private Panel pnlMain;
        private SplitContainer splitContainer1;
        private TreeView tvFolders;
        private Label lblFoldersHeader;
        private SplitContainer splitContainerPreview;
        private ListView lvFiles;
        private ColumnHeader colName;
        private ColumnHeader colFolder;
        private ColumnHeader colSize;
        private ColumnHeader colModified;
        private GroupBox grpPreview;
        private RichTextBox txtFilePreview;
        private Label lblFileClue;
    }
}


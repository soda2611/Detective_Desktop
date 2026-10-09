namespace _2611_WIN_B3.Forms
{
    partial class NotesForm
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
            btnCopyNote = new Button();
            btnSave = new Button();
            btnClose = new Button();
            lblSubtitle = new Label();
            lblTitle = new Label();
            sptContainer = new SplitContainer();
            lvNotes = new ListView();
            colTitle = new ColumnHeader();
            colCategory = new ColumnHeader();
            pnlLeftHeader = new Panel();
            lblLeftHeader = new Label();
            pnlLeftFooter = new Panel();
            lblNotesCount = new Label();
            pnlContent = new Panel();
            txtNotes = new RichTextBox();
            pnlClueBanner = new Panel();
            btnActionClue = new Button();
            lblClueBanner = new Label();
            pnlNoteMeta = new Panel();
            lblNoteInfo = new Label();
            lblNoteTitle = new Label();
            pnlBottom = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sptContainer).BeginInit();
            sptContainer.Panel1.SuspendLayout();
            sptContainer.Panel2.SuspendLayout();
            sptContainer.SuspendLayout();
            pnlLeftHeader.SuspendLayout();
            pnlLeftFooter.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlClueBanner.SuspendLayout();
            pnlNoteMeta.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnCopyNote);
            pnlHeader.Controls.Add(btnSave);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(960, 60);
            pnlHeader.TabIndex = 0;
            // 
            // btnCopyNote
            // 
            btnCopyNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyNote.BackColor = Color.FromArgb(238, 242, 255);
            btnCopyNote.Cursor = Cursors.Hand;
            btnCopyNote.FlatAppearance.BorderColor = Color.FromArgb(199, 210, 254);
            btnCopyNote.FlatStyle = FlatStyle.Flat;
            btnCopyNote.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCopyNote.ForeColor = Color.FromArgb(67, 56, 202);
            btnCopyNote.Location = new Point(560, 14);
            btnCopyNote.Name = "btnCopyNote";
            btnCopyNote.Size = new Size(150, 32);
            btnCopyNote.TabIndex = 1;
            btnCopyNote.Text = "📋 Chép vào sổ tay";
            btnCopyNote.UseVisualStyleBackColor = false;
            btnCopyNote.Visible = false;
            btnCopyNote.Click += btnCopyNote_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(22, 101, 52);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(718, 14);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 32);
            btnSave.TabIndex = 2;
            btnSave.Text = "💾 Lưu sổ tay";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(226, 232, 240);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(30, 41, 59);
            btnClose.Location = new Point(856, 14);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 32);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(14, 34);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(335, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Khám nghiệm Sticky Notes hệ thống & Sổ tay suy luận";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(12, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(498, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📝 FORENSIC NOTES — KHÁM NGHIỆM GHI CHÚ";
            // 
            // sptContainer
            // 
            sptContainer.Dock = DockStyle.Fill;
            sptContainer.FixedPanel = FixedPanel.Panel1;
            sptContainer.Location = new Point(0, 60);
            sptContainer.Name = "sptContainer";
            // 
            // sptContainer.Panel1
            // 
            sptContainer.Panel1.BackColor = Color.White;
            sptContainer.Panel1.Controls.Add(lvNotes);
            sptContainer.Panel1.Controls.Add(pnlLeftHeader);
            sptContainer.Panel1.Controls.Add(pnlLeftFooter);
            sptContainer.Panel1MinSize = 250;
            // 
            // sptContainer.Panel2
            // 
            sptContainer.Panel2.Controls.Add(pnlContent);
            sptContainer.Panel2.Controls.Add(pnlClueBanner);
            sptContainer.Panel2.Controls.Add(pnlNoteMeta);
            sptContainer.Panel2MinSize = 400;
            sptContainer.Size = new Size(960, 521);
            sptContainer.SplitterDistance = 310;
            sptContainer.SplitterWidth = 5;
            sptContainer.TabIndex = 1;
            // 
            // lvNotes
            // 
            lvNotes.BorderStyle = BorderStyle.None;
            lvNotes.Columns.AddRange(new ColumnHeader[] { colTitle, colCategory });
            lvNotes.Dock = DockStyle.Fill;
            lvNotes.FullRowSelect = true;
            lvNotes.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvNotes.Location = new Point(0, 36);
            lvNotes.MultiSelect = false;
            lvNotes.Name = "lvNotes";
            lvNotes.Size = new Size(310, 453);
            lvNotes.TabIndex = 1;
            lvNotes.UseCompatibleStateImageBehavior = false;
            lvNotes.View = View.Details;
            lvNotes.SelectedIndexChanged += lvNotes_SelectedIndexChanged;
            // 
            // colTitle
            // 
            colTitle.Text = "Tiêu đề & Nguồn";
            colTitle.Width = 200;
            // 
            // colCategory
            // 
            colCategory.Text = "Phân loại";
            colCategory.Width = 95;
            // 
            // pnlLeftHeader
            // 
            pnlLeftHeader.BackColor = Color.FromArgb(241, 245, 249);
            pnlLeftHeader.Controls.Add(lblLeftHeader);
            pnlLeftHeader.Dock = DockStyle.Top;
            pnlLeftHeader.Location = new Point(0, 0);
            pnlLeftHeader.Name = "pnlLeftHeader";
            pnlLeftHeader.Padding = new Padding(10, 0, 0, 0);
            pnlLeftHeader.Size = new Size(310, 36);
            pnlLeftHeader.TabIndex = 0;
            // 
            // lblLeftHeader
            // 
            lblLeftHeader.Dock = DockStyle.Fill;
            lblLeftHeader.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblLeftHeader.ForeColor = Color.FromArgb(51, 65, 85);
            lblLeftHeader.Location = new Point(10, 0);
            lblLeftHeader.Name = "lblLeftHeader";
            lblLeftHeader.Size = new Size(300, 36);
            lblLeftHeader.TabIndex = 0;
            lblLeftHeader.Text = "📑 TÀI LIỆU GHI CHÚ TRÍCH XUẤT";
            lblLeftHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLeftFooter
            // 
            pnlLeftFooter.BackColor = Color.FromArgb(248, 250, 252);
            pnlLeftFooter.Controls.Add(lblNotesCount);
            pnlLeftFooter.Dock = DockStyle.Bottom;
            pnlLeftFooter.Location = new Point(0, 489);
            pnlLeftFooter.Name = "pnlLeftFooter";
            pnlLeftFooter.Padding = new Padding(10, 0, 0, 0);
            pnlLeftFooter.Size = new Size(310, 32);
            pnlLeftFooter.TabIndex = 2;
            // 
            // lblNotesCount
            // 
            lblNotesCount.Dock = DockStyle.Fill;
            lblNotesCount.Font = new Font("Segoe UI", 8.25F);
            lblNotesCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblNotesCount.Location = new Point(10, 0);
            lblNotesCount.Name = "lblNotesCount";
            lblNotesCount.Size = new Size(300, 32);
            lblNotesCount.TabIndex = 0;
            lblNotesCount.Text = "Tổng số: 0 ghi chú";
            lblNotesCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(txtNotes);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 102);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(12);
            pnlContent.Size = new Size(645, 419);
            pnlContent.TabIndex = 2;
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.FromArgb(254, 254, 250);
            txtNotes.BorderStyle = BorderStyle.None;
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Font = new Font("Consolas", 11.5F);
            txtNotes.ForeColor = Color.FromArgb(30, 41, 59);
            txtNotes.Location = new Point(12, 12);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(621, 395);
            txtNotes.TabIndex = 0;
            txtNotes.Text = "";
            txtNotes.TextChanged += txtNotes_TextChanged;
            // 
            // pnlClueBanner
            // 
            pnlClueBanner.BackColor = Color.FromArgb(254, 243, 199);
            pnlClueBanner.Controls.Add(btnActionClue);
            pnlClueBanner.Controls.Add(lblClueBanner);
            pnlClueBanner.Dock = DockStyle.Top;
            pnlClueBanner.Location = new Point(0, 60);
            pnlClueBanner.Name = "pnlClueBanner";
            pnlClueBanner.Padding = new Padding(12, 0, 12, 0);
            pnlClueBanner.Size = new Size(645, 42);
            pnlClueBanner.TabIndex = 1;
            pnlClueBanner.Visible = false;
            // 
            // btnActionClue
            // 
            btnActionClue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActionClue.BackColor = Color.FromArgb(180, 83, 9);
            btnActionClue.Cursor = Cursors.Hand;
            btnActionClue.FlatAppearance.BorderSize = 0;
            btnActionClue.FlatStyle = FlatStyle.Flat;
            btnActionClue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnActionClue.ForeColor = Color.White;
            btnActionClue.Location = new Point(485, 6);
            btnActionClue.Name = "btnActionClue";
            btnActionClue.Size = new Size(150, 30);
            btnActionClue.TabIndex = 1;
            btnActionClue.Text = "🔍 Xem Bảng Chứng Cứ";
            btnActionClue.UseVisualStyleBackColor = false;
            btnActionClue.Click += btnActionClue_Click;
            // 
            // lblClueBanner
            // 
            lblClueBanner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblClueBanner.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblClueBanner.ForeColor = Color.FromArgb(146, 64, 14);
            lblClueBanner.Location = new Point(12, 0);
            lblClueBanner.Name = "lblClueBanner";
            lblClueBanner.Size = new Size(465, 42);
            lblClueBanner.TabIndex = 0;
            lblClueBanner.Text = "⭐ BẰNG CHỨNG MỚI ĐÃ ĐƯỢC GHI NHẬN TỪ MẨU GHI CHÚ NÀY";
            lblClueBanner.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlNoteMeta
            // 
            pnlNoteMeta.BackColor = Color.White;
            pnlNoteMeta.Controls.Add(lblNoteInfo);
            pnlNoteMeta.Controls.Add(lblNoteTitle);
            pnlNoteMeta.Dock = DockStyle.Top;
            pnlNoteMeta.Location = new Point(0, 0);
            pnlNoteMeta.Name = "pnlNoteMeta";
            pnlNoteMeta.Padding = new Padding(12, 8, 12, 6);
            pnlNoteMeta.Size = new Size(645, 60);
            pnlNoteMeta.TabIndex = 0;
            // 
            // lblNoteInfo
            // 
            lblNoteInfo.Dock = DockStyle.Bottom;
            lblNoteInfo.Font = new Font("Segoe UI", 9F);
            lblNoteInfo.ForeColor = Color.FromArgb(100, 116, 139);
            lblNoteInfo.Location = new Point(12, 33);
            lblNoteInfo.Name = "lblNoteInfo";
            lblNoteInfo.Size = new Size(621, 21);
            lblNoteInfo.TabIndex = 1;
            lblNoteInfo.Text = "Tác giả: Thám tử  |  Thời gian: Hiện tại  |  Phân loại: Cá nhân";
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.Dock = DockStyle.Top;
            lblNoteTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNoteTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblNoteTitle.Location = new Point(12, 8);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(621, 26);
            lblNoteTitle.TabIndex = 0;
            lblNoteTitle.Text = "📝 SỔ TAY ĐIỀU TRA CỦA BẠN";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(lblStatus);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 581);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(960, 40);
            pnlBottom.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(12, 0, 0, 0);
            lblStatus.Size = new Size(960, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Ghi chép được tự động đồng bộ vào bộ nhớ trạng thái GameState.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NotesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(960, 621);
            Controls.Add(sptContainer);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(800, 520);
            Name = "NotesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Forensic Notes & Detective Journal — Khám Nghiệm Ghi Chú & Sổ Tay";
            Load += NotesForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            sptContainer.Panel1.ResumeLayout(false);
            sptContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sptContainer).EndInit();
            sptContainer.ResumeLayout(false);
            pnlLeftHeader.ResumeLayout(false);
            pnlLeftFooter.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlClueBanner.ResumeLayout(false);
            pnlNoteMeta.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnCopyNote;
        private Button btnSave;
        private Button btnClose;
        private SplitContainer sptContainer;
        private ListView lvNotes;
        private ColumnHeader colTitle;
        private ColumnHeader colCategory;
        private Panel pnlLeftHeader;
        private Label lblLeftHeader;
        private Panel pnlLeftFooter;
        private Label lblNotesCount;
        private Panel pnlNoteMeta;
        private Label lblNoteTitle;
        private Label lblNoteInfo;
        private Panel pnlClueBanner;
        private Label lblClueBanner;
        private Button btnActionClue;
        private Panel pnlContent;
        private RichTextBox txtNotes;
        private Panel pnlBottom;
        private Label lblStatus;
    }
}


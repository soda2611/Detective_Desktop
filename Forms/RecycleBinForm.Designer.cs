namespace _2611_WIN_B3.Forms
{
    partial class RecycleBinForm
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
            btnRestore = new Button();
            lblTitle = new Label();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            lvDeleted = new ListView();
            colName = new ColumnHeader();
            colOriginalLoc = new ColumnHeader();
            colSize = new ColumnHeader();
            colDateDeleted = new ColumnHeader();
            grpDetail = new GroupBox();
            lblClueAlert = new Label();
            txtDetail = new RichTextBox();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(btnRestore);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1020, 54);
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
            btnClose.Location = new Point(920, 10);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 34);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestore.BackColor = Color.FromArgb(22, 101, 52);
            btnRestore.Cursor = Cursors.Hand;
            btnRestore.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRestore.ForeColor = Color.White;
            btnRestore.Location = new Point(745, 10);
            btnRestore.Margin = new Padding(3, 2, 3, 2);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(160, 34);
            btnRestore.TabIndex = 2;
            btnRestore.Text = "♻ Khôi phục tệp";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(14, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🗑 RECYCLE BIN — TẬP TIN ĐÃ BỊ XÓA";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 41);
            pnlMain.Margin = new Padding(3, 2, 3, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(9, 8, 9, 8);
            pnlMain.Size = new Size(774, 380);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(9, 8);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lvDeleted);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpDetail);
            splitContainer1.Size = new Size(1002, 540);
            splitContainer1.SplitterDistance = 270;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 0;
            // 
            // lvDeleted
            // 
            lvDeleted.BackColor = Color.White;
            lvDeleted.BorderStyle = BorderStyle.FixedSingle;
            lvDeleted.Columns.AddRange(new ColumnHeader[] { colName, colOriginalLoc, colSize, colDateDeleted });
            lvDeleted.Dock = DockStyle.Fill;
            lvDeleted.ForeColor = Color.FromArgb(30, 41, 59);
            lvDeleted.FullRowSelect = true;
            lvDeleted.GridLines = true;
            lvDeleted.Location = new Point(0, 0);
            lvDeleted.Margin = new Padding(3, 2, 3, 2);
            lvDeleted.MultiSelect = false;
            lvDeleted.Name = "lvDeleted";
            lvDeleted.Size = new Size(756, 179);
            lvDeleted.TabIndex = 0;
            lvDeleted.UseCompatibleStateImageBehavior = false;
            lvDeleted.View = View.Details;
            lvDeleted.SelectedIndexChanged += lvDeleted_SelectedIndexChanged;
            lvDeleted.DoubleClick += lvDeleted_DoubleClick;
            // 
            // colName
            // 
            colName.Text = "Tên tệp bị xóa";
            colName.Width = 320;
            // 
            // colOriginalLoc
            // 
            colOriginalLoc.Text = "Vị trí gốc";
            colOriginalLoc.Width = 180;
            // 
            // colSize
            // 
            colSize.Text = "Kích thước";
            colSize.Width = 110;
            // 
            // colDateDeleted
            // 
            colDateDeleted.Text = "Thời điểm xóa";
            colDateDeleted.Width = 180;
            // 
            // grpDetail
            // 
            grpDetail.BackColor = Color.White;
            grpDetail.Controls.Add(lblClueAlert);
            grpDetail.Controls.Add(txtDetail);
            grpDetail.Dock = DockStyle.Fill;
            grpDetail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpDetail.ForeColor = Color.FromArgb(15, 30, 60);
            grpDetail.Location = new Point(0, 0);
            grpDetail.Margin = new Padding(3, 2, 3, 2);
            grpDetail.Name = "grpDetail";
            grpDetail.Padding = new Padding(9, 8, 9, 8);
            grpDetail.Size = new Size(756, 182);
            grpDetail.TabIndex = 0;
            grpDetail.TabStop = false;
            grpDetail.Text = "  PHÂN TÍCH VÀ KHÔI PHỤC TẬP TIN  ";
            // 
            // lblClueAlert
            // 
            lblClueAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblClueAlert.BackColor = Color.FromArgb(240, 253, 244);
            lblClueAlert.BorderStyle = BorderStyle.FixedSingle;
            lblClueAlert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClueAlert.ForeColor = Color.FromArgb(22, 101, 52);
            lblClueAlert.Location = new Point(9, 152);
            lblClueAlert.Name = "lblClueAlert";
            lblClueAlert.Size = new Size(739, 23);
            lblClueAlert.TabIndex = 1;
            lblClueAlert.Text = "🔍 PHÁT HIỆN MANH MỐI TỪ FILE THÙNG RÁC";
            lblClueAlert.TextAlign = ContentAlignment.MiddleCenter;
            lblClueAlert.Visible = false;
            // 
            // txtDetail
            // 
            txtDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetail.BackColor = Color.FromArgb(248, 250, 252);
            txtDetail.BorderStyle = BorderStyle.None;
            txtDetail.Font = new Font("Consolas", 9.5F);
            txtDetail.ForeColor = Color.FromArgb(30, 41, 59);
            txtDetail.Location = new Point(9, 19);
            txtDetail.Margin = new Padding(3, 2, 3, 2);
            txtDetail.Name = "txtDetail";
            txtDetail.ReadOnly = true;
            txtDetail.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtDetail.Size = new Size(738, 128);
            txtDetail.TabIndex = 0;
            txtDetail.Text = "Chọn tệp và bấm 'Kiểm tra nội dung' hoặc nhấp đúp...";
            // 
            // RecycleBinForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(1020, 620);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(850, 500);
            Name = "RecycleBinForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recycle Bin — Thùng Rác Hệ Thống";
            Load += RecycleBinForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpDetail.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnRestore;
        private Button btnClose;
        private Panel pnlMain;
        private SplitContainer splitContainer1;
        private ListView lvDeleted;
        private ColumnHeader colName;
        private ColumnHeader colOriginalLoc;
        private ColumnHeader colSize;
        private ColumnHeader colDateDeleted;
        private GroupBox grpDetail;
        private RichTextBox txtDetail;
        private Label lblClueAlert;
    }
}


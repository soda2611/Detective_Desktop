namespace _2611_WIN_B3.Forms
{
    partial class EvidenceBoardForm
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
            lblTitle = new Label();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            grpEvidences = new GroupBox();
            txtEvidenceDesc = new RichTextBox();
            lblDescTitle = new Label();
            lvEvidences = new ListView();
            colId = new ColumnHeader();
            colName = new ColumnHeader();
            colSource = new ColumnHeader();
            colImportance = new ColumnHeader();
            grpConnections = new GroupBox();
            lvTimeline = new ListView();
            colTime = new ColumnHeader();
            colEvent = new ColumnHeader();
            colEvId = new ColumnHeader();
            lblTimelineTitle = new Label();
            lblConnectResult = new Label();
            btnConnect = new Button();
            cboEvidenceB = new ComboBox();
            lblSelectB = new Label();
            cboEvidenceA = new ComboBox();
            lblSelectA = new Label();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpEvidences.SuspendLayout();
            grpConnections.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 3, 4, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1440, 77);
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
            btnClose.Location = new Point(1311, 14);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 49);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(18, 18);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(525, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\U0001f9e9 EVIDENCE BOARD — BẢNG MANH MỐI & TIMELINE";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 77);
            pnlMain.Margin = new Padding(4, 3, 4, 3);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(12, 12, 12, 12);
            pnlMain.Size = new Size(1440, 978);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpEvidences);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpConnections);
            splitContainer1.Size = new Size(1416, 954);
            splitContainer1.SplitterDistance = 693;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // grpEvidences
            // 
            grpEvidences.BackColor = Color.White;
            grpEvidences.Controls.Add(txtEvidenceDesc);
            grpEvidences.Controls.Add(lblDescTitle);
            grpEvidences.Controls.Add(lvEvidences);
            grpEvidences.Dock = DockStyle.Fill;
            grpEvidences.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpEvidences.ForeColor = Color.FromArgb(15, 30, 60);
            grpEvidences.Location = new Point(0, 0);
            grpEvidences.Margin = new Padding(4, 3, 4, 3);
            grpEvidences.Name = "grpEvidences";
            grpEvidences.Padding = new Padding(12, 12, 12, 12);
            grpEvidences.Size = new Size(693, 954);
            grpEvidences.TabIndex = 0;
            grpEvidences.TabStop = false;
            grpEvidences.Text = "  MANH MỐI ĐÃ THU THẬP  ";
            // 
            // txtEvidenceDesc
            // 
            txtEvidenceDesc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEvidenceDesc.BackColor = Color.FromArgb(248, 250, 252);
            txtEvidenceDesc.BorderStyle = BorderStyle.None;
            txtEvidenceDesc.Font = new Font("Segoe UI", 9.25F);
            txtEvidenceDesc.ForeColor = Color.FromArgb(30, 41, 59);
            txtEvidenceDesc.Location = new Point(12, 438);
            txtEvidenceDesc.Margin = new Padding(4, 3, 4, 3);
            txtEvidenceDesc.Name = "txtEvidenceDesc";
            txtEvidenceDesc.ReadOnly = true;
            txtEvidenceDesc.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtEvidenceDesc.Size = new Size(494, 178);
            txtEvidenceDesc.TabIndex = 2;
            txtEvidenceDesc.Text = "Chọn một manh mối ở trên để đọc nội dung phân tích chi tiết...";
            // 
            // lblDescTitle
            // 
            lblDescTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDescTitle.AutoSize = true;
            lblDescTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDescTitle.Location = new Point(12, 409);
            lblDescTitle.Margin = new Padding(4, 0, 4, 0);
            lblDescTitle.Name = "lblDescTitle";
            lblDescTitle.Size = new Size(150, 20);
            lblDescTitle.TabIndex = 1;
            lblDescTitle.Text = "Phân tích manh mối:";
            // 
            // lvEvidences
            // 
            lvEvidences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvEvidences.BackColor = Color.White;
            lvEvidences.BorderStyle = BorderStyle.FixedSingle;
            lvEvidences.Columns.AddRange(new ColumnHeader[] { colId, colName, colSource, colImportance });
            lvEvidences.ForeColor = Color.FromArgb(30, 41, 59);
            lvEvidences.FullRowSelect = true;
            lvEvidences.GridLines = true;
            lvEvidences.Location = new Point(12, 32);
            lvEvidences.Margin = new Padding(4, 3, 4, 3);
            lvEvidences.MultiSelect = false;
            lvEvidences.Name = "lvEvidences";
            lvEvidences.Size = new Size(493, 368);
            lvEvidences.TabIndex = 0;
            lvEvidences.UseCompatibleStateImageBehavior = false;
            lvEvidences.View = View.Details;
            lvEvidences.SelectedIndexChanged += lvEvidences_SelectedIndexChanged;
            // 
            // colId
            // 
            colId.Text = "Mã";
            // 
            // colName
            // 
            colName.Text = "Tên bằng chứng";
            colName.Width = 190;
            // 
            // colSource
            // 
            colSource.Text = "Nguồn";
            colSource.Width = 90;
            // 
            // colImportance
            // 
            colImportance.Text = "Mức độ";
            colImportance.Width = 80;
            // 
            // grpConnections
            // 
            grpConnections.BackColor = Color.White;
            grpConnections.Controls.Add(lvTimeline);
            grpConnections.Controls.Add(lblTimelineTitle);
            grpConnections.Controls.Add(lblConnectResult);
            grpConnections.Controls.Add(btnConnect);
            grpConnections.Controls.Add(cboEvidenceB);
            grpConnections.Controls.Add(lblSelectB);
            grpConnections.Controls.Add(cboEvidenceA);
            grpConnections.Controls.Add(lblSelectA);
            grpConnections.Dock = DockStyle.Fill;
            grpConnections.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpConnections.ForeColor = Color.FromArgb(15, 30, 60);
            grpConnections.Location = new Point(0, 0);
            grpConnections.Margin = new Padding(4, 3, 4, 3);
            grpConnections.Name = "grpConnections";
            grpConnections.Padding = new Padding(13, 14, 13, 14);
            grpConnections.Size = new Size(718, 954);
            grpConnections.TabIndex = 0;
            grpConnections.TabStop = false;
            grpConnections.Text = "  KẾT NỐI BẰNG CHỨNG & TIMELINE  ";
            // 
            // lvTimeline
            // 
            lvTimeline.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvTimeline.BackColor = Color.White;
            lvTimeline.BorderStyle = BorderStyle.FixedSingle;
            lvTimeline.Columns.AddRange(new ColumnHeader[] { colTime, colEvent, colEvId });
            lvTimeline.ForeColor = Color.FromArgb(30, 41, 59);
            lvTimeline.FullRowSelect = true;
            lvTimeline.GridLines = true;
            lvTimeline.Location = new Point(13, 397);
            lvTimeline.Margin = new Padding(4, 3, 4, 3);
            lvTimeline.MultiSelect = false;
            lvTimeline.Name = "lvTimeline";
            lvTimeline.Size = new Size(535, 220);
            lvTimeline.TabIndex = 7;
            lvTimeline.UseCompatibleStateImageBehavior = false;
            lvTimeline.View = View.Details;
            // 
            // colTime
            // 
            colTime.Text = "Giờ";
            // 
            // colEvent
            // 
            colEvent.Text = "Sự kiện được đối chiếu";
            colEvent.Width = 320;
            // 
            // colEvId
            // 
            colEvId.Text = "Bằng chứng";
            colEvId.Width = 85;
            // 
            // lblTimelineTitle
            // 
            lblTimelineTitle.AutoSize = true;
            lblTimelineTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTimelineTitle.Location = new Point(13, 365);
            lblTimelineTitle.Margin = new Padding(4, 0, 4, 0);
            lblTimelineTitle.Name = "lblTimelineTitle";
            lblTimelineTitle.Size = new Size(266, 20);
            lblTimelineTitle.TabIndex = 6;
            lblTimelineTitle.Text = "DÒNG THỜI GIAN VỤ ÁN (TIMELINE):";
            // 
            // lblConnectResult
            // 
            lblConnectResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblConnectResult.BackColor = Color.FromArgb(248, 250, 252);
            lblConnectResult.BorderStyle = BorderStyle.FixedSingle;
            lblConnectResult.ForeColor = Color.FromArgb(30, 41, 59);
            lblConnectResult.Location = new Point(13, 259);
            lblConnectResult.Margin = new Padding(4, 0, 4, 0);
            lblConnectResult.Name = "lblConnectResult";
            lblConnectResult.Padding = new Padding(9, 9, 9, 9);
            lblConnectResult.Size = new Size(535, 91);
            lblConnectResult.TabIndex = 5;
            lblConnectResult.Text = "Chọn 2 bằng chứng ở trên rồi bấm nút 'TẠO LIÊN KẾT' để kiểm tra sự trùng khớp.";
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConnect.BackColor = Color.FromArgb(2, 132, 199);
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatAppearance.BorderColor = Color.FromArgb(56, 189, 248);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(13, 196);
            btnConnect.Margin = new Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(535, 49);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "🔗 TẠO LIÊN KẾT (CONNECT)";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // cboEvidenceB
            // 
            cboEvidenceB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboEvidenceB.BackColor = Color.White;
            cboEvidenceB.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEvidenceB.FlatStyle = FlatStyle.Flat;
            cboEvidenceB.ForeColor = Color.FromArgb(15, 23, 42);
            cboEvidenceB.FormattingEnabled = true;
            cboEvidenceB.Location = new Point(13, 144);
            cboEvidenceB.Margin = new Padding(4, 3, 4, 3);
            cboEvidenceB.Name = "cboEvidenceB";
            cboEvidenceB.Size = new Size(535, 28);
            cboEvidenceB.TabIndex = 3;
            // 
            // lblSelectB
            // 
            lblSelectB.AutoSize = true;
            lblSelectB.ForeColor = Color.FromArgb(100, 116, 139);
            lblSelectB.Location = new Point(13, 115);
            lblSelectB.Margin = new Padding(4, 0, 4, 0);
            lblSelectB.Name = "lblSelectB";
            lblSelectB.Size = new Size(148, 20);
            lblSelectB.TabIndex = 2;
            lblSelectB.Text = "Chọn bằng chứng B:";
            // 
            // cboEvidenceA
            // 
            cboEvidenceA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboEvidenceA.BackColor = Color.White;
            cboEvidenceA.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEvidenceA.FlatStyle = FlatStyle.Flat;
            cboEvidenceA.ForeColor = Color.FromArgb(15, 23, 42);
            cboEvidenceA.FormattingEnabled = true;
            cboEvidenceA.Location = new Point(13, 63);
            cboEvidenceA.Margin = new Padding(4, 3, 4, 3);
            cboEvidenceA.Name = "cboEvidenceA";
            cboEvidenceA.Size = new Size(535, 28);
            cboEvidenceA.TabIndex = 1;
            // 
            // lblSelectA
            // 
            lblSelectA.AutoSize = true;
            lblSelectA.ForeColor = Color.FromArgb(100, 116, 139);
            lblSelectA.Location = new Point(13, 34);
            lblSelectA.Margin = new Padding(4, 0, 4, 0);
            lblSelectA.Name = "lblSelectA";
            lblSelectA.Size = new Size(149, 20);
            lblSelectA.TabIndex = 0;
            lblSelectA.Text = "Chọn bằng chứng A:";
            // 
            // EvidenceBoardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(1440, 1055);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1216, 895);
            Name = "EvidenceBoardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Evidence Board — Bảng Manh Mối & Kết Nối";
            Load += EvidenceBoardForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpEvidences.ResumeLayout(false);
            grpEvidences.PerformLayout();
            grpConnections.ResumeLayout(false);
            grpConnections.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlMain;
        private SplitContainer splitContainer1;
        private GroupBox grpEvidences;
        private ListView lvEvidences;
        private ColumnHeader colId;
        private ColumnHeader colName;
        private ColumnHeader colSource;
        private ColumnHeader colImportance;
        private Label lblDescTitle;
        private RichTextBox txtEvidenceDesc;
        private GroupBox grpConnections;
        private Label lblSelectA;
        private ComboBox cboEvidenceA;
        private Label lblSelectB;
        private ComboBox cboEvidenceB;
        private Button btnConnect;
        private Label lblConnectResult;
        private Label lblTimelineTitle;
        private ListView lvTimeline;
        private ColumnHeader colTime;
        private ColumnHeader colEvent;
        private ColumnHeader colEvId;
    }
}


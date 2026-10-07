namespace _2611_WIN_B3.Forms
{
    partial class CaseReportForm
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
            lblCaseTimer = new Label();
            lblTitle = new Label();
            pnlBottom = new Panel();
            btnViewHighScores = new Button();
            lblWarning = new Label();
            btnSubmitCase = new Button();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            grpMethod = new GroupBox();
            cboMethod = new ComboBox();
            grpMotive = new GroupBox();
            cboMotive = new ComboBox();
            grpSuspect = new GroupBox();
            lblSuspectDetail = new Label();
            cboSuspect = new ComboBox();
            grpConclusion = new GroupBox();
            txtConclusion = new RichTextBox();
            grpEvidenceSelect = new GroupBox();
            clbEvidences = new CheckedListBox();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpMethod.SuspendLayout();
            grpMotive.SuspendLayout();
            grpSuspect.SuspendLayout();
            grpConclusion.SuspendLayout();
            grpEvidenceSelect.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(lblCaseTimer);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1120, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblCaseTimer
            // 
            lblCaseTimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaseTimer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaseTimer.ForeColor = Color.FromArgb(16, 95, 175);
            lblCaseTimer.Location = new Point(735, 12);
            lblCaseTimer.Name = "lblCaseTimer";
            lblCaseTimer.Size = new Size(275, 32);
            lblCaseTimer.TabIndex = 2;
            lblCaseTimer.Text = "⏱ Thời gian: 00:00";
            lblCaseTimer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(226, 232, 240);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.FromArgb(30, 41, 59);
            btnClose.Location = new Point(1020, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(14, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(510, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📋 FINAL INVESTIGATION REPORT — BÁO CÁO VỤ ÁN";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(btnViewHighScores);
            pnlBottom.Controls.Add(lblWarning);
            pnlBottom.Controls.Add(btnSubmitCase);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 686);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1120, 64);
            pnlBottom.TabIndex = 1;
            // 
            // btnViewHighScores
            // 
            btnViewHighScores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewHighScores.BackColor = Color.FromArgb(224, 238, 255);
            btnViewHighScores.Cursor = Cursors.Hand;
            btnViewHighScores.FlatAppearance.BorderColor = Color.FromArgb(170, 205, 245);
            btnViewHighScores.FlatStyle = FlatStyle.Flat;
            btnViewHighScores.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewHighScores.ForeColor = Color.FromArgb(10, 65, 140);
            btnViewHighScores.Location = new Point(595, 11);
            btnViewHighScores.Name = "btnViewHighScores";
            btnViewHighScores.Size = new Size(230, 44);
            btnViewHighScores.TabIndex = 2;
            btnViewHighScores.Text = "🏆 Bảng thành tích";
            btnViewHighScores.UseVisualStyleBackColor = false;
            btnViewHighScores.Click += btnViewHighScores_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.FromArgb(100, 116, 139);
            lblWarning.Location = new Point(14, 20);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(420, 21);
            lblWarning.TabIndex = 0;
            lblWarning.Text = "Lưu ý: Báo cáo sẽ được chuyển tới Tòa án để phân định kết quả.";
            // 
            // btnSubmitCase
            // 
            btnSubmitCase.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmitCase.BackColor = Color.FromArgb(22, 101, 52);
            btnSubmitCase.Cursor = Cursors.Hand;
            btnSubmitCase.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnSubmitCase.FlatStyle = FlatStyle.Flat;
            btnSubmitCase.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSubmitCase.ForeColor = Color.White;
            btnSubmitCase.Location = new Point(835, 10);
            btnSubmitCase.Name = "btnSubmitCase";
            btnSubmitCase.Size = new Size(275, 44);
            btnSubmitCase.TabIndex = 1;
            btnSubmitCase.Text = "⚖ NỘP BÁO CÁO (SUBMIT CASE)";
            btnSubmitCase.UseVisualStyleBackColor = false;
            btnSubmitCase.Click += btnSubmitCase_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 56);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.Size = new Size(1120, 630);
            pnlMain.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(10, 10);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(1100, 610);
            splitContainer1.SplitterDistance = 530;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(grpMethod);
            splitContainer1.Panel1.Controls.Add(grpMotive);
            splitContainer1.Panel1.Controls.Add(grpSuspect);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(grpConclusion);
            splitContainer1.Panel2.Controls.Add(grpEvidenceSelect);
            // 
            // grpMethod
            // 
            grpMethod.BackColor = Color.White;
            grpMethod.Controls.Add(cboMethod);
            grpMethod.Dock = DockStyle.Top;
            grpMethod.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpMethod.ForeColor = Color.FromArgb(15, 30, 60);
            grpMethod.Location = new Point(0, 350);
            grpMethod.Name = "grpMethod";
            grpMethod.Padding = new Padding(12);
            grpMethod.Size = new Size(470, 120);
            grpMethod.TabIndex = 2;
            grpMethod.TabStop = false;
            grpMethod.Text = "  3. THỦ ĐOẠN / PHƯƠNG THỨC THỰC HIỆN  ";
            // 
            // cboMethod
            // 
            cboMethod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMethod.BackColor = Color.White;
            cboMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMethod.FlatStyle = FlatStyle.Flat;
            cboMethod.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMethod.ForeColor = Color.FromArgb(15, 23, 42);
            cboMethod.FormattingEnabled = true;
            cboMethod.Location = new Point(12, 35);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(446, 29);
            cboMethod.TabIndex = 0;
            // 
            // grpMotive
            // 
            grpMotive.BackColor = Color.White;
            grpMotive.Controls.Add(cboMotive);
            grpMotive.Dock = DockStyle.Top;
            grpMotive.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpMotive.ForeColor = Color.FromArgb(15, 30, 60);
            grpMotive.Location = new Point(0, 230);
            grpMotive.Name = "grpMotive";
            grpMotive.Padding = new Padding(12);
            grpMotive.Size = new Size(470, 120);
            grpMotive.TabIndex = 1;
            grpMotive.TabStop = false;
            grpMotive.Text = "  2. ĐỘNG CƠ PHẠM TỘI (MOTIVE)  ";
            // 
            // cboMotive
            // 
            cboMotive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMotive.BackColor = Color.White;
            cboMotive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMotive.FlatStyle = FlatStyle.Flat;
            cboMotive.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMotive.ForeColor = Color.FromArgb(15, 23, 42);
            cboMotive.FormattingEnabled = true;
            cboMotive.Location = new Point(12, 35);
            cboMotive.Name = "cboMotive";
            cboMotive.Size = new Size(446, 29);
            cboMotive.TabIndex = 0;
            // 
            // grpSuspect
            // 
            grpSuspect.BackColor = Color.White;
            grpSuspect.Controls.Add(lblSuspectDetail);
            grpSuspect.Controls.Add(cboSuspect);
            grpSuspect.Dock = DockStyle.Top;
            grpSuspect.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpSuspect.ForeColor = Color.FromArgb(15, 30, 60);
            grpSuspect.Location = new Point(0, 0);
            grpSuspect.Name = "grpSuspect";
            grpSuspect.Padding = new Padding(12);
            grpSuspect.Size = new Size(470, 230);
            grpSuspect.TabIndex = 0;
            grpSuspect.TabStop = false;
            grpSuspect.Text = "  1. NGHI PHẠM CHÍNH (PRIMARY SUSPECT)  ";
            // 
            // lblSuspectDetail
            // 
            lblSuspectDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSuspectDetail.BackColor = Color.FromArgb(248, 250, 252);
            lblSuspectDetail.BorderStyle = BorderStyle.FixedSingle;
            lblSuspectDetail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSuspectDetail.ForeColor = Color.FromArgb(30, 41, 59);
            lblSuspectDetail.Location = new Point(12, 75);
            lblSuspectDetail.Name = "lblSuspectDetail";
            lblSuspectDetail.Padding = new Padding(8);
            lblSuspectDetail.Size = new Size(446, 140);
            lblSuspectDetail.TabIndex = 1;
            lblSuspectDetail.Text = "Chọn một nghi phạm để xem hồ sơ tóm tắt...";
            // 
            // cboSuspect
            // 
            cboSuspect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboSuspect.BackColor = Color.White;
            cboSuspect.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSuspect.FlatStyle = FlatStyle.Flat;
            cboSuspect.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboSuspect.ForeColor = Color.FromArgb(15, 23, 42);
            cboSuspect.FormattingEnabled = true;
            cboSuspect.Location = new Point(12, 35);
            cboSuspect.Name = "cboSuspect";
            cboSuspect.Size = new Size(446, 29);
            cboSuspect.TabIndex = 0;
            cboSuspect.SelectedIndexChanged += cboSuspect_SelectedIndexChanged;
            // 
            // grpConclusion
            // 
            grpConclusion.BackColor = Color.White;
            grpConclusion.Controls.Add(txtConclusion);
            grpConclusion.Dock = DockStyle.Fill;
            grpConclusion.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpConclusion.ForeColor = Color.FromArgb(15, 30, 60);
            grpConclusion.Location = new Point(0, 260);
            grpConclusion.Name = "grpConclusion";
            grpConclusion.Padding = new Padding(12);
            grpConclusion.Size = new Size(490, 266);
            grpConclusion.TabIndex = 1;
            grpConclusion.TabStop = false;
            grpConclusion.Text = "  5. TỔNG KẾT & LẬP LUẬN (CONCLUSION)  ";
            // 
            // txtConclusion
            // 
            txtConclusion.BackColor = Color.FromArgb(248, 250, 252);
            txtConclusion.BorderStyle = BorderStyle.None;
            txtConclusion.Dock = DockStyle.Fill;
            txtConclusion.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtConclusion.ForeColor = Color.FromArgb(30, 41, 59);
            txtConclusion.Location = new Point(12, 32);
            txtConclusion.Name = "txtConclusion";
            txtConclusion.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtConclusion.WordWrap = true;
            txtConclusion.Size = new Size(466, 222);
            txtConclusion.TabIndex = 0;
            txtConclusion.Text = "Ghi chú tóm tắt kết luận của bạn ở đây trước khi bấm nộp báo cáo...";
            // 
            // grpEvidenceSelect
            // 
            grpEvidenceSelect.BackColor = Color.White;
            grpEvidenceSelect.Controls.Add(clbEvidences);
            grpEvidenceSelect.Dock = DockStyle.Top;
            grpEvidenceSelect.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpEvidenceSelect.ForeColor = Color.FromArgb(15, 30, 60);
            grpEvidenceSelect.Location = new Point(0, 0);
            grpEvidenceSelect.Name = "grpEvidenceSelect";
            grpEvidenceSelect.Padding = new Padding(12);
            grpEvidenceSelect.Size = new Size(490, 260);
            grpEvidenceSelect.TabIndex = 0;
            grpEvidenceSelect.TabStop = false;
            grpEvidenceSelect.Text = "  4. ĐÍNH KÈM CÁC BẰNG CHỨNG THEN CHỐT  ";
            // 
            // clbEvidences
            // 
            clbEvidences.BackColor = Color.White;
            clbEvidences.BorderStyle = BorderStyle.FixedSingle;
            clbEvidences.CheckOnClick = true;
            clbEvidences.Dock = DockStyle.Fill;
            clbEvidences.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            clbEvidences.ForeColor = Color.FromArgb(15, 23, 42);
            clbEvidences.FormattingEnabled = true;
            clbEvidences.Location = new Point(12, 32);
            clbEvidences.Name = "clbEvidences";
            clbEvidences.Size = new Size(466, 216);
            clbEvidences.TabIndex = 0;
            // 
            // CaseReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(1120, 750);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(1000, 680);
            Name = "CaseReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Final Investigation Case Report — Nộp Báo Cáo Kết Luận";
            Load += CaseReportForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpMethod.ResumeLayout(false);
            grpMotive.ResumeLayout(false);
            grpSuspect.ResumeLayout(false);
            grpConclusion.ResumeLayout(false);
            grpEvidenceSelect.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCaseTimer;
        private Button btnClose;
        private Panel pnlBottom;
        private Button btnSubmitCase;
        private Button btnViewHighScores;
        private Label lblWarning;
        private Panel pnlMain;
        private SplitContainer splitContainer1;
        private GroupBox grpSuspect;
        private Label lblSuspectDetail;
        private ComboBox cboSuspect;
        private GroupBox grpMotive;
        private ComboBox cboMotive;
        private GroupBox grpMethod;
        private ComboBox cboMethod;
        private GroupBox grpEvidenceSelect;
        private CheckedListBox clbEvidences;
        private GroupBox grpConclusion;
        private RichTextBox txtConclusion;
    }
}


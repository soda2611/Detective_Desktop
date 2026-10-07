namespace _2611_WIN_B3.Forms
{
    partial class CaseSelectForm
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
            pnlBottom = new Panel();
            btnPlayCase = new Button();
            btnCancel = new Button();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            pnlLeft = new Panel();
            btnImportJson = new Button();
            lvCases = new ListView();
            colCaseId = new ColumnHeader();
            colTitle = new ColumnHeader();
            colDifficulty = new ColumnHeader();
            lblListHeader = new Label();
            grpCaseDetail = new GroupBox();
            txtCaseDescription = new RichTextBox();
            lblIncidentDate = new Label();
            lblMissingFile = new Label();
            lblVictim = new Label();
            lblSelectedTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpCaseDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(884, 52);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(14, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(428, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📂 CHỌN VỤ ÁN / MÀN CHƠI (CASE SELECT)";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(btnPlayCase);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 509);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(884, 52);
            pnlBottom.TabIndex = 2;
            // 
            // btnPlayCase
            // 
            btnPlayCase.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlayCase.BackColor = Color.FromArgb(22, 101, 52);
            btnPlayCase.Cursor = Cursors.Hand;
            btnPlayCase.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnPlayCase.FlatStyle = FlatStyle.Flat;
            btnPlayCase.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPlayCase.ForeColor = Color.White;
            btnPlayCase.Location = new Point(610, 10);
            btnPlayCase.Name = "btnPlayCase";
            btnPlayCase.Size = new Size(260, 32);
            btnPlayCase.TabIndex = 1;
            btnPlayCase.Text = "▶ BẮT ĐẦU ĐIỀU TRA VỤ ÁN NÀY";
            btnPlayCase.UseVisualStyleBackColor = false;
            btnPlayCase.Click += btnPlayCase_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(30, 41, 59);
            btnCancel.Location = new Point(510, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 32);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 52);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(12);
            pnlMain.Size = new Size(884, 457);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlLeft);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpCaseDetail);
            splitContainer1.Size = new Size(860, 433);
            splitContainer1.SplitterDistance = 380;
            splitContainer1.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(btnImportJson);
            pnlLeft.Controls.Add(lvCases);
            pnlLeft.Controls.Add(lblListHeader);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(380, 433);
            pnlLeft.TabIndex = 0;
            // 
            // btnImportJson
            // 
            btnImportJson.BackColor = Color.FromArgb(235, 242, 250);
            btnImportJson.Cursor = Cursors.Hand;
            btnImportJson.Dock = DockStyle.Bottom;
            btnImportJson.FlatAppearance.BorderColor = Color.FromArgb(170, 195, 225);
            btnImportJson.FlatStyle = FlatStyle.Flat;
            btnImportJson.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportJson.ForeColor = Color.FromArgb(15, 45, 85);
            btnImportJson.Location = new Point(0, 399);
            btnImportJson.Name = "btnImportJson";
            btnImportJson.Size = new Size(380, 34);
            btnImportJson.TabIndex = 2;
            btnImportJson.Text = "📥 Nhập màn chơi từ file JSON...";
            btnImportJson.UseVisualStyleBackColor = false;
            btnImportJson.Click += btnImportJson_Click;
            // 
            // lvCases
            // 
            lvCases.BackColor = Color.White;
            lvCases.BorderStyle = BorderStyle.FixedSingle;
            lvCases.Columns.AddRange(new ColumnHeader[] { colCaseId, colTitle, colDifficulty });
            lvCases.Dock = DockStyle.Fill;
            lvCases.ForeColor = Color.FromArgb(30, 41, 59);
            lvCases.FullRowSelect = true;
            lvCases.GridLines = true;
            lvCases.Location = new Point(0, 28);
            lvCases.MultiSelect = false;
            lvCases.Name = "lvCases";
            lvCases.Size = new Size(380, 405);
            lvCases.TabIndex = 1;
            lvCases.UseCompatibleStateImageBehavior = false;
            lvCases.View = View.Details;
            lvCases.SelectedIndexChanged += lvCases_SelectedIndexChanged;
            // 
            // colCaseId
            // 
            colCaseId.Text = "Mã vụ án";
            colCaseId.Width = 90;
            // 
            // colTitle
            // 
            colTitle.Text = "Tên vụ án";
            colTitle.Width = 190;
            // 
            // colDifficulty
            // 
            colDifficulty.Text = "Độ khó";
            colDifficulty.Width = 80;
            // 
            // lblListHeader
            // 
            lblListHeader.Dock = DockStyle.Top;
            lblListHeader.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblListHeader.ForeColor = Color.FromArgb(51, 65, 85);
            lblListHeader.Location = new Point(0, 0);
            lblListHeader.Name = "lblListHeader";
            lblListHeader.Size = new Size(380, 28);
            lblListHeader.TabIndex = 0;
            lblListHeader.Text = "Danh sách màn chơi có sẵn:";
            lblListHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpCaseDetail
            // 
            grpCaseDetail.BackColor = Color.White;
            grpCaseDetail.Controls.Add(txtCaseDescription);
            grpCaseDetail.Controls.Add(lblIncidentDate);
            grpCaseDetail.Controls.Add(lblMissingFile);
            grpCaseDetail.Controls.Add(lblVictim);
            grpCaseDetail.Controls.Add(lblSelectedTitle);
            grpCaseDetail.Dock = DockStyle.Fill;
            grpCaseDetail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpCaseDetail.ForeColor = Color.FromArgb(15, 30, 60);
            grpCaseDetail.Location = new Point(0, 0);
            grpCaseDetail.Name = "grpCaseDetail";
            grpCaseDetail.Padding = new Padding(12);
            grpCaseDetail.Size = new Size(476, 433);
            grpCaseDetail.TabIndex = 0;
            grpCaseDetail.TabStop = false;
            grpCaseDetail.Text = "  CHI TIẾT VỤ ÁN  ";
            // 
            // txtCaseDescription
            // 
            txtCaseDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCaseDescription.BackColor = Color.FromArgb(248, 250, 252);
            txtCaseDescription.BorderStyle = BorderStyle.None;
            txtCaseDescription.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCaseDescription.ForeColor = Color.FromArgb(30, 41, 59);
            txtCaseDescription.Location = new Point(12, 130);
            txtCaseDescription.Name = "txtCaseDescription";
            txtCaseDescription.ReadOnly = true;
            txtCaseDescription.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtCaseDescription.Size = new Size(452, 290);
            txtCaseDescription.TabIndex = 4;
            txtCaseDescription.Text = "";
            // 
            // lblIncidentDate
            // 
            lblIncidentDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblIncidentDate.ForeColor = Color.FromArgb(71, 85, 105);
            lblIncidentDate.Location = new Point(12, 100);
            lblIncidentDate.Name = "lblIncidentDate";
            lblIncidentDate.Size = new Size(452, 20);
            lblIncidentDate.TabIndex = 3;
            lblIncidentDate.Text = "Thời điểm: ---";
            // 
            // lblMissingFile
            // 
            lblMissingFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMissingFile.ForeColor = Color.FromArgb(180, 83, 9);
            lblMissingFile.Location = new Point(12, 75);
            lblMissingFile.Name = "lblMissingFile";
            lblMissingFile.Size = new Size(452, 20);
            lblMissingFile.TabIndex = 2;
            lblMissingFile.Text = "Tập tin bị mất: ---";
            // 
            // lblVictim
            // 
            lblVictim.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblVictim.ForeColor = Color.FromArgb(30, 41, 59);
            lblVictim.Location = new Point(12, 50);
            lblVictim.Name = "lblVictim";
            lblVictim.Size = new Size(452, 20);
            lblVictim.TabIndex = 1;
            lblVictim.Text = "Nạn nhân: ---";
            // 
            // lblSelectedTitle
            // 
            lblSelectedTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblSelectedTitle.Location = new Point(12, 22);
            lblSelectedTitle.Name = "lblSelectedTitle";
            lblSelectedTitle.Size = new Size(452, 26);
            lblSelectedTitle.TabIndex = 0;
            lblSelectedTitle.Text = "Vui lòng chọn một vụ án";
            // 
            // CaseSelectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(884, 561);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(760, 480);
            Name = "CaseSelectForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chọn Vụ Án — Desktop Detective";
            Load += CaseSelectForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            grpCaseDetail.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlBottom;
        private Button btnCancel;
        private Button btnPlayCase;
        private Panel pnlMain;
        private SplitContainer splitContainer1;
        private Panel pnlLeft;
        private Label lblListHeader;
        private ListView lvCases;
        private ColumnHeader colCaseId;
        private ColumnHeader colTitle;
        private ColumnHeader colDifficulty;
        private Button btnImportJson;
        private GroupBox grpCaseDetail;
        private Label lblSelectedTitle;
        private Label lblVictim;
        private Label lblMissingFile;
        private Label lblIncidentDate;
        private RichTextBox txtCaseDescription;
    }
}

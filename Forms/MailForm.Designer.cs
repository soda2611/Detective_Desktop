namespace _2611_WIN_B3.Forms
{
    partial class MailForm
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
            pnlList = new Panel();
            lvEmails = new ListView();
            colSender = new ColumnHeader();
            colSubject = new ColumnHeader();
            colTime = new ColumnHeader();
            lblListHeader = new Label();
            grpMailDetail = new GroupBox();
            lblClueAlert = new Label();
            txtMailBody = new RichTextBox();
            lblSubjectValue = new Label();
            lblSubject = new Label();
            lblDateValue = new Label();
            lblDate = new Label();
            lblRecipientValue = new Label();
            lblRecipient = new Label();
            lblSenderValue = new Label();
            lblSender = new Label();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlList.SuspendLayout();
            grpMailDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 54);
            pnlHeader.TabIndex = 0;
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
            btnClose.Location = new Point(1000, 10);
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
            lblTitle.Location = new Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✉ HỘP THƯ NỘI BỘ — NOVATECH MAIL";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 54);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.Size = new Size(1100, 646);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(10, 10);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlList);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpMailDetail);
            splitContainer1.Size = new Size(1080, 626);
            splitContainer1.SplitterDistance = 440;
            splitContainer1.TabIndex = 0;
            // 
            // pnlList
            // 
            pnlList.Controls.Add(lvEmails);
            pnlList.Controls.Add(lblListHeader);
            pnlList.Dock = DockStyle.Fill;
            pnlList.Location = new Point(0, 0);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(380, 491);
            pnlList.TabIndex = 0;
            // 
            // lvEmails
            // 
            lvEmails.BackColor = Color.White;
            lvEmails.BorderStyle = BorderStyle.FixedSingle;
            lvEmails.Columns.AddRange(new ColumnHeader[] { colSender, colSubject, colTime });
            lvEmails.Dock = DockStyle.Fill;
            lvEmails.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lvEmails.ForeColor = Color.FromArgb(30, 41, 59);
            lvEmails.FullRowSelect = true;
            lvEmails.GridLines = true;
            lvEmails.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvEmails.Location = new Point(0, 30);
            lvEmails.MultiSelect = false;
            lvEmails.Name = "lvEmails";
            lvEmails.Size = new Size(380, 461);
            lvEmails.TabIndex = 1;
            lvEmails.UseCompatibleStateImageBehavior = false;
            lvEmails.View = View.Details;
            lvEmails.SelectedIndexChanged += lvEmails_SelectedIndexChanged;
            // 
            // colSender
            // 
            colSender.Text = "Người gửi";
            colSender.Width = 120;
            // 
            // colSubject
            // 
            colSubject.Text = "Tiêu đề";
            colSubject.Width = 170;
            // 
            // colTime
            // 
            colTime.Text = "Giờ";
            colTime.Width = 70;
            // 
            // lblListHeader
            // 
            lblListHeader.Dock = DockStyle.Top;
            lblListHeader.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblListHeader.ForeColor = Color.FromArgb(51, 65, 85);
            lblListHeader.Location = new Point(0, 0);
            lblListHeader.Name = "lblListHeader";
            lblListHeader.Size = new Size(380, 30);
            lblListHeader.TabIndex = 0;
            lblListHeader.Text = "Hộp thư đến (Inbox)";
            lblListHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpMailDetail
            // 
            grpMailDetail.BackColor = Color.White;
            grpMailDetail.Controls.Add(lblClueAlert);
            grpMailDetail.Controls.Add(txtMailBody);
            grpMailDetail.Controls.Add(lblSubjectValue);
            grpMailDetail.Controls.Add(lblSubject);
            grpMailDetail.Controls.Add(lblDateValue);
            grpMailDetail.Controls.Add(lblDate);
            grpMailDetail.Controls.Add(lblRecipientValue);
            grpMailDetail.Controls.Add(lblRecipient);
            grpMailDetail.Controls.Add(lblSenderValue);
            grpMailDetail.Controls.Add(lblSender);
            grpMailDetail.Dock = DockStyle.Fill;
            grpMailDetail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpMailDetail.ForeColor = Color.FromArgb(15, 30, 60);
            grpMailDetail.Location = new Point(0, 0);
            grpMailDetail.Name = "grpMailDetail";
            grpMailDetail.Padding = new Padding(12);
            grpMailDetail.Size = new Size(480, 491);
            grpMailDetail.TabIndex = 0;
            grpMailDetail.TabStop = false;
            grpMailDetail.Text = "  CHI TIẾT THƯ  ";
            // 
            // lblClueAlert
            // 
            lblClueAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblClueAlert.BackColor = Color.FromArgb(240, 253, 244);
            lblClueAlert.BorderStyle = BorderStyle.FixedSingle;
            lblClueAlert.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClueAlert.ForeColor = Color.FromArgb(22, 101, 52);
            lblClueAlert.Location = new Point(12, 445);
            lblClueAlert.Name = "lblClueAlert";
            lblClueAlert.Size = new Size(456, 32);
            lblClueAlert.TabIndex = 9;
            lblClueAlert.Text = "🔍 BẰNG CHỨNG ĐÃ ĐƯỢC PHÁT HIỆN TỪ EMAIL NÀY";
            lblClueAlert.TextAlign = ContentAlignment.MiddleCenter;
            lblClueAlert.Visible = false;
            // 
            // txtMailBody
            // 
            txtMailBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMailBody.BackColor = Color.FromArgb(248, 250, 252);
            txtMailBody.BorderStyle = BorderStyle.None;
            txtMailBody.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtMailBody.ForeColor = Color.FromArgb(30, 41, 59);
            txtMailBody.Location = new Point(12, 140);
            txtMailBody.Name = "txtMailBody";
            txtMailBody.ReadOnly = true;
            txtMailBody.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtMailBody.WordWrap = true;
            txtMailBody.Size = new Size(456, 295);
            txtMailBody.TabIndex = 8;
            txtMailBody.Text = "Chọn một thư ở danh sách bên trái để đọc...";
            // 
            // lblSubjectValue
            // 
            lblSubjectValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSubjectValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSubjectValue.ForeColor = Color.FromArgb(15, 30, 60);
            lblSubjectValue.Location = new Point(90, 105);
            lblSubjectValue.Name = "lblSubjectValue";
            lblSubjectValue.Size = new Size(378, 22);
            lblSubjectValue.TabIndex = 7;
            lblSubjectValue.Text = "---";
            // 
            // lblSubject
            // 
            lblSubject.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubject.Location = new Point(12, 105);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(75, 20);
            lblSubject.TabIndex = 6;
            lblSubject.Text = "Tiêu đề:";
            // 
            // lblDateValue
            // 
            lblDateValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDateValue.ForeColor = Color.FromArgb(71, 85, 105);
            lblDateValue.Location = new Point(90, 80);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new Size(378, 20);
            lblDateValue.TabIndex = 5;
            lblDateValue.Text = "---";
            // 
            // lblDate
            // 
            lblDate.ForeColor = Color.FromArgb(100, 116, 139);
            lblDate.Location = new Point(12, 80);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(75, 20);
            lblDate.TabIndex = 4;
            lblDate.Text = "Thời gian:";
            // 
            // lblRecipientValue
            // 
            lblRecipientValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRecipientValue.ForeColor = Color.FromArgb(30, 41, 59);
            lblRecipientValue.Location = new Point(90, 55);
            lblRecipientValue.Name = "lblRecipientValue";
            lblRecipientValue.Size = new Size(378, 20);
            lblRecipientValue.TabIndex = 3;
            lblRecipientValue.Text = "---";
            // 
            // lblRecipient
            // 
            lblRecipient.ForeColor = Color.FromArgb(100, 116, 139);
            lblRecipient.Location = new Point(12, 55);
            lblRecipient.Name = "lblRecipient";
            lblRecipient.Size = new Size(75, 20);
            lblRecipient.TabIndex = 2;
            lblRecipient.Text = "Đến:";
            // 
            // lblSenderValue
            // 
            lblSenderValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSenderValue.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSenderValue.ForeColor = Color.FromArgb(15, 30, 60);
            lblSenderValue.Location = new Point(90, 30);
            lblSenderValue.Name = "lblSenderValue";
            lblSenderValue.Size = new Size(378, 20);
            lblSenderValue.TabIndex = 1;
            lblSenderValue.Text = "---";
            // 
            // lblSender
            // 
            lblSender.ForeColor = Color.FromArgb(100, 116, 139);
            lblSender.Location = new Point(12, 30);
            lblSender.Name = "lblSender";
            lblSender.Size = new Size(75, 20);
            lblSender.TabIndex = 0;
            lblSender.Text = "Từ:";
            // 
            // MailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(920, 580);
            Name = "MailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mail Client — Novatech Internal Mail";
            Load += MailForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlList.ResumeLayout(false);
            grpMailDetail.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlMain;
        private SplitContainer splitContainer1;
        private Panel pnlList;
        private ListView lvEmails;
        private ColumnHeader colSender;
        private ColumnHeader colSubject;
        private ColumnHeader colTime;
        private Label lblListHeader;
        private GroupBox grpMailDetail;
        private Label lblSender;
        private Label lblSenderValue;
        private Label lblRecipient;
        private Label lblRecipientValue;
        private Label lblDate;
        private Label lblDateValue;
        private Label lblSubject;
        private Label lblSubjectValue;
        private RichTextBox txtMailBody;
        private Label lblClueAlert;
    }
}


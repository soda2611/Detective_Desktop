namespace _2611_WIN_B3.Forms
{
    partial class BrowserForm
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
            txtAddressBar = new TextBox();
            lblAddress = new Label();
            lblTitle = new Label();
            pnlBottom = new Panel();
            lblClueNotice = new Label();
            pnlMain = new Panel();
            dgvHistory = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colUrl = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(txtAddressBar);
            pnlHeader.Controls.Add(lblAddress);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 84);
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
            btnClose.Location = new Point(1000, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 34);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // txtAddressBar
            // 
            txtAddressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddressBar.BackColor = Color.White;
            txtAddressBar.BorderStyle = BorderStyle.FixedSingle;
            txtAddressBar.Font = new Font("Segoe UI", 10.5F);
            txtAddressBar.ForeColor = Color.FromArgb(15, 23, 42);
            txtAddressBar.Location = new Point(100, 46);
            txtAddressBar.Name = "txtAddressBar";
            txtAddressBar.ReadOnly = true;
            txtAddressBar.Size = new Size(988, 27);
            txtAddressBar.TabIndex = 2;
            txtAddressBar.Text = "browser://history/audit_log?user=david.miller";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(100, 116, 139);
            lblAddress.Location = new Point(16, 49);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(78, 20);
            lblAddress.TabIndex = 1;
            lblAddress.Text = "URL bar:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🌐 TRÌNH DUYỆT WEB — LỊCH SỬ TRUY CẬP";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(lblClueNotice);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 491);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(12);
            pnlBottom.Size = new Size(884, 70);
            pnlBottom.TabIndex = 1;
            // 
            // lblClueNotice
            // 
            lblClueNotice.BackColor = Color.FromArgb(240, 253, 244);
            lblClueNotice.BorderStyle = BorderStyle.FixedSingle;
            lblClueNotice.Dock = DockStyle.Fill;
            lblClueNotice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClueNotice.ForeColor = Color.FromArgb(22, 101, 52);
            lblClueNotice.Location = new Point(12, 12);
            lblClueNotice.Name = "lblClueNotice";
            lblClueNotice.Size = new Size(860, 46);
            lblClueNotice.TabIndex = 0;
            lblClueNotice.Text = "💡 Nhấp vào từng dòng trong bảng lịch sử để phân tích hoạt động mạng của nghi phạm.";
            lblClueNotice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvHistory);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 80);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(12);
            pnlMain.Size = new Size(884, 411);
            pnlMain.TabIndex = 2;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colDate, colTime, colTitle, colUrl });
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.Location = new Point(12, 12);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.RowTemplate.Height = 29;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(860, 387);
            dgvHistory.TabIndex = 0;
            dgvHistory.CellClick += dgvHistory_CellClick;
            // 
            // colDate
            // 
            colDate.FillWeight = 20F;
            colDate.HeaderText = "Ngày";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.FillWeight = 15F;
            colTime.HeaderText = "Giờ";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colTitle
            // 
            colTitle.FillWeight = 40F;
            colTitle.HeaderText = "Tiêu đề trang";
            colTitle.MinimumWidth = 6;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colUrl
            // 
            colUrl.FillWeight = 50F;
            colUrl.HeaderText = "Địa chỉ URL";
            colUrl.MinimumWidth = 6;
            colUrl.Name = "colUrl";
            colUrl.ReadOnly = true;
            // 
            // BrowserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(920, 580);
            Name = "BrowserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Web Browser History — Điều tra truy cập mạng";
            Load += BrowserForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblAddress;
        private TextBox txtAddressBar;
        private Button btnClose;
        private Panel pnlBottom;
        private Label lblClueNotice;
        private Panel pnlMain;
        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colUrl;
    }
}


namespace _2611_WIN_B3.Forms
{
    partial class HighScoreForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
            pnlTopBar = new Panel();
            lblFilter = new Label();
            cboFilterCase = new ComboBox();
            lblSummary = new Label();
            pnlBottom = new Panel();
            btnOpenTxt = new Button();
            btnClear = new Button();
            btnRefresh = new Button();
            lvScores = new ListView();
            colRank = new ColumnHeader();
            colDetective = new ColumnHeader();
            colCase = new ColumnHeader();
            colScore = new ColumnHeader();
            colTime = new ColumnHeader();
            colRating = new ColumnHeader();
            colEnding = new ColumnHeader();
            colDate = new ColumnHeader();
            pnlHeader.SuspendLayout();
            pnlTopBar.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1120, 54);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(14, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(505, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏆 BẢNG VÀNG THÀNH TÍCH THÁM TỬ (HIGH SCORES)";
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
            btnClose.Location = new Point(1020, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(248, 250, 252);
            pnlTopBar.Controls.Add(lblFilter);
            pnlTopBar.Controls.Add(cboFilterCase);
            pnlTopBar.Controls.Add(lblSummary);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 50);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(950, 45);
            pnlTopBar.TabIndex = 1;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFilter.ForeColor = Color.FromArgb(15, 45, 80);
            lblFilter.Location = new Point(14, 11);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(108, 23);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Lọc vụ án:";
            // 
            // cboFilterCase
            // 
            cboFilterCase.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboFilterCase.FormattingEnabled = true;
            cboFilterCase.Location = new Point(125, 8);
            cboFilterCase.Name = "cboFilterCase";
            cboFilterCase.Size = new Size(260, 29);
            cboFilterCase.TabIndex = 1;
            cboFilterCase.SelectedIndexChanged += cboFilterCase_SelectedIndexChanged;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSummary.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.ForeColor = Color.FromArgb(22, 101, 52);
            lblSummary.Location = new Point(400, 8);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(538, 29);
            lblSummary.TabIndex = 2;
            lblSummary.Text = "Tổng số kỷ lục: 0";
            lblSummary.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(btnOpenTxt);
            pnlBottom.Controls.Add(btnClear);
            pnlBottom.Controls.Add(btnRefresh);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 510);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(950, 50);
            pnlBottom.TabIndex = 3;
            // 
            // btnOpenTxt
            // 
            btnOpenTxt.BackColor = Color.FromArgb(224, 238, 255);
            btnOpenTxt.Cursor = Cursors.Hand;
            btnOpenTxt.FlatAppearance.BorderColor = Color.FromArgb(170, 205, 245);
            btnOpenTxt.FlatStyle = FlatStyle.Flat;
            btnOpenTxt.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnOpenTxt.ForeColor = Color.FromArgb(10, 65, 140);
            btnOpenTxt.Location = new Point(14, 8);
            btnOpenTxt.Name = "btnOpenTxt";
            btnOpenTxt.Size = new Size(220, 34);
            btnOpenTxt.TabIndex = 0;
            btnOpenTxt.Text = "📂 Mở file highscores.txt";
            btnOpenTxt.UseVisualStyleBackColor = false;
            btnOpenTxt.Click += btnOpenTxt_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(254, 242, 242);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.FromArgb(185, 28, 28);
            btnClear.Location = new Point(808, 8);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "🗑 Xóa lịch sử";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(240, 244, 250);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new Point(245, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 34);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lvScores
            // 
            lvScores.Columns.AddRange(new ColumnHeader[] { colRank, colDetective, colCase, colScore, colTime, colRating, colEnding, colDate });
            lvScores.Dock = DockStyle.Fill;
            lvScores.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lvScores.FullRowSelect = true;
            lvScores.GridLines = true;
            lvScores.Location = new Point(0, 95);
            lvScores.MultiSelect = false;
            lvScores.Name = "lvScores";
            lvScores.Size = new Size(950, 415);
            lvScores.TabIndex = 2;
            lvScores.UseCompatibleStateImageBehavior = false;
            lvScores.View = View.Details;
            // 
            // colRank
            // 
            colRank.Text = "# Hạng";
            colRank.Width = 70;
            // 
            // colDetective
            // 
            colDetective.Text = "Thám tử";
            colDetective.Width = 140;
            // 
            // colCase
            // 
            colCase.Text = "Vụ án";
            colCase.Width = 130;
            // 
            // colScore
            // 
            colScore.Text = "Điểm";
            colScore.TextAlign = HorizontalAlignment.Center;
            colScore.Width = 70;
            // 
            // colTime
            // 
            colTime.Text = "Thời gian";
            colTime.TextAlign = HorizontalAlignment.Center;
            colTime.Width = 90;
            // 
            // colRating
            // 
            colRating.Text = "Xếp hạng";
            colRating.TextAlign = HorizontalAlignment.Center;
            colRating.Width = 110;
            // 
            // colEnding
            // 
            colEnding.Text = "Kết cục (Ending)";
            colEnding.Width = 190;
            // 
            // colDate
            // 
            colDate.Text = "Ngày phá án";
            colDate.Width = 140;
            // 
            // HighScoreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1120, 680);
            Controls.Add(lvScores);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(1000, 580);
            Name = "HighScoreForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bảng Vàng Thành Tích Thám Tử (High Scores)";
            Load += HighScoreForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlTopBar;
        private Label lblFilter;
        private ComboBox cboFilterCase;
        private Label lblSummary;
        private Panel pnlBottom;
        private Button btnOpenTxt;
        private Button btnRefresh;
        private Button btnClear;
        private ListView lvScores;
        private ColumnHeader colRank;
        private ColumnHeader colDetective;
        private ColumnHeader colCase;
        private ColumnHeader colScore;
        private ColumnHeader colTime;
        private ColumnHeader colRating;
        private ColumnHeader colEnding;
        private ColumnHeader colDate;
    }
}


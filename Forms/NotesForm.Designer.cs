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
            btnClose = new Button();
            btnSave = new Button();
            lblTitle = new Label();
            pnlMain = new Panel();
            txtNotes = new RichTextBox();
            pnlBottom = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(240, 244, 250);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(btnSave);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(784, 55);
            pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(226, 232, 240);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.FromArgb(30, 41, 59);
            btnClose.Location = new Point(682, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 101, 52);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(540, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Lưu ghi chép";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(15, 30, 60);
            lblTitle.Location = new Point(14, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(331, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📝 SỔ TAY THÁM TỬ — GHI CHÉP SUY LUẬN";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(txtNotes);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 55);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(12);
            pnlMain.Size = new Size(784, 466);
            pnlMain.TabIndex = 1;
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.FromArgb(254, 254, 250);
            txtNotes.BorderStyle = BorderStyle.None;
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Font = new Font("Consolas", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtNotes.ForeColor = Color.FromArgb(30, 41, 59);
            txtNotes.Location = new Point(12, 12);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(760, 442);
            txtNotes.TabIndex = 0;
            txtNotes.Text = "";
            txtNotes.TextChanged += txtNotes_TextChanged;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 248, 252);
            pnlBottom.Controls.Add(lblStatus);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 521);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(784, 40);
            pnlBottom.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(12, 0, 0, 0);
            lblStatus.Size = new Size(784, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Ghi chép được tự động đồng bộ vào bộ nhớ trạng thái GameState.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NotesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 245);
            ClientSize = new Size(784, 561);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(600, 400);
            Name = "NotesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detective Notes — Sổ Tay Thám Tử";
            Load += NotesForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnSave;
        private Button btnClose;
        private Panel pnlMain;
        private RichTextBox txtNotes;
        private Panel pnlBottom;
        private Label lblStatus;
    }
}


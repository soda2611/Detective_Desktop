using System;
using System.Drawing;
using System.Windows.Forms;
using _2611_WIN_B3.Game;

namespace _2611_WIN_B3.Forms
{
    public partial class NotesForm : Form
    {
        public NotesForm()
        {
            InitializeComponent();
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {
            Size = new Size(950, 660);
            MinimumSize = new Size(800, 520);
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtNotes.Font = new Font("Consolas", 12F, FontStyle.Regular);
            btnSave.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnSave.Size = new Size(150, 34);
            btnSave.Location = new Point(pnlHeader.Width - 255, 11);
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnClose.Size = new Size(90, 34);
            btnClose.Location = new Point(pnlHeader.Width - 95, 11);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            txtNotes.Text = GameManager.Instance.State.DetectiveNotes;
            lblStatus.Text = $"Đã tải sổ tay thám tử ({txtNotes.TextLength} ký tự).";
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            GameManager.Instance.State.DetectiveNotes = txtNotes.Text;
            lblStatus.Text = "Đang tự động đồng bộ thay đổi...";
            lblStatus.ForeColor = Color.FromArgb(180, 83, 9);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Notification);
            GameManager.Instance.State.DetectiveNotes = txtNotes.Text;
            lblStatus.Text = "✓ Đã lưu sổ tay thám tử thành công!";
            lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}


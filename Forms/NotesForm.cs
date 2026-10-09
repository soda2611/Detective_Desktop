using System;
using System.Drawing;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class NotesForm : Form
    {
        private bool _isViewingPersonalNote = true;

        public NotesForm()
        {
            InitializeComponent();
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {
            Size = new Size(1000, 680);
            MinimumSize = new Size(820, 520);
            CenterToParent();

            LoadNotesList();
        }

        private void LoadNotesList()
        {
            lvNotes.Items.Clear();

            // 1. Mục Sổ tay điều tra cá nhân của thám tử
            var journalItem = new ListViewItem("📝 Sổ tay thám tử của bạn")
            {
                Tag = null,
                Font = new Font(lvNotes.Font, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42)
            };
            journalItem.SubItems.Add("Cá nhân");
            lvNotes.Items.Add(journalItem);

            // 2. Danh sách Sticky Notes trích xuất từ vụ án
            var notes = GameManager.Instance.Notes;
            foreach (var note in notes)
            {
                bool isRead = GameManager.Instance.State.ReadNoteIds.Contains(note.Id);
                bool hasEvidence = !string.IsNullOrEmpty(note.EvidenceId);
                bool isClueDiscovered = hasEvidence && GameManager.Instance.State.DiscoveredEvidenceIds.Contains(note.EvidenceId!);

                string prefix = hasEvidence ? (isClueDiscovered ? "⭐ " : "📌 ") : "📄 ";
                var item = new ListViewItem(prefix + note.Title)
                {
                    Tag = note
                };
                item.SubItems.Add(note.Category);

                if (!isRead)
                {
                    item.Font = new Font(lvNotes.Font, FontStyle.Bold);
                    item.ForeColor = Color.FromArgb(15, 23, 42);
                }
                else
                {
                    item.Font = new Font(lvNotes.Font, FontStyle.Regular);
                    item.ForeColor = Color.FromArgb(100, 116, 139);
                }

                lvNotes.Items.Add(item);
            }

            lblNotesCount.Text = $"Tổng số: {notes.Count} ghi chú vụ án + Sổ tay cá nhân";

            // Tự động chọn item đầu tiên
            if (lvNotes.Items.Count > 0)
            {
                lvNotes.Items[0].Selected = true;
            }
        }

        private void lvNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count == 0) return;

            var item = lvNotes.SelectedItems[0];

            if (item.Tag == null)
            {
                // Chế độ: Sổ tay cá nhân của thám tử
                _isViewingPersonalNote = true;
                lblNoteTitle.Text = "📝 SỔ TAY ĐIỀU TRA CỦA BẠN (DETECTIVE JOURNAL)";
                lblNoteInfo.Text = "Tác giả: Thám tử điều tra  |  Chế độ: Soạn thảo tự do & Tự động lưu";

                pnlClueBanner.Visible = false;
                btnCopyNote.Visible = false;
                btnSave.Visible = true;

                txtNotes.ReadOnly = false;
                txtNotes.BackColor = Color.FromArgb(254, 254, 250);
                txtNotes.Font = new Font("Consolas", 11.5F, FontStyle.Regular);
                txtNotes.Text = GameManager.Instance.State.DetectiveNotes;

                lblStatus.Text = $"Đã mở sổ tay thám tử ({txtNotes.TextLength} ký tự). Gõ văn bản và bấm '💾 Lưu sổ tay'.";
                lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else if (item.Tag is NoteItem note)
            {
                // Chế độ: Khám nghiệm Sticky Note của nạn nhân/hệ thống
                _isViewingPersonalNote = false;
                lblNoteTitle.Text = note.Title;
                lblNoteInfo.Text = $"Tác giả: {note.Author}  |  Thời gian: {note.Date}  |  Phân loại: {note.Category}";

                btnCopyNote.Visible = true;
                btnSave.Visible = false;

                txtNotes.ReadOnly = true;
                txtNotes.BackColor = Color.FromArgb(255, 253, 235); // Vàng nhạt như giấy Sticky Note thật
                txtNotes.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                txtNotes.Text = note.Content;

                // Đánh dấu đã đọc
                GameManager.Instance.State.ReadNoteIds.Add(note.Id);
                item.Font = new Font(lvNotes.Font, FontStyle.Regular);
                item.ForeColor = Color.FromArgb(100, 116, 139);

                // Khám nghiệm manh mối (Clue Discovery Mechanism)
                if (!string.IsNullOrEmpty(note.EvidenceId))
                {
                    pnlClueBanner.Visible = true;
                    bool isNew = GameManager.Instance.EvidenceManager.DiscoverEvidence(note.EvidenceId);
                    var ev = GameManager.Instance.EvidenceManager.GetEvidence(note.EvidenceId);

                    if (isNew)
                    {
                        lblClueBanner.Text = $"⭐ PHÁT HIỆN BẰNG CHỨNG MỚI [{note.EvidenceId}]: {ev?.Name}";
                        lblClueBanner.ForeColor = Color.FromArgb(180, 83, 9);
                        pnlClueBanner.BackColor = Color.FromArgb(254, 243, 199);
                        lblStatus.Text = $"⭐ Đã phát hiện và ghi nhận manh mối [{note.EvidenceId}] vào hồ sơ vụ án!";
                        lblStatus.ForeColor = Color.FromArgb(180, 83, 9);
                        item.Text = "⭐ " + note.Title;
                    }
                    else
                    {
                        lblClueBanner.Text = $"🔍 BẰNG CHỨNG [{note.EvidenceId}] ĐÃ ĐƯỢC GHI NHẬN: {ev?.Name}";
                        lblClueBanner.ForeColor = Color.FromArgb(22, 101, 52);
                        pnlClueBanner.BackColor = Color.FromArgb(240, 253, 244);
                        lblStatus.Text = $"Bằng chứng [{note.EvidenceId}] đã có trong hồ sơ điều tra.";
                        lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                        item.Text = "⭐ " + note.Title;
                    }

                    btnActionClue.Visible = true;
                }
                else
                {
                    pnlClueBanner.Visible = false;
                    lblStatus.Text = $"Đang đọc tài liệu ghi chú của: {note.Author}.";
                    lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
                }
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            if (_isViewingPersonalNote)
            {
                GameManager.Instance.State.DetectiveNotes = txtNotes.Text;
                lblStatus.Text = "Đang tự động đồng bộ thay đổi vào GameState...";
                lblStatus.ForeColor = Color.FromArgb(180, 83, 9);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isViewingPersonalNote)
            {
                AudioManager.Instance.Play(SoundEffect.Notification);
                GameManager.Instance.State.DetectiveNotes = txtNotes.Text;
                lblStatus.Text = "✓ Đã lưu sổ tay thám tử thành công!";
                lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
            }
        }

        private void btnCopyNote_Click(object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count > 0 && lvNotes.SelectedItems[0].Tag is NoteItem note)
            {
                AudioManager.Instance.Play(SoundEffect.Notification);
                string snippet = $"\n\n--- [TRÍCH TỪ: {note.Title} ({note.Author})] ---\n{note.Content}\n";
                GameManager.Instance.State.DetectiveNotes += snippet;

                lblStatus.Text = $"✓ Đã sao chép trích dẫn '{note.Title}' vào Sổ tay thám tử!";
                lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
            }
        }

        private void btnActionClue_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new EvidenceBoardForm();
            form.Show(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}

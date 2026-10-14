using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class RecycleBinForm : Form
    {
        public RecycleBinForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void RecycleBinForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1400, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(860, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1050, targetW), Math.Min(680, targetH));
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lvDeleted.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            txtDetail.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular);
            grpDetail.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblClueAlert.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRestore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pnlHeader.Height = 58;
            btnRestore.Height = 38;
            btnRestore.Top = 10;
            btnClose.Height = 38;
            btnClose.Top = 10;
            lblClueAlert.Height = 38;

            colName.Width = 320;
            colOriginalLoc.Width = 300;
            colSize.Width = 120;
            colDateDeleted.Width = 200;

            LoadDeletedFiles();
            UpdateDetailLayout();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (lblTitle != null && btnRestore != null)
            {
                lblTitle.AutoEllipsis = true;
                lblTitle.Width = Math.Max(100, btnRestore.Left - lblTitle.Left - 15);
            }
            UpdateDetailLayout();
        }

        private void UpdateDetailLayout()
        {
            if (grpDetail == null || txtDetail == null || lblClueAlert == null) return;
            int clientW = grpDetail.ClientSize.Width;
            int clientH = grpDetail.ClientSize.Height;
            if (clientW < 50 || clientH < 50) return;

            int margin = 12;
            int top = 26;
            int clueH = 38;

            if (lblClueAlert.Visible)
            {
                lblClueAlert.Location = new Point(margin, clientH - clueH - 10);
                lblClueAlert.Size = new Size(clientW - (margin * 2), clueH);
                txtDetail.Location = new Point(margin, top);
                txtDetail.Size = new Size(clientW - (margin * 2), Math.Max(40, lblClueAlert.Top - top - 8));
            }
            else
            {
                txtDetail.Location = new Point(margin, top);
                txtDetail.Size = new Size(clientW - (margin * 2), Math.Max(40, clientH - top - 12));
            }
        }

        private void LoadDeletedFiles()
        {
            lvDeleted.Items.Clear();
            var deletedFiles = GameManager.Instance.CaseManager.FileItems.Where(f => f.IsDeleted).ToList();

            var c = GameManager.Instance.CaseManager.CurrentCase;
            foreach (var file in deletedFiles)
            {
                var lvi = new ListViewItem(file.FileName)
                {
                    Tag = file
                };
                string origFolder = (file.OriginalFolder ?? string.Empty).Replace(" / ", "\\").Replace("/", "\\");
                lvi.SubItems.Add(string.IsNullOrEmpty(origFolder) ? $"C:\\Users\\{c.VictimUserName}" : $"C:\\Users\\{c.VictimUserName}\\{origFolder}");
                lvi.SubItems.Add(file.Size);
                lvi.SubItems.Add(file.ModifiedTime);

                if (!string.IsNullOrEmpty(file.EvidenceId))
                {
                    lvi.ForeColor = Color.FromArgb(194, 65, 12);
                    lvi.Font = new Font(lvDeleted.Font, FontStyle.Bold);
                }
                else
                {
                    lvi.ForeColor = Color.FromArgb(15, 23, 42);
                }

                lvDeleted.Items.Add(lvi);
            }

            if (lvDeleted.Items.Count > 0)
            {
                lvDeleted.Items[0].Selected = true;
            }
            else
            {
                txtDetail.Text = "Thùng rác hiện đang trống. Tất cả tập tin đã được khôi phục hoặc không có tập tin bị xóa.";
                lblClueAlert.Visible = false;
                UpdateDetailLayout();
            }
        }

        private void InspectCurrentFile()
        {
            if (lvDeleted.SelectedItems.Count == 0) return;

            var item = lvDeleted.SelectedItems[0];
            if (item.Tag is FileItem file)
            {
                txtDetail.Text = file.Content;

                if (!string.IsNullOrEmpty(file.EvidenceId))
                {
                    bool isNew = GameManager.Instance.EvidenceManager.DiscoverEvidence(file.EvidenceId);
                    var ev = GameManager.Instance.EvidenceManager.GetEvidence(file.EvidenceId);
                    lblClueAlert.Visible = true;
                    if (isNew)
                    {
                        lblClueAlert.Text = $"⭐ TÌM THẤY TẬP TIN THEN CHỐT BỊ XÓA [{file.EvidenceId}]: {ev?.Name}";
                    }
                    else
                    {
                        lblClueAlert.Text = $"🔍 BẰNG CHỨNG [{file.EvidenceId}] ĐÃ ĐƯỢC LƯU TRỮ TRONG HỒ SƠ: {ev?.Name}";
                    }
                }
                else
                {
                    lblClueAlert.Visible = false;
                }
                UpdateDetailLayout();
            }
        }

        private void lvDeleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            InspectCurrentFile();
        }

        private void lvDeleted_DoubleClick(object sender, EventArgs e)
        {
            InspectCurrentFile();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (lvDeleted.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tập tin để khôi phục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = lvDeleted.SelectedItems[0];
            if (item.Tag is FileItem file)
            {
                // Thực hiện khôi phục tập tin thực sự về hệ thống tệp
                file.IsDeleted = false;
                file.Folder = file.OriginalFolder;
                GameManager.Instance.State.RestoredFileIds.Add(file.Id);

                bool isNew = false;
                Evidence? ev = null;
                if (!string.IsNullOrEmpty(file.EvidenceId))
                {
                    isNew = GameManager.Instance.EvidenceManager.DiscoverEvidence(file.EvidenceId);
                    ev = GameManager.Instance.EvidenceManager.GetEvidence(file.EvidenceId);
                }

                // Lưu trạng thái và thông báo tới các Form đang mở (Explorer, v.v.)
                GameManager.Instance.NotifyStateChanged();

                var c = GameManager.Instance.CaseManager.CurrentCase;
                string restoredFolder = (file.Folder ?? string.Empty).Replace(" / ", "\\").Replace("/", "\\");
                string targetPath = string.IsNullOrEmpty(restoredFolder) ? $"C:\\Users\\{c.VictimUserName}" : $"C:\\Users\\{c.VictimUserName}\\{restoredFolder}";
                string msg = $"Đã khôi phục tập tin '{file.FileName}' về thư mục {targetPath} thành công!\n" +
                             $"Nội dung đã được xác minh toàn vẹn và hiện đã có thể truy cập trong File Explorer.";

                if (isNew && ev != null)
                {
                    msg += $"\n\n⭐ Phát hiện bằng chứng then chốt: [{ev.Id}] {ev.Name}";
                }

                MessageBox.Show(msg, "Khôi phục thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nạp lại danh sách trong Thùng rác (tập tin đã khôi phục sẽ biến mất)
                LoadDeletedFiles();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}


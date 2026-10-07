using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class ExplorerForm : Form
    {
        public ExplorerForm()
        {
            InitializeComponent();
        }

        private void ExplorerForm_Load(object sender, EventArgs e)
        {
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tvFolders.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lvFiles.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            txtFilePreview.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            grpPreview.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblFileClue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            colName.Width = 340;
            colSize.Width = 110;
            colModified.Width = 190;

            InitFolderTree();
            GameManager.Instance.OnStateUpdated += OnGameStateUpdated;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (lblTitle != null && btnClose != null)
            {
                lblTitle.AutoEllipsis = true;
                lblTitle.Width = Math.Max(100, btnClose.Left - lblTitle.Left - 15);
            }
        }

        private void OnGameStateUpdated()
        {
            if (IsDisposed || !IsHandleCreated) return;
            try
            {
                BeginInvoke(new Action(() =>
                {
                    if (tvFolders.SelectedNode != null)
                    {
                        string folderName = tvFolders.SelectedNode.Tag as string ?? "";
                        LoadFilesForFolder(folderName);
                    }
                }));
            }
            catch { }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (tvFolders.SelectedNode != null)
            {
                string folderName = tvFolders.SelectedNode.Tag as string ?? "";
                LoadFilesForFolder(folderName);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            GameManager.Instance.OnStateUpdated -= OnGameStateUpdated;
            base.OnFormClosed(e);
        }

        private void InitFolderTree()
        {
            var c = GameManager.Instance.CaseManager.CurrentCase;
            tvFolders.Nodes.Clear();
            var root = new TreeNode($"This PC (Máy tính của {c.VictimShortName})");

            string[] folders = { "Documents", "Projects", "Downloads", "Pictures", "Work", "Archive" };
            foreach (var f in folders)
            {
                var node = new TreeNode(f) { Tag = f };
                root.Nodes.Add(node);
            }

            tvFolders.Nodes.Add(root);
            root.Expand();

            if (root.Nodes.Count > 0)
            {
                tvFolders.SelectedNode = root.Nodes[0];
            }
        }

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            var c = GameManager.Instance.CaseManager.CurrentCase;
            string folderName = e.Node.Tag as string ?? "";
            txtPath.Text = $"C:\\Users\\{c.VictimUserName}\\{folderName}";
            LoadFilesForFolder(folderName);
        }

        private void LoadFilesForFolder(string folderName)
        {
            lvFiles.Items.Clear();
            txtFilePreview.Text = "Chọn một tập tin ở trên để đọc nội dung...";
            lblFileClue.Visible = false;

            var files = GameManager.Instance.CaseManager.FileItems
                .Where(f => !f.IsDeleted && (string.IsNullOrEmpty(folderName) || f.Folder.Equals(folderName, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            foreach (var file in files)
            {
                var lvi = new ListViewItem(file.FileName)
                {
                    Tag = file
                };
                lvi.SubItems.Add(file.Size);
                lvi.SubItems.Add(file.ModifiedTime);

                if (!string.IsNullOrEmpty(file.EvidenceId))
                {
                    lvi.ForeColor = Color.FromArgb(194, 65, 12);
                }
                else
                {
                    lvi.ForeColor = Color.FromArgb(15, 23, 42);
                }

                lvFiles.Items.Add(lvi);
            }
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0) return;

            var item = lvFiles.SelectedItems[0];
            if (item.Tag is FileItem file)
            {
                txtFilePreview.Text = file.Content;
                GameManager.Instance.State.OpenedFileIds.Add(file.Id);

                if (!string.IsNullOrEmpty(file.EvidenceId))
                {
                    bool isNew = GameManager.Instance.EvidenceManager.DiscoverEvidence(file.EvidenceId);
                    var ev = GameManager.Instance.EvidenceManager.GetEvidence(file.EvidenceId);
                    lblFileClue.Visible = true;
                    if (isNew)
                    {
                        lblFileClue.Text = $"⭐ TẬP TIN NÀY CHỨA MANH MỐI QUAN TRỌNG [{file.EvidenceId}]: {ev?.Name}";
                    }
                    else
                    {
                        lblFileClue.Text = $"🔍 BẰNG CHỨNG [{file.EvidenceId}] ĐÃ CÓ TRONG HỒ SƠ: {ev?.Name}";
                    }
                }
                else
                {
                    lblFileClue.Visible = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}


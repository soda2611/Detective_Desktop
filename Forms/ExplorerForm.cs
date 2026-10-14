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
            AppIconHelper.ApplyTo(this);
        }

        private void ExplorerForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1400, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(880, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1050, targetW), Math.Min(680, targetH));
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            tvFolders.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lvFiles.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            txtFilePreview.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular);
            grpPreview.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblFileClue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pnlHeader.Height = 74;
            btnClose.Height = 38;
            btnClose.Top = 16;
            lblPath.Location = new Point(12, 42);
            txtPath.Location = new Point(110, 40);
            txtPath.Height = 28;
            lblFileClue.Height = 38;

            colName.Width = 320;
            colFolder.Width = 220;
            colSize.Width = 110;
            colModified.Width = 180;

            InitFolderTree();
            UpdatePreviewLayout();
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
            UpdatePreviewLayout();
        }

        private void UpdatePreviewLayout()
        {
            if (grpPreview == null || txtFilePreview == null || lblFileClue == null) return;
            int clientW = grpPreview.ClientSize.Width;
            int clientH = grpPreview.ClientSize.Height;
            if (clientW < 50 || clientH < 50) return;

            int margin = 12;
            int top = 26;
            int clueH = 38;

            if (lblFileClue.Visible)
            {
                lblFileClue.Location = new Point(margin, clientH - clueH - 10);
                lblFileClue.Size = new Size(clientW - (margin * 2), clueH);
                txtFilePreview.Location = new Point(margin, top);
                txtFilePreview.Size = new Size(clientW - (margin * 2), Math.Max(40, lblFileClue.Top - top - 8));
            }
            else
            {
                txtFilePreview.Location = new Point(margin, top);
                txtFilePreview.Size = new Size(clientW - (margin * 2), Math.Max(40, clientH - top - 12));
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
                        LoadFilesForFolder(folderName, tvFolders.SelectedNode);
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
                LoadFilesForFolder(folderName, tvFolders.SelectedNode);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            GameManager.Instance.OnStateUpdated -= OnGameStateUpdated;
            base.OnFormClosed(e);
        }

        public static string NormalizeToDocumentsPath(string? folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath)) return "Documents";
            string trimmed = folderPath.Trim();
            if (trimmed.Equals("Recycle Bin", StringComparison.OrdinalIgnoreCase)) return trimmed;

            var parts = trimmed.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(p => p.Trim())
                               .Where(p => !string.IsNullOrEmpty(p))
                               .ToList();
            if (parts.Count == 0) return "Documents";

            if (!parts[0].Equals("Documents", StringComparison.OrdinalIgnoreCase))
            {
                parts.Insert(0, "Documents");
            }
            return string.Join(" / ", parts);
        }

        private void InitFolderTree()
        {
            var c = GameManager.Instance.CaseManager.CurrentCase;
            tvFolders.Nodes.Clear();
            var root = new TreeNode($"This PC (Máy tính của {c.VictimShortName})") { Tag = "" };

            // Thư mục cha Documents đại diện cho toàn bộ tài liệu cá nhân
            var docNode = new TreeNode("Documents") { Tag = "Documents" };
            root.Nodes.Add(docNode);

            // 1. Thu thập tất cả các đường dẫn thư mục xuất hiện trong cấu hình vụ án (Folder và OriginalFolder)
            var allFolders = GameManager.Instance.CaseManager.FileItems
                .SelectMany(f => new[] { f.Folder, f.OriginalFolder })
                .Where(f => !string.IsNullOrWhiteSpace(f) && !f.Equals("Recycle Bin", StringComparison.OrdinalIgnoreCase))
                .Select(f => NormalizeToDocumentsPath(f))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(f => f)
                .ToList();

            // 2. Tự động sinh cây thư mục con hoàn toàn nằm dưới thư mục cha Documents
            foreach (var folderPath in allFolders)
            {
                AddDocumentsSubFolderPath(docNode, folderPath);
            }

            tvFolders.Nodes.Add(root);
            root.Expand();
            docNode.Expand();

            // Tự động mở rộng các nhánh thư mục con
            ExpandAllBranches(docNode);

            // Mặc định chọn ngay thư mục cha Documents
            tvFolders.SelectedNode = docNode;
        }

        private static void ExpandAllBranches(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                if (child.Nodes.Count > 0)
                {
                    child.Expand();
                    ExpandAllBranches(child);
                }
            }
        }

        private static void AddDocumentsSubFolderPath(TreeNode docNode, string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath)) return;

            var segments = folderPath
                .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray();

            if (segments.Length <= 1) return; // Chỉ có "Documents"

            TreeNode currentNode = docNode;
            var pathParts = new System.Collections.Generic.List<string> { "Documents" };

            // Duyệt từ index 1 (các thư mục con sau Documents)
            for (int i = 1; i < segments.Length; i++)
            {
                string seg = segments[i];
                pathParts.Add(seg);
                string currentAccumulatedPath = string.Join(" / ", pathParts);

                TreeNode? existingNode = currentNode.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(n => n.Text.Equals(seg, StringComparison.OrdinalIgnoreCase));

                if (existingNode == null)
                {
                    existingNode = new TreeNode(seg)
                    {
                        Tag = currentAccumulatedPath
                    };
                    currentNode.Nodes.Add(existingNode);
                }
                else
                {
                    if (existingNode.Tag == null || string.IsNullOrWhiteSpace(existingNode.Tag.ToString()))
                    {
                        existingNode.Tag = currentAccumulatedPath;
                    }
                }

                currentNode = existingNode;
            }
        }

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            var c = GameManager.Instance.CaseManager.CurrentCase;
            string folderPath = e.Node.Tag as string ?? "";

            if (string.IsNullOrEmpty(folderPath))
            {
                txtPath.Text = $"C:\\Users\\{c.VictimUserName}";
            }
            else
            {
                string winPath = string.Join("\\", folderPath
                    .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()));
                txtPath.Text = $"C:\\Users\\{c.VictimUserName}\\{winPath}";
            }

            LoadFilesForFolder(folderPath, e.Node);
        }

        private void LoadFilesForFolder(string folderName, TreeNode? currentNode)
        {
            lvFiles.Items.Clear();
            txtFilePreview.Text = "Chọn một tập tin ở trên để đọc nội dung...";
            lblFileClue.Visible = false;

            // 1. Nếu node hiện tại có các thư mục con, hiển thị các thư mục con ở đầu danh sách bên phải
            if (currentNode != null && currentNode.Nodes.Count > 0)
            {
                foreach (TreeNode childNode in currentNode.Nodes)
                {
                    var lviFolder = new ListViewItem($"📁 {childNode.Text}")
                    {
                        Tag = childNode,
                        ForeColor = Color.FromArgb(2, 132, 199),
                        Font = new Font(lvFiles.Font, FontStyle.Bold)
                    };
                    lviFolder.SubItems.Add(childNode.Tag as string ?? childNode.Text);
                    lviFolder.SubItems.Add("<Thư mục>");
                    lviFolder.SubItems.Add("—");
                    lvFiles.Items.Add(lviFolder);
                }
            }

            var allActiveFiles = GameManager.Instance.CaseManager.FileItems
                .Where(f => !f.IsDeleted)
                .ToList();

            List<FileItem> files;
            if (string.IsNullOrEmpty(folderName))
            {
                files = allActiveFiles;
            }
            else
            {
                // 1. Thử lọc các tệp tin nằm trực tiếp tại thư mục được chọn
                files = allActiveFiles.Where(f => IsMatchingFolder(f.Folder, folderName, false)).ToList();

                // 2. Nếu thư mục cha không có tệp tin trực tiếp, hiển thị các tệp tin trong các thư mục con của nó
                if (files.Count == 0)
                {
                    files = allActiveFiles.Where(f => IsMatchingFolder(f.Folder, folderName, true)).ToList();
                }
            }

            foreach (var file in files)
            {
                var lvi = new ListViewItem(file.FileName)
                {
                    Tag = file
                };
                lvi.SubItems.Add(NormalizeToDocumentsPath(file.Folder));
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

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0) return;

            var item = lvFiles.SelectedItems[0];
            if (item.Tag is TreeNode targetNode)
            {
                tvFolders.SelectedNode = targetNode;
                targetNode.Expand();
            }
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0) return;

            var item = lvFiles.SelectedItems[0];
            if (item.Tag is TreeNode folderNode)
            {
                txtFilePreview.Text = $"📁 THƯ MỤC: {folderNode.Text}\n" +
                                      $"Đường dẫn: {folderNode.Tag}\n\n" +
                                      $"👉 Nhấp đúp chuột (Double click) vào thư mục này để mở và duyệt các tệp tin bên trong.";
                lblFileClue.Visible = false;
                UpdatePreviewLayout();
                return;
            }

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
                UpdatePreviewLayout();
            }
        }

        private static bool IsMatchingFolder(string? fileFolder, string? selectedFolder, bool allowSubfolders = false)
        {
            if (string.IsNullOrEmpty(selectedFolder)) return true;
            if (string.IsNullOrEmpty(fileFolder)) fileFolder = "Documents";

            string normFile = NormalizeToDocumentsPath(fileFolder);
            string normSelected = NormalizeToDocumentsPath(selectedFolder);

            var fileParts = normFile
                .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();

            var selectedParts = normSelected
                .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();

            if (allowSubfolders)
            {
                if (fileParts.Length < selectedParts.Length) return false;
                for (int i = 0; i < selectedParts.Length; i++)
                {
                    if (!fileParts[i].Equals(selectedParts[i], StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (fileParts.Length != selectedParts.Length) return false;

            for (int i = 0; i < fileParts.Length; i++)
            {
                if (!fileParts[i].Equals(selectedParts[i], StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}


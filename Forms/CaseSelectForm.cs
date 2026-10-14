using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class CaseSelectForm : Form
    {
        private CasePackage? _selectedPackage;

        public CaseSelectForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void CaseSelectForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1450, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(900, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1100, targetW), Math.Min(700, targetH));
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lvCases.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            txtCaseDescription.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular);
            grpCaseDetail.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblListHeader.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnImportJson.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnImportJson.Height = 48;
            btnPlayCase.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pnlHeader.Height = 58;
            pnlBottom.Height = 58;
            btnPlayCase.Height = 42;
            btnPlayCase.Top = 8;
            btnCancel.Height = 42;
            btnCancel.Top = 8;

            colCaseId.Width = 130;
            colTitle.Width = 330;
            colDifficulty.Width = 130;

            // Tinh chỉnh khoảng cách cho các nhãn trong GroupBox chi tiết không bị bóp chữ
            lblSelectedTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblSelectedTitle.Height = 32;
            lblVictim.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblVictim.Height = 26;
            lblMissingFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblMissingFile.Height = 26;
            lblIncidentDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblIncidentDate.Height = 26;

            lblVictim.Location = new Point(16, 58);
            lblMissingFile.Location = new Point(16, 88);
            lblIncidentDate.Location = new Point(16, 118);
            txtCaseDescription.Location = new Point(16, 152);
            txtCaseDescription.Height = Math.Max(60, grpCaseDetail.ClientSize.Height - 168);

            LoadCaseList();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (txtCaseDescription != null && grpCaseDetail != null)
            {
                txtCaseDescription.Height = Math.Max(60, grpCaseDetail.ClientSize.Height - 168);
            }
        }

        public void LoadCaseList()
        {
            lvCases.Items.Clear();
            var cases = GameManager.Instance.CaseManager.AvailableCases;

            foreach (var c in cases)
            {
                var lvi = new ListViewItem(c.CaseId) { Tag = c };
                lvi.SubItems.Add(c.Title);
                lvi.SubItems.Add(c.Difficulty);

                if (c.CaseId == GameManager.Instance.CaseManager.CurrentPackage.CaseId)
                {
                    lvi.ForeColor = Color.FromArgb(22, 101, 52);
                    lvi.Font = new Font(lvCases.Font, FontStyle.Bold);
                }
                else
                {
                    lvi.ForeColor = Color.FromArgb(15, 23, 42);
                }

                lvCases.Items.Add(lvi);
            }

            if (lvCases.Items.Count > 0)
            {
                // Select currently active case
                int activeIndex = cases.FindIndex(c => c.CaseId == GameManager.Instance.CaseManager.CurrentPackage.CaseId);
                lvCases.Items[activeIndex >= 0 ? activeIndex : 0].Selected = true;
            }
        }

        private void lvCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCases.SelectedItems.Count == 0) return;

            var item = lvCases.SelectedItems[0];
            if (item.Tag is CasePackage pkg)
            {
                _selectedPackage = pkg;
                lblSelectedTitle.Text = $"{pkg.CaseId} — {pkg.Title} ({pkg.Difficulty})";
                lblVictim.Text = $"👤 Nạn nhân: {pkg.Victim}";
                lblMissingFile.Text = $"📁 Tập tin trọng tâm: {pkg.MissingFileName}";
                lblIncidentDate.Text = $"⏰ Thời gian xảy ra: {pkg.IncidentDate}";

                txtCaseDescription.Text =
                    $"=== TÓM TẮT TÌNH TIẾT VỤ ÁN ===\n\n" +
                    $"{pkg.Overview}\n\n" +
                    $"• Độ khó: {pkg.Difficulty}\n" +
                    $"• Số lượng nghi phạm: {pkg.Suspects.Count}\n" +
                    $"• Số lượng bằng chứng cần điều tra: {pkg.Evidences.Count}\n" +
                    $"• Số lượng email trao đổi: {pkg.Emails.Count}\n" +
                    $"• Số lượng tập tin hệ thống: {pkg.Files.Count}\n\n" +
                    $"Hãy bấm nút 'BẮT ĐẦU ĐIỀU TRA VỤ ÁN NÀY' bên dưới để tải toàn bộ dữ liệu, email, tập tin và lịch sử web của vụ án này lên Desktop!";
            }
        }

        private void btnPlayCase_Click(object sender, EventArgs e)
        {
            if (_selectedPackage == null)
            {
                MessageBox.Show("Vui lòng chọn một vụ án trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedPackage.CaseId == GameManager.Instance.CaseManager.CurrentPackage.CaseId)
            {
                Close();
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có muốn chuyển sang điều tra vụ án '{_selectedPackage.CaseId}: {_selectedPackage.Title}'?\n\nTiến trình điều tra của vụ án mới sẽ được khởi tạo lại từ đầu.",
                "Xác nhận chuyển vụ án",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                GameManager.Instance.SelectCase(_selectedPackage.CaseId);
                MessageBox.Show($"Đã chuyển sang '{_selectedPackage.CaseId}: {_selectedPackage.Title}' thành công!\nMáy tính đã tải toàn bộ dữ liệu của vụ án này.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AudioManager.Instance.Play(SoundEffect.Click);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnImportJson_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Tệp màn chơi JSON (*.json)|*.json|Tất cả tệp (*.*)|*.*";
            ofd.Title = "Chọn file JSON màn chơi trinh thám";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(ofd.FileName);
                    if (GameManager.Instance.CaseManager.ImportCaseFromJson(json, out string msg))
                    {
                        AudioManager.Instance.Play(SoundEffect.Notification);
                        MessageBox.Show(msg, "Nhập màn chơi thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCaseList();
                    }
                    else
                    {
                        AudioManager.Instance.Play(SoundEffect.Failure);
                        MessageBox.Show(msg, "Lỗi nạp file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    AudioManager.Instance.Play(SoundEffect.Failure);
                    MessageBox.Show($"Lỗi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}

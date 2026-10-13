using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class CaseReportForm : Form
    {
        public CaseReportForm()
        {
            InitializeComponent();
        }

        private void CaseReportForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1400, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(900, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1100, targetW), Math.Min(700, targetH));
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCaseTimer.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grpSuspect.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            grpMotive.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            grpMethod.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            grpEvidenceSelect.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            grpConclusion.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            clbSuspects.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            cboMotive.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            cboMethod.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            clbEvidences.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            txtConclusion.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular);
            lblSuspectDetail.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            btnSubmitCase.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            btnViewHighScores.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pnlHeader.Height = 58;
            btnClose.Height = 38;
            btnClose.Top = 10;
            lblCaseTimer.Height = 36;

            pnlBottom.Height = 64;
            btnSubmitCase.Height = 44;
            btnSubmitCase.Top = 10;
            btnViewHighScores.Height = 44;
            btnViewHighScores.Top = 10;

            // Nới rộng chiều cao các GroupBox để các điều khiển không bị ép sát
            grpSuspect.Height = 285;
            clbSuspects.Top = 28;
            clbSuspects.Height = 105;
            lblSuspectDetail.Top = 140;
            lblSuspectDetail.Height = 135;

            grpMotive.Height = 135;
            cboMotive.Top = 45;

            grpMethod.Height = 135;
            cboMethod.Top = 45;

            grpEvidenceSelect.Height = 280;

            InitSuspects();
            InitMotives();
            InitMethods();
            InitEvidenceList();

            txtConclusion.Text = GameManager.Instance.State.FinalConclusion;
            UpdateTimerDisplay();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (lblTitle != null && lblCaseTimer != null)
            {
                lblTitle.AutoEllipsis = true;
                lblTitle.Width = Math.Max(100, lblCaseTimer.Left - lblTitle.Left - 15);
            }
            if (lblWarning != null && btnViewHighScores != null)
            {
                lblWarning.AutoEllipsis = true;
                lblWarning.Width = Math.Max(100, btnViewHighScores.Left - lblWarning.Left - 15);
            }
        }

        private void UpdateTimerDisplay()
        {
            int elapsed = GameManager.Instance.State.ElapsedSeconds;
            var ts = TimeSpan.FromSeconds(elapsed);
            lblCaseTimer.Text = ts.TotalHours >= 1 
                ? $"⏱ Phá án: {ts:hh\\:mm\\:ss}" 
                : $"⏱ Phá án: {ts:mm\\:ss}";
        }

        private void InitSuspects()
        {
            clbSuspects.Items.Clear();
            var suspects = GameManager.Instance.CaseManager.Suspects;

            foreach (var s in suspects)
            {
                clbSuspects.Items.Add(new SuspectCheckItem { Suspect = s }, false);
            }

            lblSuspectDetail.Text = "💡 Nhấp vào từng nghi phạm để xem chi tiết hồ sơ & chứng cứ ngoại phạm.\n" +
                                    "   Tích chọn một hoặc nhiều nghi phạm cần khởi tố trong vụ án này.";
            if (clbSuspects.Items.Count > 0)
            {
                clbSuspects.SelectedIndex = 0;
            }
        }

        private void InitMotives()
        {
            cboMotive.Items.Clear();
            cboMotive.DropDownWidth = 650;
            cboMotive.Items.Add("-- Chọn động cơ gây án --");
            var options = GameManager.Instance.CaseManager.CurrentPackage.MotiveOptions;
            if (options != null && options.Count > 0)
            {
                var list = new List<string>(options);
                var rng = new Random(GameManager.Instance.CaseManager.CurrentPackage.CaseId.GetHashCode() + 1);
                var shuffled = list.OrderBy(_ => rng.Next()).ToList();
                foreach (var opt in shuffled)
                {
                    cboMotive.Items.Add(opt);
                }
            }
            else
            {
                cboMotive.Items.Add(GameManager.Instance.CaseManager.CurrentCase.CorrectMotive);
            }

            cboMotive.SelectedIndex = 0;
        }

        private void InitMethods()
        {
            cboMethod.Items.Clear();
            cboMethod.DropDownWidth = 650;
            cboMethod.Items.Add("-- Chọn thủ đoạn gây án --");
            var options = GameManager.Instance.CaseManager.CurrentPackage.MethodOptions;
            if (options != null && options.Count > 0)
            {
                var list = new List<string>(options);
                var rng = new Random(GameManager.Instance.CaseManager.CurrentPackage.CaseId.GetHashCode() + 2);
                var shuffled = list.OrderBy(_ => rng.Next()).ToList();
                foreach (var opt in shuffled)
                {
                    cboMethod.Items.Add(opt);
                }
            }
            else
            {
                cboMethod.Items.Add(GameManager.Instance.CaseManager.CurrentCase.CorrectMethod);
            }

            cboMethod.SelectedIndex = 0;
        }

        private void InitEvidenceList()
        {
            clbEvidences.Items.Clear();
            var discovered = GameManager.Instance.EvidenceManager.GetDiscoveredEvidences().ToList();

            foreach (var ev in discovered)
            {
                var item = new EvidenceCheckItem { Evidence = ev };
                clbEvidences.Items.Add(item, false); // Mặc định không tích sẵn, yêu cầu thám tử tự chọn bằng chứng then chốt
            }

            if (clbEvidences.Items.Count == 0)
            {
                clbEvidences.Items.Add("Chưa thu thập được bằng chứng nào!");
            }
        }

        private void clbSuspects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbSuspects.SelectedItem is SuspectCheckItem item)
            {
                var s = item.Suspect;
                lblSuspectDetail.Text = $"👤 Tên: {s.Name}\n" +
                                        $"💼 Chức vụ: {s.Role}\n" +
                                        $"📝 Đặc điểm: {s.Description}\n" +
                                        $"⏰ Bằng chứng ngoại phạm khai báo: {s.Alibi}";
            }
            else
            {
                lblSuspectDetail.Text = "💡 Nhấp vào từng nghi phạm để xem chi tiết hồ sơ & chứng cứ ngoại phạm.\n" +
                                        "   Tích chọn một hoặc nhiều nghi phạm cần khởi tố trong vụ án này.";
            }
        }

        private void btnSubmitCase_Click(object sender, EventArgs e)
        {
            var accusedSuspects = new List<Suspect>();
            for (int i = 0; i < clbSuspects.CheckedItems.Count; i++)
            {
                if (clbSuspects.CheckedItems[i] is SuspectCheckItem sItem)
                {
                    accusedSuspects.Add(sItem.Suspect);
                }
            }

            if (accusedSuspects.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một nghi phạm cần khởi tố!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMotive.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn động cơ gây án!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMethod.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn thủ đoạn gây án!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var suspectIds = accusedSuspects.Select(s => s.Id).ToList();
            string motive = cboMotive.SelectedItem?.ToString() ?? "";
            string method = cboMethod.SelectedItem?.ToString() ?? "";

            var selectedEvidenceIds = new List<string>();
            for (int i = 0; i < clbEvidences.CheckedItems.Count; i++)
            {
                if (clbEvidences.CheckedItems[i] is EvidenceCheckItem evItem)
                {
                    selectedEvidenceIds.Add(evItem.Evidence.Id);
                }
            }

            if (selectedEvidenceIds.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn các bằng chứng xác đáng đính kèm trong danh sách trước khi nộp báo cáo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GameManager.Instance.State.SelectedSuspectIds = suspectIds;
            GameManager.Instance.State.SelectedSuspectId = string.Join(", ", suspectIds);
            GameManager.Instance.State.SelectedMotive = motive;
            GameManager.Instance.State.SelectedMethod = method;
            GameManager.Instance.State.FinalConclusion = txtConclusion.Text;

            var result = GameManager.Instance.CaseManager.EvaluateCase(
                GameManager.Instance.State,
                suspectIds,
                motive,
                method,
                selectedEvidenceIds);

            GameManager.Instance.State.ReachedEnding = result.Title;
            GameManager.Instance.State.Status = InvestigationStatus.Completed;
            GameManager.Instance.NotifyStateChanged();

            int elapsedSecs = GameManager.Instance.State.ElapsedSeconds;
            var ts = TimeSpan.FromSeconds(elapsedSecs);
            string timeStr = ts.TotalHours >= 1 ? ts.ToString(@"hh\:mm\:ss") : ts.ToString(@"mm\:ss");

            // Phát âm thanh tương ứng
            if (result.Score >= 80)
            {
                AudioManager.Instance.Play(SoundEffect.Victory);
            }
            else
            {
                AudioManager.Instance.Play(SoundEffect.Failure);
            }

            string endingIcon = result.Score >= 80 ? "🏆" : (result.Score >= 50 ? "⚖️" : "❌");
            int totalEv = GameManager.Instance.CaseManager.CurrentPackage.Evidences.Count;
            string message = $"{endingIcon} {result.Title}\n\n" +
                             $"{result.Description}\n\n" +
                             $"-----------------------------------------\n" +
                             $"⭐ Điểm số đánh giá: {result.Score}/100\n" +
                             $"⏱ Thời gian phá án: {timeStr} ({elapsedSecs} giây)\n" +
                             $"🔍 Bằng chứng thu thập: {GameManager.Instance.State.DiscoveredEvidenceIds.Count}/{totalEv}\n" +
                             $"🔗 Liên kết timeline: {GameManager.Instance.State.ConnectedEvidencePairs.Count}\n" +
                             $"-----------------------------------------";

            MessageBox.Show(message, "PHÁN QUYẾT KẾT THÚC VỤ ÁN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ghi nhận thành tích vào file TXT (highscores.txt)
            try
            {
                string rank = HighScoreEntry.CalculateRank(result.Score, elapsedSecs);
                string detectiveName = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Chúc mừng bạn đã hoàn tất điều tra!\nĐiểm số: {result.Score}/100 | Thời gian: {timeStr} | Xếp hạng: {rank}\n\nNhập tên hoặc mật danh thám tử của bạn để ghi vào BẢNG VÀNG THÀNH TÍCH (highscores.txt):",
                    "Ghi danh Bảng Vàng Thám Tử",
                    "Thám tử");

                if (string.IsNullOrWhiteSpace(detectiveName)) detectiveName = "Thám tử";

                var scoreEntry = new HighScoreEntry
                {
                    Date = DateTime.Now,
                    DetectiveName = detectiveName.Trim(),
                    CaseId = GameManager.Instance.CaseManager.CurrentPackage.CaseId,
                    CaseTitle = GameManager.Instance.CaseManager.CurrentPackage.Title,
                    EndingTitle = result.Title,
                    Score = result.Score,
                    ElapsedSeconds = elapsedSecs,
                    EvidenceFound = GameManager.Instance.State.DiscoveredEvidenceIds.Count,
                    TotalEvidences = totalEv,
                    TimelineLinks = GameManager.Instance.State.ConnectedEvidencePairs.Count,
                    Rank = rank
                };

                HighScoreManager.SaveScore(scoreEntry);

                var viewPrompt = MessageBox.Show(
                    "Thành tích của bạn đã được lưu vào tập tin highscores.txt thành công!\n\nBạn có muốn mở xem Bảng Vàng Thành Tích (High Scores) ngay bây giờ không?",
                    "Lưu thành tích thành công",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (viewPrompt == DialogResult.Yes)
                {
                    var hsForm = new HighScoreForm();
                    hsForm.ShowDialog(this);
                }
            }
            catch { }

            Close();
        }

        private void btnViewHighScores_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            var hsForm = new HighScoreForm();
            hsForm.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }

        private class SuspectCheckItem
        {
            public Suspect Suspect { get; set; } = null!;
            public override string ToString() => $"{Suspect.Name} ({Suspect.Role})";
        }

        private class EvidenceCheckItem
        {
            public Evidence Evidence { get; set; } = null!;
            public override string ToString() => $"[{Evidence.Id}] {Evidence.Name}";
        }
    }
}


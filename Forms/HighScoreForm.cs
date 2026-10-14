using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _2611_WIN_B3.Game;

namespace _2611_WIN_B3.Forms
{
    public partial class HighScoreForm : Form
    {
        private List<HighScoreEntry> _allScores = new();

        public HighScoreForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1400, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(860, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1050, targetW), Math.Min(680, targetH));
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblFilter.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            cboFilterCase.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblSummary.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lvScores.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnOpenTxt.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClear.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnRefresh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pnlHeader.Height = 58;
            btnClose.Height = 38;
            btnClose.Top = 10;

            pnlTopBar.Height = 52;
            lblFilter.Top = 14;
            cboFilterCase.Top = 10;
            lblSummary.Top = 14;

            pnlBottom.Height = 58;
            btnOpenTxt.Height = 40;
            btnOpenTxt.Top = 9;
            btnClear.Height = 40;
            btnClear.Top = 9;
            btnRefresh.Height = 40;
            btnRefresh.Top = 9;

            colRank.Width = 100;
            colDetective.Width = 200;
            colCase.Width = 300;
            colScore.Width = 110;
            colTime.Width = 130;
            colRating.Width = 130;
            colEnding.Width = 280;
            colDate.Width = 190;

            ReloadData();
        }

        private void ReloadData()
        {
            _allScores = HighScoreManager.LoadScores();
            PopulateCaseFilter();
            DisplayScores();
        }

        private void PopulateCaseFilter()
        {
            string currentSelection = cboFilterCase.SelectedItem?.ToString() ?? "-- Tất cả vụ án --";
            cboFilterCase.Items.Clear();
            cboFilterCase.Items.Add("-- Tất cả vụ án --");

            var distinctCases = _allScores.Select(s => s.CaseId).Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
            foreach (var cid in distinctCases)
            {
                cboFilterCase.Items.Add(cid);
            }

            int idx = cboFilterCase.Items.IndexOf(currentSelection);
            cboFilterCase.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void DisplayScores()
        {
            lvScores.Items.Clear();

            string filter = cboFilterCase.SelectedItem?.ToString() ?? "-- Tất cả vụ án --";
            var filtered = filter == "-- Tất cả vụ án --" 
                ? _allScores 
                : _allScores.Where(s => s.CaseId.Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            int rank = 1;
            int bestScore = 0;
            string bestTime = "--:--";

            foreach (var entry in filtered)
            {
                var lvi = new ListViewItem($"#{rank++}");
                lvi.SubItems.Add(entry.DetectiveName);
                lvi.SubItems.Add(!string.IsNullOrEmpty(entry.CaseTitle) ? $"{entry.CaseId}: {entry.CaseTitle}" : entry.CaseId);
                lvi.SubItems.Add($"{entry.Score}/100");
                lvi.SubItems.Add(entry.TimeFormatted);
                lvi.SubItems.Add(entry.Rank);
                lvi.SubItems.Add(entry.EndingTitle);
                lvi.SubItems.Add(entry.Date.ToString("dd/MM/yyyy HH:mm"));

                // Tô màu theo thành tích
                if (entry.Score >= 100)
                {
                    lvi.ForeColor = Color.FromArgb(180, 83, 9); // Vàng kim / Amber
                    lvi.Font = new Font(lvScores.Font, FontStyle.Bold);
                }
                else if (entry.Score >= 80)
                {
                    lvi.ForeColor = Color.FromArgb(22, 101, 52); // Xanh lá
                }
                else if (entry.Score < 50)
                {
                    lvi.ForeColor = Color.FromArgb(185, 28, 28); // Đỏ
                }

                lvScores.Items.Add(lvi);
            }

            if (filtered.Count > 0)
            {
                bestScore = filtered.Max(s => s.Score);
                var fastest = filtered.Where(s => s.Score == bestScore).OrderBy(s => s.ElapsedSeconds).FirstOrDefault();
                bestTime = fastest?.TimeFormatted ?? "--:--";
            }

            lblSummary.Text = $"Tổng số: {filtered.Count} kỷ lục | Điểm cao nhất: {bestScore} | Thời gian tốt nhất: {bestTime}";
        }

        private void cboFilterCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayScores();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            ReloadData();
        }

        private void btnOpenTxt_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            if (!HighScoreManager.OpenFileInEditor(out string msg))
            {
                MessageBox.Show(msg, "Lỗi mở file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ lịch sử thành tích trong file highscores.txt?",
                "Xác nhận xóa bảng vàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                HighScoreManager.ClearScores();
                ReloadData();
                MessageBox.Show("Đã làm mới và xóa toàn bộ lịch sử thành tích.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}


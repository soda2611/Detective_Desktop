using System;
using System.Drawing;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvHistory.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            dgvHistory.RowTemplate.Height = 32;
            txtAddressBar.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblClueNotice.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            colDate.Width = 120;
            colTime.Width = 110;
            colTitle.Width = 380;
            colUrl.Width = 360;

            lblTitle.AutoEllipsis = true;
            UpdateTitleLayout();

            LoadBrowserHistory();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTitleLayout();
        }

        private void UpdateTitleLayout()
        {
            if (lblTitle == null || btnClose == null) return;
            lblTitle.MaximumSize = new Size(Math.Max(100, btnClose.Left - lblTitle.Left - 20), 0);
        }

        private void LoadBrowserHistory()
        {
            dgvHistory.Rows.Clear();
            var histories = GameManager.Instance.CaseManager.BrowserHistories;

            foreach (var item in histories)
            {
                int rowIndex = dgvHistory.Rows.Add(item.Date, item.Time, item.Title, item.Url);
                var row = dgvHistory.Rows[rowIndex];
                row.Tag = item;

                if (item.IsSuspicious)
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(194, 65, 12);
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                }
            }
        }

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHistory.Rows.Count) return;

            var row = dgvHistory.Rows[e.RowIndex];
            if (row.Tag is BrowserHistory history)
            {
                txtAddressBar.Text = history.Url;
                GameManager.Instance.State.CheckedBrowserIds.Add(history.Id);

                if (!string.IsNullOrEmpty(history.EvidenceId))
                {
                    bool isNew = GameManager.Instance.EvidenceManager.DiscoverEvidence(history.EvidenceId);
                    var ev = GameManager.Instance.EvidenceManager.GetEvidence(history.EvidenceId);
                    lblClueNotice.ForeColor = Color.FromArgb(22, 101, 52);
                    lblClueNotice.Text = $"⭐ PHÁT HIỆN DẤU VẾT BẤT THƯỜNG [{history.EvidenceId}]: {ev?.Name} - {history.Title} ({history.Time})";
                }
                else
                {
                    lblClueNotice.ForeColor = Color.FromArgb(30, 41, 59);
                    lblClueNotice.Text = $"ℹ️ Truy cập bình thường: {history.Title} tại {history.Url} lúc {history.Time}. Không phát hiện dấu hiệu xâm nhập.";
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


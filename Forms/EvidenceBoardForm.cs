using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class EvidenceBoardForm : Form
    {
        public EvidenceBoardForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void EvidenceBoardForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1450, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(920, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1100, targetW), Math.Min(700, targetH));
            CenterToParent();

            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grpEvidences.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lvEvidences.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            txtEvidenceDesc.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular);
            lblDescTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            grpConnections.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblSelectA.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            lblSelectB.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            cboEvidenceA.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            cboEvidenceB.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnConnect.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblConnectResult.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTimelineTitle.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold);
            lvTimeline.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pnlHeader.Height = 58;
            btnClose.Height = 38;
            btnClose.Top = 10;

            // Giãn khoảng cách các control trong Panel kết nối
            lblSelectA.Location = new Point(12, 30);
            lblSelectA.Height = 24;
            cboEvidenceA.Location = new Point(12, 56);

            lblSelectB.Location = new Point(12, 102);
            lblSelectB.Height = 24;
            cboEvidenceB.Location = new Point(12, 128);

            btnConnect.Location = new Point(12, 175);
            btnConnect.Height = 44;

            lblConnectResult.Location = new Point(12, 230);
            lblConnectResult.Height = 70;

            lblTimelineTitle.Location = new Point(12, 312);
            lblTimelineTitle.Height = 26;

            lvTimeline.Location = new Point(12, 342);
            lvTimeline.Height = grpConnections.ClientSize.Height - 356;

            lvEvidences.Anchor = AnchorStyles.None;
            lblDescTitle.Anchor = AnchorStyles.None;
            txtEvidenceDesc.Anchor = AnchorStyles.None;
            LayoutEvidencesPanel();

            colId.Width = 90;
            colName.Width = 320;
            colSource.Width = 160;
            colImportance.Width = 140;
            colTime.Width = 150;
            colEvent.Width = 380;
            colEvId.Width = 110;

            RefreshEvidences();
            RefreshTimeline();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (lblTitle != null && btnClose != null)
            {
                lblTitle.AutoEllipsis = true;
                lblTitle.Width = Math.Max(100, btnClose.Left - lblTitle.Left - 15);
            }
            if (lvTimeline != null && grpConnections != null)
            {
                lvTimeline.Height = Math.Max(100, grpConnections.ClientSize.Height - 356);
            }
            LayoutEvidencesPanel();
        }

        private void LayoutEvidencesPanel()
        {
            if (grpEvidences == null || lvEvidences == null || lblDescTitle == null || txtEvidenceDesc == null) return;
            int clientW = grpEvidences.ClientSize.Width;
            int clientH = grpEvidences.ClientSize.Height;
            if (clientW < 50 || clientH < 100) return;

            int margin = 10;
            int descH = 140;
            int titleH = 26;
            int titleY = clientH - descH - titleH - 12;
            int descY = titleY + titleH + 4;

            lblDescTitle.Location = new Point(margin, titleY);
            lblDescTitle.Size = new Size(clientW - (margin * 2), titleH);

            txtEvidenceDesc.Location = new Point(margin, descY);
            txtEvidenceDesc.Size = new Size(clientW - (margin * 2), descH);

            lvEvidences.Location = new Point(margin, 24);
            lvEvidences.Size = new Size(clientW - (margin * 2), Math.Max(60, titleY - 28));
        }

        public void RefreshEvidences()
        {
            lvEvidences.Items.Clear();
            cboEvidenceA.Items.Clear();
            cboEvidenceB.Items.Clear();

            var allEvidences = GameManager.Instance.EvidenceManager.GetAllEvidences();
            var discovered = GameManager.Instance.EvidenceManager.GetDiscoveredEvidences().ToList();

            foreach (var ev in allEvidences)
            {
                bool isFound = GameManager.Instance.State.DiscoveredEvidenceIds.Contains(ev.Id);
                var lvi = new ListViewItem(ev.Id) { Tag = isFound ? ev : null };

                if (isFound)
                {
                    lvi.SubItems.Add(ev.Name);
                    lvi.SubItems.Add(ev.Source);
                    lvi.SubItems.Add(ev.Importance);

                    if (ev.Importance == "Critical")
                    {
                        lvi.ForeColor = Color.FromArgb(194, 65, 12);
                        lvi.Font = new Font(lvEvidences.Font, FontStyle.Bold);
                    }
                    else
                    {
                        lvi.ForeColor = Color.FromArgb(15, 23, 42);
                    }

                    var comboItem = new ComboBoxItem { Text = $"[{ev.Id}] {ev.Name}", Value = ev.Id };
                    cboEvidenceA.Items.Add(comboItem);
                    cboEvidenceB.Items.Add(comboItem);
                }
                else
                {
                    lvi.SubItems.Add("🔒 [Chưa phát hiện]");
                    lvi.SubItems.Add(ev.Source);
                    lvi.SubItems.Add("???");
                    lvi.ForeColor = Color.FromArgb(148, 163, 184);
                }

                lvEvidences.Items.Add(lvi);
            }

            if (cboEvidenceA.Items.Count > 0) cboEvidenceA.SelectedIndex = 0;
            if (cboEvidenceB.Items.Count > 1) cboEvidenceB.SelectedIndex = 1;
            else if (cboEvidenceB.Items.Count > 0) cboEvidenceB.SelectedIndex = 0;

            if (lvEvidences.Items.Count > 0)
            {
                lvEvidences.Items[0].Selected = true;
            }

            if (discovered.Count == 0)
            {
                txtEvidenceDesc.Text = "💡 BẢNG ĐIỀU TRA CHƯA CÓ MANH MỐI NÀO ĐƯỢC GIẢI MÃ!\n\n" +
                                       "Gợi ý tìm bằng chứng:\n" +
                                       "• Mở ✉ Mail: Nhấp đọc từng email (đặc biệt các email trao đổi nửa đêm).\n" +
                                       "• Mở 🌐 Browser: Nhấp xem từng dòng trong bảng lịch sử duyệt web.\n" +
                                       "• Mở 📁 File Explorer: Rà soát tài liệu hệ thống, file dữ liệu và nhật ký truy cập.\n" +
                                       "• Mở 🗑 Recycle Bin: Kiểm tra và phục hồi các tập tin đã bị thủ phạm xóa.\n\n" +
                                       "Khi phát hiện được manh mối, bạn hãy quay lại đây để nối các manh mối nhằm giải mã Timeline!";
            }
        }

        public void RefreshTimeline()
        {
            lvTimeline.Items.Clear();
            var timeline = GameManager.Instance.TimelineManager.GetAvailableTimeline();

            foreach (var item in timeline)
            {
                var lvi = new ListViewItem(item.Time);
                lvi.SubItems.Add(item.EventDescription);
                lvi.SubItems.Add(string.IsNullOrEmpty(item.EvidenceId) ? "Hệ thống" : item.EvidenceId);

                if (!string.IsNullOrEmpty(item.EvidenceId))
                {
                    lvi.ForeColor = Color.FromArgb(3, 105, 161);
                }
                else
                {
                    lvi.ForeColor = Color.FromArgb(100, 116, 139);
                }

                lvTimeline.Items.Add(lvi);
            }
        }

        private void lvEvidences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEvidences.SelectedItems.Count == 0) return;

            var item = lvEvidences.SelectedItems[0];
            if (item.Tag is Evidence ev)
            {
                txtEvidenceDesc.Text = $"=== MANH MỐI: {ev.Name} ===\n\n" +
                                       $"• Mã bằng chứng: {ev.Id}\n" +
                                       $"• Nguồn phát hiện: {ev.Source}\n" +
                                       $"• Mức độ quan trọng: {ev.Importance}\n" +
                                       $"• Thời điểm ghi nhận: {ev.Timestamp ?? "Không xác định"}\n\n" +
                                       $"Mô tả:\n{ev.Description}";
            }
            else
            {
                string id = item.Text;
                string source = item.SubItems.Count > 2 ? item.SubItems[2].Text : "Hệ thống";
                txtEvidenceDesc.Text = $"🔒 [CHƯA PHÁT HIỆN MANH MỐI {id}]\n\n" +
                                       $"• Nguồn nghi vấn: {source}\n\n" +
                                       $"Gợi ý: Hãy mở ứng dụng tương ứng ({source}) trên Desktop để kiểm tra các nội dung khả nghi và thu thập bằng chứng này!";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cboEvidenceA.SelectedItem is not ComboBoxItem itemA ||
                cboEvidenceB.SelectedItem is not ComboBoxItem itemB)
            {
                MessageBox.Show("Vui lòng chọn 2 bằng chứng để kết nối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (itemA.Value == itemB.Value)
            {
                MessageBox.Show("Không thể kết nối một bằng chứng với chính nó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = GameManager.Instance.TimelineManager.CheckConnection(itemA.Value, itemB.Value);
            lblConnectResult.Text = result;

            if (result.StartsWith("CHÍNH XÁC"))
            {
                AudioManager.Instance.Play(SoundEffect.TimelineConnected);
                lblConnectResult.ForeColor = Color.FromArgb(22, 101, 52);
                RefreshTimeline();
            }
            else
            {
                AudioManager.Instance.Play(SoundEffect.Failure);
                lblConnectResult.ForeColor = Color.FromArgb(180, 83, 9);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }

        private class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
            public override string ToString() => Text;
        }
    }
}


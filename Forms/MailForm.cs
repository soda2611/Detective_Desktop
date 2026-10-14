using System;
using System.Windows.Forms;
using _2611_WIN_B3.Game;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Forms
{
    public partial class MailForm : Form
    {
        public MailForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1380, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(860, (int)(workArea.Height * 0.95));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1050, targetW), Math.Min(680, targetH));
            CenterToParent();

            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            lvEmails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            txtMailBody.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular);
            grpMailDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            lblListHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            lblSender.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            lblSenderValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            lblRecipient.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            lblRecipientValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            lblDateValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            lblSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            lblSubjectValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblClueAlert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);

            pnlHeader.Height = 58;
            btnClose.Height = 38;
            btnClose.Top = 10;
            lblListHeader.Height = 38;

            // Nới rộng các nhãn Header email để không bị đè chữ
            lblSender.Height = 26;
            lblSenderValue.Height = 26;
            lblRecipient.Height = 26;
            lblRecipientValue.Height = 26;
            lblDate.Height = 26;
            lblDateValue.Height = 26;
            lblSubject.Height = 26;
            lblSubjectValue.Height = 26;

            lblSender.Location = new Point(14, 30);
            lblSenderValue.Location = new Point(100, 30);
            lblRecipient.Location = new Point(14, 58);
            lblRecipientValue.Location = new Point(100, 58);
            lblDate.Location = new Point(14, 86);
            lblDateValue.Location = new Point(100, 86);
            lblSubject.Location = new Point(14, 114);
            lblSubjectValue.Location = new Point(100, 114);

            txtMailBody.Location = new Point(14, 150);
            txtMailBody.Height = Math.Max(100, grpMailDetail.ClientSize.Height - 195);

            lblClueAlert.Height = 38;

            colSender.Width = 200;
            colSubject.Width = 320;
            colTime.Width = 150;

            lblTitle.AutoEllipsis = true;
            UpdateTitleLayout();

            LoadEmailList();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTitleLayout();
            if (txtMailBody != null && grpMailDetail != null)
            {
                txtMailBody.Height = Math.Max(100, grpMailDetail.ClientSize.Height - 195);
            }
        }

        private void UpdateTitleLayout()
        {
            if (lblTitle == null || btnClose == null) return;
            lblTitle.MaximumSize = new System.Drawing.Size(Math.Max(100, btnClose.Left - lblTitle.Left - 20), 0);
        }

        private void LoadEmailList()
        {
            lvEmails.Items.Clear();
            var emails = GameManager.Instance.CaseManager.Emails;

            foreach (var email in emails)
            {
                var lvi = new ListViewItem(email.Sender)
                {
                    Tag = email
                };
                lvi.SubItems.Add(email.Subject);
                lvi.SubItems.Add(email.Time);

                if (GameManager.Instance.State.ReadEmailIds.Contains(email.Id))
                {
                    lvi.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                }
                else
                {
                    lvi.Font = new System.Drawing.Font(lvEmails.Font, System.Drawing.FontStyle.Bold);
                    lvi.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
                }

                lvEmails.Items.Add(lvi);
            }

            if (lvEmails.Items.Count > 0)
            {
                lvEmails.Items[0].Selected = true;
            }
        }

        private void lvEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEmails.SelectedItems.Count == 0) return;

            var item = lvEmails.SelectedItems[0];
            if (item.Tag is Email email)
            {
                lblSenderValue.Text = email.Sender;
                lblRecipientValue.Text = email.Recipient;
                lblDateValue.Text = $"{email.Date} lúc {email.Time}";
                lblSubjectValue.Text = email.Subject;
                txtMailBody.Text = email.Body;

                GameManager.Instance.State.ReadEmailIds.Add(email.Id);
                item.Font = new System.Drawing.Font(lvEmails.Font, System.Drawing.FontStyle.Regular);
                item.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);

                if (!string.IsNullOrEmpty(email.EvidenceId))
                {
                    bool isNew = GameManager.Instance.EvidenceManager.DiscoverEvidence(email.EvidenceId);
                    lblClueAlert.Visible = true;
                    if (isNew)
                    {
                        var ev = GameManager.Instance.EvidenceManager.GetEvidence(email.EvidenceId);
                        lblClueAlert.Text = $"⭐ PHÁT HIỆN BẰNG CHỨNG MỚI [{email.EvidenceId}]: {ev?.Name}";
                    }
                    else
                    {
                        lblClueAlert.Text = $"🔍 BẰNG CHỨNG [{email.EvidenceId}] ĐÃ ĐƯỢC GHI NHẬN VÀO HỒ SƠ";
                    }
                }
                else
                {
                    lblClueAlert.Visible = false;
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


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
        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lvEmails.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
            txtMailBody.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            grpMailDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblListHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblSender.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            lblSenderValue.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
            lblRecipient.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            lblRecipientValue.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
            lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            lblDateValue.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
            lblSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            lblSubjectValue.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblClueAlert.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);

            colSender.Width = 150;
            colSubject.Width = 240;
            colTime.Width = 110;

            lblTitle.AutoEllipsis = true;
            UpdateTitleLayout();

            LoadEmailList();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTitleLayout();
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


using System;

namespace _2611_WIN_B3.Models
{
    /// <summary>
    /// Lớp Email kế thừa lớp cơ sở trừu tượng InvestigationEntity
    /// </summary>
    public class Email : InvestigationEntity
    {
        private string _sender = string.Empty;
        private string _recipient = string.Empty;
        private string _subject = string.Empty;
        private string _body = string.Empty;
        private string _time = string.Empty;
        private string _date = string.Empty;

        public string Sender
        {
            get => _sender;
            set => _sender = value ?? string.Empty;
        }

        public string Recipient
        {
            get => _recipient;
            set => _recipient = value ?? string.Empty;
        }

        public string Date
        {
            get => _date;
            set => _date = value ?? string.Empty;
        }

        public string Time
        {
            get => _time;
            set => _time = value ?? string.Empty;
        }

        public string Subject
        {
            get => _subject;
            set => _subject = value ?? string.Empty;
        }

        public string Body
        {
            get => _body;
            set => _body = value ?? string.Empty;
        }

        public bool IsRead { get; set; } = false;

        public Email() : base() { }

        public Email(string id, string sender, string subject, string? evidenceId = null)
            : base(id, evidenceId)
        {
            Sender = sender;
            Subject = subject;
        }

        /// <summary>
        /// Hiện thực phương thức thuần ảo (Abstract Method Override)
        /// </summary>
        public override string GetSourceType() => "Mail Client";

        /// <summary>
        /// Ghi đè phương thức ảo (Virtual Method Override)
        /// </summary>
        public override string GetInspectionSummary()
        {
            return $"[Email] Từ: {Sender} | Tiêu đề: \"{Subject}\" ({Time}) | Đã đọc: {(IsRead ? "Đã xem" : "Chưa đọc")}";
        }
    }
}


using System;

namespace _2611_WIN_B3.Models
{
    /// <summary>
    /// Lớp BrowserHistory kế thừa lớp cơ sở trừu tượng InvestigationEntity
    /// </summary>
    public class BrowserHistory : InvestigationEntity
    {
        private string _date = string.Empty;
        private string _time = string.Empty;
        private string _url = string.Empty;
        private string _title = string.Empty;

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

        public string Url
        {
            get => _url;
            set => _url = value ?? string.Empty;
        }

        public string Title
        {
            get => _title;
            set => _title = value ?? string.Empty;
        }

        public bool IsSuspicious { get; set; } = false;

        public BrowserHistory() : base() { }

        public BrowserHistory(string id, string url, string title, string? evidenceId = null)
            : base(id, evidenceId)
        {
            Url = url;
            Title = title;
        }

        /// <summary>
        /// Hiện thực phương thức thuần ảo (Abstract Method Override)
        /// </summary>
        public override string GetSourceType() => "Web Browser";

        /// <summary>
        /// Ghi đè phương thức ảo (Virtual Method Override)
        /// </summary>
        public override string GetInspectionSummary()
        {
            return $"[Web History] {Time} - {Title} ({Url}) | Đáng ngờ: {(IsSuspicious ? "CÓ" : "Không")}";
        }
    }
}


using System;

namespace _2611_WIN_B3.Models
{
    /// <summary>
    /// Lớp Evidence đại diện cho một Manh mối / Bằng chứng trong vụ án.
    /// Minh họa rõ ràng tính Đóng gói (Encapsulation) với các biến private backing fields,
    /// các thuộc tính get/set có kiểm tra tính hợp lệ dữ liệu (validation),
    /// và phương thức ảo ToString() / GetSummary().
    /// </summary>
    public class Evidence : IInspectable
    {
        // Private backing fields
        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _source = string.Empty;
        private string _importance = "Normal";
        private bool _isDiscovered = false;
        private string? _timestamp;

        /// <summary>
        /// Mã định danh bằng chứng (VD: E001, E002)
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã bằng chứng không được để trống!");
                _id = value.Trim().ToUpper();
            }
        }

        /// <summary>
        /// Tên tiêu đề bằng chứng
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Nội dung phân tích chi tiết của bằng chứng
        /// </summary>
        public string Description
        {
            get => _description;
            set => _description = value?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Nguồn gốc phát hiện (Mail, Browser, Explorer, USB,...)
        /// </summary>
        public string Source
        {
            get => _source;
            set => _source = value?.Trim() ?? "Hệ thống";
        }

        /// <summary>
        /// Mức độ quan trọng (Critical, High, Medium, Normal)
        /// </summary>
        public string Importance
        {
            get => _importance;
            set
            {
                string val = value?.Trim() ?? "Normal";
                _importance = val;
            }
        }

        /// <summary>
        /// Trạng thái đã được người chơi phát hiện hay chưa
        /// </summary>
        public bool IsDiscovered
        {
            get => _isDiscovered;
            set => _isDiscovered = value;
        }

        /// <summary>
        /// Dấu thời gian ghi nhận (Timestamp)
        /// </summary>
        public string? Timestamp
        {
            get => _timestamp;
            set => _timestamp = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public Evidence() { }

        public Evidence(string id, string name, string description, string source, string importance = "Normal")
        {
            Id = id;
            Name = name;
            Description = description;
            Source = source;
            Importance = importance;
        }

        public virtual string GetInspectionSummary()
        {
            return $"[Bằng chứng {Id}] {Name} | Nguồn: {Source} | Mức độ: {Importance} | Khám phá: {(IsDiscovered ? "Đã tìm ra" : "Chưa")}";
        }

        public override string ToString() => $"[{Id}] {Name}";
    }
}


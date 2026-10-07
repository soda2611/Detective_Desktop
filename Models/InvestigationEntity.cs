using System;

namespace _2611_WIN_B3.Models
{
    /// <summary>
    /// Giao diện (Interface) quy định các đối tượng có thể kiểm tra / thanh tra trong quá trình điều tra vụ án
    /// </summary>
    public interface IInspectable
    {
        string GetInspectionSummary();
    }

    /// <summary>
    /// Lớp cơ sở trừu tượng (Abstract Class) cho mọi đầu mối thông tin / tài nguyên số trong máy tính
    /// Thể hiện tính Đóng Gói (Encapsulation với full property get/set kèm validation),
    /// Tính Trừu Tượng (Abstract Method / Thuần ảo) và Tính Kế Thừa (Inheritance).
    /// </summary>
    public abstract class InvestigationEntity : IInspectable
    {
        private string _id = string.Empty;
        private string? _evidenceId;

        /// <summary>
        /// Mã định danh đối tượng (Property có get/set và kiểm tra tính hợp lệ)
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã Id của thực thể điều tra không được để trống!");
                _id = value.Trim();
            }
        }

        /// <summary>
        /// Mã bằng chứng liên kết (nếu có)
        /// </summary>
        public string? EvidenceId
        {
            get => _evidenceId;
            set => _evidenceId = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        /// <summary>
        /// Thuộc tính kiểm tra xem thực thể này có chứa bằng chứng hay không
        /// </summary>
        public bool ContainsClue => !string.IsNullOrEmpty(EvidenceId);

        protected InvestigationEntity() { }

        protected InvestigationEntity(string id, string? evidenceId = null)
        {
            Id = id;
            EvidenceId = evidenceId;
        }

        /// <summary>
        /// Phương thức thuần ảo (Pure Virtual Method / Abstract Method):
        /// Bắt buộc mọi lớp con dẫn xuất phải nạp chồng (override) để định nghĩa
        /// nguồn gốc hoặc loại đối tượng (Email, Lịch sử web, File hệ thống,...).
        /// </summary>
        public abstract string GetSourceType();

        /// <summary>
        /// Phương thức ảo (Virtual Method):
        /// Cung cấp cài đặt mặc định, các lớp con có thể ghi đè (override) để hiển thị chi tiết hơn.
        /// </summary>
        public virtual string GetInspectionSummary()
        {
            return $"[{GetSourceType()}] Mã: {Id} | Manh mối: {(ContainsClue ? EvidenceId : "Không có")}";
        }
    }
}


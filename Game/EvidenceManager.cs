using System.Collections.Generic;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Game
{
    /// <summary>
    /// Lớp quản trị kho lưu trữ và trạng thái phát hiện bằng chứng (Evidence Repository & Discovery Engine).
    /// Hiện thực nguyên lý Đóng gói (Encapsulation) bảo vệ trạng thái nội bộ với Dictionary<string, Evidence>.
    /// Đóng vai trò Subject phát tín hiệu trạng thái qua Event-Driven Model.
    /// </summary>
    public class EvidenceManager
    {
        private readonly GameState _state;
        private readonly Dictionary<string, Evidence> _evidences = new();

        /// <summary>
        /// Khởi tạo EvidenceManager với kỹ thuật Dependency Injection danh sách bằng chứng
        /// </summary>
        public EvidenceManager(GameState state, IEnumerable<Evidence>? customEvidences = null)
        {
            _state = state;
            if (customEvidences != null)
            {
                foreach (var ev in customEvidences)
                {
                    AddEvidence(ev);
                }
            }
            else
            {
                InitDefaultEvidences();
            }

            _state.TotalPossibleEvidenceCount = _evidences.Count;
        }

        /// <summary>
        /// Nạp tập bằng chứng mặc định ban đầu nếu không có file cấu hình ngoài (Hardcoded Fallback)
        /// </summary>
        private void InitDefaultEvidences()
        {
            AddEvidence(new Evidence
            {
                Id = "E001",
                Name = "Email lúc 21:43 - Hẹn gặp khẩn cấp",
                Description = "Email gửi từ Elena yêu cầu David rời bàn làm việc gặp gấp tại sảnh phụ trước giờ sao lưu tự động.",
                Source = "Mail Client",
                Importance = "High",
                Timestamp = "21:43"
            });

            AddEvidence(new Evidence
            {
                Id = "E002",
                Name = "Browser History - Cloud Storage",
                Description = "Lịch sử duyệt web lúc 21:42 truy cập dịch vụ lưu trữ đám mây ngoài công ty (cloud-storage.local/upload).",
                Source = "Browser History",
                Importance = "High",
                Timestamp = "21:42"
            });

            AddEvidence(new Evidence
            {
                Id = "E003",
                Name = "Recycle Bin - File bị xóa lúc 21:55",
                Description = "File mã hóa 'Project_Nexus_Core.enc' bị chuyển vào Thùng Rác và cố tình xóa nhật ký liên kết.",
                Source = "Recycle Bin",
                Importance = "Critical",
                Timestamp = "21:55"
            });

            AddEvidence(new Evidence
            {
                Id = "E004",
                Name = "USB Access Log - Kingston 64GB",
                Description = "Ghi nhận kết nối thiết bị lưu trữ ngoài USB Kingston 64GB vào cổng phụ máy tính lúc 21:45.",
                Source = "System Log / USB",
                Importance = "Critical",
                Timestamp = "21:45"
            });

            AddEvidence(new Evidence
            {
                Id = "E005",
                Name = "Security Camera - Khu vực Lab tầng 4",
                Description = "Camera hành lang ghi nhận bóng người khả nghi tiến vào khu lab lúc 21:40 (trùng thời điểm David rời máy).",
                Source = "Security Camera",
                Importance = "Medium",
                Timestamp = "21:40"
            });

            AddEvidence(new Evidence
            {
                Id = "E006",
                Name = "Biên bản cuộc họp - MeetingNotes_2140.txt",
                Description = "Biên bản cuộc họp ghi nhận họp từ 21:40 nhưng thời gian lưu sửa đổi trên hệ thống là 21:51.",
                Source = "Documents",
                Importance = "High",
                Timestamp = "21:51"
            });

            AddEvidence(new Evidence
            {
                Id = "E007",
                Name = "Server Audit Log - Database Access",
                Description = "Nhật ký máy chủ ghi nhận tài khoản Elena thực hiện truy xuất phân quyền root không được cấp phép lúc 21:38.",
                Source = "Server Log",
                Importance = "Medium",
                Timestamp = "21:38"
            });

            AddEvidence(new Evidence
            {
                Id = "E008",
                Name = "Batch Script - clean_trace.bat",
                Description = "Tệp script batch bị xóa chứa lệnh dọn dẹp event log Windows nhằm xóa sạch dấu vết đăng nhập.",
                Source = "Recycle Bin",
                Importance = "High",
                Timestamp = "21:58"
            });
        }

        /// <summary>
        /// Đăng ký thực thể bằng chứng vào bộ từ điển tra cứu nhanh O(1)
        /// </summary>
        private void AddEvidence(Evidence evidence)
        {
            _evidences[evidence.Id] = evidence;
        }

        /// <summary>
        /// Nghiệp vụ mở khóa bằng chứng (Idempotent Evidence Discovery Operation):
        /// Kiểm tra tính duy nhất, cập nhật trạng thái và phát sự kiện phản xạ tới Presentation Layer
        /// </summary>
        public bool DiscoverEvidence(string id)
        {
            if (!_evidences.ContainsKey(id)) return false;

            if (_state.DiscoveredEvidenceIds.Add(id))
            {
                _evidences[id].IsDiscovered = true;
                _state.TriggerEvidenceDiscovered(id, _evidences[id].Name);
                return true;
            }
            return false;
        }

        public bool IsDiscovered(string id) => _state.DiscoveredEvidenceIds.Contains(id);

        public Evidence? GetEvidence(string id) => _evidences.TryGetValue(id, out var ev) ? ev : null;

        public IEnumerable<Evidence> GetAllEvidences() => _evidences.Values;

        /// <summary>
        /// Trích xuất danh sách bằng chứng đã phát hiện bằng cơ chế Deferred Execution (yield return)
        /// </summary>
        public IEnumerable<Evidence> GetDiscoveredEvidences()
        {
            foreach (var id in _state.DiscoveredEvidenceIds)
            {
                if (_evidences.TryGetValue(id, out var ev))
                {
                    yield return ev;
                }
            }
        }

        public int DiscoveredCount => _state.DiscoveredEvidenceIds.Count;
        public int TotalCount => _evidences.Count;
    }
}


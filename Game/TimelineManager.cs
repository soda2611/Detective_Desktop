using System.Collections.Generic;
using _2611_WIN_B3.Models;

namespace _2611_WIN_B3.Game
{
    /// <summary>
    /// Lớp quản trị dòng thời gian sự kiện và công cụ suy luận liên kết bằng chứng (Timeline & Inference Engine).
    /// Áp dụng Pattern: Rule-based Deductive Reasoning (Suy luận dựa trên tập luật kết nối cặp bằng chứng).
    /// </summary>
    public class TimelineManager
    {
        private readonly GameState _state;
        private readonly List<TimelineEntry> _entries = new();
        private readonly List<EvidenceConnectionRule> _rules = new();

        public TimelineManager(
            GameState state,
            IEnumerable<TimelineEntry>? customTimeline = null,
            IEnumerable<EvidenceConnectionRule>? customRules = null)
        {
            _state = state;

            if (customTimeline != null)
            {
                _entries.AddRange(customTimeline);
            }
            else
            {
                InitDefaultTimeline();
            }

            if (customRules != null)
            {
                _rules.AddRange(customRules);
            }
            else
            {
                InitDefaultRules();
            }
        }

        /// <summary>
        /// Khởi tạo các mốc thời gian pháp chứng ban đầu (Digital Forensics Baseline)
        /// </summary>
        private void InitDefaultTimeline()
        {
            _entries.Add(new TimelineEntry { Time = "21:03", EventDescription = "David Miller mở tài liệu dự án kiểm tra lần cuối.", EvidenceId = "" });
            _entries.Add(new TimelineEntry { Time = "21:17", EventDescription = "Trang bảo mật nội bộ và quyền truy cập USB bị kiểm tra từ xa.", EvidenceId = "" });
            _entries.Add(new TimelineEntry { Time = "21:40", EventDescription = "Camera hành lang ghi nhận bóng người tiến vào khu lab.", EvidenceId = "E005" });
            _entries.Add(new TimelineEntry { Time = "21:42", EventDescription = "Truy cập cloud-storage.local upload file dung lượng lớn.", EvidenceId = "E002" });
            _entries.Add(new TimelineEntry { Time = "21:43", EventDescription = "Ghi nhận email khẩn cấp gửi từ e.rostova@novatech.local tới David Miller.", EvidenceId = "E001" });
            _entries.Add(new TimelineEntry { Time = "21:45", EventDescription = "USB Kingston cắm vào cổng phụ máy tính.", EvidenceId = "E004" });
            _entries.Add(new TimelineEntry { Time = "21:51", EventDescription = "Tập tin MeetingNotes_2140.txt được lưu với mốc thời gian 21:51.", EvidenceId = "E006" });
            _entries.Add(new TimelineEntry { Time = "21:55", EventDescription = "Tập tin Project_Nexus_Core.enc bị xóa khỏi thư mục Projects.", EvidenceId = "E003" });
            _entries.Add(new TimelineEntry { Time = "21:58", EventDescription = "Chạy file clean_trace.bat xóa dấu vết.", EvidenceId = "E008" });
        }

        /// <summary>
        /// Khởi tạo các luật suy luận đối chiếu chéo (Cross-Evidence Inference Rules)
        /// </summary>
        private void InitDefaultRules()
        {
            _rules.Add(new EvidenceConnectionRule
            {
                EvidenceA = "E001",
                EvidenceB = "E004",
                SuccessMessage = "CHÍNH XÁC: Elena lừa David đi gặp riêng để cắm USB vào máy trộm dữ liệu lúc 21:45!",
                NotificationText = "[KẾT NỐI TIMELINE] Email hẹn khẩn cấp gửi đi lúc 21:43, chỉ 2 phút sau (21:45) USB bị cắm vào máy! Kẻ gian đã cố ý bẫy David!"
            });

            _rules.Add(new EvidenceConnectionRule
            {
                EvidenceA = "E002",
                EvidenceB = "E003",
                SuccessMessage = "CHÍNH XÁC: Kẻ gian đã upload file mã hóa lên Cloud Storage lúc 21:42 rồi xóa file gốc vào Thùng Rác lúc 21:55!",
                NotificationText = "[KẾT NỐI TIMELINE] Đã chứng minh kẻ gian sao lưu trái phép ra ngoài rồi xóa file gốc phi tang!"
            });

            _rules.Add(new EvidenceConnectionRule
            {
                EvidenceA = "E005",
                EvidenceB = "E006",
                SuccessMessage = "CHÍNH XÁC: Camera thấy người vào lab lúc 21:40, nhưng biên bản họp lại khai Elena đang họp lúc 21:40! Lời khai ngoại phạm bị làm giả!",
                NotificationText = "[KẾT NỐI TIMELINE] Phát hiện bằng chứng ngoại phạm của Elena là giả mạo!"
            });
        }

        /// <summary>
        /// Thẩm định tính logic của liên kết giữa 2 bằng chứng (Pair-Wise Evidence Correlation)
        /// Áp dụng thuật toán so khớp đối xứng hai chiều: A liên kết B tương đương B liên kết A
        /// </summary>
        public bool TryConnectEvidences(string idA, string idB, out string message)
        {
            if (idA == idB)
            {
                message = "Không thể kết nối cùng một bằng chứng với chính nó.";
                return false;
            }

            string pairKey = string.CompareOrdinal(idA, idB) < 0 ? $"{idA}+{idB}" : $"{idB}+{idA}";
            if (_state.ConnectedEvidencePairs.Contains(pairKey))
            {
                message = "Cặp bằng chứng này đã được bạn liên kết và xác minh trước đó.";
                return false;
            }

            // Tra cứu quy tắc tương quan trong tập luật (Rule Matching Engine)
            var rule = _rules.Find(r =>
                (r.EvidenceA == idA && r.EvidenceB == idB) ||
                (r.EvidenceA == idB && r.EvidenceB == idA));

            if (rule != null)
            {
                _state.ConnectedEvidencePairs.Add(pairKey);
                _state.Notify(rule.NotificationText);
                message = rule.SuccessMessage;
                return true;
            }

            message = "Hai bằng chứng này chưa thể hiện mối tương quan rõ ràng. Hãy thử kết hợp manh mối khác!";
            return false;
        }

        /// <summary>
        /// Phương thức hỗ trợ giao diện kiểm tra nhanh kết nối giữa 2 manh mối (UI Facade Method)
        /// </summary>
        public string CheckConnection(string idA, string idB)
        {
            TryConnectEvidences(idA, idB, out string message);
            return message;
        }

        /// <summary>
        /// Lọc và trả về các mốc sự kiện đã đủ điều kiện hiển thị trên trục thời gian
        /// </summary>
        public IEnumerable<TimelineEntry> GetAvailableTimeline()
        {
            foreach (var entry in _entries)
            {
                // Mốc sự kiện hệ thống hoặc có bằng chứng đã được khám phá
                if (string.IsNullOrEmpty(entry.EvidenceId) || _state.DiscoveredEvidenceIds.Contains(entry.EvidenceId))
                {
                    yield return entry;
                }
            }
        }
    }
}

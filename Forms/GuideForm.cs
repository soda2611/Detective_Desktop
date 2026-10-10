using System;
using System.Windows.Forms;
using _2611_WIN_B3.Game;

namespace _2611_WIN_B3.Forms
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();
        }

        private void GuideForm_Load(object sender, EventArgs e)
        {
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1400, (int)(workArea.Width * 0.95));
            int targetH = Math.Min(900, (int)(workArea.Height * 0.95));
            Size = new System.Drawing.Size(targetW, targetH);
            MinimumSize = new System.Drawing.Size(Math.Min(1100, targetW), Math.Min(700, targetH));
            CenterToParent();

            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(14, 14);
            pnlHeader.Height = 58;

            tabGuide.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F, System.Drawing.FontStyle.Bold);
            txtOverview.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular);
            txtApps.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular);
            txtEvidence.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular);
            txtEndings.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular);
            btnGotIt.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);

            pnlBottom.Height = 62;
            btnGotIt.Size = new System.Drawing.Size(220, 44);
            btnGotIt.Top = 9;

            var c = GameManager.Instance.CaseManager.CurrentCase;
            var pkg = GameManager.Instance.CaseManager.CurrentPackage;

            Text = $"Cẩm Nang Điều Tra — {c.CaseId.ToUpper()}: {c.Title}";

            txtOverview.Text =
                $"=== {c.CaseId.ToUpper()}: {c.Title.ToUpper()} ===\n" +
                $"Độ khó: {c.Difficulty} | Thời gian xảy ra: {c.IncidentDate}\n\n" +
                $"1. BỐI CẢNH VỤ ÁN:\n" +
                $"{c.Overview}\n\n" +
                $"• Nạn nhân / Đối tượng: {c.Victim}\n" +
                $"• Tập tin trọng tâm / Bị chiếm đoạt: {c.MissingFileName}\n" +
                $"• Tóm tắt nhanh: {c.SummaryBrief}\n\n" +
                $"2. MỤC TIÊU CỦA THÁM TỬ:\n" +
                $"Bạn được cấp quyền truy cập vào máy tính của {c.VictimShortName} để điều tra thu thập chứng cứ:\n" +
                $"• Lục tìm manh mối qua {pkg.Emails.Count} email, {pkg.BrowserHistories.Count} trang web, và {pkg.Files.Count} tập tin hệ thống.\n" +
                $"• Kiểm tra Thùng rác (Recycle Bin) để khôi phục các tệp tin then chốt đã bị thủ phạm xóa phi tang.\n" +
                $"• Đối chiếu lời khai và chứng cứ ngoại phạm của {pkg.Suspects.Count} nghi phạm trong danh sách.\n" +
                $"• Ghép nối các cặp manh mối trên Evidence Board để hoàn thiện Dòng thời gian ({pkg.Timeline.Count} mốc sự kiện).\n" +
                $"• Nộp Báo cáo điều tra (Case Report) khi đã xác định đúng Thủ phạm, Động cơ và Thủ đoạn gây án!";

            txtApps.Text =
                $"=== HƯỚNG DẪN SỬ DỤNG CÁC CÔNG CỤ ĐIỀU TRA ({c.CaseId}) ===\n\n" +
                $"✉ MAIL CLIENT (HỘP THƯ NỘI BỘ):\n" +
                $"• Xem các email gửi đến {c.VictimShortName} trong ngày xảy ra vụ việc.\n" +
                $"• Lưu ý các bức thư có nội dung hoặc mốc thời gian đáng ngờ, tệp đính kèm lạ hoặc yêu cầu bất thường.\n\n" +
                $"🌐 WEB BROWSER (LỊCH SỬ DUYỆT WEB):\n" +
                $"• Rà soát các địa chỉ web và cổng dịch vụ được truy cập quanh thời điểm xảy ra sự việc.\n" +
                $"• Chú ý các kết nối ra ngoài tổ chức, dịch vụ lưu trữ hoặc cổng đăng nhập quản trị.\n\n" +
                $"📁 FILE EXPLORER (QUẢN LÝ TẬP TIN):\n" +
                $"• Duyệt qua các thư mục hệ thống: Documents, Projects, Work, Downloads, Archive.\n" +
                $"• Mở đọc: Nhật ký hệ thống (log), tài liệu dự án, biên bản họp và các tập lệnh (script).\n\n" +
                $"🗑 RECYCLE BIN (THÙNG RÁC HỆ THỐNG):\n" +
                $"• Kiểm tra các tập tin đã bị xóa. Hãy chọn tệp trong Thùng rác và bấm 'Khôi phục tệp' để đưa tệp trở lại hệ thống và phân tích chứng cứ.\n\n" +
                $"📝 SỔ TAY GHI CHÉP (NOTES):\n" +
                $"• Nơi bạn ghi lại mọi suy luận cá nhân và các mắt xích nghi vấn.";

            txtEvidence.Text =
                $"=== HƯỚNG DẪN EVIDENCE BOARD & GHÉP NỐI TIMELINE ({c.CaseId}) ===\n\n" +
                $"Evidence Board là công cụ để thám tử liên kết các mảnh ghép rời rạc:\n\n" +
                $"1. DANH SÁCH MANH MỐI ({pkg.Evidences.Count} BẰNG CHỨNG CẦN TÌM):\n" +
                $"Bên trái hiển thị các bằng chứng bạn đã khám phá được kèm mức độ quan trọng (Normal, High, Critical).\n\n" +
                $"2. TẠO LIÊN KẾT (CONNECT):\n" +
                $"• Chọn Manh mối A và Manh mối B ở hai ô chọn bên phải.\n" +
                $"• Bấm nút '🔗 TẠO LIÊN KẾT (CONNECT)'.\n" +
                $"• Vụ án này có {pkg.ConnectionRules.Count} quy tắc liên kết logic giữa các manh mối. Khi ghép đúng 2 manh mối tương ứng, hệ thống sẽ xác nhận và mở khóa một sự kiện mới trên Dòng thời gian (Timeline).\n\n" +
                $"3. NGUYÊN TẮC SUY LUẬN & LIÊN KẾT:\n" +
                $"• Đối chiếu mốc thời gian (Timestamp): Kiểm tra xem thời điểm ghi nhận trên log/camera có mâu thuẫn với lời khai ngoại phạm hay không.\n" +
                $"• Lần theo luồng hành vi (Chain of Custody): Tìm kiếm hành động chuẩn bị, hành động thực thi và hành động phi tang dấu vết của thủ phạm.\n" +
                $"• Kết nối nguyên nhân - kết quả: Kết hợp động cơ phạm tội (thư từ, tài chính) với các hành động can thiệp dữ liệu bất thường trên hệ thống.";

            int minPass = Math.Max(pkg.MinEvidenceForPass, 3);
            txtEndings.Text =
                $"=== HƯỚNG DẪN NỘP CASE REPORT & 5 KẾT THÚC (ENDINGS) ({c.CaseId}) ===\n\n" +
                $"Sau khi đã thu thập đủ bằng chứng, hãy mở ứng dụng CASE REPORT trên Desktop để nộp hồ sơ kết luận:\n\n" +
                $"CẦN ĐIỀN ĐỦ 4 TIÊU CHÍ:\n" +
                $"1. Nghi phạm chính (Suspect): Chọn từ danh sách {pkg.Suspects.Count} nghi phạm.\n" +
                $"2. Động cơ (Motive): Chọn lý do thúc đẩy hành vi phạm tội.\n" +
                $"3. Thủ đoạn (Method): Chọn phương thức kẻ gian đã sử dụng để thực hiện phi vụ.\n" +
                $"4. Đính kèm bằng chứng then chốt: Tích chọn các bằng chứng xác đáng đã thu thập được.\n\n" +
                $"5 KẾT THÚC CÓ THỂ MỞ KHÓA:\n\n" +
                $"🏆 ENDING 1: CORRECT DETECTIVE (Thám tử xuất sắc - 85đ)\n" +
                $"→ Chọn đúng Thủ phạm, đúng Động cơ, đúng Thủ đoạn và đính kèm ít nhất {minPass} bằng chứng then chốt.\n\n" +
                $"❌ ENDING 2: WRONG SUSPECT (Bắt sai người - 35đ)\n" +
                $"→ Cáo buộc nhầm người vô tội do suy luận vội vàng.\n\n" +
                $"⚖️ ENDING 3: INSUFFICIENT EVIDENCE (Thiếu chứng cứ - 60đ)\n" +
                $"→ Chỉ ra đúng thủ phạm nhưng không đính kèm đủ bằng chứng then chốt để chứng minh trước tòa án.\n\n" +
                $"🚫 ENDING 4: INCOMPLETE INVESTIGATION (Điều tra dang dở - 20đ)\n" +
                $"→ Vội vàng nộp báo cáo khi mới thu thập được dưới {minPass} bằng chứng trên toàn hệ thống.\n\n" +
                $"🌟 ENDING 5: THE BIGGER CASE (Đại án hé lộ - 100đ - SECRET ENDING)\n" +
                $"→ Tìm đủ từ {(int)Math.Ceiling(pkg.Evidences.Count * 0.85f)}/{pkg.Evidences.Count} bằng chứng và hoàn thành từ 3 liên kết Timeline trở lên trên Evidence Board!";
        }

        private void btnGotIt_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            Close();
        }
    }
}


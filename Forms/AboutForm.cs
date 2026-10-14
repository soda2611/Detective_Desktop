using System;
using System.Windows.Forms;
using _2611_WIN_B3.Game;

namespace _2611_WIN_B3.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(900, 640);
            CenterToParent();
            txtAboutContent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            btnOpenGuide.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            btnResetLog.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);

            var c = GameManager.Instance.CaseManager.CurrentCase;
            var pkg = GameManager.Instance.CaseManager.CurrentPackage;

            txtAboutContent.Text =
                "=== DỰ ÁN MÔN HỌC: LẬP TRÌNH WINDOWS (C# WINFORMS) ===\n\n" +
                "1. TÊN ĐỀ TÀI: DESKTOP DETECTIVE — TRÒ CHƠI TRINH THÁM KỸ THUẬT SỐ\n" +
                $"• Vụ án đang nạp: {c.CaseId} — {c.Title} (Độ khó: {c.Difficulty})\n" +
                $"• Nạn nhân / Đối tượng: {c.Victim}\n" +
                $"• Tập tin trọng tâm: {c.MissingFileName}\n" +
                "• Nền tảng công nghệ: .NET 10 (Windows Forms)\n" +
                "• Thiết kế giao diện: 100% Visual Studio WinForms Designer kéo thả\n\n" +
                "• ĐỘI NGŨ SINH VIÊN THỰC HIỆN:\n" +
                "  1. Hồ Minh Nhật       — MSSV: 51.01.104.065 (Lập trình chính)\n" +
                "  2. Trần Ngọc Hà       — MSSV: 51.01.104.020 (Thiết kế giao diện WinForms)\n" +
                "  3. Đào Khánh Trúc     — MSSV: 51.01.104.109 (Nội dung & Dữ liệu vụ án)\n" +
                "  4. Phan Thị Trang     — MSSV: 51.01.104.102 (Kiểm thử & Soạn báo cáo)\n\n" +
                "2. CỐT TRUYỆN VỤ ÁN HIỆN TẠI:\n" +
                $"{c.Overview}\n\n" +
                "3. DỮ LIỆU ĐIỀU TRA ĐƯỢC NẠP:\n" +
                $"• Hộp thư nội bộ: {pkg.Emails.Count} email trao đổi liên quan\n" +
                $"• Lịch sử duyệt web: {pkg.BrowserHistories.Count} trang web được ghi nhận\n" +
                $"• Hệ thống tệp: {pkg.Files.Count} tập tin lưu trữ (bao gồm tập tin bị xóa trong Thùng rác)\n" +
                $"• Manh mối & Bằng chứng: {pkg.Evidences.Count} bằng chứng độc lập, {pkg.ConnectionRules.Count} quy tắc ghép nối Timeline\n" +
                $"• Nghi phạm thẩm vấn: {pkg.Suspects.Count} người có liên quan\n\n" +
                "4. THỂ HIỆN KIẾN THỨC MÔN HỌC LẬP TRÌNH WINDOWS:\n" +
                "✓ Form, Panel, GroupBox, SplitContainer, TableLayoutPanel\n" +
                "✓ PictureBox, Label, Button, TextBox, RichTextBox\n" +
                "✓ ListView (View Details, Header, Icon, Multi-Column, Selection)\n" +
                "✓ TreeView (Duyệt cấu trúc thư mục phân cấp)\n" +
                "✓ DataGridView (Lịch sử duyệt web đa cột, CellClick event)\n" +
                "✓ ComboBox & CheckedListBox (Lựa chọn nghi phạm và bằng chứng)\n" +
                "✓ TabControl (Cẩm nang hướng dẫn chia 4 chương)\n" +
                "✓ ProgressBar & Timer (Hiệu ứng tiến độ, đồng hồ thời gian thực)\n" +
                "✓ ContextMenuStrip (Menu chuột phải Desktop)\n" +
                "✓ JSON Serialization & FileSystemWatcher (Quản lý file log và phát hiện xóa file thời gian thực)\n\n" +
                "Chúc bạn có trải nghiệm phá án thú vị!";
        }

        private void btnOpenGuide_Click(object sender, EventArgs e)
        {
            var guide = new GuideForm();
            guide.ShowDialog(this);
        }

        private void btnResetLog_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa file gamelog.json và thiết lập lại toàn bộ tiến trình điều tra về ban đầu?",
                "Xác nhận xóa log",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                SaveManager.DeleteLog();
                GameManager.Instance.ResetGame(becauseFileDeleted: true);
                MessageBox.Show("Đã xóa file gamelog.json và reset trò chơi về trạng thái ban đầu!", "Đã reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            var credits = new CreditsForm();
            credits.ShowDialog(this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


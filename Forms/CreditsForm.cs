using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2611_WIN_B3.Forms
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
            AppIconHelper.ApplyTo(this);
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
            Size = new Size(880, 620);
            CenterToParent();
            pnlHeader.Height = 56;
            pnlBottom.Height = 56;
            lblHeader.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtCredits.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            btnOK.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnOK.Size = new Size(120, 38);
            btnOK.Top = 9;

            txtCredits.Text =
                "DESKTOP DETECTIVE: THE MISSING FILE\n" +
                "Đồ án môn học: Lập trình Windows (.NET WinForms)\n\n" +
                "THÀNH VIÊN THỰC HIỆN:\n" +
                "• Hồ Minh Nhật     - MSSV: 51.01.104.065 (Lập trình chính)\n" +
                "• Trần Ngọc Hà     - MSSV: 51.01.104.020 (Thiết kế giao diện)\n" +
                "• Đào Khánh Trúc   - MSSV: 51.01.104.109 (Nội dung & Dữ liệu)\n" +
                "• Phan Thị Trang   - MSSV: 51.01.104.102 (Kiểm thử & Báo cáo)\n\n" +
                "PHÂN CÔNG CÔNG VIỆC:\n" +
                "• Hồ Minh Nhật: Xây dựng cấu trúc dữ liệu và xử lý logic trò chơi.\n" +
                "• Trần Ngọc Hà: Thiết kế và bố trí các biểu mẫu giao diện (Forms).\n" +
                "• Đào Khánh Trúc: Soạn thảo dữ liệu email, tài liệu và các manh mối vụ án.\n" +
                "• Phan Thị Trang: Kiểm thử chức năng ứng dụng và biên soạn tài liệu báo cáo.\n\n" +
                "LỜI CẢM ƠN:\n" +
                "Chân thành cảm ơn Quý Thầy/Cô bộ môn Lập trình Windows đã tận tình hướng dẫn và hỗ trợ nhóm trong suốt quá trình hoàn thành đề tài.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


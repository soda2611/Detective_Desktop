using System;
using System.Drawing;
using System.Windows.Forms;
using _2611_WIN_B3.Forms;
using _2611_WIN_B3.Game;

namespace _2611_WIN_B3
{
    /// <summary>
    /// Form giao diện chính mô phỏng môi trường làm việc hệ điều hành ảo (Virtual OS Desktop Environment).
    /// Đóng vai trò Presentation Layer, tích hợp hệ thống điều hướng MDI/Multi-Form và hiển thị tiến trình.
    /// Đăng ký quan sát sự kiện từ GameManager.Instance.State (Observer Pattern).
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCaseBriefing();

            // Đăng ký các delegate lắng nghe sự kiện từ State (Observer Pattern: Event Subscription)
            GameManager.Instance.State.OnEvidenceDiscovered += State_OnEvidenceDiscovered;
            GameManager.Instance.State.OnNotification += State_OnNotification;
            GameManager.Instance.OnGameReset += () => { if (InvokeRequired) Invoke(new Action(HandleGameReset)); else HandleGameReset(); };
            GameManager.Instance.OnStateUpdated += () => { 
                if (InvokeRequired) 
                    Invoke(new Action(() => { UpdateDashboard(); SetInvestigationStatus(GameManager.Instance.State.Status); })); 
                else 
                { 
                    UpdateDashboard(); 
                    SetInvestigationStatus(GameManager.Instance.State.Status); 
                } 
            };

            UpdateDashboard();
            UpdateTimerDisplay();
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

            btnSoundToggle.Text = AudioManager.Instance.IsMuted ? "🔇 Âm: Tắt" : "🔊 Âm: Bật";
            btnSoundToggle.ForeColor = AudioManager.Instance.IsMuted ? Color.FromArgb(185, 28, 28) : Color.FromArgb(20, 60, 110);

            // Mở tối đa toàn màn hình để mang lại trải nghiệm hệ điều hành ảo chân thực
            WindowState = FormWindowState.Maximized;

            // Nâng cao kích thước font chữ cho các biểu tượng ứng dụng và nhãn giao diện
            var iconFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblDocuments.Font = iconFont;
            lblBrowser.Font = iconFont;
            lblMail.Font = iconFont;
            lblRecycleBin.Font = iconFont;
            lblSearch.Font = iconFont;
            lblNotes.Font = iconFont;
            lblEvidenceBoard.Font = iconFont;
            lblCaseReport.Font = iconFont;
            lblGuide.Font = iconFont;

            SetupDesktopIconHover();
            SetupResponsiveLayout();

            // Khôi phục trạng thái GameState hiện tại (NotStarted, InProgress, Paused, Completed)
            SetInvestigationStatus(GameManager.Instance.State.Status);

            // Bắt đầu phát nhạc nền ngay từ khi mở game
            AudioManager.Instance.StartBgm();

            FormClosing += (s, ev) => AudioManager.Instance.StopBgm();
        }

        private void SetupResponsiveLayout()
        {
            pnlDesktop.Resize += (s, e) => LayoutDesktop();
            pnlTaskbar.Resize += (s, e) => LayoutTaskbar();
            grpCaseBrief.Resize += (s, e) => LayoutCaseBriefButtons();
            
            LayoutDesktop();
            LayoutTaskbar();
            LayoutCaseBriefButtons();
        }

        private void LayoutCaseBriefButtons()
        {
            if (grpCaseBrief == null || btnSelectCase == null || btnHighScores == null || btnStartInvestigation == null) return;
            int btnH = 44;
            int margin = 18;
            int bottomY = grpCaseBrief.ClientSize.Height - btnH - 12;

            if (bottomY < 50) return;

            int selectW = 180;
            int hsW = 180;
            int startW = 190;

            // Đặt 3 nút nằm sát góc phải dưới từ phải sang trái, không bao giờ đè lên nhau
            btnSelectCase.Location = new Point(grpCaseBrief.ClientSize.Width - selectW - margin, bottomY);
            btnSelectCase.Size = new Size(selectW, btnH);

            btnHighScores.Location = new Point(btnSelectCase.Left - hsW - 10, bottomY);
            btnHighScores.Size = new Size(hsW, btnH);

            btnStartInvestigation.Location = new Point(Math.Max(margin, btnHighScores.Left - startW - 10), bottomY);
            btnStartInvestigation.Size = new Size(startW, btnH);

            // Điều chỉnh vùng hiển thị của txtCaseOverview để tránh bị nút che khuất
            txtCaseOverview.Location = new Point(margin, 34);
            txtCaseOverview.Size = new Size(
                Math.Max(100, grpCaseBrief.ClientSize.Width - (margin * 2)),
                Math.Max(50, bottomY - 44)
            );
        }

        /// <summary>
        /// Quản lý và chuyển đổi trạng thái vòng đời điều tra (GameState Lifecycle: NotStarted -> InProgress <-> Paused -> Completed)
        /// </summary>
        public void SetInvestigationStatus(InvestigationStatus newStatus)
        {
            GameManager.Instance.State.Status = newStatus;

            bool isPlayable = newStatus == InvestigationStatus.InProgress;

            // Bật/tắt các Panel biểu tượng ứng dụng điều tra trên màn hình
            Panel[] iconPanels = {
                pnlIconDocuments, pnlIconBrowser, pnlIconMail,
                pnlIconRecycleBin, pnlIconSearch, pnlIconNotes,
                pnlIconEvidenceBoard, pnlIconCaseReport
            };

            foreach (var pnl in iconPanels)
            {
                if (pnl != null)
                {
                    pnl.Enabled = isPlayable;
                    pnl.Cursor = isPlayable ? Cursors.Hand : Cursors.No;
                }
            }

            // Ứng dụng Cẩm nang hướng dẫn luôn cho phép mở để người chơi xem luật
            if (pnlIconGuide != null)
            {
                pnlIconGuide.Enabled = true;
                pnlIconGuide.Cursor = Cursors.Hand;
            }

            // Cập nhật giao diện và màu sắc cho nút Điều khiển trạng thái
            if (btnStartInvestigation != null)
            {
                switch (newStatus)
                {
                    case InvestigationStatus.NotStarted:
                        btnStartInvestigation.Text = "▶ BẮT ĐẦU";
                        btnStartInvestigation.BackColor = Color.FromArgb(22, 163, 74);
                        btnStartInvestigation.ForeColor = Color.White;
                        btnStartInvestigation.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
                        btnStartInvestigation.ContextMenuStrip = null;
                        lblNotification.ForeColor = Color.FromArgb(180, 83, 9);
                        lblNotification.Text = "⏳ Hãy đọc kỹ hồ sơ vụ án ở trên rồi bấm nút '▶ BẮT ĐẦU' để bắt đầu tính giờ và kích hoạt các ứng dụng!";
                        break;

                    case InvestigationStatus.InProgress:
                        btnStartInvestigation.Text = "⏸ TẠM DỪNG ▾";
                        btnStartInvestigation.BackColor = Color.FromArgb(254, 243, 199);
                        btnStartInvestigation.ForeColor = Color.FromArgb(180, 83, 9);
                        btnStartInvestigation.FlatAppearance.BorderColor = Color.FromArgb(245, 158, 11);
                        btnStartInvestigation.ContextMenuStrip = cmsInvestigation;
                        lblNotification.ForeColor = Color.FromArgb(22, 101, 52);
                        lblNotification.Text = "⭐ ĐANG PHÁ ÁN: Đồng hồ đang đếm giờ. Nhấp đúp vào các biểu tượng để điều tra!";
                        break;

                    case InvestigationStatus.Paused:
                        btnStartInvestigation.Text = "▶ TIẾP TỤC ▾";
                        btnStartInvestigation.BackColor = Color.FromArgb(239, 246, 255);
                        btnStartInvestigation.ForeColor = Color.FromArgb(29, 78, 216);
                        btnStartInvestigation.FlatAppearance.BorderColor = Color.FromArgb(96, 165, 250);
                        btnStartInvestigation.ContextMenuStrip = cmsInvestigation;
                        lblNotification.ForeColor = Color.FromArgb(29, 78, 216);
                        lblNotification.Text = "⏸ ĐÃ TẠM DỪNG: Đồng hồ đang dừng để giữ công tâm cho thời gian phá án. Bấm nút '▶ TIẾP TỤC ▾' khi bạn sẵn sàng!";
                        break;

                    case InvestigationStatus.Completed:
                        btnStartInvestigation.Text = "🏁 ĐÃ KẾT THÚC ▾";
                        btnStartInvestigation.BackColor = Color.FromArgb(243, 244, 246);
                        btnStartInvestigation.ForeColor = Color.FromArgb(107, 114, 128);
                        btnStartInvestigation.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
                        btnStartInvestigation.ContextMenuStrip = cmsInvestigation;
                        lblNotification.ForeColor = Color.FromArgb(22, 101, 52);
                        lblNotification.Text = "🏆 VỤ ÁN ĐÃ KẾT THÚC! Bấm nút để chọn 'Chơi lại vụ án' hoặc 'Đổi màn chơi'.";
                        break;
                }
            }
        }

        private void btnStartInvestigation_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);

            switch (GameManager.Instance.State.Status)
            {
                case InvestigationStatus.NotStarted:
                    // Chưa bắt đầu -> Bắt đầu ngay lập tức
                    SetInvestigationStatus(InvestigationStatus.InProgress);
                    break;

                case InvestigationStatus.InProgress:
                case InvestigationStatus.Paused:
                case InvestigationStatus.Completed:
                    // Đã bắt đầu -> Xổ menu lựa chọn điều khiển (Chơi lại, Tạm dừng/Tiếp tục, v.v.)
                    ShowInvestigationMenu();
                    break;
            }
        }

        private void ShowInvestigationMenu()
        {
            if (cmsInvestigation == null || btnStartInvestigation == null) return;

            var status = GameManager.Instance.State.Status;
            if (status == InvestigationStatus.InProgress)
            {
                tsmiPauseResume.Visible = true;
                tsmiPauseResume.Text = "⏸ Tạm dừng điều tra";
            }
            else if (status == InvestigationStatus.Paused)
            {
                tsmiPauseResume.Visible = true;
                tsmiPauseResume.Text = "▶ Tiếp tục phá án";
            }
            else
            {
                tsmiPauseResume.Visible = false;
            }

            cmsInvestigation.Show(btnStartInvestigation, 0, btnStartInvestigation.Height);
        }

        private void tsmiPauseResume_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            if (GameManager.Instance.State.Status == InvestigationStatus.InProgress)
            {
                SetInvestigationStatus(InvestigationStatus.Paused);
            }
            else if (GameManager.Instance.State.Status == InvestigationStatus.Paused)
            {
                SetInvestigationStatus(InvestigationStatus.InProgress);
            }
        }

        private void LayoutDesktop()
        {
            if (pnlDesktop == null || grpCaseBrief == null) return;

            int desktopW = pnlDesktop.ClientSize.Width;
            int desktopH = pnlDesktop.ClientSize.Height;

            // Xếp 9 icons thành 3 cột hoặc 2 cột tùy độ rộng màn hình
            int colWidth = 135;
            int rowHeight = 125;
            int startX = 25;
            int startY = 20;

            Panel[] icons = {
                pnlIconDocuments, pnlIconBrowser, pnlIconMail,
                pnlIconRecycleBin, pnlIconSearch, pnlIconNotes,
                pnlIconEvidenceBoard, pnlIconCaseReport, pnlIconGuide
            };

            int cols = 3;
            // Nếu màn hình quá hẹp, chuyển sang 2 cột icons
            if (desktopW < 900)
            {
                cols = 2;
            }

            for (int i = 0; i < icons.Length; i++)
            {
                if (icons[i] == null) continue;
                int c = i % cols;
                int r = i / cols;
                icons[i].Location = new Point(startX + c * colWidth, startY + r * rowHeight);
            }

            // GroupBox tóm tắt vụ án chiếm phần còn lại bên phải
            int iconsRightEdge = startX + (cols * colWidth) + 15;
            int briefLeft = Math.Max(iconsRightEdge, 440);
            int briefTop = 20;
            int briefW = Math.Max(300, desktopW - briefLeft - 20);
            int briefH = Math.Max(200, desktopH - briefTop - 15);

            grpCaseBrief.Location = new Point(briefLeft, briefTop);
            grpCaseBrief.Size = new Size(briefW, briefH);
            LayoutCaseBriefButtons();
        }

        private void LayoutTaskbar()
        {
            if (pnlTaskbar == null) return;

            int barW = pnlTaskbar.ClientSize.Width;
            int barH = pnlTaskbar.ClientSize.Height;

            // 1. Phía bên phải: btnSoundToggle, lblClock, lblCaseTimer
            int rightMargin = 20;
            int clockW = 140;
            int soundW = 130;

            // Đồng hồ & Timer căn giữa cụm bên phải
            lblClock.Location = new Point(barW - clockW - rightMargin, 26);
            lblClock.Size = new Size(clockW, 30);

            lblCaseTimer.Location = new Point(barW - clockW - rightMargin, 60);
            lblCaseTimer.Size = new Size(clockW, 32);

            btnSoundToggle.Location = new Point(lblClock.Left - soundW - 20, 36);
            btnSoundToggle.Size = new Size(soundW, 46);

            int rightEdgeStart = btnSoundToggle.Left - 24;

            // 2. Phía bên trái: Tiến trình & Thông tin vụ án
            // Row 1: Tiến trình bằng chứng (pbEvidenceProgress + lblEvidenceCounter)
            int progBarW = 240;
            pbEvidenceProgress.Location = new Point(18, 16);
            pbEvidenceProgress.Size = new Size(progBarW, 18);

            lblEvidenceCounter.AutoSize = true;
            lblEvidenceCounter.Location = new Point(18 + progBarW + 14, 12);

            // Row 1 bên phải: Thông báo/Manh mối mới (khi có sự kiện phát sinh)
            int notifLeft = lblEvidenceCounter.Right + 20;
            int notifWidth = Math.Max(50, rightEdgeStart - notifLeft);
            lblNotification.Location = new Point(notifLeft, 12);
            lblNotification.Size = new Size(notifWidth, 26);

            // Chiều rộng tối đa cho thông tin vụ án (trải dài đến tận nút Âm thanh)
            int caseInfoWidth = Math.Max(200, rightEdgeStart - 18);

            // Row 2: Tiêu đề vụ án (rộng rãi, cao thoáng)
            lblCaseTitle.AutoSize = false;
            lblCaseTitle.AutoEllipsis = true;
            lblCaseTitle.Location = new Point(18, 46);
            lblCaseTitle.Size = new Size(caseInfoWidth, 30);

            // Row 3: Chi tiết nạn nhân & file (rộng rãi, không bị chen chúc hay tràn viền)
            lblVictimInfo.AutoSize = false;
            lblVictimInfo.AutoEllipsis = true;
            lblVictimInfo.Location = new Point(18, 80);
            lblVictimInfo.Size = new Size(caseInfoWidth, 26);
        }

        private void SetupDesktopIconHover()
        {
            Panel[] iconPanels = {
                pnlIconDocuments, pnlIconBrowser, pnlIconMail,
                pnlIconRecycleBin, pnlIconSearch, pnlIconNotes,
                pnlIconEvidenceBoard, pnlIconCaseReport, pnlIconGuide
            };

            Color hoverColor = Color.FromArgb(215, 230, 250);
            Color defaultColor = Color.Transparent;

            foreach (var pnl in iconPanels)
            {
                pnl.MouseEnter += (s, e) => pnl.BackColor = hoverColor;
                pnl.MouseLeave += (s, e) => {
                    if (!pnl.ClientRectangle.Contains(pnl.PointToClient(Cursor.Position)))
                        pnl.BackColor = defaultColor;
                };

                foreach (Control child in pnl.Controls)
                {
                    child.MouseEnter += (s, e) => pnl.BackColor = hoverColor;
                    child.MouseLeave += (s, e) => {
                        if (!pnl.ClientRectangle.Contains(pnl.PointToClient(Cursor.Position)))
                            pnl.BackColor = defaultColor;
                    };
                }
            }
        }

        private void UpdateTimerDisplay()
        {
            int secs = GameManager.Instance.State.ElapsedSeconds;
            var ts = TimeSpan.FromSeconds(secs);
            lblCaseTimer.Text = ts.TotalHours >= 1 
                ? $"⏱ {ts:hh\\:mm\\:ss}" 
                : $"⏱ {ts:mm\\:ss}";
        }

        private void LoadCaseBriefing()
        {
            var c = GameManager.Instance.CaseManager.CurrentCase;
            var pkg = GameManager.Instance.CaseManager.CurrentPackage;
            Text = $"Desktop Detective — {c.CaseId.ToUpper()}: {c.Title}";
            grpCaseBrief.Text = $"  HỒ SƠ VỤ ÁN: {c.CaseId.ToUpper()} — {c.Title.ToUpper()}  ";
            lblCaseTitle.Text = $"VỤ ÁN [{c.CaseId.ToUpper()}]: {c.Title.ToUpper()}";
            lblVictimInfo.Text = $"Nạn nhân: {c.Victim} | File bị mất: {c.MissingFileName}";

            txtCaseOverview.Text =
                $"=== {c.CaseId.ToUpper()}: {c.Title.ToUpper()} ===\n" +
                $"• Độ khó: {c.Difficulty} | Ngày xảy ra: {c.IncidentDate}\n" +
                $"• Nạn nhân / Đối tượng: {c.Victim}\n" +
                $"• Tập tin bị mất / Mục tiêu: {c.MissingFileName}\n" +
                $"• Tóm tắt nhanh: {c.SummaryBrief}\n\n" +
                $"TÌNH TIẾT BAN ĐẦU:\n{c.Overview}\n\n" +
                $"DỮ LIỆU ĐIỀU TRA TRÊN HỆ THỐNG:\n" +
                $"• Số lượng nghi phạm trong diện điều tra: {pkg.Suspects.Count} người\n" +
                $"• Số lượng bằng chứng cần thu thập: {pkg.Evidences.Count} manh mối\n" +
                $"• Số lượng email trao đổi: {pkg.Emails.Count} thư\n" +
                $"• Số lượng tập tin & dữ liệu: {pkg.Files.Count} tệp\n\n" +
                $"CHỈ DẪN ĐIỀU TRA DÀNH CHO BẠN:\n" +
                $"1. Nhấp đúp vào ✉ Mail: Đọc các email trao đổi nội bộ và phát hiện các bức thư bất thường.\n" +
                $"2. Nhấp đúp vào 🌐 Browser: Rà soát lịch sử duyệt web tìm vị trí upload / truy cập mạng trái phép.\n" +
                $"3. Nhấp đúp vào 📁 Documents: Đọc tài liệu dự án, biên bản họp và các file nhật ký log.\n" +
                $"4. Nhấp đúp vào 🗑 Recycle Bin: Tìm kiếm và khôi phục các tập tin then chốt đã bị thủ phạm xóa.\n" +
                $"5. Nhấp đúp vào 📝 Notes: Ghi chú lại bất cứ nghi vấn và phân tích cá nhân nào.\n" +
                $"6. Mở 🧩 Evidence Board: Kết nối 2 manh mối tương ứng để dựng lại dòng thời gian (Timeline).\n" +
                $"7. Mở 📋 Case Report: Nộp kết luận khi đã nắm chắc danh tính thủ phạm, động cơ và thủ đoạn!\n" +
                $"8. Nhấp đúp vào 📖 Cẩm Nang: Xem chi tiết hướng dẫn & điều kiện mở 5 Endings!\n" +
                $"9. Bấm '🏆 Bảng thành tích' để xem xếp hạng và mở file highscores.txt!\n" +
                $"10. Bấm '📂 Đổi màn chơi' để mở danh sách các vụ án khác (hoặc nạp vụ án mới từ file JSON)!";
        }

        private void State_OnEvidenceDiscovered(string id, string name)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => State_OnEvidenceDiscovered(id, name)));
                return;
            }

            AudioManager.Instance.Play(SoundEffect.ClueDiscovered);
            UpdateDashboard();
            lblNotification.ForeColor = Color.FromArgb(22, 101, 52);
            lblNotification.Text = $"⭐ MANH MỐI MỚI [{id}]: {name}";
        }

        private void State_OnNotification(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => State_OnNotification(message)));
                return;
            }

            AudioManager.Instance.Play(SoundEffect.Notification);
            lblNotification.ForeColor = Color.FromArgb(15, 45, 80);
            lblNotification.Text = message;
        }

        private void UpdateDashboard()
        {
            int discovered = GameManager.Instance.EvidenceManager.DiscoveredCount;
            int total = GameManager.Instance.EvidenceManager.TotalCount;
            int percent = total > 0 ? (discovered * 100 / total) : 0;

            lblEvidenceCounter.Text = $"Bằng chứng: {discovered} / {total} ({percent}%)";
            pbEvidenceProgress.Maximum = total;
            pbEvidenceProgress.Value = Math.Min(discovered, total);
        }

        private void HandleGameReset()
        {
            LoadCaseBriefing();
            UpdateDashboard();
            UpdateTimerDisplay();
            SetInvestigationStatus(InvestigationStatus.NotStarted);
            if (!SaveManager.LogExists())
            {
                lblNotification.ForeColor = Color.FromArgb(185, 28, 28);
                lblNotification.Text = "⚠️ Tiến trình game đã được thiết lập lại từ đầu do file gamelog.json bị xóa.";
            }
            else
            {
                lblNotification.ForeColor = Color.FromArgb(22, 101, 52);
                lblNotification.Text = $"⭐ Đã nạp thành công vụ án: {GameManager.Instance.CaseManager.CurrentCase.Title}";
            }
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            // Chỉ đếm thời gian phá án khi đang ở trạng thái InProgress
            if (GameManager.Instance.State.Status == InvestigationStatus.InProgress)
            {
                GameManager.Instance.State.ElapsedSeconds++;
                UpdateTimerDisplay();
            }

            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            GameManager.Instance.CheckLogFileLiveness();
        }

        private void btnSoundToggle_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.IsMuted = !AudioManager.Instance.IsMuted;
            btnSoundToggle.Text = AudioManager.Instance.IsMuted ? "🔇 Âm: Tắt" : "🔊 Âm: Bật";
            btnSoundToggle.ForeColor = AudioManager.Instance.IsMuted ? Color.FromArgb(185, 28, 28) : Color.FromArgb(20, 60, 110);
            if (!AudioManager.Instance.IsMuted)
            {
                AudioManager.Instance.Play(SoundEffect.Click);
            }
        }

        #region App Launchers

        private void OpenDocuments_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new ExplorerForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenBrowser_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new BrowserForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenMail_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new MailForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenRecycleBin_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new RecycleBinForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenSearch_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            string keyword = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập từ khóa hoặc tên tập tin cần tra cứu trong hệ thống:",
                "Tra cứu tập tin & dữ liệu điều tra",
                "");

            if (string.IsNullOrWhiteSpace(keyword)) return;

            keyword = keyword.ToLower().Trim();
            var matchedFiles = GameManager.Instance.CaseManager.FileItems.FindAll(f =>
                f.FileName.ToLower().Contains(keyword) || f.Content.ToLower().Contains(keyword));

            if (matchedFiles.Count > 0)
            {
                AudioManager.Instance.Play(SoundEffect.Notification);
                string summary = $"Tìm thấy {matchedFiles.Count} mục liên quan đến '{keyword}':\n\n";
                foreach (var f in matchedFiles)
                {
                    summary += $"• [{f.Folder}] {f.FileName} ({f.Size})\n";
                }
                summary += "\nHãy mở File Explorer hoặc Recycle Bin để kiểm tra chi tiết!";
                MessageBox.Show(summary, "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AudioManager.Instance.Play(SoundEffect.Notification);
                MessageBox.Show($"Không tìm thấy tập tin nào khớp với từ khóa '{keyword}'.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenNotes_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new NotesForm();
            form.Show(this);
        }

        private void OpenEvidenceBoard_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new EvidenceBoardForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenGuide_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new GuideForm();
            form.Show(this);
        }

        private void OpenCaseReport_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new CaseReportForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenHighScores_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            var hsForm = new HighScoreForm();
            hsForm.ShowDialog(this);
        }

        private void OpenCaseSelect_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            var selectForm = new CaseSelectForm();
            if (selectForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadCaseBriefing();
                UpdateDashboard();
                UpdateTimerDisplay();
                SetInvestigationStatus(InvestigationStatus.NotStarted);
                lblNotification.ForeColor = Color.PaleGreen;
                lblNotification.Text = $"⭐ Đã nạp thành công vụ án: {GameManager.Instance.CaseManager.CurrentCase.Title}. Bấm '▶ BẮT ĐẦU' để điều tra!";
            }
        }

        private void btnRestartCase_Click(object sender, EventArgs e)
        {
            AudioManager.Instance.Play(SoundEffect.Click);
            var currentCase = GameManager.Instance.CaseManager.CurrentCase;
            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn chơi lại vụ án [{currentCase.CaseId.ToUpper()}]: {currentCase.Title}?\n\n" +
                "Toàn bộ manh mối đã thu thập, dòng thời gian và thời gian phá án hiện tại sẽ được đặt lại từ đầu.",
                "Xác nhận chơi lại vụ án",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                GameManager.Instance.ResetGame(becauseFileDeleted: false);
                LoadCaseBriefing();
                UpdateDashboard();
                UpdateTimerDisplay();
                SetInvestigationStatus(InvestigationStatus.NotStarted);
                lblNotification.ForeColor = Color.FromArgb(22, 101, 52);
                lblNotification.Text = $"🔄 Đã thiết lập lại vụ án [{currentCase.CaseId.ToUpper()}]. Bấm '▶ BẮT ĐẦU' để phá án từ đầu!";
            }
        }

        #endregion

        #region Context Menu Events

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            UpdateDashboard();
            lblNotification.ForeColor = Color.SkyBlue;
            lblNotification.Text = "Đã làm mới giao diện và thông tin hồ sơ vụ án.";
        }

        private void tsSaveGame_Click(object sender, EventArgs e)
        {
            bool ok = SaveManager.Save(GameManager.Instance.State, out string message);
            MessageBox.Show(message, ok ? "Lưu game thành công" : "Lỗi lưu game",
                MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void tsLoadGame_Click(object sender, EventArgs e)
        {
            var loadedState = SaveManager.Load(out string message);
            if (loadedState != null)
            {
                GameManager.Instance.ReloadState(loadedState);
                LoadCaseBriefing();
                UpdateDashboard();
                UpdateTimerDisplay();
                SetInvestigationStatus(GameManager.Instance.State.Status);
                MessageBox.Show(message, "Tải game thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsCredits_Click(object sender, EventArgs e)
        {
            var credits = new CreditsForm();
            credits.ShowDialog(this);
        }

        #endregion
    }
}


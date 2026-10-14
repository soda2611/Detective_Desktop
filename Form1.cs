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
            AppIconHelper.ApplyTo(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCaseBriefing();

            // Đăng ký các delegate lắng nghe sự kiện từ GameManager (Observer Pattern: Event Subscription)
            GameManager.Instance.OnEvidenceDiscovered += State_OnEvidenceDiscovered;
            GameManager.Instance.OnNotification += State_OnNotification;
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

            btnSoundToggle.Text = AudioManager.Instance.IsMuted ? "🔇 Tắt" : "🔊 Bật";
            btnSoundToggle.ForeColor = AudioManager.Instance.IsMuted ? Color.FromArgb(185, 28, 28) : Color.FromArgb(20, 60, 110);

            // Thiết lập kích thước cửa sổ game tỉ lệ 150% (chuẩn ~1680x980, giới hạn tối đa 95% màn hình người dùng)
            var workArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.GetWorkingArea(this);
            int targetW = Math.Min(1680, (int)(workArea.Width * 0.96));
            int targetH = Math.Min(980, (int)(workArea.Height * 0.96));
            Size = new Size(targetW, targetH);
            MinimumSize = new Size(Math.Min(1150, targetW), Math.Min(720, targetH));
            WindowState = FormWindowState.Normal;
            CenterToScreen();

            // Tăng kích thước thanh Taskbar lên 150% (68px)
            pnlTaskbar.Height = 68;

            DoubleBuffered = true;
            SetDoubleBuffered(pnlDesktop);
            SetDoubleBuffered(pnlTaskbar);
            SetDoubleBuffered(grpCaseBrief);

            // Nâng kích thước font chữ cho các biểu tượng ứng dụng lên 150% (14.5pt Semibold)
            var iconFont = new Font("Segoe UI Semibold", 14.5F, FontStyle.Bold);
            lblDocuments.Font = iconFont;
            lblBrowser.Font = iconFont;
            lblMail.Font = iconFont;
            lblRecycleBin.Font = iconFont;
            lblSearch.Font = iconFont;
            lblNotes.Font = iconFont;
            lblEvidenceBoard.Font = iconFont;
            lblCaseReport.Font = iconFont;
            lblGuide.Font = iconFont;

            // Đồng bộ Typography tỉ lệ 150% cho GroupBox và Case Brief
            grpCaseBrief.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            txtCaseOverview.Font = new Font("Segoe UI", 14F, FontStyle.Regular);

            // Đồng bộ Typography tỉ lệ 150% cho Taskbar
            lblCaseTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblVictimInfo.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            lblEvidenceCounter.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
            lblNotification.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblClock.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCaseTimer.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnSoundToggle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);

            SetupDesktopIconHover();
            SetupResponsiveLayout();

            // Khôi phục trạng thái GameState hiện tại (NotStarted, InProgress, Paused, Completed)
            SetInvestigationStatus(GameManager.Instance.State.Status);

            // Bắt đầu phát nhạc nền ngay từ khi mở game
            AudioManager.Instance.StartBgm();

            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            try
            {
                // 1. Tắt timer hệ thống để dừng truy cập I/O liveness
                systemTimer.Stop();

                // 2. Lưu tiến trình trước khi thoát
                GameManager.Instance.SaveProgress();

                // 3. Giải phóng triệt để toàn bộ NAudio AudioFileReader, WaveOut và ngắt worker thread
                AudioManager.Instance.Shutdown();

                // 4. Giải phóng FileSystemWatcher và các tài nguyên quản lý
                GameManager.Instance.Dispose();
            }
            catch { }
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try
            {
                // Đảm bảo không còn thread chạy ngầm nào giữ process hoặc khóa file
                Application.Exit();
            }
            catch { }
        }

        private static void SetDoubleBuffered(Control c)
        {
            try
            {
                var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                prop?.SetValue(c, true, null);
            }
            catch { }
        }

        private void SetupResponsiveLayout()
        {
            // Vô hiệu hóa Anchor mặc định trên các control do code tự layout để tránh xung đột co giật
            grpCaseBrief.Anchor = AnchorStyles.None;
            btnStartInvestigation.Anchor = AnchorStyles.None;
            btnHighScores.Anchor = AnchorStyles.None;
            btnSelectCase.Anchor = AnchorStyles.None;
            txtCaseOverview.Anchor = AnchorStyles.None;

            btnSoundToggle.Anchor = AnchorStyles.None;
            lblCaseTimer.Anchor = AnchorStyles.None;
            lblClock.Anchor = AnchorStyles.None;
            lblNotification.Anchor = AnchorStyles.None;
            pbEvidenceProgress.Anchor = AnchorStyles.None;
            lblEvidenceCounter.Anchor = AnchorStyles.None;
            lblCaseTitle.Anchor = AnchorStyles.None;
            lblVictimInfo.Anchor = AnchorStyles.None;

            Resize += (s, e) => {
                LayoutDesktop();
                LayoutTaskbar();
            };
            pnlDesktop.Resize += (s, e) => LayoutDesktop();
            pnlTaskbar.Resize += (s, e) => LayoutTaskbar();
            grpCaseBrief.Resize += (s, e) => LayoutCaseBriefButtons();
            
            LayoutDesktop();
            LayoutTaskbar();
            LayoutCaseBriefButtons();
        }

        private void LayoutCaseBriefButtons()
        {
            if (grpCaseBrief == null || btnSelectCase == null || btnHighScores == null || btnStartInvestigation == null || txtCaseOverview == null) return;

            int clientW = grpCaseBrief.ClientSize.Width;
            int clientH = grpCaseBrief.ClientSize.Height;
            int margin = 18;
            int btnH = 54;
            int gap = 12;
            int availW = clientW - (margin * 2);

            if (availW < 100 || clientH < 100) return;

            int topOfButtons;

            // Thiết lập font chữ nút bấm tỷ lệ 150%
            btnStartInvestigation.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnHighScores.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
            btnSelectCase.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);

            // Kiểm tra xem 3 nút có đủ chỗ hiển thị trên 1 hàng không (ngưỡng tối thiểu ~580px)
            if (availW >= 580)
            {
                // === CHẾ ĐỘ 1 HÀNG (Widescreen / Standard) ===
                int bottomY = clientH - btnH - 16;
                topOfButtons = bottomY;

                // Tỷ lệ: Nút chính Bắt đầu chiếm ~40%, 2 nút phụ chia đều phần còn lại
                int b1 = (availW - (gap * 2)) * 40 / 100;
                int b2 = (availW - (gap * 2) - b1) / 2;
                int b3 = availW - (gap * 2) - b1 - b2;

                btnStartInvestigation.Location = new Point(margin, bottomY);
                btnStartInvestigation.Size = new Size(b1, btnH);

                btnHighScores.Location = new Point(btnStartInvestigation.Right + gap, bottomY);
                btnHighScores.Size = new Size(b2, btnH);

                btnSelectCase.Location = new Point(btnHighScores.Right + gap, bottomY);
                btnSelectCase.Size = new Size(b3, btnH);
            }
            else
            {
                // === CHẾ ĐỘ 2 HÀNG (Compact / Responsive Stacking) ===
                int row2Y = clientH - btnH - 14;
                int row1Y = row2Y - btnH - gap;
                topOfButtons = row1Y;

                btnStartInvestigation.Location = new Point(margin, row1Y);
                btnStartInvestigation.Size = new Size(availW, btnH);

                int halfW = (availW - gap) / 2;
                btnHighScores.Location = new Point(margin, row2Y);
                btnHighScores.Size = new Size(halfW, btnH);

                btnSelectCase.Location = new Point(btnHighScores.Right + gap, row2Y);
                btnSelectCase.Size = new Size(availW - halfW - gap, btnH);
            }

            // Tự động căn chỉnh kích thước vùng văn bản txtCaseOverview, tuyệt đối không bị nút che lấp
            int overviewTop = 38;
            int overviewHeight = Math.Max(40, topOfButtons - overviewTop - 12);
            txtCaseOverview.Location = new Point(margin, overviewTop);
            txtCaseOverview.Size = new Size(availW, overviewHeight);
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
                    AudioManager.Instance.Play(SoundEffect.Notification);
                    if (!AudioManager.Instance.IsBgmPlaying && !AudioManager.Instance.IsMuted)
                    {
                        AudioManager.Instance.StartBgm();
                    }
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

            Panel[] icons = {
                pnlIconDocuments, pnlIconBrowser, pnlIconMail,
                pnlIconRecycleBin, pnlIconSearch, pnlIconNotes,
                pnlIconEvidenceBoard, pnlIconCaseReport, pnlIconGuide
            };

            // Phân bổ cột icon: 2 cột khi hẹp (< 950px), 3 cột chuẩn hệ điều hành
            int cols = (desktopW < 950) ? 2 : 3;

            int startX = 25;
            int startY = 22;
            int colWidth = 175;
            int rowHeight = 155;

            for (int i = 0; i < icons.Length; i++)
            {
                if (icons[i] == null) continue;
                int c = i % cols;
                int r = i / cols;
                icons[i].Location = new Point(startX + c * colWidth, startY + r * rowHeight);
            }

            // Căn chỉnh GroupBox hồ sơ vụ án bên phải
            int iconsRightEdge = startX + (cols * colWidth) + 20;
            int briefLeft = Math.Max(iconsRightEdge, cols == 2 ? 390 : 570);
            int briefTop = 20;
            int briefW = Math.Max(380, desktopW - briefLeft - 24);
            int briefH = Math.Max(260, desktopH - briefTop - 18);

            grpCaseBrief.Location = new Point(briefLeft, briefTop);
            grpCaseBrief.Size = new Size(briefW, briefH);
            LayoutCaseBriefButtons();
        }

        private void LayoutTaskbar()
        {
            if (pnlTaskbar == null) return;

            int barW = pnlTaskbar.ClientSize.Width;
            int barH = pnlTaskbar.ClientSize.Height;

            // Ẩn các nhãn tiêu đề vụ án trùng lặp khỏi Taskbar để tối ưu diện tích và độ thanh thoát
            lblCaseTitle.Visible = false;
            lblVictimInfo.Visible = false;

            // 1. Cụm bên phải: System Tray (Đồng hồ + Stopwatch đếm giờ + Nút Âm thanh)
            int rightMargin = 20;
            int clockW = 120;
            int timerW = 135;
            int soundW = 125;
            int elemY = Math.Max(10, (barH - 42) / 2);

            lblClock.Location = new Point(barW - clockW - rightMargin, elemY + 3);
            lblClock.Size = new Size(clockW, 36);
            lblClock.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
            lblClock.TextAlign = ContentAlignment.MiddleCenter;

            lblCaseTimer.Location = new Point(lblClock.Left - timerW - 12, elemY + 3);
            lblCaseTimer.Size = new Size(timerW, 36);
            lblCaseTimer.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
            lblCaseTimer.TextAlign = ContentAlignment.MiddleCenter;

            btnSoundToggle.Location = new Point(lblCaseTimer.Left - soundW - 14, elemY);
            btnSoundToggle.Size = new Size(soundW, 42);
            btnSoundToggle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSoundToggle.Text = AudioManager.Instance.IsMuted ? "🔇 Tắt" : "🔊 Bật";

            int rightEdge = btnSoundToggle.Left - 20;

            // 2. Cụm bên trái: Tiến trình thu thập bằng chứng
            int leftMargin = 20;
            int progBarW = 170;
            int progY = Math.Max(12, (barH - 22) / 2);
            pbEvidenceProgress.Location = new Point(leftMargin, progY);
            pbEvidenceProgress.Size = new Size(progBarW, 22);

            lblEvidenceCounter.AutoSize = true;
            lblEvidenceCounter.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblEvidenceCounter.Location = new Point(leftMargin + progBarW + 14, Math.Max(8, (barH - 30) / 2));

            int leftBoundary = lblEvidenceCounter.Right + 20;

            // 3. Cụm trung tâm: Bảng tin thông báo thời gian thực rộng rãi, không bị bóp
            int notifWidth = Math.Max(80, rightEdge - leftBoundary);
            lblNotification.AutoSize = false;
            lblNotification.AutoEllipsis = true;
            lblNotification.Location = new Point(leftBoundary, Math.Max(8, (barH - 40) / 2));
            lblNotification.Size = new Size(notifWidth, 40);
            lblNotification.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold);
            lblNotification.TextAlign = ContentAlignment.MiddleLeft;
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
                $"• Mức độ: {c.Difficulty}  |  Ngày xảy ra: {c.IncidentDate}\n" +
                $"• Nạn nhân: {c.Victim}\n" +
                $"• Mục tiêu: Thu hồi '{c.MissingFileName}' & vạch trần thủ phạm\n" +
                $"• Tóm tắt: {c.SummaryBrief}\n\n" +
                $"TÌNH TIẾT VỤ ÁN:\n{c.Overview}\n\n" +
                $"DỮ LIỆU ĐIỀU TRA KHẢ DỤNG TRÊN HỆ THỐNG:\n" +
                $"• {pkg.Suspects.Count} nghi phạm trong diện thẩm vấn\n" +
                $"• {pkg.Evidences.Count} bằng chứng cần thu thập & đối soát\n" +
                $"• {pkg.Emails.Count} email nội bộ  |  {pkg.Files.Count} tệp tin hệ thống  |  {pkg.Notes.Count} ghi chú trích xuất\n\n" +
                $"💡 GỢI Ý ĐIỀU TRA:\n" +
                $"Mở các ứng dụng trên màn hình để thu thập dấu vết kỹ thuật số. Mở 🧩 Evidence Board để dựng lại dòng thời gian, và hoàn thành 📋 Case Report khi đã đủ chứng cứ!";

            // Tự động cập nhật giao diện biểu tượng ứng dụng theo cấu hình DisabledApps của vụ án (100% Data-Driven)
            UpdateAppIconVisualState("Browser", lblBrowser, "Browser", "Offline");
            UpdateAppIconVisualState("Mail", lblMail, "Mail", "No Signal");
            UpdateAppIconVisualState("Documents", lblDocuments, "Documents", "Locked");
            UpdateAppIconVisualState("RecycleBin", lblRecycleBin, "Recycle Bin", "Disabled");
            UpdateAppIconVisualState("Search", lblSearch, "Search", "Offline");
            UpdateAppIconVisualState("Notes", lblNotes, "Notes", "Empty");
        }

        private void UpdateAppIconVisualState(string appKey, Label lbl, string defaultName, string? offlineSuffix = null)
        {
            var pkg = GameManager.Instance.CaseManager.CurrentPackage;
            bool isDisabled = pkg.DisabledApps != null && pkg.DisabledApps.Contains(appKey);
            lbl.Font = isDisabled ? new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold) : new Font("Segoe UI Semibold", 14.5F, FontStyle.Bold);
            string suffix = offlineSuffix ?? "Offline";
            lbl.Text = isDisabled ? $"{defaultName} 🔒\n({suffix})" : defaultName;
            lbl.ForeColor = isDisabled ? Color.FromArgb(130, 140, 150) : Color.FromArgb(15, 30, 60);
            lbl.Height = 48;
        }

        private void State_OnEvidenceDiscovered(string id, string name)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => State_OnEvidenceDiscovered(id, name)));
                return;
            }

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
            btnSoundToggle.Text = AudioManager.Instance.IsMuted ? "🔇 Tắt" : "🔊 Bật";
            btnSoundToggle.ForeColor = AudioManager.Instance.IsMuted ? Color.FromArgb(185, 28, 28) : Color.FromArgb(20, 60, 110);
            if (!AudioManager.Instance.IsMuted)
            {
                AudioManager.Instance.Play(SoundEffect.Click);
            }
        }

        #region App Launchers

        private bool CheckAppAccessible(string appKey, string defaultTitle)
        {
            var pkg = GameManager.Instance.CaseManager.CurrentPackage;
            if (pkg.DisabledApps != null && pkg.DisabledApps.Contains(appKey))
            {
                AudioManager.Instance.Play(SoundEffect.Failure);
                string reason = (pkg.AppLockReasons != null && pkg.AppLockReasons.TryGetValue(appKey, out var msg))
                    ? msg
                    : $"🚫 Ứng dụng {appKey} hiện đang bị cách ly hoặc ngoại tuyến trong vụ án này!";
                MessageBox.Show(reason, defaultTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void OpenDocuments_Click(object sender, EventArgs e)
        {
            if (!CheckAppAccessible("Documents", "TRUY CẬP TỆP TIN")) return;
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new ExplorerForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenBrowser_Click(object sender, EventArgs e)
        {
            if (!CheckAppAccessible("Browser", "HỆ THỐNG CÁCH LY (AIR-GAPPED)")) return;
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new BrowserForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenMail_Click(object sender, EventArgs e)
        {
            if (!CheckAppAccessible("Mail", "MÁY CHỦ THƯ NỘI BỘ NGOẠI TUYẾN")) return;
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new MailForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenRecycleBin_Click(object sender, EventArgs e)
        {
            if (!CheckAppAccessible("RecycleBin", "THÙNG RÁC HỆ THỐNG")) return;
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new RecycleBinForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
            form.Show(this);
        }

        private void OpenSearch_Click(object sender, EventArgs e)
        {
            if (!CheckAppAccessible("Search", "CÔNG CỤ TÌM KIẾM")) return;
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
            if (!CheckAppAccessible("Notes", "SỔ TAY GHI CHÚ")) return;
            AudioManager.Instance.Play(SoundEffect.AppOpen);
            var form = new NotesForm();
            form.FormClosed += (s, ev) => UpdateDashboard();
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


using System;
using System.IO;

namespace _2611_WIN_B3.Game
{
    /// <summary>
    /// Lớp điều phối trung tâm toàn bộ vòng đời ứng dụng (Central Game Coordinator).
    /// Hiện thực Design Pattern: Singleton Pattern (Thread-safe via Lazy<T>).
    /// Quản lý trạng thái phân tầng: GameState, EvidenceManager, TimelineManager, CaseManager.
    /// Giám sát sự kiện hệ điều hành: FileSystemWatcher (I/O event monitoring) & Timer Polling.
    /// </summary>
    public class GameManager
    {
        // Khởi tạo Singleton Thread-Safe sử dụng System.Lazy<T>
        private static readonly Lazy<GameManager> _instance = 
            new Lazy<GameManager>(() => new GameManager());

        /// <summary>
        /// Điểm truy cập toàn cục duy nhất (Global Access Point) tới GameManager
        /// </summary>
        public static GameManager Instance => _instance.Value;

        // Domain & State Managers (Kiến trúc phân tầng Domain-Driven)
        public GameState State { get; private set; }
        public EvidenceManager EvidenceManager { get; private set; }
        public TimelineManager TimelineManager { get; private set; }
        public CaseManager CaseManager { get; private set; }

        // Multicast Events thông báo tới Presentation Layer (Observer Pattern)
        public event Action? OnGameReset;
        public event Action? OnStateUpdated;

        private FileSystemWatcher? _fileWatcher;
        private bool _isResetting = false;

        public GameManager()
        {
            CaseManager = new CaseManager();

            // Khôi phục trạng thái tiến trình tuần tự hóa từ disk nếu tồn tại
            if (SaveManager.LogExists() && SaveManager.LoadLog(out _) is { } loadedState)
            {
                State = loadedState;
                if (!string.IsNullOrEmpty(State.ActiveCaseId) && State.ActiveCaseId != CaseManager.CurrentPackage.CaseId)
                {
                    CaseManager.SwitchCase(State.ActiveCaseId);
                }

                // Nếu khởi động từ tiến trình cũ trong gamelog mà đang dở dang (InProgress),
                // bắt buộc đưa về trạng thái Paused nhằm giữ công tâm cho thời gian phá án của người chơi
                if (State.Status == InvestigationStatus.InProgress)
                {
                    State.Status = InvestigationStatus.Paused;
                }
            }
            else
            {
                State = new GameState { ActiveCaseId = CaseManager.CurrentPackage.CaseId };
            }

            // Đồng bộ trạng thái file đã khôi phục vào hệ thống tệp
            CaseManager.SyncFileStates(State);

            // Khởi tạo các Manager chuyên biệt theo Dependency Injection thủ công
            EvidenceManager = new EvidenceManager(State, CaseManager.CurrentPackage.Evidences);
            TimelineManager = new TimelineManager(State, CaseManager.CurrentPackage.Timeline, CaseManager.CurrentPackage.ConnectionRules);

            SetupEventHooks();
            SetupFileWatcher();

            // Ghi nhật ký tiến trình ban đầu (Persistence Initialization)
            SaveManager.AutoSave(State);
        }

        /// <summary>
        /// Đăng ký lắng nghe sự kiện từ State (Observer Pattern: Subject -> Observer)
        /// </summary>
        private void SetupEventHooks()
        {
            State.OnEvidenceDiscovered += (id, name) =>
            {
                SaveProgress();
                OnStateUpdated?.Invoke();
            };

            State.OnNotification += (msg) =>
            {
                SaveProgress();
                OnStateUpdated?.Invoke();
            };
        }

        /// <summary>
        /// Tuần tự hóa và lưu trạng thái xuống tệp JSON (State Persistence)
        /// </summary>
        public void SaveProgress()
        {
            if (_isResetting) return;
            SaveManager.AutoSave(State);
        }

        /// <summary>
        /// Cấu hình FileSystemWatcher để bắt sự kiện xóa tệp từ Hệ điều hành (OS-Level File Event Trap)
        /// </summary>
        private void SetupFileWatcher()
        {
            try
            {
                string dir = Directory.GetCurrentDirectory();
                _fileWatcher = new FileSystemWatcher(dir, SaveManager.LogFileName)
                {
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                    EnableRaisingEvents = true
                };

                _fileWatcher.Deleted += (s, e) =>
                {
                    ResetGame(becauseFileDeleted: true);
                };
            }
            catch { }
        }

        /// <summary>
        /// Cơ chế phòng vệ kép (Dual-Defense Liveness Polling): Kiểm tra sự tồn tại của log mỗi chu kỳ timer
        /// </summary>
        public void CheckLogFileLiveness()
        {
            if (_isResetting) return;

            if (!SaveManager.LogExists() && State.DiscoveredEvidenceIds.Count > 0)
            {
                ResetGame(becauseFileDeleted: true);
            }
        }

        /// <summary>
        /// Chuyển đổi gói vụ án (Context Switching giữa các Case Packages)
        /// </summary>
        public void SelectCase(string caseId)
        {
            if (CaseManager.SwitchCase(caseId))
            {
                ResetGame(becauseFileDeleted: false);
            }
        }

        /// <summary>
        /// Nạp lại GameState từ file lưu thủ công (Manual Save Restore)
        /// </summary>
        public void ReloadState(GameState newState)
        {
            State = newState;
            if (!string.IsNullOrEmpty(State.ActiveCaseId) && State.ActiveCaseId != CaseManager.CurrentPackage.CaseId)
            {
                CaseManager.SwitchCase(State.ActiveCaseId);
            }
            if (State.Status == InvestigationStatus.InProgress)
            {
                State.Status = InvestigationStatus.Paused;
            }
            CaseManager.SyncFileStates(State);
            EvidenceManager = new EvidenceManager(State, CaseManager.CurrentPackage.Evidences);
            TimelineManager = new TimelineManager(State, CaseManager.CurrentPackage.Timeline, CaseManager.CurrentPackage.ConnectionRules);
            SetupEventHooks();
            SaveProgress();
            OnStateUpdated?.Invoke();
        }

        /// <summary>
        /// Báo hiệu trạng thái điều tra vừa thay đổi và lưu tiến trình xuống disk
        /// </summary>
        public void NotifyStateChanged()
        {
            CaseManager.SyncFileStates(State);
            SaveProgress();
            OnStateUpdated?.Invoke();
        }

        /// <summary>
        /// Đặt lại toàn bộ tiến trình điều tra về trạng thái ban đầu (State Rollback)
        /// </summary>
        public void ResetGame(bool becauseFileDeleted = false)
        {
            _isResetting = true;
            try
            {
                State = new GameState 
                { 
                    ActiveCaseId = CaseManager.CurrentPackage.CaseId,
                    TotalPossibleEvidenceCount = CaseManager.CurrentPackage.Evidences.Count
                };
                CaseManager.SyncFileStates(State);
                EvidenceManager = new EvidenceManager(State, CaseManager.CurrentPackage.Evidences);
                TimelineManager = new TimelineManager(State, CaseManager.CurrentPackage.Timeline, CaseManager.CurrentPackage.ConnectionRules);

                SetupEventHooks();

                if (!becauseFileDeleted)
                {
                    SaveManager.AutoSave(State);
                }

                if (becauseFileDeleted)
                {
                    State.Notify("⚠️ File gamelog.json đã bị xóa! Toàn bộ tiến trình điều tra đã được thiết lập lại từ đầu.");
                }

                OnGameReset?.Invoke();
                OnStateUpdated?.Invoke();
            }
            finally
            {
                _isResetting = false;
            }
        }
    }
}


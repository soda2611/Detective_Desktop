using System;
using System.Collections.Generic;

namespace _2611_WIN_B3.Game
{
    public enum InvestigationStatus
    {
        NotStarted,
        InProgress,
        Paused,
        Completed
    }

    public class GameState
    {
        public string ActiveCaseId { get; set; } = "CASE-001";
        public InvestigationStatus Status { get; set; } = InvestigationStatus.NotStarted;
        public HashSet<string> DiscoveredEvidenceIds { get; set; } = new HashSet<string>();
        public HashSet<string> ReadEmailIds { get; set; } = new HashSet<string>();
        public HashSet<string> OpenedFileIds { get; set; } = new HashSet<string>();
        public HashSet<string> RestoredFileIds { get; set; } = new HashSet<string>();
        public HashSet<string> CheckedBrowserIds { get; set; } = new HashSet<string>();
        public List<string> ConnectedEvidencePairs { get; set; } = new List<string>();
        public string DetectiveNotes { get; set; } = "=== SỔ TAY GHI CHÉP ĐIỀU TRA ===\n- Ghi lại các manh mối, mâu thuẫn thời gian và nghi vấn cần đối chiếu.\n- Dữ liệu sổ tay được lưu trữ tự động vào tiến trình điều tra.\n";
        public string SelectedSuspectId { get; set; } = string.Empty;
        public string SelectedMotive { get; set; } = string.Empty;
        public string SelectedMethod { get; set; } = string.Empty;
        public string FinalConclusion { get; set; } = string.Empty;
        public int ElapsedSeconds { get; set; } = 0;
        public string ReachedEnding { get; set; } = string.Empty;
        public int TotalPossibleEvidenceCount { get; set; } = 8;

        public event Action<string, string>? OnEvidenceDiscovered;
        public event Action<string>? OnNotification;

        public void Notify(string message)
        {
            OnNotification?.Invoke(message);
        }

        public void TriggerEvidenceDiscovered(string id, string name)
        {
            OnEvidenceDiscovered?.Invoke(id, name);
        }
    }
}


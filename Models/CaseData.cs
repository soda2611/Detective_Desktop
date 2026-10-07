using System.Collections.Generic;

namespace _2611_WIN_B3.Models
{
    public class FileItem : InvestigationEntity
    {
        private string _fileName = string.Empty;
        private string _folder = string.Empty;
        private string _originalFolder = string.Empty;
        private string _size = string.Empty;
        private string _modifiedTime = string.Empty;
        private string _content = string.Empty;

        public string FileName
        {
            get => _fileName;
            set => _fileName = value ?? string.Empty;
        }

        public string Folder
        {
            get => _folder;
            set => _folder = value ?? string.Empty;
        }

        public string OriginalFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(_originalFolder)) return _originalFolder;
                if (!string.IsNullOrEmpty(Folder) && !Folder.Equals("Recycle Bin", System.StringComparison.OrdinalIgnoreCase)) return Folder;
                if (FileName.Contains("Project") || FileName.Contains("Nexus") || FileName.Contains("enc") || FileName.Contains("db")) return "Projects";
                if (FileName.Contains("key") || FileName.Contains("rsa") || FileName.Contains("log") || FileName.Contains("pem") || FileName.Contains("auth")) return "Work";
                if (FileName.Contains("bat") || FileName.Contains("split") || FileName.Contains("ps1") || FileName.Contains("sh")) return "Downloads";
                return "Documents";
            }
            set => _originalFolder = value ?? string.Empty;
        }

        public string Size
        {
            get => _size;
            set => _size = value ?? string.Empty;
        }

        public string ModifiedTime
        {
            get => _modifiedTime;
            set => _modifiedTime = value ?? string.Empty;
        }

        public string Content
        {
            get => _content;
            set => _content = value ?? string.Empty;
        }

        public bool IsDeleted { get; set; } = false;

        // Lưu vết trạng thái ban đầu của vụ án phục vụ reset/đồng bộ
        public bool InitialIsDeleted { get; set; } = false;
        public string InitialFolder { get; set; } = string.Empty;

        public FileItem() : base() { }

        public FileItem(string id, string fileName, string folder, string? evidenceId = null)
            : base(id, evidenceId)
        {
            FileName = fileName;
            Folder = folder;
            OriginalFolder = folder;
            InitialFolder = folder;
        }

        public override string GetSourceType() => IsDeleted ? "Recycle Bin" : "File System";

        public override string GetInspectionSummary()
        {
            return $"[{GetSourceType()}] {Folder}/{FileName} ({Size}) - Sửa đổi: {ModifiedTime}";
        }
    }

    public class TimelineEntry
    {
        public string Time { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public string EvidenceId { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
    }

    public class EvidenceConnectionRule
    {
        public string EvidenceA { get; set; } = string.Empty;
        public string EvidenceB { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;
        public string NotificationText { get; set; } = string.Empty;
    }

    public class CaseData
    {
        public string CaseId { get; set; } = "Case #001";
        public string Title { get; set; } = "The Missing File";
        public string Victim { get; set; } = "David Miller (Senior Project Manager)";
        public string MissingFileName { get; set; } = "Project_Nexus_Core.enc";
        public string IncidentDate { get; set; } = "2026-10-05";
        public string Overview { get; set; } = "David Miller was found unconscious in his office last night. The core project file 'Project_Nexus_Core.enc' containing proprietary algorithms was deleted, and an unauthorized cloud backup was created.";
        public string Difficulty { get; set; } = "Dễ";
        public string SummaryBrief { get; set; } = "Vụ án trộm cắp tài sản trí tuệ công nghệ cao tại tập đoàn Novatech.";
        public string CorrectSuspectId { get; set; } = "SUSPECT_02"; // Elena Rostova
        public string CorrectMotive { get; set; } = "Gián điệp công nghệ - Nhận tiền lót tay 50,000 USD từ đối thủ CyberTech";
        public string CorrectMethod { get; set; } = "Lừa nạn nhân ra ngoài, cắm USB sao chép, tải lên Cloud và xóa file gốc";
        public List<string> RequiredEvidenceIds { get; set; } = new List<string> { "E001", "E002", "E003", "E004", "E006" };

        public string VictimShortName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Victim)) return "Người dùng";
                return Victim.Split('(')[0].Replace("Dr.", "").Trim();
            }
        }

        public string VictimUserName
        {
            get
            {
                string shortName = VictimShortName;
                return shortName.Replace(" ", "");
            }
        }
    }

    public class CasePackage
    {
        public string CaseId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Victim { get; set; } = string.Empty;
        public string MissingFileName { get; set; } = string.Empty;
        public string IncidentDate { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public string Difficulty { get; set; } = "Bình thường";
        public string SummaryBrief { get; set; } = string.Empty;

        // Solution criteria
        public string CorrectSuspectId { get; set; } = string.Empty;
        public string CorrectMotive { get; set; } = string.Empty;
        public string CorrectMethod { get; set; } = string.Empty;
        public List<string> MotiveOptions { get; set; } = new();
        public List<string> MethodOptions { get; set; } = new();
        public List<string> RequiredEvidenceIds { get; set; } = new();
        public int MinEvidenceForPass { get; set; } = 3;

        // Data arrays
        public List<Suspect> Suspects { get; set; } = new();
        public List<Evidence> Evidences { get; set; } = new();
        public List<Email> Emails { get; set; } = new();
        public List<BrowserHistory> BrowserHistories { get; set; } = new();
        public List<FileItem> Files { get; set; } = new();
        public List<TimelineEntry> Timeline { get; set; } = new();
        public List<EvidenceConnectionRule> ConnectionRules { get; set; } = new();

        public CaseData ToCaseData()
        {
            return new CaseData
            {
                CaseId = CaseId,
                Title = Title,
                Victim = Victim,
                MissingFileName = MissingFileName,
                IncidentDate = IncidentDate,
                Overview = Overview,
                Difficulty = Difficulty,
                SummaryBrief = SummaryBrief,
                CorrectSuspectId = CorrectSuspectId,
                CorrectMotive = CorrectMotive,
                CorrectMethod = CorrectMethod,
                RequiredEvidenceIds = RequiredEvidenceIds
            };
        }
    }
}

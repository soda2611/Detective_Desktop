using System;

using System.Collections.Generic;

using System.IO;

using System.Text.Json;

using _2611_WIN_B3.Models;



namespace _2611_WIN_B3.Game

{

    /// <summary>

    /// Lớp quản trị các gói vụ án và luật thẩm định kết luận (Case Package & Evaluation Engine).

    /// Áp dụng mẫu thiết kế Dynamic Content Loader: Tải dữ liệu vụ án từ các tệp tin cấu hình JSON rời rạc.

    /// Hiện thực thuật toán cây quyết định đa nhánh để đánh giá 5 kịch bản kết thúc (Decision Tree Ending Evaluation).

    /// </summary>

    public class CaseManager

    {

        public List<CasePackage> AvailableCases { get; private set; } = new();

        public CasePackage CurrentPackage { get; private set; } = new();



        public CaseData CurrentCase => CurrentPackage.ToCaseData();

        public List<Suspect> Suspects => CurrentPackage.Suspects;

        public List<Email> Emails => CurrentPackage.Emails;

        public List<BrowserHistory> BrowserHistories => CurrentPackage.BrowserHistories;

        public List<FileItem> FileItems => CurrentPackage.Files;

        public List<NoteItem> Notes => CurrentPackage.Notes;



        private static readonly JsonSerializerOptions JsonOptions = new()

        {

            PropertyNameCaseInsensitive = true,

            WriteIndented = true

        };



        public CaseManager()

        {

            LoadAvailableCases();

        }



        /// <summary>

        /// Quét các đường dẫn ứng viên để nạp toàn bộ danh mục vụ án từ ổ đĩa (Multi-Path Directory Probe)

        /// </summary>

        public void LoadAvailableCases()

        {

            AvailableCases.Clear();

            var candidatePaths = new List<string>

            {

                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Cases"),

                Path.Combine(Directory.GetCurrentDirectory(), "Data", "Cases"),

                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "Cases"),

                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Data", "Cases"),

                @"D:\ltw\2611_WIN_B3\Data\Cases"

            };



            string? validDir = null;

            foreach (var p in candidatePaths)

            {

                try

                {

                    string full = Path.GetFullPath(p);

                    if (Directory.Exists(full) && Directory.GetFiles(full, "*.json").Length > 0)

                    {

                        validDir = full;

                        break;

                    }

                }

                catch { }

            }



            if (!string.IsNullOrEmpty(validDir))

            {

                string[] files = Directory.GetFiles(validDir, "*.json");

                // Sắp xếp thứ tự tệp theo ký tự tăng dần (Alphabetical Sort)

                Array.Sort(files);

                foreach (string f in files)

                {

                    try

                    {

                        string json = File.ReadAllText(f);

                        var pkg = JsonSerializer.Deserialize<CasePackage>(json, JsonOptions);

                        if (pkg != null && !string.IsNullOrEmpty(pkg.CaseId))

                        {

                            InitPackageDefaults(pkg);

                            AvailableCases.Add(pkg);

                        }

                    }

                    catch { }

                }

            }



            if (AvailableCases.Count == 0)

            {

                // Khởi tạo vụ án dự phòng mặc định (Fallback In-Memory Case Definition)

                var defaultCase = new CasePackage

                {

                    CaseId = "Case #001",

                    Title = "The Missing File",

                    Victim = "David Miller (Senior Project Manager)",

                    MissingFileName = "Project_Nexus_Core.enc",

                    IncidentDate = "2026-10-05",

                    Overview = "David Miller bị phát hiện bất tỉnh tại văn phòng tầng 4. File mã hóa cốt lõi Project_Nexus_Core.enc bị đánh cắp.",

                    CorrectSuspectId = "SUSPECT_02",

                    CorrectMotive = "Gián điệp công nghệ - Nhận tiền lót tay 50,000 USD từ đối thủ CyberTech",

                    CorrectMethod = "Lừa nạn nhân ra ngoài, cắm USB sao chép, tải lên Cloud và xóa file gốc"

                };

                InitPackageDefaults(defaultCase);

                AvailableCases.Add(defaultCase);

            }



            CurrentPackage = AvailableCases[0];

        }





        /// <summary>

        /// Khởi tạo và chuẩn hóa dữ liệu gói vụ án theo kiến trúc thuần dữ liệu (100% Dynamic Data-Driven Architecture).

        /// Toàn bộ thông tin vụ án (manh mối, tệp tin, nghi phạm, ghi chú, luật kết nối, app bị khóa)

        /// được đọc trực tiếp từ tệp JSON mà TUYỆT ĐỐI KHÔNG CẦN sửa đổi hay dev lại mã nguồn C# trong CaseManager!

        /// </summary>

        private void InitPackageDefaults(CasePackage pkg)

        {

            pkg.Files ??= new List<FileItem>();

            pkg.Notes ??= new List<NoteItem>();

            pkg.Suspects ??= new List<Suspect>();

            pkg.Evidences ??= new List<Evidence>();

            pkg.Emails ??= new List<Email>();

            pkg.BrowserHistories ??= new List<BrowserHistory>();

            pkg.Timeline ??= new List<TimelineEntry>();

            pkg.ConnectionRules ??= new List<EvidenceConnectionRule>();

            pkg.DisabledApps ??= new List<string>();

            pkg.AppLockReasons ??= new Dictionary<string, string>();

            pkg.RequiredEvidenceIds ??= new List<string>();

            pkg.MotiveOptions ??= new List<string>();

            pkg.MethodOptions ??= new List<string>();



            // 1. Lưu vết trạng thái ban đầu của hệ thống tệp tin (phục vụ reset và khôi phục từ Recycle Bin)

            foreach (var file in pkg.Files)

            {

                file.InitialIsDeleted = file.IsDeleted;

                file.InitialFolder = file.Folder;



                // Tự động bảo toàn dữ liệu: Nếu file có EvidenceId nhưng Evidences chưa khai báo, tự động tạo

                if (!string.IsNullOrEmpty(file.EvidenceId) && !pkg.Evidences.Exists(e => e.Id == file.EvidenceId))

                {

                    pkg.Evidences.Add(new Evidence

                    {

                        Id = file.EvidenceId,

                        Name = $"Tập tin - {file.FileName}",

                        Description = $"Manh mối trích xuất từ tập tin '{file.FileName}'.",

                        Source = file.IsDeleted ? "Recycle Bin" : $"Documents / {file.Folder}",

                        Importance = "High",

                        Timestamp = file.ModifiedTime.Length >= 5 ? file.ModifiedTime[^5..] : "12:00"

                    });

                }

            }



            // 2. Tự động kiểm tra tính toàn vẹn của ghi chú Sticky Notes

            foreach (var note in pkg.Notes)

            {

                if (!string.IsNullOrEmpty(note.EvidenceId) && !pkg.Evidences.Exists(e => e.Id == note.EvidenceId))

                {

                    pkg.Evidences.Add(new Evidence

                    {

                        Id = note.EvidenceId,

                        Name = $"Ghi chú - {note.Title}",

                        Description = $"Manh mối trích xuất từ mẩu ghi chú '{note.Title}' của {note.Author}.",

                        Source = "Sticky Notes",

                        Importance = "High",

                        Timestamp = note.Date.Length >= 5 ? note.Date[^5..] : "12:00"

                    });

                }

            }



            // 3. Chuẩn hóa ngưỡng bằng chứng yêu cầu tối thiểu nếu gói chưa thiết lập

            if (pkg.MinEvidenceForPass <= 0)

            {

                pkg.MinEvidenceForPass = Math.Max(1, pkg.Evidences.Count / 2);

            }

        }



        /// <summary>

        /// Đồng bộ trạng thái tập tin dựa trên tập RestoredFileIds của GameState

        /// </summary>

        public void SyncFileStates(GameState state)

        {

            if (CurrentPackage.Files == null) return;

            foreach (var file in CurrentPackage.Files)

            {

                if (state.RestoredFileIds.Contains(file.Id))

                {

                    file.IsDeleted = false;

                    file.Folder = file.OriginalFolder;

                }

                else

                {

                    file.IsDeleted = file.InitialIsDeleted;

                    file.Folder = !string.IsNullOrEmpty(file.InitialFolder) ? file.InitialFolder : file.Folder;

                }

            }

        }



        /// <summary>

        /// Chuyển đổi ngữ cảnh sang vụ án được chỉ định theo CaseId

        /// </summary>

        public bool SwitchCase(string caseId)

        {

            var target = AvailableCases.Find(c => c.CaseId.Equals(caseId, StringComparison.OrdinalIgnoreCase));

            if (target != null)

            {

                CurrentPackage = target;

                return true;

            }

            return false;

        }



        /// <summary>

        /// Nạp và đăng ký một màn chơi mới từ chuỗi JSON bên ngoài (External Case Importer)

        /// </summary>

        public bool ImportCaseFromJson(string json, out string message)

        {

            try

            {

                var pkg = JsonSerializer.Deserialize<CasePackage>(json, JsonOptions);

                if (pkg == null || string.IsNullOrEmpty(pkg.CaseId) || string.IsNullOrEmpty(pkg.Title))

                {

                    message = "File JSON không hợp lệ hoặc thiếu thông tin CaseId/Title bắt buộc.";

                    return false;

                }



                InitPackageDefaults(pkg);



                // Kiểm tra trùng lặp để thực hiện Replace hoặc Append

                int idx = AvailableCases.FindIndex(c => c.CaseId.Equals(pkg.CaseId, StringComparison.OrdinalIgnoreCase));

                if (idx >= 0)

                {

                    AvailableCases[idx] = pkg;

                }

                else

                {

                    AvailableCases.Add(pkg);

                }



                // Lưu tệp vật lý xuống thư mục Data/Cases để tái sử dụng lâu dài

                string casesDir = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Cases");

                Directory.CreateDirectory(casesDir);

                string cleanId = pkg.CaseId.Replace("#", "").Replace(" ", "_").ToLower();

                string savePath = Path.Combine(casesDir, $"{cleanId}.json");

                File.WriteAllText(savePath, json);



                CurrentPackage = pkg;

                message = $"Đã nạp màn chơi '{pkg.CaseId}: {pkg.Title}' thành công!";

                return true;

            }

            catch (Exception ex)

            {

                message = $"Lỗi phân tích cú pháp JSON: {ex.Message}";

                return false;

            }

        }



        /// <summary>

        /// Thuật toán đánh giá kết quả điều tra và phân nhánh 5 kết thúc (Decision Tree Logic)

        /// </summary>

        public InvestigationResult EvaluateCase(

            GameState state,

            string suspectId,

            string motive,

            string method,

            List<string> selectedEvidences)

        {

            int discoveredCount = state.DiscoveredEvidenceIds.Count;

            int connectedCount = state.ConnectedEvidencePairs.Count;



            // Nhánh 1: Kiểm tra ngưỡng thu thập bằng chứng tối thiểu (Min Evidence Threshold Check)

            int minPass = CurrentPackage.MinEvidenceForPass > 0 ? CurrentPackage.MinEvidenceForPass : Math.Max(1, CurrentPackage.Evidences.Count / 2);

            if (discoveredCount < minPass)

            {

                return new InvestigationResult

                {

                    EndingType = EndingType.IncompleteInvestigation,

                    Title = "ENDING 4: ĐIỀU TRA DANG DỞ",

                    Description = $"Bạn nộp báo cáo khi mới thu thập được {discoveredCount} bằng chứng (yêu cầu tối thiểu {minPass}). Cảnh sát và viện kiểm sát bác bỏ báo cáo vì hồ sơ quá sơ sài. Vụ án bị đình chỉ và kẻ thủ ác vẫn nhởn nhơ ngoài vòng pháp luật!",

                    Score = 20

                };

            }



            // Nhánh 2: Kiểm tra định danh nghi phạm (Suspect Identity Verification)

            if (!suspectId.Equals(CurrentPackage.CorrectSuspectId, StringComparison.OrdinalIgnoreCase))

            {

                var correctSuspect = Suspects.Find(s => s.Id == CurrentPackage.CorrectSuspectId);

                string culpritName = correctSuspect?.Name ?? "Thủ phạm thực sự";

                return new InvestigationResult

                {

                    EndingType = EndingType.WrongSuspect,

                    Title = "ENDING 2: BẮT SAI NGHI PHẠM",

                    Description = $"Bạn đã cáo buộc sai người! Người bị bạn nêu tên có chứng cứ ngoại phạm xác thực. Trong khi đó, {culpritName} đã kịp tẩu thoát cùng tài liệu bị đánh cắp!",

                    Score = 35

                };

            }



            // Nhánh 3: Kiểm tra các bằng chứng cốt lõi đính kèm trong báo cáo (Required Core Evidences Verification)

            bool hasRequired = true;

            if (CurrentPackage.RequiredEvidenceIds != null && CurrentPackage.RequiredEvidenceIds.Count > 0)

            {

                foreach (var req in CurrentPackage.RequiredEvidenceIds)

                {

                    if (!selectedEvidences.Contains(req))

                    {

                        hasRequired = false;

                        break;

                    }

                }

            }



            if (!hasRequired)

            {

                return new InvestigationResult

                {

                    EndingType = EndingType.InsufficientEvidence,

                    Title = "ENDING 3: THIẾU BẰNG CHỨNG THUYẾT PHỤC",

                    Description = "Bạn đoán đúng danh tính thủ phạm, nhưng tại phiên tòa luật sư biện hộ đã bác bỏ cáo buộc vì bạn chưa đính kèm đủ các bằng chứng vật chứng cốt lõi. Tòa tuyên trả tự do cho nghi phạm do thiếu chứng cứ!",

                    Score = 60

                };

            }



            // Nhánh 3b: Kiểm tra động cơ và phương thức gây án (Motive & Method Reasoning Verification)

            bool correctMotive = string.IsNullOrEmpty(CurrentPackage.CorrectMotive) ||

                                 motive.Trim().Equals(CurrentPackage.CorrectMotive.Trim(), StringComparison.OrdinalIgnoreCase);

            bool correctMethod = string.IsNullOrEmpty(CurrentPackage.CorrectMethod) ||

                                 method.Trim().Equals(CurrentPackage.CorrectMethod.Trim(), StringComparison.OrdinalIgnoreCase);



            if (!correctMotive || !correctMethod)

            {

                return new InvestigationResult

                {

                    EndingType = EndingType.InsufficientEvidence,

                    Title = "ENDING 3: LẬP LUẬN THIẾU THUYẾT PHỤC",

                    Description = "Bạn đã chỉ ra đúng thủ phạm và đính kèm bằng chứng, nhưng nhận định sai về động cơ hoặc thủ đoạn gây án. Viện kiểm sát yêu cầu củng cố lại lập luận trước khi đưa vụ án ra xét xử!",

                    Score = 55

                };

            }



            // Nhánh 4: Kịch bản ẩn nâng cao (The Bigger Case / Comprehensive Mastery Ending)

            int totalPossible = CurrentPackage.Evidences.Count > 0 ? CurrentPackage.Evidences.Count : 6;

            int requiredConnections = Math.Min(2, CurrentPackage.ConnectionRules.Count);

            if (discoveredCount >= totalPossible - 1 && (requiredConnections == 0 || connectedCount >= requiredConnections))

            {

                return new InvestigationResult

                {

                    EndingType = EndingType.TheBiggerCase,

                    Title = "ENDING 5: ĐẠI ÁN GIÁN ĐIỆP (THE BIGGER CASE)",

                    Description = $"XUẤT SẮC TUYỆT ĐỐI! Bạn đã vạch trần toàn bộ âm mưu trong vụ án '{CurrentPackage.Title}'. Bạn phát hiện toàn bộ mắt xích giao dịch ngầm, dòng tiền chuyển khoản và xóa vết tinh vi. Ban giám đốc và cơ quan an ninh trao tặng bạn Huy chương Thám tử Danh dự!",

                    Score = 100

                };

            }



            // Nhánh 5: Kịch bản phá án thành công chuẩn (Standard Successful Resolution)

            return new InvestigationResult

            {

                EndingType = EndingType.CorrectDetective,

                Title = "ENDING 1: THÁM TỬ XUẤT SẮC (CORRECT DETECTIVE)",

                Description = $"XUẤT SẮC! Báo cáo điều tra của bạn sắc bén và thuyết phục. Thủ phạm đã phải cúi đầu nhận tội trước chuỗi bằng chứng đanh thép. Tập tin quan trọng '{CurrentPackage.MissingFileName}' đã được khôi phục nguyên vẹn!",

                Score = 85

            };

        }

    }



    /// <summary>

    /// Kiểu liệt kê các kịch bản kết thúc của vụ án (Multiple Ending Enumeration)

    /// </summary>

    public enum EndingType

    {

        CorrectDetective,

        WrongSuspect,

        InsufficientEvidence,

        IncompleteInvestigation,

        TheBiggerCase

    }



    /// <summary>

    /// Đối tượng đóng gói kết quả thẩm định báo cáo điều tra (Investigation Evaluation Result DTO)

    /// </summary>

    public class InvestigationResult

    {

        public EndingType EndingType { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Score { get; set; } = 0;

    }

}


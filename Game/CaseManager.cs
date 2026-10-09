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

        private void InitPackageDefaults(CasePackage pkg)
        {
            InitPackageFileDefaults(pkg);
            InitPackageNotesDefaults(pkg);
        }

        private void InitPackageFileDefaults(CasePackage pkg)
        {
            if (pkg.Files == null) return;
            foreach (var file in pkg.Files)
            {
                file.InitialIsDeleted = file.IsDeleted;
                file.InitialFolder = file.Folder;
            }
        }

        private void InitPackageNotesDefaults(CasePackage pkg)
        {
            if (pkg.Notes == null) pkg.Notes = new List<NoteItem>();
            if (pkg.Notes.Count > 0) return;

            string id = pkg.CaseId.ToLowerInvariant();
            if (id.Contains("001") || id.Contains("1"))
            {
                // Vụ án 1: The Missing File (David Miller ghi chú công việc trước khi bị tấn công)
                pkg.Notes.Add(new NoteItem
                {
                    Id = "NOTE_01",
                    Title = "📌 Việc cần làm trước khi về (05/10)",
                    Author = "David Miller (Senior Project Manager)",
                    Date = "2026-10-05 17:30",
                    Category = "Sticky Note",
                    EvidenceId = "E009",
                    Content = 
                        "TO-DO TRƯỚC KHI VỀ:\n" +
                        "────────────────────────────────────────\n" +
                        "1. Kiểm tra tiến độ mã hóa file Project_Nexus_Core.enc trước hạn chót 22:00.\n" +
                        "2. Đợi Elena ghé trả lại chiếc USB Kingston màu xanh (bữa mượn sao chép slide QA).\n" +
                        "3. Mua bánh sandwich ở canteen tầng 1 trước 21:30.\n" +
                        "4. Khóa cửa phòng làm việc cẩn thận trước khi ra về."
                });

                pkg.Notes.Add(new NoteItem
                {
                    Id = "NOTE_02",
                    Title = "☕ Lời nhắn & Việc nhà",
                    Author = "David Miller",
                    Date = "2026-10-05 14:00",
                    Category = "Cá nhân",
                    EvidenceId = null,
                    Content =
                        "LỜI NHẮN:\n" +
                        "────────────────────────────────────────\n" +
                        "• Vợ dặn tối nay về sớm trước 22:30 đón con.\n" +
                        "• Bác bảo vệ nhắc xe máy để nhầm khu vực B2.\n" +
                        "• Đợt đánh giá quý tới: Đề xuất tăng phụ cấp cho nhóm QA của Sarah và Elena."
                });

                // Đảm bảo E009 có trong danh mục bằng chứng của vụ án
                if (!pkg.Evidences.Exists(e => e.Id == "E009"))
                {
                    pkg.Evidences.Add(new Evidence
                    {
                        Id = "E009",
                        Name = "Sticky Note - Lời nhắc trả USB của David Miller",
                        Description = "Mẩu giấy việc cần làm dán trên màn hình David Miller: ghi lại việc Elena Rostova đang giữ chiếc USB Kingston của phòng lab.",
                        Source = "Sticky Notes",
                        Importance = "Critical",
                        Timestamp = "17:30"
                    });
                }

                // Thêm mốc Timeline 17:30 nếu chưa có
                var t009 = pkg.Timeline.Find(t => t.EvidenceId == "E009");
                if (t009 != null)
                {
                    t009.Time = "17:30";
                    t009.EventDescription = "David Miller dán mẩu giấy to-do nhắc nhở việc Elena đang giữ chiếc USB Kingston.";
                }
                else
                {
                    pkg.Timeline.Insert(0, new TimelineEntry
                    {
                        Time = "17:30",
                        EventDescription = "David Miller dán mẩu giấy to-do nhắc nhở việc Elena đang giữ chiếc USB Kingston.",
                        EvidenceId = "E009"
                    });
                }

                // Thêm luật suy luận Timeline giữa E009 và E004 (USB Kingston)
                if (!pkg.ConnectionRules.Exists(r => (r.EvidenceA == "E009" && r.EvidenceB == "E004") || (r.EvidenceA == "E004" && r.EvidenceB == "E009")))
                {
                    pkg.ConnectionRules.Add(new EvidenceConnectionRule
                    {
                        EvidenceA = "E009",
                        EvidenceB = "E004",
                        SuccessMessage = "CHÍNH XÁC: Chiếc USB Kingston cắm vào máy lúc 21:45 chính là chiếc USB mà David ghi chú Elena đang giữ!",
                        NotificationText = "[KẾT NỐI TIMELINE] Mẩu giấy ghi chú lúc 17:30 xác nhận Elena giữ chiếc USB Kingston, vạch trần kẻ cắm USB sao chép file lúc 21:45!"
                    });
                }
            }
            else if (id.Contains("002") || id.Contains("2"))
            {
                // Vụ án 2: The Ransomware Attack (Robert Vance bàn giao công việc trước kỳ nghỉ cuối tuần)
                pkg.Notes.Add(new NoteItem
                {
                    Id = "NOTE_101",
                    Title = "📌 Bàn giao trực cuối tuần",
                    Author = "Robert Vance (Chief Accountant)",
                    Date = "2026-10-10 17:15",
                    Category = "Sticky Note",
                    EvidenceId = "E109",
                    Content =
                        "LƯU Ý CUỐI TUẦN:\n" +
                        "────────────────────────────────────────\n" +
                        "• Kevin Shaw (IT) có qua xin cấp tài khoản VPN máy chủ kế toán để 'chạy bảo trì bản vá định kỳ đêm Chủ nhật'.\n" +
                        "• Đã cấp credential tạm thời cho Kevin, hạn chót đến 06:00 sáng Thứ Hai.\n" +
                        "• Sáng Thứ Hai nhớ đổi lại mật khẩu root máy chủ và thu hồi quyền VPN của Kevin.\n" +
                        "• Nhớ tắt điều hòa phòng làm việc."
                });

                pkg.Notes.Add(new NoteItem
                {
                    Id = "NOTE_102",
                    Title = "📋 Danh mục chứng từ cần quyết toán",
                    Author = "Robert Vance",
                    Date = "2026-10-09 11:30",
                    Category = "Tài chính",
                    EvidenceId = null,
                    Content =
                        "QUYẾT TOÁN THUẾ QUÝ 3:\n" +
                        "────────────────────────────────────────\n" +
                        "1. Rà soát hóa đơn tiếp khách phòng Marketing.\n" +
                        "2. Nhắc bên ngân hàng gửi sao kê tài khoản doanh nghiệp.\n" +
                        "3. Lịch hẹn nha sĩ vào chiều Thứ Ba."
                });

                if (!pkg.Evidences.Exists(e => e.Id == "E109"))
                {
                    pkg.Evidences.Add(new Evidence
                    {
                        Id = "E109",
                        Name = "Sticky Note - Bút tích cấp quyền VPN cuối tuần của Robert Vance",
                        Description = "Ghi chú bàn giao công việc của Kế toán trưởng: ghi lại việc đã cấp quyền truy cập VPN máy chủ kế toán cho quản trị viên Kevin Shaw sử dụng trong kỳ nghỉ cuối tuần.",
                        Source = "Sticky Notes",
                        Importance = "Critical",
                        Timestamp = "17:15"
                    });
                }

                // Thêm luật kết nối giữa E109 và E104 (VPN ngoài giờ)
                if (!pkg.ConnectionRules.Exists(r => (r.EvidenceA == "E109" && r.EvidenceB == "E104") || (r.EvidenceA == "E104" && r.EvidenceB == "E109")))
                {
                    pkg.ConnectionRules.Add(new EvidenceConnectionRule
                    {
                        EvidenceA = "E109",
                        EvidenceB = "E104",
                        SuccessMessage = "CHÍNH XÁC: Phiên kết nối VPN lúc 02:15 sáng sử dụng chính tài khoản mà Robert đã ghi chú cấp tạm cho Kevin Shaw mượn!",
                        NotificationText = "[KẾT NỐI TIMELINE] Ghi chú bàn giao xác nhận Kevin Shaw được cấp quyền VPN cuối tuần, vạch trần kẻ kết nối từ xa lúc 02:15 để phát tán ransomware!"
                    });
                }
            }
            else if (id.Contains("003") || id.Contains("3"))
            {
                // Vụ án 3: The Ghost in the System (Dr. Evelyn Reed ghi chép quan sát phòng lab AI)
                pkg.Notes.Add(new NoteItem
                {
                    Id = "NOTE_201",
                    Title = "📌 Việc cần kiểm tra phòng lab AI",
                    Author = "Dr. Evelyn Reed (Head of AI Research)",
                    Date = "2026-10-19 16:45",
                    Category = "Sticky Note",
                    EvidenceId = "E209",
                    Content =
                        "GHI CHÚ LAB AI:\n" +
                        "────────────────────────────────────────\n" +
                        "• Samuel Drake dạo này liên tục gặng hỏi về cấu trúc file checkpoint Genesis-70B và cách bypass SSH nội bộ.\n" +
                        "• Samuel mượn thẻ ra vào phòng Server Vault với lý do 'kiểm tra nhiệt độ rack máy chủ', sáng mai nhớ đòi lại thẻ!\n" +
                        "• Nhắc cả nhóm: Tuyệt đối không lưu SSH key cá nhân trên máy trạm chung!"
                });

                pkg.Notes.Add(new NoteItem
                {
                    Id = "NOTE_202",
                    Title = "🧪 Tiến độ huấn luyện mô hình Genesis",
                    Author = "Dr. Evelyn Reed",
                    Date = "2026-10-18 10:00",
                    Category = "Nghiên cứu",
                    EvidenceId = null,
                    Content =
                        "EXPERIMENT LOG:\n" +
                        "────────────────────────────────────────\n" +
                        "• Epoch 42: Hàm mất mát (Loss) đã hội tụ về 0.82.\n" +
                        "• Dự kiến nộp bản thảo bài báo khoa học cho hội nghị AI tháng 12.\n" +
                        "• Nhớ mua thêm cà phê hạt cho máy pha ở phòng sinh hoạt chung."
                });

                if (!pkg.Evidences.Exists(e => e.Id == "E209"))
                {
                    pkg.Evidences.Add(new Evidence
                    {
                        Id = "E209",
                        Name = "Sticky Note - Ghi chú nhắc nhở của Dr. Evelyn về Samuel",
                        Description = "Mẩu giấy dán tại bàn làm việc của Dr. Evelyn: ghi lại việc Samuel Drake mượn thẻ vào phòng Server Vault và liên tục tò mò về cấu trúc file checkpoint AI.",
                        Source = "Sticky Notes",
                        Importance = "Critical",
                        Timestamp = "16:45"
                    });
                }

                // Thêm luật kết nối giữa E209 và E205 (Nhật ký cửa Server Vault)
                if (!pkg.ConnectionRules.Exists(r => (r.EvidenceA == "E209" && r.EvidenceB == "E205") || (r.EvidenceA == "E205" && r.EvidenceB == "E209")))
                {
                    pkg.ConnectionRules.Add(new EvidenceConnectionRule
                    {
                        EvidenceA = "E209",
                        EvidenceB = "E205",
                        SuccessMessage = "CHÍNH XÁC: Thẻ nhân viên quét mở phòng Server lúc 02:55 chính là chiếc thẻ mà Dr. Evelyn đã ghi chú cho Samuel Drake mượn!",
                        NotificationText = "[KẾT NỐI TIMELINE] Ghi chú của Dr. Evelyn xác nhận Samuel Drake giữ thẻ mở Server Vault, chứng minh Samuel đã trực tiếp đột nhập phòng máy chủ!"
                    });
                }
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
            int minPass = Math.Max(CurrentPackage.MinEvidenceForPass, 3);
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
            int totalPossible = CurrentPackage.Evidences.Count > 0 ? CurrentPackage.Evidences.Count : 8;
            if (discoveredCount >= totalPossible - 1 && connectedCount >= 2)
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

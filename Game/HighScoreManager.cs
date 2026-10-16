using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _2611_WIN_B3.Game
{
    public class HighScoreEntry
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string DetectiveName { get; set; } = "Thám tử";
        public string CaseId { get; set; } = string.Empty;
        public string CaseTitle { get; set; } = string.Empty;
        public string EndingTitle { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public int ElapsedSeconds { get; set; } = 0;
        public int EvidenceFound { get; set; } = 0;
        public int TotalEvidences { get; set; } = 0;
        public int TimelineLinks { get; set; } = 0;
        public string Rank { get; set; } = "B";

        public string TimeFormatted
        {
            get
            {
                var ts = TimeSpan.FromSeconds(ElapsedSeconds);
                return ts.TotalHours >= 1 ? ts.ToString(@"hh\:mm\:ss") : ts.ToString(@"mm\:ss");
            }
        }

        public static string CalculateRank(int score, int elapsedSeconds)
        {
            if (score >= 100)
            {
                return elapsedSeconds <= 300 ? "S+ (Thiên tài)" : "S (Xuất sắc)";
            }
            if (score >= 85) return "A (Giỏi)";
            if (score >= 60) return "B (Khá)";
            if (score >= 40) return "C (Trung bình)";
            return "F (Chưa đạt)";
        }
    }

    /// <summary>
    /// Quản lý lưu trữ và nạp bảng vàng thành tích (High Scores) qua tập tin văn bản thuần TXT.
    /// File được đồng bộ giữa thư mục ứng dụng và thư mục gốc của đồ án để tiện xem trực tiếp.
    /// </summary>
    public static class HighScoreManager
    {
        public const string FileName = "highscores.txt";

        private static string? GetProjectRootFilePath()
        {
            string[] candidateRootDirs = new[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".."),
                Directory.GetCurrentDirectory()
            };

            foreach (var dir in candidateRootDirs)
            {
                try
                {
                    string fullDir = Path.GetFullPath(dir);
                    if (Directory.Exists(fullDir))
                    {
                        if (Directory.GetFiles(fullDir, "*.csproj").Length > 0 || Directory.Exists(Path.Combine(fullDir, "Data")))
                        {
                            return Path.Combine(fullDir, FileName);
                        }
                    }
                }
                catch { }
            }

            return null;
        }

        public static string GetFilePath()
        {
            // Ưu tiên đường dẫn tương đối (relative path) tại thư mục làm việc hiện tại hoặc project root
            string[] candidatePaths = new[]
            {
                FileName,
                Path.Combine(Directory.GetCurrentDirectory(), FileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", FileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", FileName)
            };

            foreach (var path in candidatePaths)
            {
                try
                {
                    if (File.Exists(path)) return path;
                }
                catch { }
            }

            return Path.Combine(Directory.GetCurrentDirectory(), FileName);
        }

        /// <summary>
        /// Ghi thêm một kỷ lục phá án mới vào file TXT
        /// </summary>
        public static void SaveScore(HighScoreEntry entry)
        {
            try
            {
                string targetPath = GetFilePath();
                var sb = new StringBuilder();

                // Nếu file chưa tồn tại thì tạo phần mở đầu trang trọng
                if (!File.Exists(targetPath) || new FileInfo(targetPath).Length == 0)
                {
                    sb.AppendLine("========================================================================================================");
                    sb.AppendLine("                                BẢNG VÀNG THÀNH TÍCH PHÁ ÁN (DETECTIVE HIGH SCORES)                      ");
                    sb.AppendLine("========================================================================================================");
                    sb.AppendLine("Hệ thống tự động ghi nhận các kết quả điều tra, thời gian phá án và điểm số của các thám tử.");
                    sb.AppendLine("--------------------------------------------------------------------------------------------------------");
                }

                sb.AppendLine();
                sb.AppendLine("[RECORD]");
                sb.AppendLine($"Date: {entry.Date:yyyy-MM-dd HH:mm:ss}");
                sb.AppendLine($"Detective: {entry.DetectiveName}");
                sb.AppendLine($"CaseId: {entry.CaseId}");
                sb.AppendLine($"CaseTitle: {entry.CaseTitle}");
                sb.AppendLine($"Ending: {entry.EndingTitle}");
                sb.AppendLine($"Score: {entry.Score}");
                sb.AppendLine($"ElapsedSeconds: {entry.ElapsedSeconds}");
                sb.AppendLine($"Time: {entry.TimeFormatted}");
                sb.AppendLine($"Evidences: {entry.EvidenceFound}/{entry.TotalEvidences}");
                sb.AppendLine($"TimelineLinks: {entry.TimelineLinks}");
                sb.AppendLine($"Rank: {entry.Rank}");
                sb.AppendLine("--------------------------------------------------------------------------------------------------------");

                File.AppendAllText(targetPath, sb.ToString(), Encoding.UTF8);

                // Đồng bộ sang thư mục gốc project nếu đang chạy trong bin
                try
                {
                    string? rootPath = GetProjectRootFilePath();
                    if (!string.IsNullOrEmpty(rootPath))
                    {
                        string fullRoot = Path.GetFullPath(rootPath);
                        string fullTarget = Path.GetFullPath(targetPath);
                        if (!fullRoot.Equals(fullTarget, StringComparison.OrdinalIgnoreCase))
                        {
                            File.WriteAllText(fullRoot, File.ReadAllText(targetPath, Encoding.UTF8), Encoding.UTF8);
                        }
                    }
                }
                catch { }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi ghi file highscores: " + ex.Message);
            }
        }

        /// <summary>
        /// Đọc toàn bộ danh sách thành tích từ file TXT và sắp xếp theo Điểm (giảm dần) -> Thời gian (tăng dần)
        /// </summary>
        public static List<HighScoreEntry> LoadScores()
        {
            var list = new List<HighScoreEntry>();
            string targetPath = GetFilePath();

            if (!File.Exists(targetPath)) return list;

            try
            {
                string[] lines = File.ReadAllLines(targetPath, Encoding.UTF8);
                HighScoreEntry? current = null;

                foreach (string rawLine in lines)
                {
                    string line = rawLine.Trim();
                    if (line.Equals("[RECORD]", StringComparison.OrdinalIgnoreCase))
                    {
                        if (current != null) list.Add(current);
                        current = new HighScoreEntry();
                        continue;
                    }

                    if (current == null) continue;

                    int colonIdx = line.IndexOf(':');
                    if (colonIdx <= 0) continue;

                    string key = line.Substring(0, colonIdx).Trim();
                    string val = line.Substring(colonIdx + 1).Trim();

                    switch (key.ToLowerInvariant())
                    {
                        case "date":
                            if (DateTime.TryParse(val, out var dt)) current.Date = dt;
                            break;
                        case "detective":
                            current.DetectiveName = val;
                            break;
                        case "caseid":
                            current.CaseId = val;
                            break;
                        case "casetitle":
                            current.CaseTitle = val;
                            break;
                        case "ending":
                            current.EndingTitle = val;
                            break;
                        case "score":
                            if (int.TryParse(val, out var score)) current.Score = score;
                            break;
                        case "elapsedseconds":
                            if (int.TryParse(val, out var secs)) current.ElapsedSeconds = secs;
                            break;
                        case "evidences":
                            var parts = val.Split('/');
                            if (parts.Length == 2 && int.TryParse(parts[0], out var found) && int.TryParse(parts[1], out var total))
                            {
                                current.EvidenceFound = found;
                                current.TotalEvidences = total;
                            }
                            break;
                        case "timelinelinks":
                            if (int.TryParse(val, out var links)) current.TimelineLinks = links;
                            break;
                        case "rank":
                            current.Rank = val;
                            break;
                    }
                }

                if (current != null) list.Add(current);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi đọc highscores.txt: " + ex.Message);
            }

            // Sắp xếp: Điểm số cao nhất lên trước, cùng điểm thì thời gian ít hơn (nhanh hơn) lên trước
            return list.OrderByDescending(x => x.Score)
                       .ThenBy(x => x.ElapsedSeconds)
                       .ThenByDescending(x => x.Date)
                       .ToList();
        }

        /// <summary>
        /// Mở trực tiếp file highscores.txt bằng ứng dụng mặc định (Notepad)
        /// </summary>
        public static bool OpenFileInEditor(out string message)
        {
            string path = GetFilePath();
            if (!File.Exists(path))
            {
                // Tạo file mẫu nếu chưa có
                File.WriteAllText(path, 
                    "========================================================================================================\r\n" +
                    "                                BẢNG VÀNG THÀNH TÍCH PHÁ ÁN (DETECTIVE HIGH SCORES)                      \r\n" +
                    "========================================================================================================\r\n" +
                    "Chưa có bản ghi thành tích nào. Hãy hoàn thành điều tra và nộp Case Report để ghi danh!\r\n", 
                    Encoding.UTF8);
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
                message = "Đã mở file highscores.txt";
                return true;
            }
            catch (Exception ex)
            {
                message = "Không thể mở file: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa toàn bộ lịch sử thành tích
        /// </summary>
        public static void ClearScores()
        {
            string path = GetFilePath();
            try
            {
                if (File.Exists(path)) File.Delete(path);
                string? root = GetProjectRootFilePath();
                if (!string.IsNullOrEmpty(root) && File.Exists(root)) File.Delete(root);
            }
            catch { }
        }
    }
}


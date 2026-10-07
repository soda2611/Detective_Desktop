using System;
using System.IO;
using System.Text.Json;

namespace _2611_WIN_B3.Game
{
    /// <summary>
    /// Lớp quản trị tệp tin và cơ chế tuần tự hóa dữ liệu (Serialization / Deserialization Manager).
    /// Chịu trách nhiệm ghi/đọc dữ liệu tiến trình điều tra ra định dạng JSON (JSON Persistence).
    /// </summary>
    public class SaveManager
    {
        public const string LogFileName = "gamelog.json";
        public const string ManualSaveFileName = "savegame.json";

        // Tối ưu hóa cấu hình JSON Serializer: Indented Format & Case-Insensitive Mapping
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Tuần tự hóa đối tượng GameState và ghi đè đồng bộ xuống tệp nhật ký gamelog.json (Auto-Save Pipeline)
        /// </summary>
        /// <param name="state">Đối tượng trạng thái điều tra cần lưu</param>
        /// <returns>True nếu thao tác I/O thành công, False nếu bắt ngoại lệ</returns>
        public static bool AutoSave(GameState state)
        {
            try
            {
                string json = JsonSerializer.Serialize(state, JsonOptions);
                File.WriteAllText(LogFileName, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Giải tuần tự hóa (Deserialize) trạng thái từ tệp gamelog.json (State Recovery Pipeline)
        /// </summary>
        /// <param name="message">Thông điệp phản hồi kết quả truy xuất</param>
        /// <returns>Đối tượng GameState đã được phục hồi hoặc null nếu tệp không tồn tại/lỗi cú pháp</returns>
        public static GameState? LoadLog(out string message)
        {
            try
            {
                if (!File.Exists(LogFileName))
                {
                    message = "File gamelog.json không tồn tại.";
                    return null;
                }

                string json = File.ReadAllText(LogFileName);
                var state = JsonSerializer.Deserialize<GameState>(json, JsonOptions);
                if (state != null)
                {
                    message = "Đã khôi phục tiến trình từ gamelog.json thành công!";
                    return state;
                }

                message = "File gamelog.json bị lỗi định dạng cấu trúc JSON.";
                return null;
            }
            catch (Exception ex)
            {
                message = $"Ngoại lệ khi giải tuần tự hóa gamelog.json: {ex.Message}";
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra tính hiện hữu của tệp log trên hệ thống tệp tin cục bộ (File Existence Probe)
        /// </summary>
        public static bool LogExists() => File.Exists(LogFileName);

        /// <summary>
        /// Xóa tệp log để phục vụ cơ chế thiết lập lại trò chơi (Cache Eviction / File Deletion)
        /// </summary>
        public static bool DeleteLog()
        {
            try
            {
                if (File.Exists(LogFileName))
                {
                    File.Delete(LogFileName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lưu trạng thái thủ công (Snapshot Persistence) theo yêu cầu người dùng vào savegame.json
        /// </summary>
        public static bool Save(GameState state, out string message)
        {
            try
            {
                string json = JsonSerializer.Serialize(state, JsonOptions);
                File.WriteAllText(ManualSaveFileName, json);
                message = "Tiến trình điều tra đã được lưu thành công vào savegame.json!";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi I/O khi lưu tệp savegame.json: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Nạp trạng thái thủ công (Manual Snapshot Restore) từ savegame.json
        /// </summary>
        public static GameState? Load(out string message)
        {
            try
            {
                if (!File.Exists(ManualSaveFileName))
                {
                    message = "Chưa tìm thấy tệp lưu savegame.json nào.";
                    return null;
                }

                string json = File.ReadAllText(ManualSaveFileName);
                var state = JsonSerializer.Deserialize<GameState>(json, JsonOptions);
                if (state != null)
                {
                    message = "Tải tiến trình từ tệp lưu savegame.json thành công!";
                    return state;
                }

                message = "Tệp savegame.json bị hỏng hoặc cấu trúc không tương thích.";
                return null;
            }
            catch (Exception ex)
            {
                message = $"Ngoại lệ I/O khi đọc tệp savegame.json: {ex.Message}";
                return null;
            }
        }
    }
}


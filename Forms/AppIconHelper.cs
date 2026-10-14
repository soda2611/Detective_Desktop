using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _2611_WIN_B3.Forms
{
    /// <summary>
    /// Tiện ích hỗ trợ quản lý và gán biểu tượng (Icon) đồng bộ cho các Form từ img/logo.png.
    /// </summary>
    public static class AppIconHelper
    {
        private static Icon? _cachedAppIcon;
        private static readonly object _lock = new object();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        /// <summary>
        /// Lấy đối tượng Icon chuẩn của ứng dụng từ file ảnh logo.png duy nhất trong thư mục img/.
        /// </summary>
        public static Icon? GetAppIcon()
        {
            if (_cachedAppIcon != null)
                return _cachedAppIcon;

            lock (_lock)
            {
                if (_cachedAppIcon != null)
                    return _cachedAppIcon;

                try
                {
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string projectDir = Directory.GetCurrentDirectory();

                    string[] candidatePaths = new[]
                    {
                        Path.Combine(baseDir, "img", "logo.png"),
                        Path.Combine(projectDir, "img", "logo.png"),
                        Path.Combine(baseDir, "logo.png"),
                        Path.Combine(projectDir, "logo.png")
                    };

                    foreach (var path in candidatePaths)
                    {
                        if (File.Exists(path))
                        {
                            using var bmp = new Bitmap(path);
                            IntPtr hIcon = bmp.GetHicon();
                            try
                            {
                                using var tempIcon = Icon.FromHandle(hIcon);
                                _cachedAppIcon = (Icon)tempIcon.Clone();
                                return _cachedAppIcon;
                            }
                            finally
                            {
                                DestroyIcon(hIcon);
                            }
                        }
                    }

                    // Fallback nếu không tìm thấy file logo.png
                    string exePath = Environment.ProcessPath ?? Application.ExecutablePath;
                    if (File.Exists(exePath))
                    {
                        _cachedAppIcon = Icon.ExtractAssociatedIcon(exePath);
                    }
                }
                catch
                {
                    // Tránh crash ứng dụng nếu gặp giới hạn đồ họa GDI+
                }

                return _cachedAppIcon;
            }
        }

        /// <summary>
        /// Gán icon đồng bộ cho Form.
        /// </summary>
        public static void ApplyTo(Form form)
        {
            if (form == null || form.IsDisposed) return;

            try
            {
                var icon = GetAppIcon();
                if (icon != null)
                {
                    form.Icon = icon;
                    form.ShowIcon = true;
                }
            }
            catch { }
        }
    }
}


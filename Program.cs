namespace _2611_WIN_B3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                Application.Run(new Form1());
            }
            finally
            {
                try
                {
                    _2611_WIN_B3.Game.AudioManager.Instance.Shutdown();
                    _2611_WIN_B3.Game.GameManager.Instance.Dispose();
                }
                catch { }

                // Đảm bảo toàn bộ luồng nền và handles hệ điều hành được đóng hoàn toàn
                Environment.Exit(0);
            }
        }
    }
}
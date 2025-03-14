using System;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo thư viện sử dụng Singleton pattern
            Library.Instance.Initialize();

            // Hiển thị form chính
            Application.Run(new MainForm());
        }
    }
}
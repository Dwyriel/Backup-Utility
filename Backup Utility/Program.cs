using System;
using System.Windows.Forms;

namespace Backup_Utility
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            catch (Exception e)
            {
                string errorText = "Something went wrong, make sure the program is outside of " + '"' + "Program Files" + '"' + " folder and its subfolders or run the program as an Administrator.";
                ErrorLogger.ShowErrorTextWithExceptionMessage(errorText, e);
            }
        }
    }
}

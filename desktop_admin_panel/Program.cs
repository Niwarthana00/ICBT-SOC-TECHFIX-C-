using System;
using System.Windows.Forms;

namespace desktop_admin_panel
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with the loading form
            Application.Run(new loading());
        }
    }
}

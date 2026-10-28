using System;
using System.Net;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // show any error we missed as a message instead of crashing
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) => ErrorHelper.Show(e.Exception);

            // openlibrary.org needs TLS 1.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}

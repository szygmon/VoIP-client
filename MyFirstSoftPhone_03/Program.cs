using System;
using System.Windows.Forms;

namespace VoIPclient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoginForm lf = new LoginForm();
            Application.Run(lf);
        }
    }
}

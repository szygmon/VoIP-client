using System;
using System.Windows.Forms;

namespace MyFirstSoftPhone_03
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
            
            string username = lf.username;
            string password = lf.pass;
            string server = lf.server;

            MainForm mf = new MainForm(server, username, password);
            Application.Run(mf);
        }
    }
}

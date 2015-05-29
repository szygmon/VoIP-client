using System;
using System.Windows.Forms;

namespace MyFirstSoftPhone_03
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
            //Application.Run(new MainForm("101", "101"));
            
            //Login:
            LoginForm lf = new LoginForm();
            Application.Run(lf);
            
            //Get the login info
            string username = lf.username;
            string password = lf.pass;

            MainForm mf = new MainForm(username, password);
            Application.Run(mf);

            //goto Login;
        }
    }
}

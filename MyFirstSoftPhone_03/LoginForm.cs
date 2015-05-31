using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFirstSoftPhone_03
{
    public partial class LoginForm : Form
    {
        public string username;
        public string pass;
        public string server;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.username = tb_username.Text;
            this.pass = tb_pass.Text;
            this.server = tb_server.Text;
            this.Close();
        }

        private void tb_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_login_Click(sender, e);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}

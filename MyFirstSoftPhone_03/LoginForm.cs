using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace VoIPclient
{
    public partial class LoginForm : Form
    {
        public string username;
        public string pass;
        public string server;
        byte[] salt;
        HMACMD5 hmacMD5;
        public LoginForm()
        {
            salt = System.Text.Encoding.UTF8.GetBytes("VoIP_SM0x01");
            hmacMD5 = new HMACMD5(salt);
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_username.Text) && !String.IsNullOrEmpty(tb_pass.Text) && !String.IsNullOrEmpty(tb_server.Text))
            {
                var password = System.Text.Encoding.UTF8.GetBytes(tb_pass.Text);
                var saltedHash = hmacMD5.ComputeHash(password);

                this.username = tb_username.Text;
                this.pass = System.Text.Encoding.UTF8.GetString(saltedHash);
                this.server = tb_server.Text;
                //this.Close();
                this.Hide();
                MainForm mf = new MainForm(server, username, pass, this);
                mf.Show();
            }
            else
            {
                setInfo("Uzupełnij wszystkie pola!");
            }
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

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                //Establishing the connection 
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect(tb_server.Text, 7777);
                Console.WriteLine("Connected");

                //Using the network stream to send data
                NetworkStream nts = tcpclnt.GetStream();
                StreamReader strread = new StreamReader(nts);
                StreamWriter strwrite = new StreamWriter(nts);
                //Sending a pre-stored text data

                var password = System.Text.Encoding.UTF8.GetBytes(tb_pass.Text);
                var saltedHash = hmacMD5.ComputeHash(password);

                string str1 = tb_username.Text + "@" + System.Text.Encoding.UTF8.GetString(saltedHash);
                strwrite.WriteLine(str1);
                strwrite.Flush();
                string info = strread.ReadLine(); 
                setInfo(info);
                strwrite.Close();
                strread.Close();
                nts.Close();
                //tb_pass.Text = System.Text.Encoding.UTF8.GetString(saltedHash);
                tcpclnt.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Error..... " + ee.StackTrace);
            }
        }

        public void setInfo(string info)
        {
            lb_infoLogin.Text = info;
        }

    }
}

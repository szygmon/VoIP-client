namespace VoIPclient
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_infoLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(61, 121);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(163, 22);
            this.tb_username.TabIndex = 1;
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(61, 173);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.PasswordChar = '*';
            this.tb_pass.Size = new System.Drawing.Size(164, 22);
            this.tb_pass.TabIndex = 2;
            this.tb_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pass_KeyPress);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(61, 217);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(67, 29);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "Zaloguj";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(134, 217);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(90, 29);
            this.btn_register.TabIndex = 3;
            this.btn_register.Text = "Zarejestruj";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nazwa użytkownika:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasło:";
            // 
            // tb_server
            // 
            this.tb_server.Location = new System.Drawing.Point(61, 63);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(163, 22);
            this.tb_server.TabIndex = 0;
            this.tb_server.Text = "192.168.1.119";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "IP serwera VoIP:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lb_infoLogin
            // 
            this.lb_infoLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_infoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_infoLogin.ForeColor = System.Drawing.Color.Red;
            this.lb_infoLogin.Location = new System.Drawing.Point(0, 0);
            this.lb_infoLogin.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lb_infoLogin.Name = "lb_infoLogin";
            this.lb_infoLogin.Size = new System.Drawing.Size(282, 17);
            this.lb_infoLogin.TabIndex = 8;
            this.lb_infoLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 362);
            this.Controls.Add(this.lb_infoLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_server);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.tb_username);
            this.Name = "LoginForm";
            this.Text = "VoIP SM - logowanie";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_infoLogin;
    }
}
namespace MyFirstSoftPhone_03
{
    partial class MainForm
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
            this.lb_Log = new System.Windows.Forms.ListBox();
            this.btn_HangUp = new System.Windows.Forms.Button();
            this.btn_PickUp = new System.Windows.Forms.Button();
            this.lbl_NumberToDial = new System.Windows.Forms.Label();
            this.tb_Display = new System.Windows.Forms.TextBox();
            this.btn_logout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbx_friends = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_addFriend = new System.Windows.Forms.Button();
            this.btn_remFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Log
            // 
            this.lb_Log.FormattingEnabled = true;
            this.lb_Log.ItemHeight = 16;
            this.lb_Log.Location = new System.Drawing.Point(17, 16);
            this.lb_Log.Margin = new System.Windows.Forms.Padding(4);
            this.lb_Log.Name = "lb_Log";
            this.lb_Log.Size = new System.Drawing.Size(427, 740);
            this.lb_Log.TabIndex = 0;
            // 
            // btn_HangUp
            // 
            this.btn_HangUp.Location = new System.Drawing.Point(844, 105);
            this.btn_HangUp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_HangUp.Name = "btn_HangUp";
            this.btn_HangUp.Size = new System.Drawing.Size(100, 28);
            this.btn_HangUp.TabIndex = 2;
            this.btn_HangUp.Text = "Zakończ";
            this.btn_HangUp.UseVisualStyleBackColor = true;
            this.btn_HangUp.Click += new System.EventHandler(this.btn_HangUp_Click);
            // 
            // btn_PickUp
            // 
            this.btn_PickUp.Location = new System.Drawing.Point(516, 105);
            this.btn_PickUp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PickUp.Name = "btn_PickUp";
            this.btn_PickUp.Size = new System.Drawing.Size(100, 28);
            this.btn_PickUp.TabIndex = 15;
            this.btn_PickUp.Text = "Zadzwoń";
            this.btn_PickUp.UseVisualStyleBackColor = true;
            this.btn_PickUp.Click += new System.EventHandler(this.btn_PickUp_Click);
            // 
            // lbl_NumberToDial
            // 
            this.lbl_NumberToDial.AutoSize = true;
            this.lbl_NumberToDial.Location = new System.Drawing.Point(592, 9);
            this.lbl_NumberToDial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NumberToDial.Name = "lbl_NumberToDial";
            this.lbl_NumberToDial.Size = new System.Drawing.Size(101, 17);
            this.lbl_NumberToDial.TabIndex = 16;
            this.lbl_NumberToDial.Text = "niezalogowany";
            // 
            // tb_Display
            // 
            this.tb_Display.Location = new System.Drawing.Point(516, 65);
            this.tb_Display.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Display.Name = "tb_Display";
            this.tb_Display.Size = new System.Drawing.Size(427, 22);
            this.tb_Display.TabIndex = 17;
            this.tb_Display.TextChanged += new System.EventHandler(this.tb_Display_TextChanged);
            this.tb_Display.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Display_KeyPress);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(868, 16);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 28);
            this.btn_logout.TabIndex = 21;
            this.btn_logout.Text = "Wyloguj";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Zadzwoń do:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Użytkownik:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbx_friends
            // 
            this.lbx_friends.FormattingEnabled = true;
            this.lbx_friends.ItemHeight = 16;
            this.lbx_friends.Location = new System.Drawing.Point(516, 198);
            this.lbx_friends.Name = "lbx_friends";
            this.lbx_friends.Size = new System.Drawing.Size(427, 164);
            this.lbx_friends.TabIndex = 24;
            this.lbx_friends.SelectedIndexChanged += new System.EventHandler(this.lbx_friends_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Lista znajomych:";
            // 
            // btn_addFriend
            // 
            this.btn_addFriend.Location = new System.Drawing.Point(630, 105);
            this.btn_addFriend.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addFriend.Name = "btn_addFriend";
            this.btn_addFriend.Size = new System.Drawing.Size(99, 28);
            this.btn_addFriend.TabIndex = 26;
            this.btn_addFriend.Text = "+ znajomy";
            this.btn_addFriend.UseVisualStyleBackColor = true;
            this.btn_addFriend.Click += new System.EventHandler(this.btn_addFriend_Click);
            // 
            // btn_remFriend
            // 
            this.btn_remFriend.Location = new System.Drawing.Point(737, 105);
            this.btn_remFriend.Margin = new System.Windows.Forms.Padding(4);
            this.btn_remFriend.Name = "btn_remFriend";
            this.btn_remFriend.Size = new System.Drawing.Size(99, 28);
            this.btn_remFriend.TabIndex = 27;
            this.btn_remFriend.Text = "- znajomy";
            this.btn_remFriend.UseVisualStyleBackColor = true;
            this.btn_remFriend.Click += new System.EventHandler(this.btn_remFriend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 779);
            this.Controls.Add(this.btn_remFriend);
            this.Controls.Add(this.btn_addFriend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbx_friends);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.tb_Display);
            this.Controls.Add(this.lbl_NumberToDial);
            this.Controls.Add(this.btn_PickUp);
            this.Controls.Add(this.btn_HangUp);
            this.Controls.Add(this.lb_Log);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "VoIP SM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Log;
        private System.Windows.Forms.Button btn_HangUp;
        private System.Windows.Forms.Button btn_PickUp;
        private System.Windows.Forms.Label lbl_NumberToDial;
        private System.Windows.Forms.TextBox tb_Display;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbx_friends;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_addFriend;
        private System.Windows.Forms.Button btn_remFriend;
    }
}


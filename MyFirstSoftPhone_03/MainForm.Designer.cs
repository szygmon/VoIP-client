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
            this.btn_Redial = new System.Windows.Forms.Button();
            this.btn_Hold = new System.Windows.Forms.Button();
            this.btn_Transfer = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lbl_NumberToDial.Location = new System.Drawing.Point(512, 11);
            this.lbl_NumberToDial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NumberToDial.Name = "lbl_NumberToDial";
            this.lbl_NumberToDial.Size = new System.Drawing.Size(46, 17);
            this.lbl_NumberToDial.TabIndex = 16;
            this.lbl_NumberToDial.Text = "label1";
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
            // btn_Redial
            // 
            this.btn_Redial.Location = new System.Drawing.Point(516, 181);
            this.btn_Redial.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Redial.Name = "btn_Redial";
            this.btn_Redial.Size = new System.Drawing.Size(100, 28);
            this.btn_Redial.TabIndex = 18;
            this.btn_Redial.Text = "Redial";
            this.btn_Redial.UseVisualStyleBackColor = true;
            this.btn_Redial.Click += new System.EventHandler(this.btn_Redial_Click);
            // 
            // btn_Hold
            // 
            this.btn_Hold.Location = new System.Drawing.Point(680, 181);
            this.btn_Hold.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Hold.Name = "btn_Hold";
            this.btn_Hold.Size = new System.Drawing.Size(100, 28);
            this.btn_Hold.TabIndex = 19;
            this.btn_Hold.Text = "Hold";
            this.btn_Hold.UseVisualStyleBackColor = true;
            this.btn_Hold.Click += new System.EventHandler(this.btn_Hold_Click);
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.Location = new System.Drawing.Point(844, 181);
            this.btn_Transfer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.Size = new System.Drawing.Size(100, 28);
            this.btn_Transfer.TabIndex = 20;
            this.btn_Transfer.Text = "Transfer";
            this.btn_Transfer.UseVisualStyleBackColor = true;
            this.btn_Transfer.Click += new System.EventHandler(this.btn_Transfer_Click);
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
            this.label1.Location = new System.Drawing.Point(516, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Zadzwoń do:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 779);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_Transfer);
            this.Controls.Add(this.btn_Hold);
            this.Controls.Add(this.btn_Redial);
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
        private System.Windows.Forms.Button btn_Redial;
        private System.Windows.Forms.Button btn_Hold;
        private System.Windows.Forms.Button btn_Transfer;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label label1;
    }
}


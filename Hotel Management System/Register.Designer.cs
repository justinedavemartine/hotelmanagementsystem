namespace Hotel_Management_System
{
    partial class RegisterForm
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.showpass_chk = new Guna.UI2.WinForms.Guna2CheckBox();
            this.login_link = new System.Windows.Forms.Label();
            this.close_btn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.reg_btn = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.user_lbl = new System.Windows.Forms.Label();
            this.userPass_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.userName_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userConfirmPass_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackgroundImage = global::Hotel_Management_System.Properties.Resources.user;
            this.guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2Panel2.Location = new System.Drawing.Point(148, 38);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(100, 100);
            this.guna2Panel2.TabIndex = 17;
            // 
            // showpass_chk
            // 
            this.showpass_chk.AutoSize = true;
            this.showpass_chk.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.showpass_chk.CheckedState.BorderRadius = 0;
            this.showpass_chk.CheckedState.BorderThickness = 0;
            this.showpass_chk.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.showpass_chk.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showpass_chk.Location = new System.Drawing.Point(41, 467);
            this.showpass_chk.Name = "showpass_chk";
            this.showpass_chk.Size = new System.Drawing.Size(104, 17);
            this.showpass_chk.TabIndex = 21;
            this.showpass_chk.Text = "Show Password";
            this.showpass_chk.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.showpass_chk.UncheckedState.BorderRadius = 0;
            this.showpass_chk.UncheckedState.BorderThickness = 0;
            this.showpass_chk.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.showpass_chk.CheckedChanged += new System.EventHandler(this.showpass_chk_CheckedChanged);
            // 
            // login_link
            // 
            this.login_link.AutoSize = true;
            this.login_link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_link.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_link.Location = new System.Drawing.Point(155, 558);
            this.login_link.Name = "login_link";
            this.login_link.Size = new System.Drawing.Size(71, 17);
            this.login_link.TabIndex = 20;
            this.login_link.Text = "Login now";
            this.login_link.Click += new System.EventHandler(this.login_link_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.BorderColor = System.Drawing.Color.Transparent;
            this.close_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.close_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.close_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.close_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.close_btn.FillColor = System.Drawing.Color.Red;
            this.close_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.Color.White;
            this.close_btn.HoverState.BorderColor = System.Drawing.Color.Azure;
            this.close_btn.HoverState.FillColor = System.Drawing.Color.LightCoral;
            this.close_btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.close_btn.Location = new System.Drawing.Point(350, 9);
            this.close_btn.Name = "close_btn";
            this.close_btn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.close_btn.Size = new System.Drawing.Size(32, 31);
            this.close_btn.TabIndex = 19;
            this.close_btn.Text = "X";
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(91, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 30);
            this.label2.TabIndex = 18;
            this.label2.Text = "Create New Account";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // reg_btn
            // 
            this.reg_btn.BorderRadius = 10;
            this.reg_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.reg_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.reg_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reg_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.reg_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(174)))), ((int)(((byte)(210)))));
            this.reg_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_btn.ForeColor = System.Drawing.Color.White;
            this.reg_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(67)))), ((int)(((byte)(159)))));
            this.reg_btn.Location = new System.Drawing.Point(31, 501);
            this.reg_btn.Name = "reg_btn";
            this.reg_btn.Size = new System.Drawing.Size(331, 46);
            this.reg_btn.TabIndex = 16;
            this.reg_btn.Text = "REGISTER";
            this.reg_btn.Click += new System.EventHandler(this.reg_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "PASSWORD";
            // 
            // user_lbl
            // 
            this.user_lbl.AutoSize = true;
            this.user_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_lbl.Location = new System.Drawing.Point(41, 210);
            this.user_lbl.Name = "user_lbl";
            this.user_lbl.Size = new System.Drawing.Size(77, 17);
            this.user_lbl.TabIndex = 14;
            this.user_lbl.Text = "USERNAME";
            // 
            // userPass_txt
            // 
            this.userPass_txt.BorderColor = System.Drawing.Color.Gray;
            this.userPass_txt.BorderRadius = 10;
            this.userPass_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userPass_txt.DefaultText = "";
            this.userPass_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.userPass_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.userPass_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userPass_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userPass_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userPass_txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.userPass_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userPass_txt.Location = new System.Drawing.Point(31, 324);
            this.userPass_txt.Name = "userPass_txt";
            this.userPass_txt.PasswordChar = '●';
            this.userPass_txt.PlaceholderText = "";
            this.userPass_txt.SelectedText = "";
            this.userPass_txt.Size = new System.Drawing.Size(331, 46);
            this.userPass_txt.TabIndex = 13;
            // 
            // userName_txt
            // 
            this.userName_txt.BorderColor = System.Drawing.Color.Gray;
            this.userName_txt.BorderRadius = 10;
            this.userName_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userName_txt.DefaultText = "";
            this.userName_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.userName_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.userName_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userName_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userName_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userName_txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.userName_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userName_txt.Location = new System.Drawing.Point(31, 238);
            this.userName_txt.Name = "userName_txt";
            this.userName_txt.PasswordChar = '\0';
            this.userName_txt.PlaceholderText = "";
            this.userName_txt.SelectedText = "";
            this.userName_txt.Size = new System.Drawing.Size(331, 46);
            this.userName_txt.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "CONFIRM PASSWORD";
            // 
            // userConfirmPass_txt
            // 
            this.userConfirmPass_txt.BorderColor = System.Drawing.Color.Gray;
            this.userConfirmPass_txt.BorderRadius = 10;
            this.userConfirmPass_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userConfirmPass_txt.DefaultText = "";
            this.userConfirmPass_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.userConfirmPass_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.userConfirmPass_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userConfirmPass_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userConfirmPass_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userConfirmPass_txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.userConfirmPass_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userConfirmPass_txt.Location = new System.Drawing.Point(31, 408);
            this.userConfirmPass_txt.Name = "userConfirmPass_txt";
            this.userConfirmPass_txt.PasswordChar = '●';
            this.userConfirmPass_txt.PlaceholderText = "";
            this.userConfirmPass_txt.SelectedText = "";
            this.userConfirmPass_txt.Size = new System.Drawing.Size(331, 46);
            this.userConfirmPass_txt.TabIndex = 22;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 598);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userConfirmPass_txt);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.showpass_chk);
            this.Controls.Add(this.login_link);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reg_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.user_lbl);
            this.Controls.Add(this.userPass_txt);
            this.Controls.Add(this.userName_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2CheckBox showpass_chk;
        private System.Windows.Forms.Label login_link;
        private Guna.UI2.WinForms.Guna2CircleButton close_btn;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button reg_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label user_lbl;
        private Guna.UI2.WinForms.Guna2TextBox userPass_txt;
        private Guna.UI2.WinForms.Guna2TextBox userName_txt;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox userConfirmPass_txt;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
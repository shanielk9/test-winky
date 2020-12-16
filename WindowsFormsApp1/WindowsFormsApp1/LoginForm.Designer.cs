namespace WindowsFormsApp1
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
            this.SignInBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.FullNameTxtBx = new System.Windows.Forms.TextBox();
            this.EmailTxtBx = new System.Windows.Forms.TextBox();
            this.PasswordTxtBx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SignInBtn
            // 
            this.SignInBtn.Location = new System.Drawing.Point(28, 166);
            this.SignInBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SignInBtn.Name = "SignInBtn";
            this.SignInBtn.Size = new System.Drawing.Size(208, 28);
            this.SignInBtn.TabIndex = 0;
            this.SignInBtn.Text = "Sign In";
            this.SignInBtn.UseVisualStyleBackColor = true;
            this.SignInBtn.Click += new System.EventHandler(this.SignInBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(28, 130);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(208, 28);
            this.loginBtn.TabIndex = 1;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // FullNameTxtBx
            // 
            this.FullNameTxtBx.Location = new System.Drawing.Point(28, 22);
            this.FullNameTxtBx.Margin = new System.Windows.Forms.Padding(4);
            this.FullNameTxtBx.Name = "FullNameTxtBx";
            this.FullNameTxtBx.Size = new System.Drawing.Size(207, 22);
            this.FullNameTxtBx.TabIndex = 2;
            this.FullNameTxtBx.Text = "Full Name";
            this.FullNameTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FullNameTxtBx.Click += new System.EventHandler(this.FullNameTxtBx_Click);
            // 
            // EmailTxtBx
            // 
            this.EmailTxtBx.Location = new System.Drawing.Point(28, 54);
            this.EmailTxtBx.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTxtBx.Name = "EmailTxtBx";
            this.EmailTxtBx.Size = new System.Drawing.Size(207, 22);
            this.EmailTxtBx.TabIndex = 3;
            this.EmailTxtBx.Text = "Email";
            this.EmailTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EmailTxtBx.Click += new System.EventHandler(this.EmailTxtBx_Click);
            // 
            // PasswordTxtBx
            // 
            this.PasswordTxtBx.Location = new System.Drawing.Point(28, 86);
            this.PasswordTxtBx.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTxtBx.Name = "PasswordTxtBx";
            this.PasswordTxtBx.Size = new System.Drawing.Size(207, 22);
            this.PasswordTxtBx.TabIndex = 4;
            this.PasswordTxtBx.Text = "Password";
            this.PasswordTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTxtBx.Click += new System.EventHandler(this.PasswordTxtBx_Click);
            this.PasswordTxtBx.TextChanged += new System.EventHandler(this.PasswordTxtBx_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 220);
            this.Controls.Add(this.PasswordTxtBx);
            this.Controls.Add(this.EmailTxtBx);
            this.Controls.Add(this.FullNameTxtBx);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.SignInBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SignInBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox FullNameTxtBx;
        private System.Windows.Forms.TextBox EmailTxtBx;
        private System.Windows.Forms.TextBox PasswordTxtBx;
    }
}


namespace ClientScheduler
{
    partial class LoginScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            usernameTxt = new TextBox();
            passwordTxt = new TextBox();
            label3 = new Label();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(105, 39);
            label1.Name = "label1";
            label1.Size = new Size(99, 45);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 122);
            label2.Name = "label2";
            label2.Size = new Size(88, 21);
            label2.TabIndex = 1;
            label2.Text = "Username: ";
            // 
            // usernameTxt
            // 
            usernameTxt.Location = new Point(168, 124);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(100, 23);
            usernameTxt.TabIndex = 1;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(168, 203);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PasswordChar = '*';
            passwordTxt.Size = new Size(100, 23);
            passwordTxt.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 201);
            label3.Name = "label3";
            label3.Size = new Size(83, 21);
            label3.TabIndex = 3;
            label3.Text = "Password: ";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(105, 257);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(99, 35);
            loginBtn.TabIndex = 3;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 417);
            Controls.Add(loginBtn);
            Controls.Add(passwordTxt);
            Controls.Add(label3);
            Controls.Add(usernameTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Client Scheduler Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
        private Label label3;
        private Button loginBtn;
    }
}

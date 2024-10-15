namespace UI
{
    partial class LoginForm
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
            UsernameTB = new TextBox();
            PasswordTB = new TextBox();
            LoginB = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 22);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 67);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Password: ";
            // 
            // UsernameTB
            // 
            UsernameTB.Location = new Point(158, 19);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.Size = new Size(100, 23);
            UsernameTB.TabIndex = 2;
            // 
            // PasswordTB
            // 
            PasswordTB.Location = new Point(158, 64);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.Size = new Size(100, 23);
            PasswordTB.TabIndex = 3;
            // 
            // LoginB
            // 
            LoginB.Location = new Point(158, 100);
            LoginB.Name = "LoginB";
            LoginB.Size = new Size(75, 23);
            LoginB.TabIndex = 4;
            LoginB.Text = "Login";
            LoginB.UseVisualStyleBackColor = true;
            LoginB.Click += LoginB_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 135);
            Controls.Add(LoginB);
            Controls.Add(PasswordTB);
            Controls.Add(UsernameTB);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox UsernameTB;
        private TextBox PasswordTB;
        private Button LoginB;
    }
}

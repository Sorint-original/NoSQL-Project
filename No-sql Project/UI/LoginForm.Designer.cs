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
            label1.ForeColor = Color.White;
            label1.Location = new Point(45, 29);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(45, 89);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Password: ";
            // 
            // UsernameTB
            // 
            UsernameTB.BackColor = Color.FromArgb(38, 38, 38);
            UsernameTB.ForeColor = Color.White;
            UsernameTB.Location = new Point(181, 25);
            UsernameTB.Margin = new Padding(3, 4, 3, 4);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.Size = new Size(114, 27);
            UsernameTB.TabIndex = 2;
            // 
            // PasswordTB
            // 
            PasswordTB.BackColor = Color.FromArgb(38, 38, 38);
            PasswordTB.ForeColor = Color.White;
            PasswordTB.Location = new Point(181, 85);
            PasswordTB.Margin = new Padding(3, 4, 3, 4);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.Size = new Size(114, 27);
            PasswordTB.TabIndex = 3;
            // 
            // LoginB
            // 
            LoginB.BackColor = Color.FromArgb(38, 38, 38);
            LoginB.ForeColor = Color.White;
            LoginB.Location = new Point(181, 133);
            LoginB.Margin = new Padding(3, 4, 3, 4);
            LoginB.Name = "LoginB";
            LoginB.Size = new Size(86, 31);
            LoginB.TabIndex = 4;
            LoginB.Text = "Login";
            LoginB.UseVisualStyleBackColor = false;
            LoginB.Click += LoginB_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(355, 180);
            Controls.Add(LoginB);
            Controls.Add(PasswordTB);
            Controls.Add(UsernameTB);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
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

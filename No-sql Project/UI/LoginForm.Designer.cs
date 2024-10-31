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
            ClearFieldsLabel = new Label();
            UsernameTB = new TextBox();
            PasswordTB = new TextBox();
            LoginB = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            ExitLabel = new Label();
            label2 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // ClearFieldsLabel
            // 
            ClearFieldsLabel.AutoSize = true;
            ClearFieldsLabel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ClearFieldsLabel.ForeColor = Color.FromArgb(0, 117, 214);
            ClearFieldsLabel.Location = new Point(206, 326);
            ClearFieldsLabel.Name = "ClearFieldsLabel";
            ClearFieldsLabel.Size = new Size(111, 20);
            ClearFieldsLabel.TabIndex = 0;
            ClearFieldsLabel.Text = "Clear Fields";
            ClearFieldsLabel.Click += ClearFieldsLabel_Click;
            // 
            // UsernameTB
            // 
            UsernameTB.BackColor = Color.FromArgb(38, 38, 38);
            UsernameTB.BorderStyle = BorderStyle.None;
            UsernameTB.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            UsernameTB.ForeColor = Color.FromArgb(0, 117, 214);
            UsernameTB.Location = new Point(89, 224);
            UsernameTB.Margin = new Padding(3, 4, 3, 4);
            UsernameTB.Multiline = true;
            UsernameTB.Name = "UsernameTB";
            UsernameTB.Size = new Size(218, 25);
            UsernameTB.TabIndex = 2;
            // 
            // PasswordTB
            // 
            PasswordTB.BackColor = Color.FromArgb(38, 38, 38);
            PasswordTB.BorderStyle = BorderStyle.None;
            PasswordTB.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordTB.ForeColor = Color.FromArgb(0, 117, 214);
            PasswordTB.Location = new Point(89, 273);
            PasswordTB.Margin = new Padding(3, 4, 3, 4);
            PasswordTB.Multiline = true;
            PasswordTB.Name = "PasswordTB";
            PasswordTB.Size = new Size(218, 25);
            PasswordTB.TabIndex = 2;
            // 
            // LoginB
            // 
            LoginB.BackColor = Color.FromArgb(0, 117, 214);
            LoginB.FlatStyle = FlatStyle.Flat;
            LoginB.Font = new Font("Bauhaus 93", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            LoginB.ForeColor = Color.White;
            LoginB.Location = new Point(45, 350);
            LoginB.Margin = new Padding(3, 4, 3, 4);
            LoginB.Name = "LoginB";
            LoginB.Size = new Size(272, 31);
            LoginB.TabIndex = 4;
            LoginB.Text = "LOGIN";
            LoginB.UseVisualStyleBackColor = false;
            LoginB.Click += LoginB_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo_Project;
            pictureBox1.Location = new Point(111, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Lock_Logo;
            pictureBox2.Location = new Point(45, 265);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Employee_Logo;
            pictureBox3.Location = new Point(45, 215);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(38, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(45, 256);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 1);
            panel1.TabIndex = 7;
            // 
            // ExitLabel
            // 
            ExitLabel.AutoSize = true;
            ExitLabel.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ExitLabel.ForeColor = Color.FromArgb(0, 117, 214);
            ExitLabel.Location = new Point(156, 400);
            ExitLabel.Name = "ExitLabel";
            ExitLabel.Size = new Size(41, 20);
            ExitLabel.TabIndex = 0;
            ExitLabel.Text = "Exit";
            ExitLabel.Click += ExitLabel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bauhaus 93", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(113, 155);
            label2.Name = "label2";
            label2.Size = new Size(130, 45);
            label2.TabIndex = 8;
            label2.Text = "LOGIN";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(44, 305);
            panel2.Name = "panel2";
            panel2.Size = new Size(263, 1);
            panel2.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(362, 434);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(LoginB);
            Controls.Add(PasswordTB);
            Controls.Add(UsernameTB);
            Controls.Add(ExitLabel);
            Controls.Add(ClearFieldsLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ClearFieldsLabel;
        private TextBox UsernameTB;
        private TextBox PasswordTB;
        private Button LoginB;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Label ExitLabel;
        private Label label2;
        private Panel panel2;
    }
}

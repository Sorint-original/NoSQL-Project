namespace UI
{
    partial class EmployeeCreateForm
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
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            EmployeeName = new TextBox();
            EmployeeUserName = new TextBox();
            EmployeePassword = new TextBox();
            EmployeeEmail = new TextBox();
            EmployeeRole = new ComboBox();
            cmbActiveStatus = new ComboBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(142, 426);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(284, 426);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 27);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 2;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 88);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 151);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 216);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 5;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 281);
            label5.Name = "label5";
            label5.Size = new Size(50, 25);
            label5.TabIndex = 6;
            label5.Text = "Role:";
            // 
            // EmployeeName
            // 
            EmployeeName.Location = new Point(219, 24);
            EmployeeName.Name = "EmployeeName";
            EmployeeName.Size = new Size(245, 31);
            EmployeeName.TabIndex = 7;
            // 
            // EmployeeUserName
            // 
            EmployeeUserName.Location = new Point(219, 85);
            EmployeeUserName.Name = "EmployeeUserName";
            EmployeeUserName.Size = new Size(245, 31);
            EmployeeUserName.TabIndex = 8;
            // 
            // EmployeePassword
            // 
            EmployeePassword.Location = new Point(219, 151);
            EmployeePassword.Name = "EmployeePassword";
            EmployeePassword.Size = new Size(245, 31);
            EmployeePassword.TabIndex = 9;
            // 
            // EmployeeEmail
            // 
            EmployeeEmail.Location = new Point(219, 213);
            EmployeeEmail.Name = "EmployeeEmail";
            EmployeeEmail.Size = new Size(245, 31);
            EmployeeEmail.TabIndex = 10;
            // 
            // EmployeeRole
            // 
            EmployeeRole.FormattingEnabled = true;
            EmployeeRole.Items.AddRange(new object[] { "regular", "admin" });
            EmployeeRole.Location = new Point(219, 278);
            EmployeeRole.Name = "EmployeeRole";
            EmployeeRole.Size = new Size(182, 33);
            EmployeeRole.TabIndex = 11;
            // 
            // cmbActiveStatus
            // 
            cmbActiveStatus.FormattingEnabled = true;
            cmbActiveStatus.Items.AddRange(new object[] { "Active", "Not Active" });
            cmbActiveStatus.Location = new Point(219, 354);
            cmbActiveStatus.Name = "cmbActiveStatus";
            cmbActiveStatus.Size = new Size(182, 33);
            cmbActiveStatus.TabIndex = 12;
            // 
            // EmployeeCreateForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 512);
            Controls.Add(cmbActiveStatus);
            Controls.Add(EmployeeRole);
            Controls.Add(EmployeeEmail);
            Controls.Add(EmployeePassword);
            Controls.Add(EmployeeUserName);
            Controls.Add(EmployeeName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "EmployeeCreateForm";
            Text = "EmployeeCreateForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox EmployeeName;
        private TextBox EmployeeUserName;
        private TextBox EmployeePassword;
        private TextBox EmployeeEmail;
        private ComboBox EmployeeRole;
        private ComboBox cmbActiveStatus;
    }
}
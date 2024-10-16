namespace UI
{
    partial class ListMainForm
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
            MainListView = new ListView();
            AddB = new Button();
            UpdateB = new Button();
            DeleteB = new Button();
            DescriptionBox = new TextBox();
            AdminTicketPanel = new Panel();
            ArchListB = new Button();
            ArchSelectedB = new Button();
            LogoutB = new Button();
            AdminTicketPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainListView
            // 
            MainListView.FullRowSelect = true;
            MainListView.Location = new Point(29, 73);
            MainListView.Name = "MainListView";
            MainListView.Size = new Size(564, 289);
            MainListView.TabIndex = 0;
            MainListView.UseCompatibleStateImageBehavior = false;
            MainListView.SelectedIndexChanged += MainListView_SelectedIndexChanged;
            // 
            // AddB
            // 
            AddB.Location = new Point(29, 380);
            AddB.Name = "AddB";
            AddB.Size = new Size(96, 43);
            AddB.TabIndex = 1;
            AddB.Text = "Add";
            AddB.UseVisualStyleBackColor = true;
            AddB.Click += AddB_Click;
            // 
            // UpdateB
            // 
            UpdateB.Location = new Point(151, 380);
            UpdateB.Name = "UpdateB";
            UpdateB.Size = new Size(96, 43);
            UpdateB.TabIndex = 2;
            UpdateB.Text = "Update";
            UpdateB.UseVisualStyleBackColor = true;
            UpdateB.Click += UpdateB_Click;
            // 
            // DeleteB
            // 
            DeleteB.Location = new Point(277, 380);
            DeleteB.Name = "DeleteB";
            DeleteB.Size = new Size(96, 43);
            DeleteB.TabIndex = 3;
            DeleteB.Text = "Delete";
            DeleteB.UseVisualStyleBackColor = true;
            DeleteB.Click += DeleteB_Click;
            // 
            // DescriptionBox
            // 
            DescriptionBox.BackColor = SystemColors.Window;
            DescriptionBox.Location = new Point(617, 261);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.ReadOnly = true;
            DescriptionBox.Size = new Size(171, 162);
            DescriptionBox.TabIndex = 4;
            // 
            // AdminTicketPanel
            // 
            AdminTicketPanel.Controls.Add(ArchListB);
            AdminTicketPanel.Controls.Add(ArchSelectedB);
            AdminTicketPanel.Location = new Point(599, 73);
            AdminTicketPanel.Name = "AdminTicketPanel";
            AdminTicketPanel.Size = new Size(198, 182);
            AdminTicketPanel.TabIndex = 5;
            // 
            // ArchListB
            // 
            ArchListB.Location = new Point(52, 100);
            ArchListB.Name = "ArchListB";
            ArchListB.Size = new Size(104, 47);
            ArchListB.TabIndex = 1;
            ArchListB.Text = "Archive current list";
            ArchListB.UseVisualStyleBackColor = true;
            // 
            // ArchSelectedB
            // 
            ArchSelectedB.Location = new Point(52, 35);
            ArchSelectedB.Name = "ArchSelectedB";
            ArchSelectedB.Size = new Size(104, 47);
            ArchSelectedB.TabIndex = 0;
            ArchSelectedB.Text = "Archive selected";
            ArchSelectedB.UseVisualStyleBackColor = true;
            // 
            // LogoutB
            // 
            LogoutB.Location = new Point(713, 12);
            LogoutB.Name = "LogoutB";
            LogoutB.Size = new Size(75, 23);
            LogoutB.TabIndex = 6;
            LogoutB.Text = "Log out";
            LogoutB.UseVisualStyleBackColor = true;
            LogoutB.Click += LogoutB_Click;
            // 
            // ListMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LogoutB);
            Controls.Add(AdminTicketPanel);
            Controls.Add(DescriptionBox);
            Controls.Add(DeleteB);
            Controls.Add(UpdateB);
            Controls.Add(AddB);
            Controls.Add(MainListView);
            Name = "ListMainForm";
            Text = "ListMainForm";
            AdminTicketPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView MainListView;
        private Button AddB;
        private Button UpdateB;
        private Button DeleteB;
        private TextBox DescriptionBox;
        private Panel AdminTicketPanel;
        private Button ArchSelectedB;
        private Button ArchListB;
        private Button LogoutB;
    }
}
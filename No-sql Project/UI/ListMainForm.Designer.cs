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
            ArchSelectedB = new Button();
            ArchListB = new Button();
            UpdateListButton = new Button();
            LogoutB = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TitleTextbox_search = new TextBox();
            PriorityBox = new ComboBox();
            StatusBox = new ComboBox();
            StarterDateTime = new DateTimePicker();
            EndDateTime = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SortByBoxTickets = new ComboBox();
            label8 = new Label();
            FilterResultTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            ticketsToolStripMenuItem = new ToolStripMenuItem();
            employeeToolStripMenuItem = new ToolStripMenuItem();
            TicketFilterPanel = new Panel();
            checkBoxFilterDate = new CheckBox();
            AdminTicketPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            TicketFilterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainListView
            // 
            MainListView.BackColor = Color.FromArgb(38, 38, 38);
            MainListView.ForeColor = Color.White;
            MainListView.FullRowSelect = true;
            MainListView.Location = new Point(33, 137);
            MainListView.Margin = new Padding(3, 4, 3, 4);
            MainListView.Name = "MainListView";
            MainListView.Size = new Size(673, 384);
            MainListView.TabIndex = 0;
            MainListView.UseCompatibleStateImageBehavior = false;
            MainListView.SelectedIndexChanged += MainListView_SelectedIndexChanged;
            // 
            // AddB
            // 
            AddB.BackColor = Color.FromArgb(38, 38, 38);
            AddB.Location = new Point(33, 542);
            AddB.Margin = new Padding(3, 4, 3, 4);
            AddB.Name = "AddB";
            AddB.Size = new Size(110, 57);
            AddB.TabIndex = 1;
            AddB.Text = "Add";
            AddB.UseVisualStyleBackColor = false;
            AddB.Click += AddB_Click;
            // 
            // UpdateB
            // 
            UpdateB.BackColor = Color.FromArgb(38, 38, 38);
            UpdateB.Location = new Point(149, 542);
            UpdateB.Margin = new Padding(3, 4, 3, 4);
            UpdateB.Name = "UpdateB";
            UpdateB.Size = new Size(110, 57);
            UpdateB.TabIndex = 2;
            UpdateB.Text = "Update";
            UpdateB.UseVisualStyleBackColor = false;
            UpdateB.Click += UpdateB_Click;
            // 
            // DeleteB
            // 
            DeleteB.BackColor = Color.FromArgb(38, 38, 38);
            DeleteB.Location = new Point(265, 542);
            DeleteB.Margin = new Padding(3, 4, 3, 4);
            DeleteB.Name = "DeleteB";
            DeleteB.Size = new Size(110, 57);
            DeleteB.TabIndex = 3;
            DeleteB.Text = "Delete";
            DeleteB.UseVisualStyleBackColor = false;
            DeleteB.Click += DeleteB_Click;
            // 
            // DescriptionBox
            // 
            DescriptionBox.BackColor = Color.FromArgb(38, 38, 38);
            DescriptionBox.ForeColor = Color.White;
            DescriptionBox.Location = new Point(752, 395);
            DescriptionBox.Margin = new Padding(3, 4, 3, 4);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.ReadOnly = true;
            DescriptionBox.Size = new Size(242, 215);
            DescriptionBox.TabIndex = 4;
            // 
            // AdminTicketPanel
            // 
            AdminTicketPanel.Controls.Add(ArchSelectedB);
            AdminTicketPanel.Controls.Add(ArchListB);
            AdminTicketPanel.Location = new Point(752, 293);
            AdminTicketPanel.Margin = new Padding(3, 4, 3, 4);
            AdminTicketPanel.Name = "AdminTicketPanel";
            AdminTicketPanel.Size = new Size(242, 68);
            AdminTicketPanel.TabIndex = 5;
            AdminTicketPanel.Paint += AdminTicketPanel_Paint;
            // 
            // ArchSelectedB
            // 
            ArchSelectedB.BackColor = Color.FromArgb(38, 38, 38);
            ArchSelectedB.Location = new Point(122, 4);
            ArchSelectedB.Margin = new Padding(3, 4, 3, 4);
            ArchSelectedB.Name = "ArchSelectedB";
            ArchSelectedB.Size = new Size(117, 63);
            ArchSelectedB.TabIndex = 0;
            ArchSelectedB.Text = "Archive selected";
            ArchSelectedB.UseVisualStyleBackColor = false;
            // 
            // ArchListB
            // 
            ArchListB.BackColor = Color.FromArgb(38, 38, 38);
            ArchListB.Location = new Point(0, 4);
            ArchListB.Margin = new Padding(3, 4, 3, 4);
            ArchListB.Name = "ArchListB";
            ArchListB.Size = new Size(117, 63);
            ArchListB.TabIndex = 1;
            ArchListB.Text = "Archive current list";
            ArchListB.UseVisualStyleBackColor = false;
            // 
            // UpdateListButton
            // 
            UpdateListButton.BackColor = Color.FromArgb(38, 38, 38);
            UpdateListButton.Location = new Point(580, 103);
            UpdateListButton.Name = "UpdateListButton";
            UpdateListButton.Size = new Size(126, 28);
            UpdateListButton.TabIndex = 28;
            UpdateListButton.Text = "Update list";
            UpdateListButton.UseVisualStyleBackColor = false;
            // 
            // LogoutB
            // 
            LogoutB.BackColor = Color.FromArgb(38, 38, 38);
            LogoutB.Location = new Point(934, 48);
            LogoutB.Margin = new Padding(3, 4, 3, 4);
            LogoutB.Name = "LogoutB";
            LogoutB.Size = new Size(86, 31);
            LogoutB.TabIndex = 6;
            LogoutB.Text = "Log out";
            LogoutB.UseVisualStyleBackColor = false;
            LogoutB.Click += LogoutB_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 44);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 8;
            label1.Text = "Filter on:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(276, 9);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 11;
            label2.Text = "Priority:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(139, 9);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 15;
            label3.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 16;
            label4.Text = "Title:";
            // 
            // TitleTextbox_search
            // 
            TitleTextbox_search.Location = new Point(0, 39);
            TitleTextbox_search.Name = "TitleTextbox_search";
            TitleTextbox_search.PlaceholderText = "Search";
            TitleTextbox_search.Size = new Size(110, 27);
            TitleTextbox_search.TabIndex = 18;
            // 
            // PriorityBox
            // 
            PriorityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PriorityBox.FormattingEnabled = true;
            PriorityBox.Items.AddRange(new object[] { "All", "High", "Middle", "Low" });
            PriorityBox.Location = new Point(276, 39);
            PriorityBox.Name = "PriorityBox";
            PriorityBox.Size = new Size(110, 28);
            PriorityBox.TabIndex = 19;
            // 
            // StatusBox
            // 
            StatusBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusBox.FormattingEnabled = true;
            StatusBox.Items.AddRange(new object[] { "All", "Open", "Pending", "Resolved", "Closed" });
            StatusBox.Location = new Point(139, 38);
            StatusBox.Name = "StatusBox";
            StatusBox.Size = new Size(110, 28);
            StatusBox.TabIndex = 20;
            // 
            // StarterDateTime
            // 
            StarterDateTime.Location = new Point(456, 540);
            StarterDateTime.Name = "StarterDateTime";
            StarterDateTime.Size = new Size(250, 27);
            StarterDateTime.TabIndex = 21;
            // 
            // EndDateTime
            // 
            EndDateTime.Location = new Point(456, 582);
            EndDateTime.Name = "EndDateTime";
            EndDateTime.Size = new Size(250, 27);
            EndDateTime.TabIndex = 22;
            EndDateTime.Value = new DateTime(2024, 10, 30, 0, 0, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(400, 541);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 23;
            label5.Text = "From:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(403, 587);
            label6.Name = "label6";
            label6.Size = new Size(32, 20);
            label6.TabIndex = 24;
            label6.Text = "Till:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(405, 8);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 25;
            label7.Text = "Sort by:";
            // 
            // SortByBoxTickets
            // 
            SortByBoxTickets.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByBoxTickets.FormattingEnabled = true;
            SortByBoxTickets.Items.AddRange(new object[] { "New to Old", "Old to New" });
            SortByBoxTickets.Location = new Point(405, 39);
            SortByBoxTickets.Name = "SortByBoxTickets";
            SortByBoxTickets.Size = new Size(110, 28);
            SortByBoxTickets.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(752, 189);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 29;
            label8.Text = "Filter Results:";
            // 
            // FilterResultTextBox
            // 
            FilterResultTextBox.Location = new Point(752, 212);
            FilterResultTextBox.Name = "FilterResultTextBox";
            FilterResultTextBox.Size = new Size(242, 27);
            FilterResultTextBox.TabIndex = 30;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ticketsToolStripMenuItem, employeeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1032, 28);
            menuStrip1.TabIndex = 32;
            menuStrip1.Text = "menuStrip1";
            // 
            // ticketsToolStripMenuItem
            // 
            ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            ticketsToolStripMenuItem.Size = new Size(68, 24);
            ticketsToolStripMenuItem.Text = "Tickets";
            // 
            // employeeToolStripMenuItem
            // 
            employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            employeeToolStripMenuItem.Size = new Size(89, 24);
            employeeToolStripMenuItem.Text = "Employee";
            // 
            // TicketFilterPanel
            // 
            TicketFilterPanel.Controls.Add(SortByBoxTickets);
            TicketFilterPanel.Controls.Add(PriorityBox);
            TicketFilterPanel.Controls.Add(StatusBox);
            TicketFilterPanel.Controls.Add(TitleTextbox_search);
            TicketFilterPanel.Controls.Add(label4);
            TicketFilterPanel.Controls.Add(label7);
            TicketFilterPanel.Controls.Add(label3);
            TicketFilterPanel.Controls.Add(label2);
            TicketFilterPanel.Location = new Point(33, 67);
            TicketFilterPanel.Name = "TicketFilterPanel";
            TicketFilterPanel.Size = new Size(541, 66);
            TicketFilterPanel.TabIndex = 33;
            // 
            // checkBoxFilterDate
            // 
            checkBoxFilterDate.AutoSize = true;
            checkBoxFilterDate.Location = new Point(588, 72);
            checkBoxFilterDate.Name = "checkBoxFilterDate";
            checkBoxFilterDate.Size = new Size(118, 24);
            checkBoxFilterDate.TabIndex = 34;
            checkBoxFilterDate.Text = "Filter by date";
            checkBoxFilterDate.UseVisualStyleBackColor = true;
            // 
            // ListMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(1032, 623);
            Controls.Add(checkBoxFilterDate);
            Controls.Add(TicketFilterPanel);
            Controls.Add(UpdateListButton);
            Controls.Add(FilterResultTextBox);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(EndDateTime);
            Controls.Add(StarterDateTime);
            Controls.Add(label1);
            Controls.Add(LogoutB);
            Controls.Add(AdminTicketPanel);
            Controls.Add(DescriptionBox);
            Controls.Add(DeleteB);
            Controls.Add(UpdateB);
            Controls.Add(AddB);
            Controls.Add(MainListView);
            Controls.Add(menuStrip1);
            ForeColor = Color.White;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ListMainForm";
            AdminTicketPanel.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            TicketFilterPanel.ResumeLayout(false);
            TicketFilterPanel.PerformLayout();
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TitleTextbox_search;
        private ComboBox PriorityBox;
        private ComboBox StatusBox;
        private DateTimePicker StarterDateTime;
        private DateTimePicker EndDateTime;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox SortByBoxTickets;
        private Button UpdateListButton;
        private Label label8;
        private TextBox FilterResultTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ticketsToolStripMenuItem;
        private ToolStripMenuItem employeeToolStripMenuItem;
        private Panel TicketFilterPanel;
        private CheckBox checkBoxFilterDate;
    }
}
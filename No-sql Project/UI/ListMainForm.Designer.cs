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
            FilterOnLabel = new Label();
            PriorityLabel = new Label();
            StatusLabel = new Label();
            TitleLabel = new Label();
            TitleTextbox_search = new TextBox();
            PriorityBox = new ComboBox();
            StatusBox = new ComboBox();
            StarterDateTime = new DateTimePicker();
            EndDateTime = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            TicketSortByLabel = new Label();
            SortByBoxTickets = new ComboBox();
            label8 = new Label();
            FilterResultTextBox = new TextBox();
            menuStrip = new MenuStrip();
            ticketsToolStripMenuItem = new ToolStripMenuItem();
            employeeToolStripMenuItem = new ToolStripMenuItem();
            TicketFilterPanel = new Panel();
            EmployeePanel = new Panel();
            ActivityComboBox = new ComboBox();
            RoleComboBox = new ComboBox();
            SortByBoxEmployee = new ComboBox();
            label1 = new Label();
            NameSearchBox = new TextBox();
            EmployeeSortByLabel = new Label();
            label9 = new Label();
            RoleLabel = new Label();
            EmployeeStatusLabel = new Label();
            checkBoxFilterDate = new CheckBox();
            TicketDatePanel = new Panel();
            ResultPanel = new Panel();
            panel1 = new Panel();
            SelectSpecificEmployeeTicket = new Button();
            PercentagesLabel = new Label();
            panel2 = new Panel();
            OpenLabel = new Label();
            PendingLabel = new Label();
            ResolvedLabel = new Label();
            ClosedLabel = new Label();
            AdminTicketPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            TicketFilterPanel.SuspendLayout();
            EmployeePanel.SuspendLayout();
            TicketDatePanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            panel2.SuspendLayout();
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
            AddB.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            AddB.Location = new Point(33, 541);
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
            UpdateB.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateB.Location = new Point(149, 541);
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
            DeleteB.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteB.Location = new Point(265, 541);
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
            AdminTicketPanel.Location = new Point(752, 310);
            AdminTicketPanel.Margin = new Padding(3, 4, 3, 4);
            AdminTicketPanel.Name = "AdminTicketPanel";
            AdminTicketPanel.Size = new Size(242, 68);
            AdminTicketPanel.TabIndex = 5;
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
            ArchSelectedB.Click += ArchSelectedB_Click;
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
            ArchListB.Click += ArchListB_Click;
            // 
            // UpdateListButton
            // 
            UpdateListButton.BackColor = Color.FromArgb(38, 38, 38);
            UpdateListButton.Location = new Point(581, 103);
            UpdateListButton.Name = "UpdateListButton";
            UpdateListButton.Size = new Size(126, 28);
            UpdateListButton.TabIndex = 28;
            UpdateListButton.Text = "Update list";
            UpdateListButton.UseVisualStyleBackColor = false;
            UpdateListButton.Click += UpdateListButton_Click;
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
            // FilterOnLabel
            // 
            FilterOnLabel.AutoSize = true;
            FilterOnLabel.ForeColor = Color.White;
            FilterOnLabel.Location = new Point(33, 44);
            FilterOnLabel.Name = "FilterOnLabel";
            FilterOnLabel.Size = new Size(66, 20);
            FilterOnLabel.TabIndex = 8;
            FilterOnLabel.Text = "Filter on:";
            // 
            // PriorityLabel
            // 
            PriorityLabel.AutoSize = true;
            PriorityLabel.ForeColor = Color.White;
            PriorityLabel.Location = new Point(277, 9);
            PriorityLabel.Name = "PriorityLabel";
            PriorityLabel.Size = new Size(59, 20);
            PriorityLabel.TabIndex = 11;
            PriorityLabel.Text = "Priority:";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.ForeColor = Color.White;
            StatusLabel.Location = new Point(139, 9);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(52, 20);
            StatusLabel.TabIndex = 15;
            StatusLabel.Text = "Status:";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(3, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(41, 20);
            TitleLabel.TabIndex = 16;
            TitleLabel.Text = "Title:";
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
            PriorityBox.Items.AddRange(new object[] { "All", "Low", "Normal", "High" });
            PriorityBox.Location = new Point(277, 39);
            PriorityBox.Name = "PriorityBox";
            PriorityBox.Size = new Size(110, 28);
            PriorityBox.TabIndex = 19;
            // 
            // StatusBox
            // 
            StatusBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusBox.FormattingEnabled = true;
            StatusBox.Items.AddRange(new object[] { "All", "Open", "Pending", "Resolved", "Closed" });
            StatusBox.Location = new Point(139, 37);
            StatusBox.Name = "StatusBox";
            StatusBox.Size = new Size(110, 28);
            StatusBox.TabIndex = 20;
            // 
            // StarterDateTime
            // 
            StarterDateTime.Location = new Point(61, 3);
            StarterDateTime.Name = "StarterDateTime";
            StarterDateTime.Size = new Size(250, 27);
            StarterDateTime.TabIndex = 21;
            // 
            // EndDateTime
            // 
            EndDateTime.Location = new Point(61, 44);
            EndDateTime.Name = "EndDateTime";
            EndDateTime.Size = new Size(250, 27);
            EndDateTime.TabIndex = 22;
            EndDateTime.Value = new DateTime(2024, 10, 30, 0, 0, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 3);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 23;
            label5.Text = "From:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 49);
            label6.Name = "label6";
            label6.Size = new Size(32, 20);
            label6.TabIndex = 24;
            label6.Text = "Till:";
            // 
            // TicketSortByLabel
            // 
            TicketSortByLabel.AutoSize = true;
            TicketSortByLabel.Location = new Point(405, 8);
            TicketSortByLabel.Name = "TicketSortByLabel";
            TicketSortByLabel.Size = new Size(59, 20);
            TicketSortByLabel.TabIndex = 25;
            TicketSortByLabel.Text = "Sort by:";
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
            label8.Location = new Point(11, 13);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 29;
            label8.Text = "Filter Results:";
            // 
            // FilterResultTextBox
            // 
            FilterResultTextBox.Location = new Point(11, 41);
            FilterResultTextBox.Name = "FilterResultTextBox";
            FilterResultTextBox.Size = new Size(242, 27);
            FilterResultTextBox.TabIndex = 30;
            FilterResultTextBox.TextChanged += FilterResultTextBox_TextChanged;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { ticketsToolStripMenuItem, employeeToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 3, 0, 3);
            menuStrip.Size = new Size(1032, 30);
            menuStrip.TabIndex = 32;
            menuStrip.Text = "menuStrip1";
            // 
            // ticketsToolStripMenuItem
            // 
            ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            ticketsToolStripMenuItem.Size = new Size(68, 24);
            ticketsToolStripMenuItem.Text = "Tickets";
            ticketsToolStripMenuItem.Click += ticketsToolStripMenuItem_Click;
            // 
            // employeeToolStripMenuItem
            // 
            employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            employeeToolStripMenuItem.Size = new Size(89, 24);
            employeeToolStripMenuItem.Text = "Employee";
            employeeToolStripMenuItem.Click += employeeToolStripMenuItem_Click;
            // 
            // TicketFilterPanel
            // 
            TicketFilterPanel.Controls.Add(SortByBoxTickets);
            TicketFilterPanel.Controls.Add(PriorityBox);
            TicketFilterPanel.Controls.Add(StatusBox);
            TicketFilterPanel.Controls.Add(TitleTextbox_search);
            TicketFilterPanel.Controls.Add(TitleLabel);
            TicketFilterPanel.Controls.Add(TicketSortByLabel);
            TicketFilterPanel.Controls.Add(StatusLabel);
            TicketFilterPanel.Controls.Add(PriorityLabel);
            TicketFilterPanel.Location = new Point(33, 72);
            TicketFilterPanel.Name = "TicketFilterPanel";
            TicketFilterPanel.Size = new Size(541, 67);
            TicketFilterPanel.TabIndex = 33;
            // 
            // EmployeePanel
            // 
            EmployeePanel.Controls.Add(ActivityComboBox);
            EmployeePanel.Controls.Add(RoleComboBox);
            EmployeePanel.Controls.Add(SortByBoxEmployee);
            EmployeePanel.Controls.Add(label1);
            EmployeePanel.Controls.Add(NameSearchBox);
            EmployeePanel.Controls.Add(EmployeeSortByLabel);
            EmployeePanel.Controls.Add(label9);
            EmployeePanel.Controls.Add(RoleLabel);
            EmployeePanel.Controls.Add(EmployeeStatusLabel);
            EmployeePanel.Location = new Point(33, 80);
            EmployeePanel.Name = "EmployeePanel";
            EmployeePanel.Size = new Size(541, 59);
            EmployeePanel.TabIndex = 25;
            // 
            // ActivityComboBox
            // 
            ActivityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ActivityComboBox.FormattingEnabled = true;
            ActivityComboBox.Items.AddRange(new object[] { "Active", "Inactive\t" });
            ActivityComboBox.Location = new Point(283, 27);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(110, 28);
            ActivityComboBox.TabIndex = 27;
            // 
            // RoleComboBox
            // 
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Items.AddRange(new object[] { "All", "Employee", "Admin" });
            RoleComboBox.Location = new Point(149, 25);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(110, 28);
            RoleComboBox.TabIndex = 28;
            // 
            // SortByBoxEmployee
            // 
            SortByBoxEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByBoxEmployee.FormattingEnabled = true;
            SortByBoxEmployee.Items.AddRange(new object[] { "Username", "Name", "Email", "Role" });
            SortByBoxEmployee.Location = new Point(406, 27);
            SortByBoxEmployee.Name = "SortByBoxEmployee";
            SortByBoxEmployee.Size = new Size(110, 28);
            SortByBoxEmployee.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, -1);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 41;
            label1.Text = "Name:";
            // 
            // NameSearchBox
            // 
            NameSearchBox.Location = new Point(3, 27);
            NameSearchBox.Name = "NameSearchBox";
            NameSearchBox.PlaceholderText = "Search";
            NameSearchBox.Size = new Size(125, 27);
            NameSearchBox.TabIndex = 40;
            // 
            // EmployeeSortByLabel
            // 
            EmployeeSortByLabel.AutoSize = true;
            EmployeeSortByLabel.Location = new Point(406, -1);
            EmployeeSortByLabel.Name = "EmployeeSortByLabel";
            EmployeeSortByLabel.Size = new Size(59, 20);
            EmployeeSortByLabel.TabIndex = 39;
            EmployeeSortByLabel.Text = "Sort by:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 8);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 36;
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(149, -1);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(42, 20);
            RoleLabel.TabIndex = 37;
            RoleLabel.Text = "Role:";
            // 
            // EmployeeStatusLabel
            // 
            EmployeeStatusLabel.AutoSize = true;
            EmployeeStatusLabel.Location = new Point(283, -1);
            EmployeeStatusLabel.Name = "EmployeeStatusLabel";
            EmployeeStatusLabel.Size = new Size(52, 20);
            EmployeeStatusLabel.TabIndex = 38;
            EmployeeStatusLabel.Text = "Status:";
            // 
            // checkBoxFilterDate
            // 
            checkBoxFilterDate.AutoSize = true;
            checkBoxFilterDate.Location = new Point(587, 72);
            checkBoxFilterDate.Name = "checkBoxFilterDate";
            checkBoxFilterDate.Size = new Size(118, 24);
            checkBoxFilterDate.TabIndex = 34;
            checkBoxFilterDate.Text = "Filter by date";
            checkBoxFilterDate.UseVisualStyleBackColor = true;
            checkBoxFilterDate.CheckedChanged += checkBoxFilterDate_CheckedChanged;
            // 
            // TicketDatePanel
            // 
            TicketDatePanel.Controls.Add(EndDateTime);
            TicketDatePanel.Controls.Add(StarterDateTime);
            TicketDatePanel.Controls.Add(label5);
            TicketDatePanel.Controls.Add(label6);
            TicketDatePanel.Location = new Point(395, 541);
            TicketDatePanel.Name = "TicketDatePanel";
            TicketDatePanel.Size = new Size(311, 76);
            TicketDatePanel.TabIndex = 35;
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(panel1);
            ResultPanel.Controls.Add(label8);
            ResultPanel.Controls.Add(FilterResultTextBox);
            ResultPanel.Location = new Point(741, 137);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(250, 75);
            ResultPanel.TabIndex = 42;
            // 
            // panel1
            // 
            panel1.Location = new Point(11, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(242, 89);
            panel1.TabIndex = 43;
            // 
            // SelectSpecificEmployeeTicket
            // 
            SelectSpecificEmployeeTicket.BackColor = Color.FromArgb(38, 38, 38);
            SelectSpecificEmployeeTicket.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            SelectSpecificEmployeeTicket.Location = new Point(379, 541);
            SelectSpecificEmployeeTicket.Name = "SelectSpecificEmployeeTicket";
            SelectSpecificEmployeeTicket.Size = new Size(110, 57);
            SelectSpecificEmployeeTicket.TabIndex = 42;
            SelectSpecificEmployeeTicket.Text = "Select Employee Ticket";
            SelectSpecificEmployeeTicket.UseVisualStyleBackColor = false;
            // 
            // PercentagesLabel
            // 
            PercentagesLabel.AutoSize = true;
            PercentagesLabel.Location = new Point(8, 0);
            PercentagesLabel.Name = "PercentagesLabel";
            PercentagesLabel.Size = new Size(91, 20);
            PercentagesLabel.TabIndex = 31;
            PercentagesLabel.Text = "Percentages:";
            // 
            // panel2
            // 
            panel2.Controls.Add(OpenLabel);
            panel2.Controls.Add(PercentagesLabel);
            panel2.Controls.Add(PendingLabel);
            panel2.Controls.Add(ResolvedLabel);
            panel2.Controls.Add(ClosedLabel);
            panel2.Location = new Point(744, 218);
            panel2.Name = "panel2";
            panel2.Size = new Size(247, 89);
            panel2.TabIndex = 43;
            // 
            // OpenLabel
            // 
            OpenLabel.AutoSize = true;
            OpenLabel.Location = new Point(3, 30);
            OpenLabel.Name = "OpenLabel";
            OpenLabel.Size = new Size(0, 20);
            OpenLabel.TabIndex = 44;
            // 
            // PendingLabel
            // 
            PendingLabel.AutoSize = true;
            PendingLabel.Location = new Point(3, 68);
            PendingLabel.Name = "PendingLabel";
            PendingLabel.Size = new Size(0, 20);
            PendingLabel.TabIndex = 45;
            // 
            // ResolvedLabel
            // 
            ResolvedLabel.AutoSize = true;
            ResolvedLabel.Location = new Point(130, 30);
            ResolvedLabel.Name = "ResolvedLabel";
            ResolvedLabel.Size = new Size(0, 20);
            ResolvedLabel.TabIndex = 46;
            // 
            // ClosedLabel
            // 
            ClosedLabel.AutoSize = true;
            ClosedLabel.Location = new Point(130, 68);
            ClosedLabel.Name = "ClosedLabel";
            ClosedLabel.Size = new Size(0, 20);
            ClosedLabel.TabIndex = 47;
            // 
            // ListMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(1032, 623);
            Controls.Add(panel2);
            Controls.Add(SelectSpecificEmployeeTicket);
            Controls.Add(ResultPanel);
            Controls.Add(EmployeePanel);
            Controls.Add(checkBoxFilterDate);
            Controls.Add(TicketFilterPanel);
            Controls.Add(UpdateListButton);
            Controls.Add(FilterOnLabel);
            Controls.Add(LogoutB);
            Controls.Add(AdminTicketPanel);
            Controls.Add(DescriptionBox);
            Controls.Add(DeleteB);
            Controls.Add(UpdateB);
            Controls.Add(AddB);
            Controls.Add(MainListView);
            Controls.Add(menuStrip);
            Controls.Add(TicketDatePanel);
            ForeColor = Color.White;
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ListMainForm";
            AdminTicketPanel.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            TicketFilterPanel.ResumeLayout(false);
            TicketFilterPanel.PerformLayout();
            EmployeePanel.ResumeLayout(false);
            EmployeePanel.PerformLayout();
            TicketDatePanel.ResumeLayout(false);
            TicketDatePanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label FilterOnLabel;
        private Label PriorityLabel;
        private Label StatusLabel;
        private Label TitleLabel;
        private TextBox TitleTextbox_search;
        private ComboBox PriorityBox;
        private ComboBox StatusBox;
        private DateTimePicker StarterDateTime;
        private DateTimePicker EndDateTime;
        private Label label5;
        private Label label6;
        private Label TicketSortByLabel;
        private ComboBox SortByBoxTickets;
        private Button UpdateListButton;
        private Label label8;
        private TextBox FilterResultTextBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem ticketsToolStripMenuItem;
        private ToolStripMenuItem employeeToolStripMenuItem;
        private Panel TicketFilterPanel;
        private CheckBox checkBoxFilterDate;
        private Panel TicketDatePanel;
        private Panel EmployeePanel;
        private TextBox NameSearchBox;
        private Label EmployeeSortByLabel;
        private Label label9;
        private Label RoleLabel;
        private Label EmployeeStatusLabel;
        private Label label1;
        private ComboBox ActivityComboBox;
        private ComboBox RoleComboBox;
        private ComboBox SortByBoxEmployee;
        private Panel ResultPanel;
        private Button SelectSpecificEmployeeTicket;
        private Label PercentagesLabel;
        private Panel panel1;
        private Panel panel2;
        private Label OpenLabel;
        private Label PendingLabel;
        private Label ResolvedLabel;
        private Label ClosedLabel;
    }
}
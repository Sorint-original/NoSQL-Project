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
            menuStrip1 = new MenuStrip();
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
            SelectSpecificEmployeeTicket = new Button();
            AdminTicketPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            TicketFilterPanel.SuspendLayout();
            EmployeePanel.SuspendLayout();
            TicketDatePanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainListView
            // 
            MainListView.BackColor = Color.FromArgb(38, 38, 38);
            MainListView.ForeColor = Color.White;
            MainListView.FullRowSelect = true;
            MainListView.Location = new Point(29, 103);
            MainListView.Name = "MainListView";
            MainListView.Size = new Size(589, 289);
            MainListView.TabIndex = 0;
            MainListView.UseCompatibleStateImageBehavior = false;
            MainListView.SelectedIndexChanged += MainListView_SelectedIndexChanged;
            // 
            // AddB
            // 
            AddB.BackColor = Color.FromArgb(38, 38, 38);
            AddB.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            AddB.Location = new Point(29, 406);
            AddB.Name = "AddB";
            AddB.Size = new Size(96, 43);
            AddB.TabIndex = 1;
            AddB.Text = "Add";
            AddB.UseVisualStyleBackColor = false;
            AddB.Click += AddB_Click;
            // 
            // UpdateB
            // 
            UpdateB.BackColor = Color.FromArgb(38, 38, 38);
            UpdateB.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateB.Location = new Point(130, 406);
            UpdateB.Name = "UpdateB";
            UpdateB.Size = new Size(96, 43);
            UpdateB.TabIndex = 2;
            UpdateB.Text = "Update";
            UpdateB.UseVisualStyleBackColor = false;
            UpdateB.Click += UpdateB_Click;
            // 
            // DeleteB
            // 
            DeleteB.BackColor = Color.FromArgb(38, 38, 38);
            DeleteB.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteB.Location = new Point(232, 406);
            DeleteB.Name = "DeleteB";
            DeleteB.Size = new Size(96, 43);
            DeleteB.TabIndex = 3;
            DeleteB.Text = "Delete";
            DeleteB.UseVisualStyleBackColor = false;
            DeleteB.Click += DeleteB_Click;
            // 
            // DescriptionBox
            // 
            DescriptionBox.BackColor = Color.FromArgb(38, 38, 38);
            DescriptionBox.ForeColor = Color.White;
            DescriptionBox.Location = new Point(658, 296);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.ReadOnly = true;
            DescriptionBox.Size = new Size(212, 162);
            DescriptionBox.TabIndex = 4;
            // 
            // AdminTicketPanel
            // 
            AdminTicketPanel.Controls.Add(ArchSelectedB);
            AdminTicketPanel.Controls.Add(ArchListB);
            AdminTicketPanel.Location = new Point(658, 220);
            AdminTicketPanel.Name = "AdminTicketPanel";
            AdminTicketPanel.Size = new Size(212, 51);
            AdminTicketPanel.TabIndex = 5;
            // 
            // ArchSelectedB
            // 
            ArchSelectedB.BackColor = Color.FromArgb(38, 38, 38);
            ArchSelectedB.Location = new Point(107, 3);
            ArchSelectedB.Name = "ArchSelectedB";
            ArchSelectedB.Size = new Size(102, 47);
            ArchSelectedB.TabIndex = 0;
            ArchSelectedB.Text = "Archive selected";
            ArchSelectedB.UseVisualStyleBackColor = false;
            ArchSelectedB.Click += ArchSelectedB_Click;
            // 
            // ArchListB
            // 
            ArchListB.BackColor = Color.FromArgb(38, 38, 38);
            ArchListB.Location = new Point(0, 3);
            ArchListB.Name = "ArchListB";
            ArchListB.Size = new Size(102, 47);
            ArchListB.TabIndex = 1;
            ArchListB.Text = "Archive current list";
            ArchListB.UseVisualStyleBackColor = false;
            ArchListB.Click += ArchListB_Click;
            // 
            // UpdateListButton
            // 
            UpdateListButton.BackColor = Color.FromArgb(38, 38, 38);
            UpdateListButton.Location = new Point(508, 77);
            UpdateListButton.Margin = new Padding(3, 2, 3, 2);
            UpdateListButton.Name = "UpdateListButton";
            UpdateListButton.Size = new Size(110, 21);
            UpdateListButton.TabIndex = 28;
            UpdateListButton.Text = "Update list";
            UpdateListButton.UseVisualStyleBackColor = false;
            UpdateListButton.Click += UpdateListButton_Click;
            // 
            // LogoutB
            // 
            LogoutB.BackColor = Color.FromArgb(38, 38, 38);
            LogoutB.Location = new Point(817, 36);
            LogoutB.Name = "LogoutB";
            LogoutB.Size = new Size(75, 23);
            LogoutB.TabIndex = 6;
            LogoutB.Text = "Log out";
            LogoutB.UseVisualStyleBackColor = false;
            LogoutB.Click += LogoutB_Click;
            // 
            // FilterOnLabel
            // 
            FilterOnLabel.AutoSize = true;
            FilterOnLabel.ForeColor = Color.White;
            FilterOnLabel.Location = new Point(29, 33);
            FilterOnLabel.Name = "FilterOnLabel";
            FilterOnLabel.Size = new Size(53, 15);
            FilterOnLabel.TabIndex = 8;
            FilterOnLabel.Text = "Filter on:";
            // 
            // PriorityLabel
            // 
            PriorityLabel.AutoSize = true;
            PriorityLabel.ForeColor = Color.White;
            PriorityLabel.Location = new Point(242, 7);
            PriorityLabel.Name = "PriorityLabel";
            PriorityLabel.Size = new Size(48, 15);
            PriorityLabel.TabIndex = 11;
            PriorityLabel.Text = "Priority:";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.ForeColor = Color.White;
            StatusLabel.Location = new Point(122, 7);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(42, 15);
            StatusLabel.TabIndex = 15;
            StatusLabel.Text = "Status:";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(3, 7);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(32, 15);
            TitleLabel.TabIndex = 16;
            TitleLabel.Text = "Title:";
            // 
            // TitleTextbox_search
            // 
            TitleTextbox_search.Location = new Point(0, 29);
            TitleTextbox_search.Margin = new Padding(3, 2, 3, 2);
            TitleTextbox_search.Name = "TitleTextbox_search";
            TitleTextbox_search.PlaceholderText = "Search";
            TitleTextbox_search.Size = new Size(97, 23);
            TitleTextbox_search.TabIndex = 18;
            // 
            // PriorityBox
            // 
            PriorityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PriorityBox.FormattingEnabled = true;
            PriorityBox.Items.AddRange(new object[] { "All", "Low", "Normal", "High" });
            PriorityBox.Location = new Point(242, 29);
            PriorityBox.Margin = new Padding(3, 2, 3, 2);
            PriorityBox.Name = "PriorityBox";
            PriorityBox.Size = new Size(97, 23);
            PriorityBox.TabIndex = 19;
            // 
            // StatusBox
            // 
            StatusBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusBox.FormattingEnabled = true;
            StatusBox.Items.AddRange(new object[] { "All", "Open", "Pending", "Resolved", "Closed" });
            StatusBox.Location = new Point(122, 28);
            StatusBox.Margin = new Padding(3, 2, 3, 2);
            StatusBox.Name = "StatusBox";
            StatusBox.Size = new Size(97, 23);
            StatusBox.TabIndex = 20;
            // 
            // StarterDateTime
            // 
            StarterDateTime.Location = new Point(53, 2);
            StarterDateTime.Margin = new Padding(3, 2, 3, 2);
            StarterDateTime.Name = "StarterDateTime";
            StarterDateTime.Size = new Size(219, 23);
            StarterDateTime.TabIndex = 21;
            // 
            // EndDateTime
            // 
            EndDateTime.Location = new Point(53, 33);
            EndDateTime.Margin = new Padding(3, 2, 3, 2);
            EndDateTime.Name = "EndDateTime";
            EndDateTime.Size = new Size(219, 23);
            EndDateTime.TabIndex = 22;
            EndDateTime.Value = new DateTime(2024, 10, 30, 0, 0, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 2);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 23;
            label5.Text = "From:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 37);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 24;
            label6.Text = "Till:";
            // 
            // TicketSortByLabel
            // 
            TicketSortByLabel.AutoSize = true;
            TicketSortByLabel.Location = new Point(354, 6);
            TicketSortByLabel.Name = "TicketSortByLabel";
            TicketSortByLabel.Size = new Size(47, 15);
            TicketSortByLabel.TabIndex = 25;
            TicketSortByLabel.Text = "Sort by:";
            // 
            // SortByBoxTickets
            // 
            SortByBoxTickets.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByBoxTickets.FormattingEnabled = true;
            SortByBoxTickets.Items.AddRange(new object[] { "New to Old", "Old to New" });
            SortByBoxTickets.Location = new Point(354, 29);
            SortByBoxTickets.Margin = new Padding(3, 2, 3, 2);
            SortByBoxTickets.Name = "SortByBoxTickets";
            SortByBoxTickets.Size = new Size(97, 23);
            SortByBoxTickets.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 10);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 29;
            label8.Text = "Filter Results:";
            // 
            // FilterResultTextBox
            // 
            FilterResultTextBox.Location = new Point(10, 31);
            FilterResultTextBox.Margin = new Padding(3, 2, 3, 2);
            FilterResultTextBox.Name = "FilterResultTextBox";
            FilterResultTextBox.Size = new Size(212, 23);
            FilterResultTextBox.TabIndex = 30;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ticketsToolStripMenuItem, employeeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(903, 24);
            menuStrip1.TabIndex = 32;
            menuStrip1.Text = "menuStrip1";
            // 
            // ticketsToolStripMenuItem
            // 
            ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            ticketsToolStripMenuItem.Size = new Size(55, 20);
            ticketsToolStripMenuItem.Text = "Tickets";
            ticketsToolStripMenuItem.Click += ticketsToolStripMenuItem_Click;
            // 
            // employeeToolStripMenuItem
            // 
            employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            employeeToolStripMenuItem.Size = new Size(71, 20);
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
            TicketFilterPanel.Location = new Point(29, 54);
            TicketFilterPanel.Margin = new Padding(3, 2, 3, 2);
            TicketFilterPanel.Name = "TicketFilterPanel";
            TicketFilterPanel.Size = new Size(473, 50);
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
            EmployeePanel.Location = new Point(29, 60);
            EmployeePanel.Margin = new Padding(3, 2, 3, 2);
            EmployeePanel.Name = "EmployeePanel";
            EmployeePanel.Size = new Size(473, 44);
            EmployeePanel.TabIndex = 25;
            // 
            // ActivityComboBox
            // 
            ActivityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ActivityComboBox.FormattingEnabled = true;
            ActivityComboBox.Items.AddRange(new object[] { "Active", "Inactive\t" });
            ActivityComboBox.Location = new Point(248, 20);
            ActivityComboBox.Margin = new Padding(3, 2, 3, 2);
            ActivityComboBox.Name = "ActivityComboBox";
            ActivityComboBox.Size = new Size(97, 23);
            ActivityComboBox.TabIndex = 27;
            // 
            // RoleComboBox
            // 
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Items.AddRange(new object[] { "All", "Employee", "Admin" });
            RoleComboBox.Location = new Point(130, 19);
            RoleComboBox.Margin = new Padding(3, 2, 3, 2);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(97, 23);
            RoleComboBox.TabIndex = 28;
            // 
            // SortByBoxEmployee
            // 
            SortByBoxEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByBoxEmployee.FormattingEnabled = true;
            SortByBoxEmployee.Items.AddRange(new object[] { "Username", "Name", "Email", "Role" });
            SortByBoxEmployee.Location = new Point(355, 20);
            SortByBoxEmployee.Margin = new Padding(3, 2, 3, 2);
            SortByBoxEmployee.Name = "SortByBoxEmployee";
            SortByBoxEmployee.Size = new Size(97, 23);
            SortByBoxEmployee.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, -1);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 41;
            label1.Text = "Name:";
            // 
            // NameSearchBox
            // 
            NameSearchBox.Location = new Point(3, 20);
            NameSearchBox.Margin = new Padding(3, 2, 3, 2);
            NameSearchBox.Name = "NameSearchBox";
            NameSearchBox.PlaceholderText = "Search";
            NameSearchBox.Size = new Size(110, 23);
            NameSearchBox.TabIndex = 40;
            // 
            // EmployeeSortByLabel
            // 
            EmployeeSortByLabel.AutoSize = true;
            EmployeeSortByLabel.Location = new Point(355, -1);
            EmployeeSortByLabel.Name = "EmployeeSortByLabel";
            EmployeeSortByLabel.Size = new Size(47, 15);
            EmployeeSortByLabel.TabIndex = 39;
            EmployeeSortByLabel.Text = "Sort by:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 6);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 36;
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(130, -1);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(33, 15);
            RoleLabel.TabIndex = 37;
            RoleLabel.Text = "Role:";
            // 
            // EmployeeStatusLabel
            // 
            EmployeeStatusLabel.AutoSize = true;
            EmployeeStatusLabel.Location = new Point(248, -1);
            EmployeeStatusLabel.Name = "EmployeeStatusLabel";
            EmployeeStatusLabel.Size = new Size(42, 15);
            EmployeeStatusLabel.TabIndex = 38;
            EmployeeStatusLabel.Text = "Status:";
            // 
            // checkBoxFilterDate
            // 
            checkBoxFilterDate.AutoSize = true;
            checkBoxFilterDate.Location = new Point(514, 54);
            checkBoxFilterDate.Margin = new Padding(3, 2, 3, 2);
            checkBoxFilterDate.Name = "checkBoxFilterDate";
            checkBoxFilterDate.Size = new Size(94, 19);
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
            TicketDatePanel.Location = new Point(346, 406);
            TicketDatePanel.Margin = new Padding(3, 2, 3, 2);
            TicketDatePanel.Name = "TicketDatePanel";
            TicketDatePanel.Size = new Size(272, 57);
            TicketDatePanel.TabIndex = 35;
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(label8);
            ResultPanel.Controls.Add(FilterResultTextBox);
            ResultPanel.Location = new Point(648, 103);
            ResultPanel.Margin = new Padding(3, 2, 3, 2);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(219, 56);
            ResultPanel.TabIndex = 42;
            // 
            // SelectSpecificEmployeeTicket
            // 
            SelectSpecificEmployeeTicket.BackColor = Color.FromArgb(38, 38, 38);
            SelectSpecificEmployeeTicket.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            SelectSpecificEmployeeTicket.Location = new Point(332, 406);
            SelectSpecificEmployeeTicket.Margin = new Padding(3, 2, 3, 2);
            SelectSpecificEmployeeTicket.Name = "SelectSpecificEmployeeTicket";
            SelectSpecificEmployeeTicket.Size = new Size(96, 43);
            SelectSpecificEmployeeTicket.TabIndex = 42;
            SelectSpecificEmployeeTicket.Text = "Select Employee Ticket";
            SelectSpecificEmployeeTicket.UseVisualStyleBackColor = false;
            // 
            // ListMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 52);
            ClientSize = new Size(903, 467);
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
            Controls.Add(menuStrip1);
            Controls.Add(TicketDatePanel);
            ForeColor = Color.White;
            MainMenuStrip = menuStrip1;
            Name = "ListMainForm";
            AdminTicketPanel.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            TicketFilterPanel.ResumeLayout(false);
            TicketFilterPanel.PerformLayout();
            EmployeePanel.ResumeLayout(false);
            EmployeePanel.PerformLayout();
            TicketDatePanel.ResumeLayout(false);
            TicketDatePanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
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
        private MenuStrip menuStrip1;
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
    }
}
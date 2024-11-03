﻿using Model;
using MongoDB.Driver;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ListMainForm : Form
    {
        private bool showTickets; // If the list displays tickets or emplyees
        private Employee LogedEmployee;
        private TicketService ticketService;
        private EmployeeService employeeService;
        private Employee QuerryedEmployee;
        private List<Ticket> unfileredTicketList;
        private List<Label> percentagesLabels;
        public ListMainForm(Employee employee)
        {
            InitializeComponent();
            LogedEmployee = employee;
            MainListView.View = View.Details;
            ticketService = new TicketService();
            employeeService = new EmployeeService();
            FormSetup();
        }
        public void FormSetup()
        {
            showTickets = true;
            SetupListStructure();
            RoleBasedSetup();
            UpdateAccessLabel();
            SetupPercentagesLabelList();
            ShowTicektSpecificPanels();
            RefreshListView();
            EndDateTime.Value = EndDateTime.Value.AddDays(1);
            TicketDatePanel.Hide();
        }
        public void SetupPercentagesLabelList()
        {
            percentagesLabels = new List<Label>();
            percentagesLabels.Add(OpenLabel);
            percentagesLabels.Add(PendingLabel);
            percentagesLabels.Add(ResolvedLabel);
            percentagesLabels.Add(ClosedLabel);
        }
        public void RoleBasedSetup()
        {
            if (LogedEmployee.Role == Role.admin)
            {
                QuerryedEmployee = null;
            }
            else
            {
                QuerryedEmployee = LogedEmployee;
                AdminTicketPanel.Hide();
                menuStrip.Hide();
            }
        }
        public void ShowTicektSpecificPanels()
        {
            //show ticket panels
            if (LogedEmployee.Role == Role.admin)
            {
                AdminTicketPanel.Show();
            }
            TicketFilterPanel.Show();
            checkBoxFilterDate.Show();
            DescriptionBox.Show();
            ResultPanel.Show();
            PercentagesPanel.Show();
            AccessLabel.Show();
            checkBoxFilterDate.Checked = false;
            //hide employee panels
            SelectSpecificEmployeeTickets.Hide();
            TicketDatePanel.Hide();
            EmployeePanel.Hide();
        }
        public void ShowEmployeeSpecificPanels()
        {
            //show employee panels
            EmployeePanel.Show();
            SelectSpecificEmployeeTickets.Show();

            //hide Ticket panels
            AdminTicketPanel.Hide();
            TicketFilterPanel.Hide();
            checkBoxFilterDate.Hide();
            TicketDatePanel.Hide();
            DescriptionBox.Hide();
            ResultPanel.Hide();
            PercentagesPanel.Hide();
            AccessLabel.Hide();
        }
        public void SetupListStructure()
        {
            SetupFilterUI();
            if (showTickets)
            {
                SetupListviewTicket();
            }
            else
            {
                SetupListviewEmployee();
            }
        }
        public void SetupFilterUI()
        {
            PriorityBox.SelectedIndex = 0;
            StatusBox.SelectedIndex = 0;
            SortByBoxTickets.SelectedIndex = 0;
            RoleComboBox.SelectedIndex = 0;
            ActivityComboBox.SelectedIndex = 0;
            SortByBoxEmployee.SelectedIndex = 0;
        }
        public void AddTicketsToList(List<Ticket> list)
        {
            foreach (Ticket ticket in list)
            {
                ListViewItem li = new ListViewItem(ticket.Title);
                li.SubItems.Add(ticket.Status.ToString());
                li.SubItems.Add(ticket.Priority.ToString());
                li.SubItems.Add(ticket.CreationTime.ToString());
                if (ticket.SolutionTime == DateTime.MinValue)
                {
                    li.SubItems.Add("NA");
                }
                else
                {
                    li.SubItems.Add(ticket.SolutionTime.ToString());
                }
                li.Tag = ticket;   // link ticket object to listview item
                MainListView.Items.Add(li);
            }
        }
        public void AddEmployeeToList(List<Employee> list)
        {
            foreach (Employee employee in list)
            {
                ListViewItem li = new ListViewItem(employee.UserName);
                li.SubItems.Add(employee.Name);
                li.SubItems.Add(employee.Email);
                li.SubItems.Add(employee.Role.ToString());
                li.SubItems.Add(employee.IsActive.ToString());
                li.Tag = employee;   // link employee object to listview item
                MainListView.Items.Add(li);
            }
        }
        //Refreshs the elements in the listview based on the currnt display case
        public void RefreshListView()
        {
            if (showTickets)
            {
                UpdateTickets();
            }
            else
            {
                UpdateEmployees();
            }
        }
        //Add the columns in the listview to display tickets
        public void SetupListviewTicket()
        {
            int columnWidth = (MainListView.Width - 10) / 5;
            MainListView.Items.Clear();
            MainListView.Columns.Clear();
            MainListView.Columns.Add("Title", columnWidth);
            MainListView.Columns.Add("Status", columnWidth);
            MainListView.Columns.Add("Priority", columnWidth);
            MainListView.Columns.Add("Creation Date", columnWidth);
            MainListView.Columns.Add("Solution Date", columnWidth);
        }
        //Add the columns in the listview to display employee
        public void SetupListviewEmployee()
        {
            int columnWidth = (MainListView.Width - 10) / 5;
            MainListView.Items.Clear();
            MainListView.Columns.Clear();
            MainListView.Columns.Add("UserName", columnWidth);
            MainListView.Columns.Add("Name", columnWidth);
            MainListView.Columns.Add("Email", columnWidth);
            MainListView.Columns.Add("Role", columnWidth);
            MainListView.Columns.Add("Active", columnWidth);
        }

        public void UpdateTickets()
        {
            UpdatePercentages();
            List<FilterDefinition<Ticket>> filters = ticketService.GetFilters(QuerryedEmployee, TitleTextbox_search.Text, (Status)StatusBox.SelectedIndex, (Priority)PriorityBox.SelectedIndex, checkBoxFilterDate.Checked, StarterDateTime.Value, EndDateTime.Value);
            if (filters != null)
            {
                MainListView.Items.Clear();
                unfileredTicketList = ticketService.CustomQuerry(filters, ticketService.GetSort(SortByBoxTickets.SelectedIndex));
                AddTicketsToList(ticketService.FilterTickets(unfileredTicketList, FilterResultTextBox.Text));
            }
            else
            {
                MessageBox.Show("The date filters was incorectly entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateEmployees()
        {
            MainListView.Items.Clear();
            List<FilterDefinition<Employee>> filters = employeeService.GetFilters(NameSearchBox.Text, (Role)RoleComboBox.SelectedIndex, ActivityComboBox.SelectedIndex == 0);
            AddEmployeeToList(employeeService.CustomQuerry(filters, employeeService.GetSort(SortByBoxEmployee.SelectedIndex)));
        }
        private void AddB_Click(object sender, EventArgs e)// add object functionality
        {
            Form form;
            if (showTickets)//it opens the respective creation form based on which objects are displayed
            {
                form = new TicketCreateForm(LogedEmployee.Role);
            }
            else
            {
                form = new EmployeeCreateForm();
            }
            form.ShowDialog();
            RefreshListView();
        }

        private void UpdateB_Click(object sender, EventArgs e)//Update button functionality
        {
            if (MainListView.SelectedItems.Count > 0) // if nothing is selected in the list it does nothing
            {
                Form form;
                if (showTickets)//it opens the respective creation form based on which objects are displayed
                {
                    form = new TicketCreateForm(LogedEmployee.Role, (Ticket)MainListView.SelectedItems[0].Tag);
                }
                else
                {
                    form = new EmployeeCreateForm((Employee)MainListView.SelectedItems[0].Tag);
                }
                form.ShowDialog();
                RefreshListView();
            }
        }


        private void DeleteB_Click(object sender, EventArgs e) // Delete button functionality
        {
            if (MainListView.SelectedItems.Count > 0)// if nothing is selected in the list it does nothing
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the selected items?", "Delete Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (ListViewItem item in MainListView.SelectedItems)//goes through all selected items
                    {
                        DeleteItem(item);
                    }
                }
                RefreshListView();
            }
        }
        private void DeleteItem(ListViewItem item)// 
        {
            if (showTickets)
            {
                // "Deleted" tickets have their status set to closed
                Ticket ticket = (Ticket)item.Tag;
                ticketService.CloseTicket(ticket);
            }
            else
            {
                // Employees are deactivated
                Employee employee = (Employee)item.Tag;
                employeeService.DeactivateEmployee(employee);
            }
        }
        private void ArchListB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to archive the current list of tickets?", "Archive Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ticketService.ArchiveTickets(ticketService.FilterTickets(unfileredTicketList, FilterResultTextBox.Text));
            }
            RefreshListView();
        }
        private void ArchSelectedB_Click(object sender, EventArgs e)
        {
            if (MainListView.SelectedItems.Count > 0)// if nothing is selected in the list it does nothing
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to archive the selected tickets?", "Archive Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<Ticket> tickets = new List<Ticket>();
                    foreach (ListViewItem item in MainListView.SelectedItems)//goes through all selected items
                    {
                        tickets.Add((Ticket)item.Tag);
                    }
                    ticketService.ArchiveTickets(tickets);
                }
                RefreshListView();
            }
        }
        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)// this methods activates each time the user presses and selects or unelects an element in the listview
        {
            if (showTickets && MainListView.SelectedItems.Count > 0)
            {
                //it dislays the description of the ticket in a specific description box
                Ticket ticket = (Ticket)MainListView.SelectedItems[0].Tag;
                DescriptionBox.Text = ticket.Description;
            }
        }
        private void LogoutB_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }
        private void UpdateListButton_Click(object sender, EventArgs e)
        {
            FilterResultTextBox.Text = string.Empty;
            RefreshListView();
        }
        private void FilterResultTextBox_TextChanged(object sender, EventArgs e)
        {
            MainListView.Items.Clear();
            AddTicketsToList(ticketService.FilterTickets(unfileredTicketList, FilterResultTextBox.Text));
        }
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEmployeeSpecificPanels();
            showTickets = false;
            QuerryedEmployee = null;
            SetupListStructure();
            RefreshListView();
        }
        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTicektSpecificPanels();
            QuerryedEmployee = null;
            UpdateAccessLabel();
            showTickets = true;
            SetupListStructure();
            RefreshListView();
        }
        private void checkBoxFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxFilterDate.Checked)
            {
                TicketDatePanel.Hide();
            }
            else
            {
                TicketDatePanel.Show();
            }
        }
        private void UpdatePercentages()
        {
            Dictionary<Status, float> Percentages = ticketService.GetPercentages(QuerryedEmployee);
            for(int i = 1; i <= 4; i++)
            {
                Status currentStatus = (Status)i;
                if (Percentages.ContainsKey(currentStatus))
                {
                    percentagesLabels[i - 1].Text = $"{currentStatus}: {Percentages[currentStatus]}%";
                }
                else
                {
                    percentagesLabels[i - 1].Text = $"{currentStatus}: 0%";
                }
            }
        }
        private void UpdateAccessLabel()
        {
            if (QuerryedEmployee == null)
            {
                AccessLabel.Text = "You are accessing: All tickets";
            }
            else
            {
                AccessLabel.Text = $"You are accessing: {QuerryedEmployee.UserName} tickets";
            }
        }
        private void SelectSpecificEmployeeTickets_Click(object sender, EventArgs e)
        {
            if (MainListView.SelectedItems.Count > 0) {
                QuerryedEmployee = (Employee)MainListView.SelectedItems[0].Tag;
                UpdateAccessLabel();
                showTickets = true;
                ShowTicektSpecificPanels();
                SetupListStructure();
                RefreshListView();
            }
            else
            {
                MessageBox.Show($"You need to select an employee to see his specific tickets", "Error", MessageBoxButtons.OK);
            }
        }
    }
}

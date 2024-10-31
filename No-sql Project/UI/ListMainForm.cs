using Model;
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
            UpdateAccessLabel();
            ShowTicektSpecificPanels();
            RefreshListView();
            EndDateTime.Value = EndDateTime.Value.AddDays(1);
            TicketDatePanel.Hide();

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
            SelectSpecificEmployeeTicket.Hide();
            TicketDatePanel.Hide();
            EmployeePanel.Hide();
        }

        public void ShowEmployeeSpecificPanels()
        {
            //show employee panels
            EmployeePanel.Show();
            SelectSpecificEmployeeTicket.Show();

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
            SetupTicketFilterUI();
            if (showTickets)
            {
                SetupListviewTicket();
            }
            else
            {
                SetupListviewEmployee();
            }
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

                li.Tag = ticket;   // link lecturer object to listview item
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

                li.Tag = employee;   // link lecturer object to listview item
                MainListView.Items.Add(li);
            }

        }

        //Refreshs the elements in the listview based on the currnt display case
        public void RefreshListView()
        {
            if (showTickets)
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
            else
            {
                MainListView.Items.Clear();
                List<FilterDefinition<Employee>> filters = employeeService.GetFilters(NameSearchBox.Text, (Role)RoleComboBox.SelectedIndex, ActivityComboBox.SelectedIndex == 0);
                AddEmployeeToList(employeeService.CustomQuerry(filters, employeeService.GetSort(SortByBoxEmployee.SelectedIndex)));
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

        public void SetupTicketFilterUI()
        {
            PriorityBox.SelectedIndex = 0;
            StatusBox.SelectedIndex = 0;
            SortByBoxTickets.SelectedIndex = 0;
            RoleComboBox.SelectedIndex = 0;
            ActivityComboBox.SelectedIndex = 0;
            SortByBoxEmployee.SelectedIndex = 0;
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
                // Employees are removed from the database
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
            SetupListStructure();
            RefreshListView();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTicektSpecificPanels();
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
            if (Percentages.ContainsKey(Status.open))
            {
                OpenLabel.Text = $"Open: {Percentages[Status.open]}%";

            }
            else
            {
                OpenLabel.Text = "Open: 0%";
            }
            if (Percentages.ContainsKey(Status.pending))
            {
                PendingLabel.Text = $"Pending: {Percentages[Status.pending]}%";

            }
            else
            {
                PendingLabel.Text = "Pending: 0%";
            }
            if (Percentages.ContainsKey(Status.resolved))
            {
                ResolvedLabel.Text = $"Resolved: {Percentages[Status.resolved]}%";

            }
            else
            {
                ResolvedLabel.Text = "Resolved: 0%";
            }
            if (Percentages.ContainsKey(Status.closed))
            {
                ClosedLabel.Text = $"Closed: {Percentages[Status.closed]}%";

            }
            else
            {
                ClosedLabel.Text = "Closed: 0%";
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

    }
}

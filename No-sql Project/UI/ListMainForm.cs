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
            }
            
            ShowTicektSpecificPanels();
            RefreshListView();
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
            TicketDatePanel.Hide();
            checkBoxFilterDate.Checked = false;
            //hide employee panels
            SelectSpecificEmployeeTicket.Hide();
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
        }

        public void SetupListStructure()
        {
            if (showTickets)
            {
                SetupTicketFilterUI();
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
                li.SubItems.Add(employee.IsDeleted.ToString());

                li.Tag = employee;   // link lecturer object to listview item
                MainListView.Items.Add(li);
            }

        }

        //Refreshs the elements in the listview based on the currnt display case
        public void RefreshListView()
        {
            MainListView.Items.Clear();
            if (showTickets)
            {
                unfileredTicketList = ticketService.CustomQuerry(GetFilters(), GetSort());
                AddTicketsToList(FilterTickets());
            }
            else
            {

            }
        }

        public List<Ticket> FilterTickets()
        {
            return ticketService.Filtertickets(unfileredTicketList, FilterResultTextBox.Text);
        }

        public List<FilterDefinition<Ticket>> GetFilters()
        {
            List<FilterDefinition<Ticket>> filters = new List<FilterDefinition<Ticket>>();
            //checks if it filters by an employee id
            if (QuerryedEmployee != null)
            {
                filters.Add(ticketService.FilterTicketsByEmployee(QuerryedEmployee));
            }
            //check tile search

            //check Status filter 
            if (StatusBox.SelectedIndex > 0)
            {
                filters.Add(getStatusFilter());
            }
            //check Priority filter
            if (PriorityBox.SelectedIndex > 0)
            {
                filters.Add(getPriorityFilter());
            }
            //check date filters
            if (checkBoxFilterDate.Checked)
            {
                DateTime StartDate = StarterDateTime.Value;
                DateTime EndDate = EndDateTime.Value;
                int dateCase = CheckDateErrors(StartDate, EndDate);
                if (dateCase > 0)
                {
                    GetErrorMessage(dateCase);
                    return null;
                }
                else
                {
                    filters.Add(ticketService.FilterAfterSpecificDate(StartDate));
                    filters.Add(ticketService.FilterAfterSpecificDate(EndDate));
                }
            }
            return filters;
        }

        public int CheckDateErrors(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate > EndDate)
            {
                return 1;
            }
            else if (StartDate > DateTime.Now)
            {
                return 2;
            }
            return 0;
        }

        public void GetErrorMessage(int errorcase)
        {
            switch (errorcase)
            {
                case 1:
                    MessageBox.Show("the start date can't be after the end date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("the start date can't be in the future", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }

        public FilterDefinition<Ticket> getStatusFilter()
        {
            switch (StatusBox.SelectedIndex)
            {
                case 1:
                    return ticketService.FilterByStatus(Status.open);
                case 2:
                    return ticketService.FilterByStatus(Status.pending);
                case 3:
                    return ticketService.FilterByStatus(Status.resolved);
                case 4:
                    return ticketService.FilterByStatus(Status.closed);
            }
            return null;
        }

        public FilterDefinition<Ticket> getPriorityFilter()
        {
            switch (PriorityBox.SelectedIndex)
            {
                case 1:
                    return ticketService.FilterTicketsByPriority(Priority.high);
                case 2:
                    return ticketService.FilterTicketsByPriority(Priority.normal);
                case 3:
                    return ticketService.FilterTicketsByPriority(Priority.low);
            }
            return null;
        }
        public SortDefinition<Ticket> GetSort()
        {
            switch (SortByBoxTickets.SelectedIndex)
            {
                case 0:
                    return ticketService.SortByCreationDateDescending();
                case 1:
                    return ticketService.SortByCreationDateAscending();
            }
            return null;
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
            MainListView.Columns.Add("Status", columnWidth);
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
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the selected items", "Delete Warning", MessageBoxButtons.YesNo);
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
            AddTicketsToList(FilterTickets());
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEmployeeSpecificPanels();
            showTickets = false;
            SetupListStructure();
            RefreshListView();
        }

        private void ticketsToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}

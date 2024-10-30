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

        }

        public void ShowTicektSpecificPanels()
        {
            //show ticket panels
            if (LogedEmployee.Role == Role.admin)
            {
                AdminTicketPanel.Show();
            }
            //hide employee panels
        }

        public void ShowEmployeeSpecificPanels()
        {
            //show employee panels

            //hide Ticket panels
            AdminTicketPanel.Hide();
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
                AddTicketsToList(ticketService.CustomQuerry(GetFilters(), GetSort()));
            }
            else
            {

            }
        }

        public List<FilterDefinition<Ticket>> GetFilters()
        {
            List<FilterDefinition<Ticket>> filters = new List<FilterDefinition<Ticket>>();
            //checks if it filters by an employee id
            if(QuerryedEmployee != null)
            {
                filters.Add(ticketService.FilterTicketsByEmployee(QuerryedEmployee));
            }
            return filters;
        }

        public SortDefinition<Ticket> GetSort()
        {
            var sort = ticketService.SortByStatus();
            return sort;
        }

        //Add the columns in the listview to display tickets
        public void SetupListviewTicket()
        {
            int columnWidth = (MainListView.Width - 10) / 5;
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
            int columnWidth = (MainListView.Width - 10) / 4;
            MainListView.Columns.Clear();
            MainListView.Columns.Add("UserName", columnWidth);
            MainListView.Columns.Add("Name", columnWidth);
            MainListView.Columns.Add("Email", columnWidth);
            MainListView.Columns.Add("Role", columnWidth);
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

        private void AdminTicketPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

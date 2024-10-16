using Model;
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
        private TicketService ticektService;
        private EmployeeService employeeService;
        private ListDisplayCase CurrentCase;
        private Employee QuerryedEmployee;
        public ListMainForm(Employee employee)
        {
            InitializeComponent();
            LogedEmployee = employee;
            MainListView.View = View.Details;
            ticektService = new TicketService();
            employeeService = new EmployeeService();
            FormSetup();
        }

        public void FormSetup()
        {
            showTickets = true;
            SetupListStructure();
            if (LogedEmployee.Role == Role.admin)
            {
                CurrentCase = ListDisplayCase.AllTickets;
            }
            else
            {
                CurrentCase = ListDisplayCase.SpecificEmployeeTickets;
                QuerryedEmployee = LogedEmployee;
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
                li.SubItems.Add(ticket.SolutionTime.ToString());

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
            switch (CurrentCase)
            {
                case ListDisplayCase.AllTickets:
                    AddTicketsToList(ticektService.GetAllTickets());
                    break;
                case ListDisplayCase.SpecificEmployeeTickets:
                    AddTicketsToList(ticektService.GetTicketsByEmployeeId(QuerryedEmployee));
                    break;
            }
        }

        //Add the columns in the listview to display tickets
        public void SetupListviewTicket()
        {
            MainListView.Columns.Clear();
            MainListView.Columns.Add("Title", MainListView.Width/5);
            MainListView.Columns.Add("Status", MainListView.Width / 5);
            MainListView.Columns.Add("Priority", MainListView.Width / 5);
            MainListView.Columns.Add("Creation Date", MainListView.Width / 5);
            MainListView.Columns.Add("Solution Date", MainListView.Width / 5);
        }

        //Add the columns in the listview to display employee
        public void SetupListviewEmployee()
        {
            MainListView.Columns.Clear();
            MainListView.Columns.Add("UserName", MainListView.Width / 4);
            MainListView.Columns.Add("Name", MainListView.Width / 4);
            MainListView.Columns.Add("Email", MainListView.Width / 4);
            MainListView.Columns.Add("Role", MainListView.Width / 4);
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
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the selceted items", "Delete Warning", MessageBoxButtons.YesNo);
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
                ticket.Status = Status.closed;
                ticektService.UpdateTicket(ticket);
            }
            else
            {
                // Employees are removed from the database
                Employee employee = (Employee)item.Tag;
                employeeService.DeleteEmployee(employee);
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
    }
}

public enum ListDisplayCase
{
    AllTickets,SpecificEmployeeTickets
}

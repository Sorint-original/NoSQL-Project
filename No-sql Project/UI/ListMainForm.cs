using Model;
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
        private bool admin; // the acces the logged employee will get
        private bool showTickts; // If the list displays tickets or emplyees
        private Employee employee;
        public ListMainForm(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            showTickts = true;
            mainListView.View = View.Details;
            FormSetup();
        }

        public void FormSetup()
        {
            if (employee.Role == Role.admin)
            {
                admin = true;
            }
            else
            {
                admin = false;
            }
            if (showTickts)
            {
                SetupListviewTicket();
            }
            else
            {
                SetupListviewTicket();
            }
        }


        //Add the columns in the listview to display tickets
        public void SetupListviewTicket()
        {
            mainListView.Columns.Add("Title");
            mainListView.Columns.Add("Status");
            mainListView.Columns.Add("Priority");
            mainListView.Columns.Add("Creation Date");
            mainListView.Columns.Add("Solution Date");
        }

        //Add the columns in the listview to display employee
        public void SetupListviewEmployee() 
        {
            mainListView.Columns.Add("UserName");
            mainListView.Columns.Add("Name");
            mainListView.Columns.Add("Email");
            mainListView.Columns.Add("Role");
        }


    }
}

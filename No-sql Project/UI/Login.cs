using Model;
using Service;

namespace UI
{
    public partial class Login : Form
    {

        EmployeeService employeeService = new EmployeeService();
        public Login()
        {
            InitializeComponent();
        }

        private void LoginB_Click(object sender, EventArgs e)
        {
            //Getting the employee by username
            string Username = UsernameTB.Text;
            Employee employee = employeeService.GetEmployeesByUsername(Username);
        }
    }
}

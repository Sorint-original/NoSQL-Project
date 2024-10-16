using Model;
using Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class LoginForm : Form
    {

        EmployeeService employeeService = new EmployeeService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginB_Click(object sender, EventArgs e)
        {
            ////Getting the employee by username
            //string Username = UsernameTB.Text;
            //Employee employee = employeeService.GetEmployeesByUsername(Username);

            // Getting the username and password from input
            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            // Authenticate the employee
            Employee employee = Login(username, password);

            if (employee == null)
            {
                // Show an error message if login fails
                MessageBox.Show("Invalid username or password. Please try again.","ERROR");
                return;
            }
            ListMainForm listMainForm = new ListMainForm(employee);  // Create an instance of the ListMainForm

            listMainForm.Show();  // Show the ListMainForm
            this.Hide();  // Hide the current login form

        }

        public Employee Login(string username, string password)
        {
            Employee employee = employeeService.GetEmployeesByUsername(username);
            if (employee != null && employee.Password == password)
            {
                return employee;  // Login successful, return employee
            }
            return null;  // Invalid credentials
        }

    }
    }


using DAL;
using Model;
using Service;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class LoginForm : Form
    {

        EmployeeService employeeService = new EmployeeService();
        public LoginForm()
        {
            InitializeComponent();
            PasswordTB.PasswordChar = '*'; // set password character to hide input 
        }

        private void LoginB_Click(object sender, EventArgs e)
        {
            
            // Getting the username and password from input
            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            //HASHING THE PASSWORD FOR COPARISON
            string hashedPassword = employeeService.HashPassword(password);

            // Authenticate the employee
            Employee employee = Login(username, hashedPassword);

            if (employee == null)
            {
                //check if username exist 
                if (!employeeService.DoesUsernameExist(username))
                {
                    // Show an error message if login fails
                    MessageBox.Show("Username not found . Please try again ", "ERROR");
                }
                else
                {
                    MessageBox.Show("Incorrect password . Please try again.", "ERROR");
                }
                return;
            }
            ListMainForm listMainForm = new ListMainForm(employee);  // Create an instance of the ListMainForm

            listMainForm.Show();  // Show the ListMainForm
            this.Hide();  // Hide the current login form

        }

        public Employee Login(string username, string hashedPassword)
        {
            try
            {
                Employee employee = employeeService.GetEmployeesByUsername(username);
                if (employee != null && employee.Password == hashedPassword)
                {
                    return employee;  // Login successful, return employee
                }
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during the login process
            }
            return null;  // Invalid credentials
        }

        private void ClearFieldsLabel_Click(object sender, EventArgs e)
        {
            ClearAndFocus();
        }
        public void ClearAndFocus()
        {
            UsernameTB.Clear();
            PasswordTB.Clear();
            UsernameTB.Focus();
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


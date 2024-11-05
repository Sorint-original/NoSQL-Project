using Model;
using MongoDB.Bson;
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
    public partial class EmployeeCreateForm : Form
    {
        private EmployeeService employeeService;

        public EmployeeCreateForm(Employee employee = null)
        {
            InitializeComponent();
            employeeService = new EmployeeService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string username = EmployeeUserName.Text;
            string name = EmployeeName.Text;
            string email = EmployeeEmail.Text;
            string password = EmployeePassword.Text;

            EmployeeRole.DataSource = Enum.GetValues(typeof(Role));
            Role role = (Role)EmployeeRole.SelectedItem;

            if (!ValidateForm()) return;

            // Create a new Employee object
            Employee newEmployee = new Employee(
                ObjectId.GenerateNewId(), // Generates a new ObjectId for the employee
                username,
                name,
                email,
                employeeService.HashPassword(password), // Hash the password before storing
                role,
                true // Set `IsActive` to true by default for new employees
            );

            try
            {
                // Save the new employee using the service
                employeeService.CreateEmployee(newEmployee);
                MessageBox.Show("Employee created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Optionally close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(EmployeeUserName.Text) ||
                string.IsNullOrWhiteSpace(EmployeeName.Text) ||
                string.IsNullOrWhiteSpace(EmployeeEmail.Text) ||
                string.IsNullOrWhiteSpace(EmployeePassword.Text) ||
                EmployeeRole.SelectedItem == null)
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ClearFormFields()
        {
            EmployeeUserName.Clear();
            EmployeeName.Clear();
            EmployeeEmail.Clear();
            EmployeePassword.Clear();
            EmployeeRole.SelectedIndex = -1; // Reset ComboBox
        }

    }
}

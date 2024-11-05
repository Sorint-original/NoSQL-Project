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
        private Employee existingEmployee;

        public EmployeeCreateForm(Employee employee = null)
        {
            InitializeComponent();
            employeeService = new EmployeeService();

            if (employee != null)
            {
                existingEmployee = employee;
                PopulateFormFields(employee);
                btnSave.Text = "Update"; // Change the button text to indicate editing mode
            }
        }
        private void PopulateFormFields(Employee employee)
        {
            EmployeeUserName.Text = employee.UserName;
            EmployeeName.Text = employee.Name;
            EmployeeEmail.Text = employee.Email;
            EmployeeRole.DataSource = Enum.GetValues(typeof(Role));
            EmployeeRole.SelectedItem = employee.Role;
            EmployeePassword.Text = employee.Password;
        }

        private bool ValidateForm()
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(EmployeeUserName.Text) ||
                string.IsNullOrWhiteSpace(EmployeeName.Text) ||
                string.IsNullOrWhiteSpace(EmployeeEmail.Text) ||
                string.IsNullOrWhiteSpace(EmployeePassword.Text) ||
                EmployeeRole.SelectedItem == null)
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if email is in a valid format
            if (!IsValidEmail(EmployeeEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if password meets strength requirements (example: minimum 8 characters)
            if (EmployeePassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearFormFields()
        {
            EmployeeUserName.Clear();
            EmployeeName.Clear();
            EmployeeEmail.Clear();
            EmployeePassword.Clear();
            EmployeeRole.SelectedIndex = -1; // Reset ComboBox
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            

            if (existingEmployee != null)
            {
                // Collect data from input fields
                string username = EmployeeUserName.Text;
                string name = EmployeeName.Text;
                string email = EmployeeEmail.Text;
                string password = EmployeePassword.Text;
                //EmployeeRole.DataSource = Enum.GetValues(typeof(Role));
                Role role = (Role)EmployeeRole.SelectedItem;

                existingEmployee.UserName = username;
                existingEmployee.Name = name;
                existingEmployee.Email = email;
                existingEmployee.Password = password;
                existingEmployee.Role = role;

                try
                {
                    employeeService.UpdateEmployee(existingEmployee);
                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Collect data from input fields
                string username = EmployeeUserName.Text;
                string name = EmployeeName.Text;
                string email = EmployeeEmail.Text;
                string password = EmployeePassword.Text;
                EmployeeRole.DataSource = Enum.GetValues(typeof(Role));
                Role role = (Role)EmployeeRole.SelectedItem;

                if (employeeService.DoesUsernameExist(username))
                {
                    MessageBox.Show("This username is already in use. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Employee newEmployee = new Employee(
                    ObjectId.GenerateNewId(),
                    username,
                    name,
                    email,
                    password,
                    role,
                    true
                );

                try
                {
                    employeeService.CreateEmployee(newEmployee);
                    MessageBox.Show("Employee created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

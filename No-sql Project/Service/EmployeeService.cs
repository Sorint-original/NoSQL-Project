using DAL;
using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();

        public Employee GetEmployeesByUsername(string username)
        {

            List<Employee> list = employeeDAO.GetEmployeesByUsername(username);
            if(list.Count > 0)
            {
                return list[0];

            }
            else
            {
                return null;
            }
        }

        // validate login credentials
        public Employee Login(string username, string password)
        {
            Employee employee = GetEmployeesByUsername(username); 
            if (employee != null && employee.Password == password)
            {
                return employee;  // Login successful, return employee
            }
            return null;  // Invalid credentials
        }


        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = employeeDAO.GetAllEmployee();
            return list;
        }
      
        public void DeleteEmployee(Employee employee) 
        { 
            employeeDAO.DeleteEmployee(employee); 
        }

    }
}

    


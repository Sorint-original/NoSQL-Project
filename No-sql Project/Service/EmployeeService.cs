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

            return employeeDAO.GetEmployeeByUsername(username);

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

        public void UpdateEmployee(Employee employee)
        {
            employeeDAO.UpdateEmployee(employee);
        }

        public void DeactivateEmployee(Employee employee)
        {
            employee.IsDeleted = true;
            UpdateEmployee(employee);
        }
    }
}

    


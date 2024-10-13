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

        public List<Employee> GetEmployeesByUsername(string username)
        {

            List<Employee> list = employeeDAO.GetEmployeesByUsername(username);
            return list;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = employeeDAO.GetAllEmployee();
            return list;
        }

    }
}

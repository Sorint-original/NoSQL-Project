﻿using DAL;
using Model;
using MongoDB.Driver;
using System.Security.Cryptography;
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
            employee.IsActive = true;
            UpdateEmployee(employee);
        }

        public List<Employee> CustomQuerry(List<FilterDefinition<Employee>> filters, SortDefinition<Employee> sort)
        {
            return employeeDAO.CustomQuerry(filters, sort);
        }

        public List<FilterDefinition<Employee>> GetFilters(string nameSearch,Role role,bool Active)
        {
            List<FilterDefinition<Employee>> filters = new List<FilterDefinition<Employee>>();
            //check title search
            if (nameSearch != null)
            {

            }
            //check Role filter
            if((int)role != 0)
            {
                filters.Add(FilterEmployeesByRole(role));
            }
            //get activity filter
            filters.Add(FilterEmployeesByActivity(Active));

            return filters;
        }
        public FilterDefinition<Employee> FilterEmployeesByRole(Role role)
        {
            var filter = Builders<Employee>.Filter.Eq(t => t.Role, role);
            return filter;
        }
        public FilterDefinition<Employee> FilterEmployeesByActivity(bool Active)
        {
            var filter = Builders<Employee>.Filter.Eq(t => t.IsActive, Active);
            return filter;
        }

        public SortDefinition<Employee> GetSort(int Index)
        {
            switch (Index)
            {
                case 0:
                    return SortByUsername();
                case 1:
                    return SortByName();
                case 2:
                    return SortByEmail();
                case 3:
                    return SortByRole();
            }
            return null;
        }

        public SortDefinition<Employee> SortByUsername()
        {
            return  Builders<Employee>.Sort.Ascending(e => e.UserName);
        }

        public SortDefinition<Employee> SortByName()
        {
            return Builders<Employee>.Sort.Ascending(e => e.Name);
        }

        public SortDefinition<Employee> SortByEmail()
        {
            return Builders<Employee>.Sort.Ascending(e => e.Email);
        }

        public SortDefinition<Employee> SortByRole()
        {
            return Builders<Employee>.Sort.Ascending(e => e.Role);
        }
        public void HashAllPasswords()
        {
            List<Employee> employees = employeeDAO.GetAllEmployee();

            foreach (Employee employee in employees)
            {
                // Check if the password is not already hashed (assuming hashed passwords have a consistent length)
                if (employee.Password.Length != 64)
                {
                    employee.Password = HashPassword(employee.Password);
                    employeeDAO.UpdateEmployee(employee);
                }
            }
            Console.WriteLine("All passwords have been hashed.");
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        //check the existence of the username 
        public bool DoesUsernameExist(string username)
        {
            try
            {
                Employee employee = employeeDAO.GetEmployeeByUsername(username);
                return employee != null;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}

    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DAL
{
    public class EmployeeDAO: BaseDAO
    {
        private readonly IMongoCollection<Employee> _employeeCollection;
        public EmployeeDAO() : base()
        {
            _employeeCollection = GetCollection<Employee>("Employees");
        }

    //GetAllEmployees(order by Username)
    public List<Employee> GetAllEmployees()
        {
            var sort = Builders<Employee>.Sort.Ascending(e => e.UserName);
            return _employeeCollection.Find(FilterDefinition<Employee>.Empty).Sort(sort).ToList();
        }
        
        //GetEmployeeByUsername
        public Employee GetEmployeeByUsername(string username)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.UserName, username) & Builders<Employee>.Filter.Eq(e => e.IsActive, true);
            return _employeeCollection.Find(filter).Single();
        }
        public void CreateEmployee(Employee employee)
        {
           _employeeCollection.InsertOne(employee);
        }
        public void UpdateEmployee (Employee employee)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.Id, employee.Id);
            _employeeCollection.ReplaceOne(filter,employee);
            
        }
        public void DeleteEmployee (Employee employee)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.Id, employee.Id);
            _employeeCollection.DeleteOne(filter);
        }

        public List<Employee> CustomQuerry(List<FilterDefinition<Employee>> filters, SortDefinition<Employee> sort)
        {
            FilterDefinition<Employee> filter;
            if (filters.Count == 0)
            {
                filter = FilterDefinition<Employee>.Empty;
            }
            else
            {
                filter = CombineFilters(filters);
            }
            if (sort == null)
            {
                return _employeeCollection.Find(filter).ToList();
            }
            else
            {
                return _employeeCollection.Find(filter).Sort(sort).ToList();
            }
        }

        private FilterDefinition<Employee> CombineFilters(List<FilterDefinition<Employee>> filters)
        {
            FilterDefinition<Employee> filter = filters[0];
            for (int i = 1; i < filters.Count; i++)
            {
                filter = filter & filters[i];
            }
            return filter;
        }
    }
}

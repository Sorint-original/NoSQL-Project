using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Employee> GetAllEmployee()
        {
            var sort = Builders<Employee>.Sort.Ascending(e => e.UserName);
            return _employeeCollection.Find(FilterDefinition<Employee>.Empty).Sort(sort).ToList();
        }
        
        //GetEmployeeByUsername
        public List<Employee> GetEmployeesByUsername(string username)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.UserName, username);
            return _employeeCollection.Find(filter).ToList();
        }
        public void CreateEmployee(ObjectId Id, string UserName, string Name, string Email, string Password, Role role)
        {
            var newEmplyoyee = new Employee(
                ObjectId.GenerateNewId(),   // Generate a new ObjectId
                UserName,
                Name,
                Email,
                Password,
                role
                        
            );

           _employeeCollection.InsertOne(newEmplyoyee);
            Console.WriteLine("Employee created successfully.");
        }
        public void UpdateEmployee (Employee employee)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.Id, employee.Id);
            _employeeCollection.ReplaceOneAsync(filter,employee);
            
        }
        public void DeleteEmpliyee (Employee employee)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.Id, employee.Id);
            _employeeCollection.DeleteOneAsync(filter);
        }
    }
}

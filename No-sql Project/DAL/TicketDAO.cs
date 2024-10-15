using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace DAL
{
    internal class TicketDAO : BaseDAO
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;

        public TicketDAO() : base()
        {
            _ticketsCollection = GetCollection<Ticket>("Tickets");
        }

        //GetAllTickets(order by Status)
        public List<Ticket> GetAllTickets()
        {
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return _ticketsCollection.Find(FilterDefinition<Ticket>.Empty).Sort(sort).ToList();
        }

        //GetTiketsByEmployeeId
        public List<Ticket> GetTicketsByEmployeeId(ObjectId employeeId)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employeeId);
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return _ticketsCollection.Find(filter).Sort(sort).ToList();
        }

        //create a new ticket
        public void CreateTicket(ObjectId employeeId, string title, string description, Priority priority)
        {
            var newTicket = new Ticket(
                ObjectId.GenerateNewId(),   // Generate a new ObjectId
                employeeId,
                title,
                description,
                Status.open,
                priority,
                DateTime.UtcNow,
                DateTime.MinValue            // Set SolutionTime to MinValue as it's not resolved yet
            );

            _ticketsCollection.InsertOne(newTicket);
            Console.WriteLine("Ticket created successfully.");
        }

        //Update tickets
        public void UpdateTicket(Ticket ticket)
        {
            var filter = Builders<Ticket>.Filter.Eq(t =>t.Id, ticket.Id);
            _ticketsCollection.ReplaceOneAsync(filter, ticket);
            //it updates all the atributes of the ticket
        }

        //Delete tickets
        public void DeleteTicket(Ticket ticket)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Id, ticket.Id);
            _ticketsCollection.DeleteOneAsync(filter);
        }

        //GetAlltickets by status
        public List<Ticket> GetTicketsByStatus(Status Status)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Status, Status);
            return _ticketsCollection.Find(filter).ToList();
        }

        // Get the status precentages for employee's tickets
        public async Task<string> GetStatusPrecentagesForSpecificEmployee(Employee employee)
        {
            int totalAmountOfTickets = GetTicketsByEmployeeId(employee.Id).Count;
            var filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employee.Id);
            var singleFieldAggregate = _ticketsCollection.Aggregate().Match(filter).Group(t => t.Status, Group => new {status = Group.Key, total = Group.Sum(U => 1)});
            var GroupStatuses = await singleFieldAggregate.ToListAsync();
            string status = "";
            foreach (var group in GroupStatuses)
            {
                status += $"{group.status}: {(group.total / totalAmountOfTickets)*100} ";
            }
            //var result = new Task<string>(() => status);
            return status;
        }

        // Get the status precentages for all tickets
        public async Task<string> GetStatusPercentageForAllTickets()
        {
            int totalAmountOfTickets = GetAllTickets().Count;
            var singleFieldAggregate = _ticketsCollection.Aggregate().Group(t => t.Status, Group => new { status = Group.Key, total = Group.Sum(U => 1) });
            var GroupStatuses = await singleFieldAggregate.ToListAsync();
            string status = "";
            foreach (var group in GroupStatuses)
            {
                status += $"{group.status}: {(group.total / totalAmountOfTickets) * 100} ";
            }
            //var result = new Task<string>(() => status);
            return status;
        }
    }
}
; 
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

        //Delete tickets

        //GetAlltickets by status

    }
}

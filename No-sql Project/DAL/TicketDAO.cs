using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class TicketDAO : BaseDAO
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;
        private readonly IMongoCollection<Ticket> _archiveCollection;

        public TicketDAO() : base()
        {
            _ticketsCollection = GetCollection<Ticket>("Tickets");
            _archiveCollection = GetCollection<Ticket>("Archive");
        }

        //GetAllTickets(order by Status)
        public List<Ticket> GetAllTickets()
        {
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return _ticketsCollection.Find(FilterDefinition<Ticket>.Empty).Sort(sort).ToList();
        }

        //GetTiketsByEmployeeId
        public List<Ticket> GetTicketsByEmployeeId(Employee employee)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employee.Id);
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return _ticketsCollection.Find(filter).Sort(sort).ToList();
        }

        //create a new ticket
        public void CreateTicket(Ticket ticket)
        {
            _ticketsCollection.InsertOne(ticket);
        }

        //Update tickets
        public void UpdateTicket(Ticket ticket)
        {
            var filter = Builders<Ticket>.Filter.Eq(t =>t.Id, ticket.Id);
            _ticketsCollection.ReplaceOne(filter, ticket);
            //it updates all the atributes of the ticket
        }

        //Delete tickets
        public void DeleteTicket(Ticket ticket)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Id, ticket.Id);
            _ticketsCollection.DeleteOne(filter);
        }

        //GetAlltickets by status
        public List<Ticket> GetTicketsByStatus(Status Status)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Status, Status);
            return _ticketsCollection.Find(filter).ToList();
        }

        // Get the status precentages for employee's tickets
        public Dictionary<Status,float> GetPercentagesForTickets(Employee employee = null)
        {
            Dictionary<Status, float> percentages = new Dictionary<Status, float>();
            int totalAmountOfTickets ;
            FilterDefinition<Ticket> filter;
            if (employee != null) {
                 totalAmountOfTickets = GetTicketsByEmployeeId(employee).Count;
                filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employee.Id);
            }
            else
            {
                totalAmountOfTickets = GetAllTickets().Count;
                filter = Builders<Ticket>.Filter.Empty;
            }
            var singleFieldAggregate = _ticketsCollection.Aggregate().Match(filter).Group(t => t.Status, Group => new { status = Group.Key, total = Group.Sum(U => 1) });
            var GroupStatuses = singleFieldAggregate.ToList();

            foreach (var group in GroupStatuses)
            {
                percentages.Add(group.status, (group.total/ totalAmountOfTickets)*100);
            }
            return percentages;
        }

        // INDIVIDUAL FEATURE SORIN TICKET ARCHIVING
        public void ArchiveAllTicketsBeforeDate(DateTime Date)
        {
            List<Ticket> tickets = GetTicketsBeforeDate(Date);
            TransferTickets(tickets);
        }

        public List<Ticket> GetTicketsBeforeDate(DateTime Date)
        {
            var filter = Builders<Ticket>.Filter.Lte(t => t.CreationTime, Date);
            var sort = Builders<Ticket>.Sort.Ascending(t => t.CreationTime);
            List<Ticket> tickets = _ticketsCollection.Find(filter).Sort(sort).ToList();
            return tickets;
        }

        public void TransferTickets(List<Ticket> tickets)
        {
            foreach (Ticket ticket in tickets)
            {
                DeleteTicket(ticket);
                AddInArchive(ticket);
            }

        }

        public void AddInArchive(Ticket ticket)
        {
            _archiveCollection.InsertOne(ticket);
        }

        // INDIVIDUAL FEATURE BRIAN PRIORITY SORTING

        public List<Ticket> SortTicketsByPriority()
        {
            //sorting and returning the filterd tickets by high, medium and low priority
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Priority);
            return _ticketsCollection.Find(FilterDefinition<Ticket>.Empty).Sort(sort).ToList();
        }
        public List<Ticket> GetTicketsByPriority(Priority priority)
        {
            //sorting and returning the filterd tickets by one priority
            var filter = Builders<Ticket>.Filter.Eq(t => t.Priority, priority);
            return _ticketsCollection.Find(filter).ToList();
        }
    }
}
; 
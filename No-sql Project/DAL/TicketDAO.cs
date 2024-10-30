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
        //GetAllTickets(order by Status)
        private List<Ticket> GetAllTickets()
        {
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return _ticketsCollection.Find(FilterDefinition<Ticket>.Empty).Sort(sort).ToList();
        }

        //GetTiketsByEmployeeId
        private List<Ticket> GetTicketsByEmployeeId(Employee employee)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employee.Id);
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return _ticketsCollection.Find(filter).Sort(sort).ToList();
        }

        // INDIVIDUAL FEATURE SORIN TICKET ARCHIVING
        public void ArchiveTickets(List<Ticket> tickets)
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

        // Methods to handle complexed custom and unpredictable querries from the listView

        public List<Ticket> CustomQuerry(List<FilterDefinition<Ticket>> filters, SortDefinition<Ticket> sort)
        {
            FilterDefinition<Ticket> filter;
            if (filters.Count == 0)
            {
                filter = FilterDefinition<Ticket>.Empty;
            }
            else
            {
                filter = CombineFilters(filters);
            }
            if (sort == null)
            {
                return _ticketsCollection.Find(filter).ToList();
            }
            else
            {
                return _ticketsCollection.Find(filter).Sort(sort).ToList();
            }
        }

        private FilterDefinition<Ticket> CombineFilters(List<FilterDefinition<Ticket>> filters)
        {
            FilterDefinition<Ticket> filter = filters[0];
            for (int i = 1; i < filters.Count; i++) 
            {
                filter = filter & filters[i];
            }
            return filter;
        }

        //Methods that return filtres or sorts for custom querrys in listView
        //get filter based on employee
        public FilterDefinition<Ticket> FilterTicketsByEmployee(Employee employee)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employee.Id);
            return filter;
        }
        // get sort based on status
        public SortDefinition<Ticket> SortByStatus()
        {
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Status);
            return sort;
        }

        //Filter tickets by status
        public FilterDefinition<Ticket> FilterByStatus(Status Status)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Status, Status);
            return filter;
        }

        // get sort based on creation date
        public SortDefinition<Ticket> SortByCreationDateAscending()
        {
            var sort = Builders<Ticket>.Sort.Ascending(t => t.CreationTime);
            return sort;
        }

        public SortDefinition<Ticket> SortByCreationDateDecending()
        {
            var sort = Builders<Ticket>.Sort.Descending(t => t.CreationTime);
            return sort;
        }

        //Filter tickets created before a specific date
        public FilterDefinition<Ticket> FilterBeforeSpecificDate(DateTime Date)
        {
            var filter = Builders<Ticket>.Filter.Lte(t => t.CreationTime, Date);
            return filter;
        }

        //Filter tickets created after a specific date
        public FilterDefinition<Ticket> FilterAfterSpecificDate(DateTime Date)
        {
            var filter = Builders<Ticket>.Filter.Gte(t => t.CreationTime, Date);
            return filter;
        }

        // INDIVIDUAL FEATURE BRIAN PRIORITY SORTING
        public SortDefinition<Ticket> SortTicketsByPriority()
        {
            //sorting and returning the filterd tickets by high, medium and low priority
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Priority);
            return sort;
        }
        public FilterDefinition<Ticket> GetTicketsByPriority(Priority priority)
        {
            //sorting and returning the filterd tickets by one priority
            var filter = Builders<Ticket>.Filter.Eq(t => t.Priority, priority);
            return filter;
        }

    }
}
; 
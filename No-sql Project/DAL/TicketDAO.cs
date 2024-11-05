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

        // Get the status precentages for employee's tickets
        public Dictionary<Status,float> GetPercentagesForTickets(Employee employee = null)
        {
            Dictionary<Status, float> percentages = new Dictionary<Status, float>();
            float totalAmountOfTickets ;
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
        public void AddInArchive(Ticket ticket)
        {
            _archiveCollection.InsertOne(ticket);
        }

        //Delete tickets
        public void DeleteTicket(Ticket ticket)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Id, ticket.Id);
            _ticketsCollection.DeleteOne(filter);
        }

        // Methods to handle complexed custom and unpredictable querries from the listView

        public List<Ticket> CustomQuerry(List<FilterDefinition<Ticket>> filters, int SortIndex)
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
            SortDefinition<Ticket> sort = GetSort(SortIndex);
            if (sort != null)
            {
                return _ticketsCollection.Find(filter).Sort(sort).ToList();
            }
            else
            {
                return CustomQuerryWithEnumSort(filter,SortIndex);
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

        public SortDefinition<Ticket> GetSort(int Index)
        {
            switch (Index)// The index is 0 or 1 if it sorts by date, if it sorts by enum it will be 2 for status and 3 for priority 
            {
                case 0:
                    return SortByCreationDateDescending();
                case 1:
                    return SortByCreationDateAscending();
            }
            return null;
        }
        // get sort based on creation date
        public SortDefinition<Ticket> SortByCreationDateAscending()
        {
            var sort = Builders<Ticket>.Sort.Ascending(t => t.CreationTime);
            return sort;
        }

        public SortDefinition<Ticket> SortByCreationDateDescending()
        {
            var sort = Builders<Ticket>.Sort.Descending(t => t.CreationTime);
            return sort;
        }

        private List<Ticket> CustomQuerryWithEnumSort(FilterDefinition<Ticket> filter, int SortIndex)
        {
            string addorder;
            if (SortIndex == 2)
            {
                //sort by status
                addorder=SortByStatus();
            }
            else
            {
                //sort by priority
                addorder=SortByPriority();
            }
            string unsetorder = "{ $unset: \"_order\" }";
            SortDefinition<Ticket> sort = Builders<Ticket>.Sort.Ascending(t => t._order);
            List<Ticket> list =
                _ticketsCollection.Aggregate()
                .Match(filter)
                .AppendStage<Ticket>(addorder)
                .Sort(sort)
                .AppendStage<Ticket>(unsetorder)
                .ToList();
            return list;
        }

        // get sort based on status
        public string SortByStatus()
        {
            return "{$addFields: {_order: {$indexOfArray:[[\"open\",\"pending\",\"resolved\",\"closed\"],\"$Status\"]}}}";
        }
        //BRIAN INDIVIDUAL FEATURE
        public string SortByPriority( )
        {
            return "{$addFields: {_order: {$indexOfArray:[[\"high\",\"normal\",\"low\"],\"$Priority\"]}}}";
        }
    }
}
; 
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class PriorityDAO: BaseDAO
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;

        public PriorityDAO() : base()
        {
            _ticketsCollection = GetCollection<Ticket>("Tickets");
        }
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
            return _ticketsCollection.Find(FilterDefinition<Ticket>.Empty).ToList();
        }

    }
}

using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class IndividualFeature_DatabaseArchiving : BaseDAO
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;
        private readonly IMongoCollection<Ticket> _archiveCollection;
        private TicketDAO ticketDAO;

        public IndividualFeature_DatabaseArchiving() : base()
        {
            _ticketsCollection = GetCollection<Ticket>("Tickets");
            _archiveCollection = GetCollection<Ticket>("Archive");
            ticketDAO = new TicketDAO();
        }

        public void ArchiveAllTicketsBeforeDate(DateTime Date)
        {
            List<Ticket> tickets = GetTicketsBeforeDate(Date);
            TransferTickets(tickets);
        }

        public List<Ticket> GetTicketsBeforeDate(DateTime Date)
        {
            var filter = Builders<Ticket>.Filter.Lte(t => t.CreationTime, Date );
            var sort = Builders<Ticket>.Sort.Ascending(t => t.CreationTime);
            List<Ticket>  tickets = _ticketsCollection.Find(filter).Sort(sort).ToList();
            return tickets;
        }

        public void TransferTickets(List<Ticket> tickets) 
        {
            foreach (Ticket ticket in tickets)
            {
                ticketDAO.DeleteTicket(ticket);
                AddInArchive(ticket);
            }

        }

        public void AddInArchive(Ticket ticket)
        {
            _archiveCollection.InsertOne(ticket);
        }
    }
}

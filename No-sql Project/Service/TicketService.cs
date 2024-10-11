using System.Collections.Generic;
using DAL;
using Model;
namespace Service
{
    public class TicketService
    {
        private TicketDAO ticketDAO;
        private TicketFiltering ticketFiltering;
        private List<Ticket> preloadedTickets; // load the tickt form the database once and reuse them when needed

        public TicketService()
        {
            ticketDAO = new TicketDAO();
            ticketFiltering = new TicketFiltering();
            preloadedTickets = ticketDAO.GetAllTickets();
        }
         public List<Ticket> GetAllTickets()
        {
            return preloadedTickets; //  Return the preloaded tickets instead of querying the database again
        }

        public List<Ticket> FilterTickets(string keyword)
        {
            return ticketFiltering.Filtertickets(preloadedTickets, keyword);
        }
    }
}

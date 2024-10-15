using System.Collections.Generic;
using DAL;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Service
{
    public class TicketService
    {
        private TicketDAO ticketDAO;
        private TicketFiltering ticketFiltering;

        public TicketService()
        {
            ticketDAO = new TicketDAO();
            ticketFiltering = new TicketFiltering();
        }
         public List<Ticket> GetAllTickets()
        {
            return ticketDAO.GetAllTickets(); ; 
        }

        public List<Ticket> FilterTickets(List<Ticket> list, string keyword)
        {
            return ticketFiltering.Filtertickets( list, keyword);
        }

        public List<Ticket> GetTicketsByEmployeeId(ObjectId employeeId)
        {
            return ticketDAO.GetTicketsByEmployeeId(employeeId);
        }
    }
}

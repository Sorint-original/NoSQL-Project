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

        public TicketService()
        {
            ticketDAO = new TicketDAO();
        }
         public List<Ticket> GetAllTickets()
        {
            return ticketDAO.GetAllTickets();
        }

        public List<Ticket> GetTicketsByEmployeeId(Employee employee)
        {
            return ticketDAO.GetTicketsByEmployeeId(employee);
        }

        public void UpdateTicket(Ticket ticket)
        {
            ticketDAO.UpdateTicket(ticket);
        }

        public void CloseTicket(Ticket ticket)
        {
            ticket.Status = Status.closed;
            UpdateTicket(ticket);
        }

        // INDIVIDUAL FEATURE LAITH FILTERING A GIVEN LIST 
        public List<Ticket> Filtertickets(List<Ticket> tickets, string keyword)
        {
            List<Ticket> filteredTickets = new List<Ticket>(); // to hold the filterd ticket 

            foreach (Ticket ticket in tickets)
            {
                //check if the keyword matches the tickts Statuse , priorty , title ,id .description

                if (ticket.Status.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) || ticket.Priority.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        ticket.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || ticket.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    filteredTickets.Add(ticket); //if matched add to the filterd tickets 
                }
            }

            return filteredTickets;
        }
    }
}

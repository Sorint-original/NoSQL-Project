using System.Collections.Generic;
using DAL;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using ZstdSharp.Unsafe;
namespace Service
{
    public class TicketService
    {
        private TicketDAO ticketDAO;

        public TicketService()
        {
            ticketDAO = new TicketDAO();
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

        public List<Ticket> CustomQuerry(List<FilterDefinition<Ticket>> filters, SortDefinition<Ticket> sort)
        {
            return ticketDAO.CustomQuerry(filters, sort);
        }

        //Methods that return filtres or sorts for custom querrys in listView
        //get filter based on employee
        public FilterDefinition<Ticket> FilterTicketsByEmployee(Employee employee)
        {
            return ticketDAO.FilterTicketsByEmployee(employee);
        }
        // get sort based on status
        public SortDefinition<Ticket> SortByStatus()
        {
            return ticketDAO.SortByStatus();
        }

        //Filter tickets by status
        public FilterDefinition<Ticket> FilterByStatus(Status Status)
        {
            return ticketDAO.FilterByStatus(Status);
        }

        // get sort based on creation date
        public SortDefinition<Ticket> SortByCreationDate()
        {
            return ticketDAO.SortByCreationDate();
        }

        //Filter tickets created before a specific date
        public FilterDefinition<Ticket> FilterBeforeSpecificDate(DateTime Date)
        {
            return ticketDAO.FilterBeforeSpecificDate(Date);
        }

        //Filter tickets created after a specific date
        public FilterDefinition<Ticket> FilterAfterSpecificDate(DateTime Date)
        {
            return ticketDAO.FilterAfterSpecificDate(Date);
        }

        // INDIVIDUAL FEATURE BRIAN PRIORITY SORTING
        public SortDefinition<Ticket> SortTicketsByPriority()
        {
            //sorting and returning the filterd tickets by high, medium and low priority
            return ticketDAO.SortTicketsByPriority();
        }
        public FilterDefinition<Ticket> GetTicketsByPriority(Priority priority)
        {
            //sorting and returning the filterd tickets by one priority
            return ticketDAO.GetTicketsByPriority(priority);
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class TicketFiltering
    {
        public List<Ticket> Filtertickets(List<Ticket> tickets, string keyword)
        {
            List<Ticket> filteredTickets = new List<Ticket>(); // to hold the filterd ticket 

            foreach (Ticket ticket in tickets)
            {
                //check if the keyword matches the tickts Statuse , priorty , title ,id .description
                
                if(ticket.Status.ToString().Contains(keyword , StringComparison.OrdinalIgnoreCase)) 
            }
        }
    }
}

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
        public List<Ticket> FilterTickets(List<Ticket> tickets, string keyword)
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

        public List<FilterDefinition<Ticket>> GetFilters(Employee querryedEmployee, string titleSearch, Status status, Priority priority, bool FilterDate, DateTime StartDate, DateTime EndDate)
        {
            List<FilterDefinition<Ticket>> filters = new List<FilterDefinition<Ticket>>();
            //checks if it filters by an employee id
            if (querryedEmployee != null)
            {
                filters.Add(FilterTicketsByEmployee(querryedEmployee));
            }
            //check title search
            if (titleSearch != null)
            {

            }

            //check Status filter 
            if (status != null)
            {
                filters.Add(FilterByStatus(status));
            }
            //check Priority filter
            if (priority != null)
            {
                filters.Add(FilterByPriority(priority));
            }
            //check date filters
            if (FilterDate)
            {
                if (!CheckDatesAreCorrect(StartDate, EndDate))
                {
                    return null;
                }
                else
                {
                    filters.Add(FilterAfterSpecificDate(StartDate));
                    filters.Add(FilterAfterSpecificDate(EndDate));
                }
            }
            return filters;
        }

        public bool CheckDatesAreCorrect(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate > EndDate)
            {
                return false;
            }
            else if (StartDate > DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public SortDefinition<Ticket> GetSort(int Index)
        {
            switch (Index)
            {
                case 0:
                    return SortByCreationDateDescending();
                case 1:
                    return SortByCreationDateAscending();
            }
            return null;
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

        public SortDefinition<Ticket> SortByCreationDateDescending()
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
        public SortDefinition<Ticket> SortByPriority()
        {
            //sorting and returning the filterd tickets by high, medium and low priority
            var sort = Builders<Ticket>.Sort.Ascending(t => t.Priority);
            return sort;
        }
        public FilterDefinition<Ticket> FilterByPriority(Priority priority)
        {
            //sorting and returning the filterd tickets by one priority
            var filter = Builders<Ticket>.Filter.Eq(t => t.Priority, priority);
            return filter;
        }
    }
}

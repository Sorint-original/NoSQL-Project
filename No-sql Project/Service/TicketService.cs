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
        public Dictionary<Status, float> GetPercentages(Employee employee)
        {
            return ticketDAO.GetPercentagesForTickets(employee);
        }

        //Individual FEATURE SORIN ARCHIVING
        public void ArchiveTickets(List<Ticket> tickets)
        {
            foreach (Ticket ticket in tickets)
            {
                ticketDAO.DeleteTicket(ticket);
                ticketDAO.AddInArchive(ticket);
            }
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

        public List<Ticket> CustomQuerry(List<FilterDefinition<Ticket>> filters, int SortIndex)
        {
            return ticketDAO.CustomQuerry(filters, SortIndex);
        }

        //Get the filters for the custom querry
        public List<FilterDefinition<Ticket>> GetFilters(Employee querryedEmployee, string titleSearch, Status status, Priority priority, bool FilterDate, DateTime StartDate, DateTime EndDate)
        {
            List<FilterDefinition<Ticket>> filters = new List<FilterDefinition<Ticket>>();
            //checks if it filters by an employee id
            if (querryedEmployee != null)
            {
                filters.Add(FilterTicketsByEmployee(querryedEmployee));
            }
            //check title search
            if (!string.IsNullOrWhiteSpace(titleSearch))
            {
                filters.Add(FilterTitle(titleSearch));
            }

            //check Status filter 
            if ((int)status != 0)
            {
                filters.Add(FilterByStatus(status));
            }
            //check Priority filter
            if ((int)priority != 0)
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
                    filters.Add(FilterBeforeSpecificDate(EndDate));
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

        //Methods that return filtres for custom querrys in listView
        //get filter based on employee
        public FilterDefinition<Ticket> FilterTicketsByEmployee(Employee employee)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.EmployeeId, employee.Id);
            return filter;
        }

        //Filter tickets by status
        public FilterDefinition<Ticket> FilterByStatus(Status Status)
        {
            var filter = Builders<Ticket>.Filter.Eq(t => t.Status, Status);
            return filter;
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

        // INDIVIDUAL FEATURE BRIAN PRIORITY FILTERING
        public FilterDefinition<Ticket> FilterByPriority(Priority priority)
        {
            //sorting and returning the filterd tickets by one priority
            var filter = Builders<Ticket>.Filter.Eq(t => t.Priority, priority);
            return filter;
        }

        //INDIVIDUAL FEATURE AYAZ FILTER TITLE

        public FilterDefinition<Ticket> FilterTitle(string title)
        {
            return Builders<Ticket>.Filter.Regex("Title", new MongoDB.Bson.BsonRegularExpression(title, "i")); // 'i' for case-insensitive
        }
    }
}

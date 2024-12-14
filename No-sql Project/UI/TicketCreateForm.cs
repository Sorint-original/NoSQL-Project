using Model;
using MongoDB.Bson;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class TicketCreateForm : Form
    {
        private Ticket ticketInput = null;
        private Employee logedEmployee;
        private TicketService ticketService;
        public TicketCreateForm(Employee logedEmployee, Ticket ticket = null)
        {
            InitializeComponent();
            ticketService = new TicketService();
            this.logedEmployee = logedEmployee;
            PriorityBox.SelectedIndex = 0;
            StatusBox.SelectedIndex = 0;

            if(logedEmployee.Role == Role.regular)//Only an admin could change the status of a ticket
            {
                StatusPanel.Hide();
            }
            else
            {
                StatusPanel.Show();
            }
            if (ticket != null) {
                UpdateTicket(ticket);
            }
        }

        private void UpdateTicket(Ticket ticket)// fills the form witht the proprieties of the tickt that is being updated
        {
            ticketInput = ticket;
            TickeTitleBox.Text = ticket.Title;
            DescriptionBox.Text = ticket.Description;
            PriorityBox.SelectedIndex = (int)ticket.Priority -1;
            StatusBox.SelectedIndex = (int)ticket.Status - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)// canels and exits the ticket creator
        {
            this.Close();
        }

        private Status GetStatus()// gets status from status combo box
        {
            return (Status)(StatusBox.SelectedIndex+1);
        }

        private Priority GetPriority()// gets priority from priority combo box
        {
            return (Priority)(PriorityBox.SelectedIndex + 1);
        }

        private void AddTicket()
        {
            try
            {
                Ticket ticket = new Ticket(ObjectId.GenerateNewId(), logedEmployee.Id, TickeTitleBox.Text, DescriptionBox.Text, GetStatus(), GetPriority(), DateTime.Now, DateTime.MinValue);
                if(ticket.Status > Status.pending)// in case an admin creates a ticket that is already completed(it happens especially when we created filler data)
                {
                    ticket.SolutionTime = DateTime.Now;
                }
                ticketService.CreateTicket(ticket);
                MessageBox.Show("Tciket created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTicket()
        {
            try
            {
                ticketService.UpdateTicket(ticketInput);
                MessageBox.Show("Tciket created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TickeTitleBox.Text) || string.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Ttile and ddescription can't be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ticketInput == null)
                {
                    AddTicket();
                }
                else
                {
                    ticketInput.Title = TickeTitleBox.Text;
                    ticketInput.Description = DescriptionBox.Text;
                    ticketInput.Priority = GetPriority();
                    if (ticketInput.Status != GetStatus())
                    {
                        if (ticketInput.Status < Status.resolved && GetStatus() >= Status.resolved)//Thhe ticket has been solved or closed
                        {
                            ticketInput.SolutionTime = DateTime.Now;    
                        }
                        else if(ticketInput.Status >= Status.resolved && GetStatus() < Status.resolved)// the solution or closed status have been undone
                        {
                            ticketInput.SolutionTime = DateTime.MinValue;
                        }
                        ticketInput.Status = GetStatus();
                    }
                    UpdateTicket();

                }

            }
        }

    }
}

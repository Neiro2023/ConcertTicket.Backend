using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketAmphitheater
{
    public class CreateTicketAmphitheater : IRequest<TicketAmphitheater>
    {
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public int TicketRow { get; set; }
        public int TicketPlace { get; set; }
    }
}

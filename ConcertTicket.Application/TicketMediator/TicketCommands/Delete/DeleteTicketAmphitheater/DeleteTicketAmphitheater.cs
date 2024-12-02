using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketAmphitheater
{
    public class DeleteTicketAmphitheater : IRequest
    {
        public string GuestPhone { get; set; }
    }
}

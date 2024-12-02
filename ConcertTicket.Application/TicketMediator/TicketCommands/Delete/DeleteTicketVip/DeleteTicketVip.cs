using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeliteTicket
{
    public class DeleteTicketVip : IRequest
    {
        public string GuestPhone { get; set; }
    }
}

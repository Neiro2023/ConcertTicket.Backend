using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketVip
{
    public class UpdateTicketVip : IRequest
    {
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
    }
}

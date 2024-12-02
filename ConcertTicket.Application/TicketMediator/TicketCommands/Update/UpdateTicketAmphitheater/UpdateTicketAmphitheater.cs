using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketAmphitheater
{
    public class UpdateTicketAmphitheater : IRequest
    {
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
    }
}

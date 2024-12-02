using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicket
{
    public class UpdateTicketBalcony : IRequest
    {
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
    }
}

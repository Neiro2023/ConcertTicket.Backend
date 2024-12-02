using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketBalcony
{
    public class DeleteTicketBalcony : IRequest
    {
        public string GuestPhone { get; set; }
    }
}

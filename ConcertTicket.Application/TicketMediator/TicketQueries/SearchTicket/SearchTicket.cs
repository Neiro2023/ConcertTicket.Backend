using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket
{
    public class SearchTicket : IRequest<SearchTicketVm>
    {
        public string GuestPhone { get; set; }
    }
}

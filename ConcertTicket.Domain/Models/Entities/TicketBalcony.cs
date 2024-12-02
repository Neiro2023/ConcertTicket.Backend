using ConcertTicket.Domain.Models.Enums;

namespace ConcertTicket.Domain.Models.Entities
{
    public sealed class TicketBalcony : Ticket
    {
        public TicketRowEnum TicketStatus { get; private set; } = TicketRowEnum.Balcony;
        public decimal TicketPrice { get; private set; } = 20_000.00m;
    }
}

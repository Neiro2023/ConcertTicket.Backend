using ConcertTicket.Domain.Models.Enums;

namespace ConcertTicket.Domain.Models.Entities
{
    public sealed class TicketVip : Ticket
    {
        public TicketRowEnum TicketStatus { get; private set; } = TicketRowEnum.VIP;
        public decimal TicketPrice { get; private set; } = 100_000.00m;
    }
}

using ConcertTicket.Domain.Models.Enums;

namespace ConcertTicket.Domain.Models.Entities
{
    public sealed class TicketAmphitheater : Ticket
    {
        public TicketRowEnum TicketStatus { get; private set; } = TicketRowEnum.Amphitheater;
        public decimal TicketPrice { get; private set; } = 50_000.00m;
    }
}

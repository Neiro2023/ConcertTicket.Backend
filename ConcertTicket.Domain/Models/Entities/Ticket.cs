namespace ConcertTicket.Domain.Models.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SerialId { get; set; } = Guid.NewGuid();
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public int TicketRow { get; set; }
        public int TicketPlace { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
        public DateOnly ConcertDate { get; private set; } = new DateOnly(2025, 03, 01);
        public string ConcertPlace { get; private set; } = "Город: Москва, Улица: Кремлевская набережная, Номер: 1";
    }
}

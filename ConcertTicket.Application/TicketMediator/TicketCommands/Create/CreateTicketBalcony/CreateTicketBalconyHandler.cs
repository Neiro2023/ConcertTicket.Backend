using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketBalcony
{
    public class CreateTicketBalconyHandler : IRequestHandler<CreateTicketBalcony, TicketBalcony>
    {
        private readonly IPostgreDbContext _dbContext;
        public CreateTicketBalconyHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task<TicketBalcony> Handle(CreateTicketBalcony request, CancellationToken cancellationToken)
        {
            TicketBalcony ticketBalcony = new TicketBalcony { GuestName = request.GuestName, GuestPhone = request.GuestPhone, TicketRow = request.TicketRow, TicketPlace = request.TicketPlace };
            if ((request.TicketPlace < 51 || request.TicketPlace > 100) && (request.TicketRow < 6 || request.TicketRow > 10))
            {
                await Console.Out.WriteLineAsync("Для балкона предусмотренны 6, 7, 8, 9 и 10 ряды, места с 51 по 100");
                throw new Exception("Для балкона предусмотренны 6, 7, 8, 9 и 10 ряды, места с 51 по 100");
            }
            await _dbContext.TicketBalconies.AddAsync(ticketBalcony, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return ticketBalcony;
        }
    }
}

using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicket
{
    public class CreateTicketVipHanler : IRequestHandler<CreateTicketVip, TicketVip>
    {
        private readonly IPostgreDbContext _dbContext;
        public CreateTicketVipHanler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task<TicketVip> Handle(CreateTicketVip request, CancellationToken cancellationToken)
        {
            TicketVip ticketVip = new TicketVip { GuestName = request.GuestName, GuestPhone = request.GuestPhone, TicketRow = request.TicketRow, TicketPlace = request.TicketPlace };

            if ((request.TicketPlace < 1 || request.TicketPlace > 10) && (request.TicketRow != 1))
            {
                await Console.Out.WriteLineAsync("Для VIP предусмотрен ряд 1, места с 1 по 10");
                throw new Exception("Для VIP предусмотрен ряд 1, места с 1 по 10");
            }
            await _dbContext.TicketVips.AddAsync(ticketVip, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return ticketVip;
        }
    }
}

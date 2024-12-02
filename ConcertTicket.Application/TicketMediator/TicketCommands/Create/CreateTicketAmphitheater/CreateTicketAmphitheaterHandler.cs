using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketAmphitheater
{
    public class CreateTicketAmphitheaterHandler : IRequestHandler<CreateTicketAmphitheater, TicketAmphitheater>
    {
        private readonly IPostgreDbContext _dbContext;
        public CreateTicketAmphitheaterHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task<TicketAmphitheater> Handle(CreateTicketAmphitheater request, CancellationToken cancellationToken)
        {
            TicketAmphitheater ticketAmphitheater = new TicketAmphitheater { GuestName = request.GuestName, GuestPhone = request.GuestPhone, TicketRow = request.TicketRow, TicketPlace = request.TicketPlace };

            if ((request.TicketPlace <= 10 || request.TicketPlace > 50) && (request.TicketRow <= 2 || request.TicketRow > 5))
            {
                await Console.Out.WriteLineAsync("Для амфитеатра предусмотренны 2, 3, 4 и 5 ряды, места с 11 по 50");
                throw new Exception("Для амфитеатра предусмотренны 2, 3, 4 и 5 ряды, места с 11 по 50");
            }

            await _dbContext.TicketAmphitheaters.AddAsync(ticketAmphitheater, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return ticketAmphitheater;
        }
    }
}

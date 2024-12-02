using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketAmphitheater
{
    public class DeleteTicketAmphitheaterHandler : IRequestHandler<DeleteTicketAmphitheater>
    {
        private readonly IPostgreDbContext _dbContext;
        public DeleteTicketAmphitheaterHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteTicketAmphitheater request, CancellationToken cancellationToken)
        {
            TicketAmphitheater ticketAmphitheater = await _dbContext.TicketAmphitheaters.FindAsync(new[] { request.GuestPhone }, cancellationToken);
            if (ticketAmphitheater == null || ticketAmphitheater.GuestPhone != request.GuestPhone)
            {
                await Console.Out.WriteLineAsync($"Билета с номером телефона {ticketAmphitheater.GuestPhone} не зарегистрированно");
                throw new Exception("Такого билета нет");
            }
            _dbContext.TicketAmphitheaters.Remove(ticketAmphitheater);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await Console.Out.WriteLineAsync($"Место {ticketAmphitheater.TicketPlace}, {ticketAmphitheater.TicketRow}го ряда освободилось");
        }
    }
}

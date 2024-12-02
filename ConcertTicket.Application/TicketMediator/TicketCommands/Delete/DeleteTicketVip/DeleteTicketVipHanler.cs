using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeliteTicket
{
    public class DeleteTicketVipHanler : IRequestHandler<DeleteTicketVip>
    {
        private readonly IPostgreDbContext _dbContext;
        public DeleteTicketVipHanler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteTicketVip request, CancellationToken cancellationToken)
        {
            TicketVip ticketVip = await _dbContext.TicketVips.FindAsync(new[] { request.GuestPhone }, cancellationToken);
            if (ticketVip == null || ticketVip.GuestPhone != request.GuestPhone)
            {
                await Console.Out.WriteLineAsync($"Билета с номером телефона {ticketVip.GuestPhone} не зарегистрированно");
                throw new Exception("Такого билета нет");
            }
            _dbContext.TicketVips.Remove(ticketVip);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await Console.Out.WriteLineAsync($"Место {ticketVip.TicketPlace}, {ticketVip.TicketRow}го ряда освободилось");
        }
    }
}

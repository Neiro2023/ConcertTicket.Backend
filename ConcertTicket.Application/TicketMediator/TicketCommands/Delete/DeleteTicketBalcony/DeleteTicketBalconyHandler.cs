using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketBalcony
{
    public class DeleteTicketBalconyHandler : IRequestHandler<DeleteTicketBalcony>
    {
        private readonly IPostgreDbContext _dbContext;
        public DeleteTicketBalconyHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteTicketBalcony request, CancellationToken cancellationToken)
        {
            TicketBalcony ticketBalcony = await _dbContext.TicketBalconies.FindAsync(new[] { request.GuestPhone }, cancellationToken);
            if (ticketBalcony == null || ticketBalcony.GuestPhone != request.GuestPhone)
            {
                await Console.Out.WriteLineAsync($"Билета с номером телефона {ticketBalcony.GuestPhone} не зарегистрированно");
                throw new Exception("Такого билета нет");
            }
            _dbContext.TicketBalconies.Remove(ticketBalcony);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await Console.Out.WriteLineAsync($"Место {ticketBalcony.TicketPlace}, {ticketBalcony.TicketRow}го ряда освободилось");
        }
    }
}

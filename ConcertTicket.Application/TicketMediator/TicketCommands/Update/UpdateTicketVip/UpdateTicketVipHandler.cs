using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketVip
{
    public class UpdateTicketVipHandler : IRequestHandler<UpdateTicketVip>
    {
        private readonly IPostgreDbContext _dbContext;
        public UpdateTicketVipHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateTicketVip request, CancellationToken cancellationToken)
        {
            TicketVip ticketVip = await _dbContext.TicketVips.FirstOrDefaultAsync(n => n.GuestPhone == request.GuestPhone, cancellationToken);

            if (ticketVip == null || ticketVip.GuestPhone != request.GuestPhone)
            {
                await Console.Out.WriteLineAsync($"Билета с номером телефона {ticketVip.GuestPhone} не найдено");
                throw new Exception("Такого билета нет");
            }

            ticketVip.GuestName = request.GuestName;
            ticketVip.GuestPhone = request.GuestPhone;
            ticketVip.EditDate = DateTime.UtcNow;

            _dbContext.TicketVips.Update(ticketVip);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

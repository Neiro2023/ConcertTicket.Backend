using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketAmphitheater
{
    public class UpdateTicketAmphitheaterHandler : IRequestHandler<UpdateTicketAmphitheater>
    {
        private readonly IPostgreDbContext _dbContext;
        public UpdateTicketAmphitheaterHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateTicketAmphitheater request, CancellationToken cancellationToken)
        {
            TicketAmphitheater ticketAmphitheater = await _dbContext.TicketAmphitheaters.FirstOrDefaultAsync(n => n.GuestPhone == request.GuestPhone, cancellationToken);

            if (ticketAmphitheater == null || ticketAmphitheater.GuestPhone != request.GuestPhone)
            {
                await Console.Out.WriteLineAsync($"Билета с номером телефона {ticketAmphitheater.GuestPhone} не найдено");
                throw new Exception("Такого билета нет");
            }

            ticketAmphitheater.GuestName = request.GuestName;
            ticketAmphitheater.GuestPhone = request.GuestPhone;
            ticketAmphitheater.EditDate = DateTime.UtcNow;

            _dbContext.TicketAmphitheaters.Update(ticketAmphitheater);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

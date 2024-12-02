using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicket
{
    public class UpdateTicketBalconyHandler : IRequestHandler<UpdateTicketBalcony>
    {
        private readonly IPostgreDbContext _dbContext;
        public UpdateTicketBalconyHandler(IPostgreDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateTicketBalcony request, CancellationToken cancellationToken)
        {
            TicketBalcony ticketBalcony = await _dbContext.TicketBalconies.FirstOrDefaultAsync(n => n.GuestPhone == request.GuestPhone, cancellationToken);

            if (ticketBalcony == null || ticketBalcony.GuestPhone != request.GuestPhone)
            {
                await Console.Out.WriteLineAsync($"Билета с номером телефона {ticketBalcony.GuestPhone} не найдено");
                throw new Exception("Такого билета нет");
            }

            ticketBalcony.GuestName = request.GuestName;
            ticketBalcony.GuestPhone = request.GuestPhone;
            ticketBalcony.EditDate = DateTime.UtcNow;

            _dbContext.TicketBalconies.Update(ticketBalcony);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

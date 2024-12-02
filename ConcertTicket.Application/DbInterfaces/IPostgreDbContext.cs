using ConcertTicket.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicket.Application.DbContexts
{
    public interface IPostgreDbContext
    {
        public DbSet<TicketVip> TicketVips { get; set; } 
        public DbSet<TicketAmphitheater> TicketAmphitheaters { get; set; } 
        public DbSet<TicketBalcony> TicketBalconies { get; set; } 
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

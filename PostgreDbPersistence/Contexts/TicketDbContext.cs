using ConcertTicket.Application.DbContexts;
using ConcertTicket.Domain.Models.Entities;
using ConcertTicket.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostgreDbPersistence.Configurations;

namespace PostgreDbPersistence.Contexts
{
    public class TicketDbContext : DbContext, IPostgreDbContext
    {
        public DbSet<TicketVip> TicketVips { get; set; } = null!;
        public DbSet<TicketAmphitheater> TicketAmphitheaters { get; set; } = null!;
        public DbSet<TicketBalcony> TicketBalconies { get; set; } = null!;

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var converter = new EnumToStringConverter<TicketRowEnum>();
            builder.Entity<TicketVip>().Property(e => e.TicketStatus).HasConversion(converter);
            var converter1 = new EnumToStringConverter<TicketRowEnum>();
            builder.Entity<TicketAmphitheater>().Property(e => e.TicketStatus).HasConversion(converter);
            var converter2 = new EnumToStringConverter<TicketRowEnum>();
            builder.Entity<TicketBalcony>().Property(e => e.TicketStatus).HasConversion(converter);
            builder.ApplyConfiguration(new TicketConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

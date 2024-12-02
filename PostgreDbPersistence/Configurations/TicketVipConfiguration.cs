using ConcertTicket.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostgreDbPersistence.Configurations
{
    public class TicketVipConfiguration : IEntityTypeConfiguration<TicketVip>
    {
        public void Configure(EntityTypeBuilder<TicketVip> builder)
        {
            builder.HasIndex(u => u.TicketPlace).IsUnique();
            builder.HasIndex(u => u.TicketRow).IsUnique();
            builder.HasIndex(u => u.GuestPhone).IsUnique();
            builder.Property(u => u.GuestPhone).HasMaxLength(11);
        }
    }
}

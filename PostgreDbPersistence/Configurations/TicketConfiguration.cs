using ConcertTicket.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostgreDbPersistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasKey(x => x.SerialId);
            builder.HasIndex(x => x.SerialId).IsUnique();
            builder.Property(u => u.GuestName).HasMaxLength(50);
        }
    }
}

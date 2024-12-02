using ConcertTicket.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostgreDbPersistence.Configurations
{
    public class TicketAmphitheaterConfiguration : IEntityTypeConfiguration<TicketAmphitheater>
    {
        public void Configure(EntityTypeBuilder<TicketAmphitheater> builder)
        {
            builder.HasKey(x => x.TicketPlace);
            builder.HasIndex(u => u.TicketPlace).IsUnique();
            builder.HasKey(x => x.GuestPhone);
            builder.HasIndex(u => u.GuestPhone).IsUnique();
            builder.Property(u=> u.GuestPhone).HasMaxLength(11);
        }
    }
}

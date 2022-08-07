using Bookings.Domain;
using Bookings.Persistence.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookings.Persistence.EntityConfiguration
{
    public class BookingStatusConfiguration : EntityConfigurationBase<BookingStatus, int>
    {
        public override void ConfigureMore(EntityTypeBuilder<BookingStatus> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("BookingStatus");
            builder.Property(e => e.ID);
            builder.HasData(
                new BookingStatus { ID = 1, Status = "Reserved" },
                new BookingStatus { ID = 2, Status = "Confirmed" }
            );
        }
    }
}

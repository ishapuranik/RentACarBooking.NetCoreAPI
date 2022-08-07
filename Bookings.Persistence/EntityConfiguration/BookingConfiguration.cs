using Bookings.Domain;
using Bookings.Persistence.Core;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Persistence.EntityConfiguration
{
    public class BookingConfiguration : EntityConfigurationBase<Booking, int>
    {
        public override void ConfigureMore(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("Booking").HasOne<Vehicle>(s => s.Vehicle)
                .WithMany(g => g.Booking)
                .HasForeignKey(s => s.VehicleID);

            builder.HasOne<Renter>(d => d.RenterDetails)
                .WithMany(g => g.Bookings)
                .HasForeignKey(s => s.RenterID);

            builder.HasOne<BookingStatus>(d => d.BookingStatus)
                .WithMany(g => g.Bookings)
                .HasForeignKey(s => s.BookingStatusID);

            builder.Property(e => e.ID).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}

using Bookings.Domain;
using Bookings.Persistence.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookings.Persistence.EntityConfiguration
{
    public class RenterConfiguration : EntityConfigurationBase<Renter, int>
    {
        public override void ConfigureMore(EntityTypeBuilder<Renter> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("Renter");
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
        }
    }
}

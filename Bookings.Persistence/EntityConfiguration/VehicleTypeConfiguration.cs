using Bookings.Domain;
using Bookings.Persistence.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookings.Persistence.EntityConfiguration
{
    public class VehicleTypeConfiguration : EntityConfigurationBase<VehicleType, int>
    {
        public override void ConfigureMore(EntityTypeBuilder<VehicleType> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("VehicleType");
            builder.Property(e => e.ID);
            builder.HasData(
                new VehicleType { ID = 1,  Type = "Hatchback" },
                new VehicleType { ID = 2, Type = "SUV" },
                new VehicleType { ID = 3, Type = "4 -Wheel Drive" },
                new VehicleType { ID = 4, Type = "Minivan" },
                new VehicleType { ID = 5, Type = "Convertible" }
            );
        }
    }
}

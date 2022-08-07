using Bookings.Domain;
using Bookings.Persistence.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookings.Persistence.EntityConfiguration
{
    public class VehicleConfiguration : EntityConfigurationBase<Vehicle, int>
    {
        public override void ConfigureMore(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("Vehicle");
            builder.Property(e => e.ID);
            builder.HasData(
                            new Vehicle { ID = 1, Make = "Fiat", Model = "500", NumberOfPassengerSeats = 40, VehicleTypeID = 1, StandardPerDayRate = 130.88m, PeakPerDayRate = 145.7m, FleetQuantity = 5 },
                            new Vehicle { ID = 2, Make = "Vauxhall", Model = "Crossland", NumberOfPassengerSeats = 4, VehicleTypeID = 2, StandardPerDayRate = 165.30m, PeakPerDayRate = 180.30m, FleetQuantity = 2 },
                            new Vehicle { ID = 3, Make = "Range Rover", Model = "Evoque", NumberOfPassengerSeats = 4, VehicleTypeID = 3, StandardPerDayRate = 250.00m, PeakPerDayRate = 275.50m, FleetQuantity = 2 },
                            new Vehicle { ID = 4, Make = "Mercedes-Benz", Model = "E300 Cabriolet", NumberOfPassengerSeats = 3, VehicleTypeID = 5, StandardPerDayRate = 270.22m, PeakPerDayRate = 300.65m, FleetQuantity = 1 },
                            new Vehicle { ID = 5, Make = "Mercedes-Benz", Model = "V220d Sport MPV", NumberOfPassengerSeats = 7, VehicleTypeID = 4, StandardPerDayRate = 362.30m, PeakPerDayRate = 410.05m, FleetQuantity = 2 },
                            new Vehicle { ID = 6, Make = "Range Rover", Model = "Velar D300 R", NumberOfPassengerSeats = 4, VehicleTypeID = 3, StandardPerDayRate = 350.99m, PeakPerDayRate = 380.00m, FleetQuantity = 3 },
                            new Vehicle { ID = 7, Make = "Citroen", Model = "Grand Picasso", NumberOfPassengerSeats = 6, VehicleTypeID = 4, StandardPerDayRate = 345.17m, PeakPerDayRate = 380.00m, FleetQuantity = 3 },
                            new Vehicle { ID = 8, Make = "Volkswagen", Model = "Golf", NumberOfPassengerSeats = 4, VehicleTypeID = 1, StandardPerDayRate = 180.04m, PeakPerDayRate = 200.12m, FleetQuantity = 3 },
                            new Vehicle { ID = 9, Make = "Mercedes-Benz", Model = "A Class", NumberOfPassengerSeats = 4, VehicleTypeID = 1, StandardPerDayRate = 270.31m, PeakPerDayRate = 282.99m, FleetQuantity = 3 },
                            new Vehicle { ID = 10, Make = "Skoda", Model = "Octavia", NumberOfPassengerSeats = 4, VehicleTypeID = 1, StandardPerDayRate = 272.42m, PeakPerDayRate = 283.12m, FleetQuantity = 2 },
                            new Vehicle { ID = 11, Make = "MG", Model = "ZS Auto", NumberOfPassengerSeats = 4, VehicleTypeID = 2, StandardPerDayRate = 245.72m, PeakPerDayRate = 250.81m, FleetQuantity = 1 }
                );
        }
    }
}

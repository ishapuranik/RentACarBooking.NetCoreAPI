using System.ComponentModel.DataAnnotations.Schema;

namespace Bookings.Domain
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NumberOfPassengerSeats { get; set; }
        public int VehicleTypeID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal StandardPerDayRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PeakPerDayRate { get; set; }
        public int FleetQuantity { get; set; }
        public ICollection<Booking> Booking { get; set; }
    }
}

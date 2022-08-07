using System.ComponentModel.DataAnnotations.Schema;

namespace Bookings.Domain
{
    public class Booking
    {
        public int ID { get; set; }
        public string Reference { get; set; }
        public int VehicleID { get; set; }
        public int RenterID { get; set; }
        public DateTime RenterStartDate { get; set; }
        public DateTime RenterEndDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCost { get; set; }
        public int BookingStatusID { get; set; }
        public Vehicle Vehicle { get; set; }
        public Renter RenterDetails { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Shared.Dtos
{
    public class ReserveBookingDto
    {
        public string Reference { get; set; }
        public int VehicleID { get; set; }
        public int RenterID { get; set; }
        public DateTime RenterStartDate { get; set; }
        public DateTime RenterEndDate { get; set; }
        public decimal TotalCost { get; set; }
        public int BookingStatusID { get; set; }
    }
}

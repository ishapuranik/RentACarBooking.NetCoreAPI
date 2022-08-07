using Bookings.Shared.ResponseModels;
using MediatR;

namespace Bookings.API.CQRS.Booking.Command
{
    public class ReserveBookingRequest : IRequest<GetReserveBookingCommandResponse>
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

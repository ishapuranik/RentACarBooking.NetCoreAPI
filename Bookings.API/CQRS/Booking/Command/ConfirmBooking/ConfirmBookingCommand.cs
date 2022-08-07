using Bookings.Shared.ResponseModels;
using MediatR;

namespace Bookings.API.CQRS.Booking.Command.ConfirmBooking
{
    public class ConfirmBookingCommand : IRequest<GetConfirmBookingResponse>
    { 
        public int BookingID { get; set; }
    }
}

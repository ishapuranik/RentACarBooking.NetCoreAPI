using Bookings.Shared.Dtos;

namespace Bookings.Services
{
    public interface IBookingService
    {
        public Task<int> ReserveBooking(ReserveBookingDto request);
        public Task ConfirmBooking(int bookingID);
    }
}

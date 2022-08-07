using Bookings.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Services
{
    public interface IBookingService
    {
        public Task<int> ReserveBooking(ReserveBookingDto request);
        public Task ConfirmBooking(int bookingID);
    }
}

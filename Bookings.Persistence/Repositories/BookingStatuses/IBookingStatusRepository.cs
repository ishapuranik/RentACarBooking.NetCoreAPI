using Bookings.Domain.Core;

namespace Bookings.Domain.Repositories.BookingStatuses
{
    public interface IBookingStatusRepository : IRepository<BookingStatus, int>
    {
    }
}

using Bookings.Persistence;
using Bookings.Persistence.Core;

namespace Bookings.Domain.Repositories.BookingStatuses
{
    public class BookingStatusRepository : RepositoryBase<BookingStatus, RentACarDBContext, int>, IBookingStatusRepository

    {
        public BookingStatusRepository(RentACarDBContext dbContext) : base(dbContext)
        {
        }

    }
}

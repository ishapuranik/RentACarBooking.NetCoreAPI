using Bookings.Persistence;
using Bookings.Persistence.Core;

namespace Bookings.Domain.Repositories.Bookings
{
    public class BookingRepository : RepositoryBase<Booking, RentACarDBContext, int>, IBookingRepository

    {
        public BookingRepository(RentACarDBContext dbContext) : base(dbContext)
        {
        }
    }
}

using Bookings.Domain;
using Bookings.Persistence.Core;

namespace Bookings.Persistence.Repositories.Renters
{
    public class RenterRepository : RepositoryBase<Renter, RentACarDBContext, int>, IRenterRepository
    {
        public RenterRepository(RentACarDBContext dbContext) : base(dbContext)
        {
        }
    }
}

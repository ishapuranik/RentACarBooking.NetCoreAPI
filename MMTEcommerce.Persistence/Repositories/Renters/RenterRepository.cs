using Bookings.Domain;
using Bookings.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Persistence.Repositories.Renters
{
    public class RenterRepository : RepositoryBase<Renter, RentACarDBContext, int>, IRenterRepository
    {
        public RenterRepository(RentACarDBContext dbContext) : base(dbContext)
        {
        }
    }
}

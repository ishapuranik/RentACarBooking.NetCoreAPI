using Bookings.Persistence;
using Bookings.Persistence.Core;

namespace Bookings.Domain.Repositories.VehicleTypes
{
    public class VehicleTypeRepository : RepositoryBase<Vehicle, RentACarDBContext, int>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(RentACarDBContext dbContext) : base(dbContext)
        {
        }
    }
}

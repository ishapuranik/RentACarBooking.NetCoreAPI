using Bookings.Persistence;
using Bookings.Persistence.Core;

namespace Bookings.Domain.Repositories.Vehicles
{
    public class VehicleRepository : RepositoryBase<Vehicle, RentACarDBContext, int>, IVehicleRepository
    {
        public VehicleRepository(RentACarDBContext dbContext) : base(dbContext)
        {
        }

        public int GetVehicleFleetQuantity(int id)
        {
            var vehicle = Query.Where(x => x.ID == id).SingleOrDefault();
            return vehicle == null ? throw new KeyNotFoundException($"Vehicle with ID {id} not found") : vehicle.FleetQuantity;
        }
    }
}

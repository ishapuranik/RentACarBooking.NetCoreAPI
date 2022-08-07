using Bookings.Domain.Core;

namespace Bookings.Domain.Repositories.Vehicles
{
    public interface IVehicleRepository : IRepository<Vehicle, int>
    {
        int GetVehicleFleetQuantity(int id);
    }
}

using Bookings.Domain.Repositories.Bookings;
using Bookings.Domain.Repositories.Vehicles;
using Bookings.Persistence;
using Bookings.Shared.Persistence;
using Bookings.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingsAPI.Tests.Services
{
    public class BookingServiceTests
    {
        private InMemoryDbContext<RentACarDBContext> _inMemoryDbContext;
        private IBookingRepository _bookingRepository;
        private IVehicleRepository _vehicleRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public BookingServiceTests()
        {
            SetupInMemoryDB();
            SetupRepositories();
        }

        private void SetupInMemoryDB()
        {
            _inMemoryDbContext = new InMemoryDbContext<RentACarDBContext>("RentACarDB_InMemory");
            InMemoryDbHelper.PopulateInMemoryDb(_inMemoryDbContext);
        }

        private void SetupRepositories()
        {
            var dbContext = _inMemoryDbContext.GetDbContext();
            _bookingRepository = new BookingRepository(dbContext);
            _vehicleRepository = new VehicleRepository(dbContext);
        }

        [Fact(Skip ="")]
        public void ConfirmBooking_Updates_Booking_record_to_Confirmed()
        {
            //Since, the tests runs one by one - at the end of the assertions in each tests methods, please make sure we do call - _inMemoryDbContext.Database.EnsureDeleted();
        }

        [Fact(Skip = "")]
        public void ConfirmBooking_throw_KeyNotFoundException_when_bookingID_not_found()
        {

        }

        [Fact(Skip = "")]
        public void ReserveBooking_throw_KeyNotFoundException_when_bookingID_not_found()
        {

        }

        [Fact(Skip = "")]
        public void ReserveBooking_calls_SaveChangesAsync()
        {

        }
    }
}

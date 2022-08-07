using Bookings.Persistence;

namespace Bookings.Tests.Helpers
{
    public static class InMemoryDbHelper
    {
        private static void AddBookingStatusEntities(InMemoryDbContext<RentACarDBContext> context)
        {
            /* 
             * Add entities data
            context.AddEntities<BookingStatus>(new List<BookingStatus>() {
                new BookingStatus()
                {
                   
                }
                ,new BookingStatus()
                {
                    
                }
            });
            */
        }

        private static void AddVehicleTypeEntities(InMemoryDbContext<RentACarDBContext> context)
        {
            /* 
             * Add entities data
            context.AddEntities<VehicleType>(new List<VehicleType>() {
                new VehicleType()
                {
                   
                }
                ,new VehicleType()
                {
                    
                }
            });
            */
        }

        private static void AddVehicleEntities(InMemoryDbContext<RentACarDBContext> context)
        {
            /* 
             * Add entities data
            context.AddEntities<Vehicle>(new List<Vehicle>() {
                new Vehicle()
                {
                   
                }
                ,new Vehicle()
                {
                    
                }
                ,new Vehicle()
                {
                    
                }
                ,new Vehicle()
                {
                    
                }
            });
            */
        }

        private static void AddRenterEntities(InMemoryDbContext<RentACarDBContext> context)
        {
            /* 
             * Add entities data
            context.AddEntities<Renter>(new List<Renter>() {
                new Renter()
                {
                   
                }
                ,new Renter()
                {
                    
                }
                ,new Renter()
                {
                    
                }
                ,new Renter()
                {
                    
                }
            });
            */
        }

        private static void AddBookingEntities(InMemoryDbContext<RentACarDBContext> context)
        {
            /* 
             * Add entities data
            context.AddEntities<Booking>(new List<Booking>() {
                new Booking()
                {
                   
                }
                ,new Booking()
                {
                    
                }
                ,new Booking()
                {
                    
                }
                ,new Booking()
                {
                    
                }
            });
            */
        }

        public static void PopulateInMemoryDb(InMemoryDbContext<RentACarDBContext> inMemoryDbContext)
        {
            AddVehicleTypeEntities(inMemoryDbContext);
            AddBookingStatusEntities(inMemoryDbContext);
            AddRenterEntities(inMemoryDbContext);
            AddVehicleEntities(inMemoryDbContext);
            AddBookingEntities(inMemoryDbContext);
        }
    }
}

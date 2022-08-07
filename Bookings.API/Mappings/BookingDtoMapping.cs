using AutoMapper;
using Bookings.API.CQRS.Booking.Command;
using Bookings.Shared.Dtos;

namespace Bookings.API.Mappings
{
    public class BookingDtoMapping : Profile
    {
        public BookingDtoMapping()
        {
            CreateMap<ReserveBookingRequest, ReserveBookingDto>();
        }
    }
}

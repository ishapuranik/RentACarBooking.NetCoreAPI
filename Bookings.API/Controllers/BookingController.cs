using Bookings.API.Core;
using Bookings.API.CQRS.Booking.Command;
using Bookings.API.CQRS.Booking.Command.ConfirmBooking;
using Bookings.Shared.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.API.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(
            IMediator mediator,
            IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _mediator = mediator;
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBooking([FromBody] ReserveBookingRequest command)
        {
            return await HandleRequest(command);
        }

        [HttpPut("confirmed")]
        public async Task<IActionResult> ConfirmBooking([FromBody] ConfirmBookingCommand command)
        {
            return await HandleRequest(command);
        }
    }
}

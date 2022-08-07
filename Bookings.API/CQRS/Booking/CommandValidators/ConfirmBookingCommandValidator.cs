using Bookings.API.CQRS.Booking.Command.ConfirmBooking;
using FluentValidation;

namespace Bookings.API.CQRS.Booking.CommandValidators
{
    public class ConfirmBookingCommandValidator : AbstractValidator<ConfirmBookingCommand>
    {
        public ConfirmBookingCommandValidator()
        {
            RuleFor(x => x.BookingID).NotEmpty().NotNull().NotEqual(0).WithMessage("A valid Booking ID is required.");
        }
    }
}

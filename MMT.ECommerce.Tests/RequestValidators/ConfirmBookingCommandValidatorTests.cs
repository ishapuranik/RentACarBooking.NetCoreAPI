using Bookings.API.CQRS.Booking.Command.ConfirmBooking;
using Bookings.API.CQRS.Booking.CommandValidators;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingsAPI.Tests.RequestValidators
{
    public class ConfirmBookingCommandValidatorTests
    {
        private ConfirmBookingCommandValidator _validator;

        public ConfirmBookingCommandValidatorTests()
        {
            _validator = new ConfirmBookingCommandValidator();
        }

        [Fact]
        public void Validator_Should_Not_Have_Error_When_RequestModel_Has_ValidValues()
        {
            //Arrange
            var model = new ConfirmBookingCommand()
            {
                BookingID = 1001
            };

            //Act
            var result = _validator.TestValidate(model);
            //Assert
            result.IsValid.Should().BeTrue();
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_Should_Have_Error_When_RequestModel_Has_InValidValues()
        {
            //Arrange
            var model = new ConfirmBookingCommand()
            {
                BookingID = 0
            };

            //Act
            var result = _validator.TestValidate(model);
            //Assert
            result.IsValid.Should().BeFalse();
            result.ShouldHaveValidationErrorFor("BookingID");
        }
    }
}

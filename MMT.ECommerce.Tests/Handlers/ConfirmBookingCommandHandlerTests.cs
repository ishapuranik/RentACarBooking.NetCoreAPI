using AutoMapper;
using Bookings.API.CQRS.Booking.Command;
using Bookings.API.CQRS.Booking.Command.ConfirmBooking;
using Bookings.Services;
using Bookings.Shared.Dtos;
using Bookings.Shared.Log;
using Bookings.Shared.ResponseModels;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BookingsAPI.Tests.Handlers
{
    public class ConfirmBookingCommandHandlerTests
    {
        private readonly Mock<ILogWrapper> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IBookingService> _bookingService;

        public ConfirmBookingCommandHandlerTests()
        {
            _logger = new Mock<ILogWrapper>();
            _mapper = new Mock<IMapper>();
            _bookingService = new Mock<IBookingService>();
        }

        [Fact]
        public async void ConfirmBookingCommandHandler_Should_Return_failed_response_when_key_not_found()
        {
            //Arrange
            var request = new ConfirmBookingCommand() { BookingID = 3534 };
            _bookingService.Setup(x => x.ConfirmBooking(It.IsAny<int>())).Throws<KeyNotFoundException>();

            var sut = new ConfirmBookingCommandHandler(_logger.Object, _mapper.Object, _bookingService.Object);
            var result = await sut.Handle(request, new CancellationToken());

            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Be($"Booking ID { request.BookingID } is invalid, failed to confirm the booking");
        }

        [Fact]
        public async void ConfirmBookingCommandHandler_Should_Return_success_response()
        {
            //Arrange
            var request = new ConfirmBookingCommand() { BookingID = 3534 };
            _bookingService.Setup(x => x.ConfirmBooking(It.IsAny<int>()));

            var sut = new ConfirmBookingCommandHandler(_logger.Object, _mapper.Object, _bookingService.Object);
            var result = await sut.Handle(request, new CancellationToken());

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

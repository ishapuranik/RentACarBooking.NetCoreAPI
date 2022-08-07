using AutoMapper;
using Bookings.API.CQRS.Booking.Command;
using Bookings.Services;
using Bookings.Shared.Dtos;
using Bookings.Shared.Log;
using Bookings.Shared.ResponseModels;
using FluentAssertions;
using Moq;
using Xunit;

namespace BookingsAPI.Tests.Handlers
{
    public class ReserveBookingRequestHandlerTests
    {
        private readonly Mock<ILogWrapper> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IBookingService> _bookingService;

        public ReserveBookingRequestHandlerTests()
        {
            _logger = new Mock<ILogWrapper>();
            _mapper = new Mock<IMapper>();
            _bookingService = new Mock<IBookingService>();
        }

        [Fact]
        public async void ReserveBookingRequestHandler_Handle_returns_failed_response_when_mapper_returns_null()
        {
            //Arrange
            var request = new ReserveBookingRequest() { BookingStatusID = 1001, Reference = "Ref", RenterEndDate = DateTime.Now.AddDays(10) };
            ReserveBookingDto reserveBookingDto = null;
            _mapper.Setup(x => x.Map<ReserveBookingDto>(request)).Returns(reserveBookingDto);

            var sut = new ReserveBookingRequestHandler(_logger.Object, _mapper.Object, null);

            var result = await sut.Handle(request, new CancellationToken());

            result.Should().BeOfType(typeof(GetReserveBookingCommandResponse));
            result.Success.Should().Be(false);
        }

        [Fact]
        public async void ReserveBookingRequestHandler_Handle_returns_valid_bookingID_in_the_response()
        {
            //Arrange
            int bookingID = 1123;
            var request = new ReserveBookingRequest() { BookingStatusID = 1001, Reference = "Ref", RenterEndDate = DateTime.Now.AddDays(10) };
            ReserveBookingDto reserveBookingDto = new ReserveBookingDto() { BookingStatusID = 1001, Reference = "Ref", RenterEndDate = DateTime.Now.AddDays(10) };

            _mapper.Setup(x => x.Map<ReserveBookingDto>(request)).Returns(reserveBookingDto);
            _bookingService.Setup(x => x.ReserveBooking(It.IsAny<ReserveBookingDto>())).ReturnsAsync(bookingID);

            var sut = new ReserveBookingRequestHandler(_logger.Object, _mapper.Object, _bookingService.Object);

            //Act
            var result = await sut.Handle(request, new CancellationToken());

            //Assert
            result.Should().BeOfType(typeof(GetReserveBookingCommandResponse));
            result.Success.Should().Be(true);
            result.BookingID.Should().Be(bookingID);
            _mapper.Verify(r => r.Map<ReserveBookingDto>(It.IsAny<ReserveBookingRequest>()), Times.Once);
        }
    }
}

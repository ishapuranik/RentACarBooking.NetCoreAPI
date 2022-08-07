using AutoMapper;
using Bookings.Services;
using Bookings.Shared.Log;
using Bookings.Shared.ResponseModels;
using MediatR;

namespace Bookings.API.CQRS.Booking.Command.ConfirmBooking
{
    public class ConfirmBookingCommandHandler : IRequestHandler<ConfirmBookingCommand, GetConfirmBookingResponse>
    {
        private readonly ILogWrapper _logger;
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;

        public ConfirmBookingCommandHandler(ILogWrapper logger, IMapper mapper, IBookingService bookingService)
        {
            _logger = logger;
            _mapper = mapper;
            _bookingService = bookingService;
        }

        public async Task<GetConfirmBookingResponse> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookingService.ConfirmBooking(request.BookingID);
            }
            catch (KeyNotFoundException)
            {
                _logger.Error($"Booking with booking ID {request.BookingID} not found. Cannot confirm the booking.", null);
                return new GetConfirmBookingResponse()
                {
                    Success = false,
                    Message = $"Booking ID { request.BookingID } is invalid, failed to confirm the booking"
                };
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to confirm vehicle booking having booking ID {request.BookingID}", ex);
                return new GetConfirmBookingResponse()
                {
                    Success = false,
                    Message = $"Failed to confirm the booking with BookingID {request.BookingID}"
                };
            }

            return new GetConfirmBookingResponse()
            {
                Success = true
            };
        }
    }
}

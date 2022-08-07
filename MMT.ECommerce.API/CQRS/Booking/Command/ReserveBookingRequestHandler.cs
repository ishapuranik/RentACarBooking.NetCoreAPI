using AutoMapper;
using Bookings.Services;
using Bookings.Shared.Dtos;
using Bookings.Shared.Log;
using Bookings.Shared.ResponseModels;
using MediatR;

namespace Bookings.API.CQRS.Booking.Command
{
    public class ReserveBookingRequestHandler : IRequestHandler<ReserveBookingRequest, GetReserveBookingCommandResponse>
    {
        private readonly ILogWrapper _logger;
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;

        public ReserveBookingRequestHandler(ILogWrapper logger, IMapper mapper, IBookingService bookingService)
        {
            _logger = logger;
            _mapper = mapper;
            _bookingService = bookingService;
        }

        public async Task<GetReserveBookingCommandResponse> Handle(ReserveBookingRequest request, CancellationToken cancellationToken)
        {
            int bookingID = 0;
            try
            {
                var reserveBookingDto = _mapper.Map<ReserveBookingDto>(request);

                if (reserveBookingDto == null)
                {
                    _logger.Error($"Failed to register vehicle booking for renter {request.RenterID}. Failed to map the request object", null);
                    return new GetReserveBookingCommandResponse()
                    {
                        Success = false,
                        Message = "Failed to map ReserveBookingRequest object" //Calling server will decide what message should ne displayed to the user or what to do with this message
                    };
                }

                bookingID = await _bookingService.ReserveBooking(reserveBookingDto);
            }
            catch (KeyNotFoundException)
            {
                _logger.Error($"Failed to register vehicle booking for renter {request.RenterID}. Vehicle record with ID {request.VehicleID} not found.", null);
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to register vehicle booking for renter {request.RenterID}", ex);
            }

            return new GetReserveBookingCommandResponse()
            {
                BookingID = bookingID,
                Success = bookingID != 0 ? true : false
            };
        }
    }
}

namespace Bookings.Shared.ResponseModels
{
    public class GetReserveBookingCommandResponse : BaseResponseModel
    {
        public bool Success { get; set; }
        public int BookingID { get; set; }
    }
}

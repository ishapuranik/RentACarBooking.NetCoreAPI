namespace Bookings.Domain
{
    public class BookingStatus
    {
        public int ID { get; set; }
        public string Status { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}

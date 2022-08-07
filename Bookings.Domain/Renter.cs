namespace Bookings.Domain
{
    public class Renter
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        //A user can rent multiple cars
        public ICollection<Booking> Bookings { get; set; }
    }
}

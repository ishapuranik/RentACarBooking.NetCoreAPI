namespace Bookings.Domain
{
    public class VehicleType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }
    }
}

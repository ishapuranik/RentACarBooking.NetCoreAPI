namespace Bookings.Shared.CustomExceptions
{
    public class CustomerDetailsNotMatchedException : Exception
    {
        public CustomerDetailsNotMatchedException()
        {
        }

        public CustomerDetailsNotMatchedException(string message)
            : base(message)
        {
        }

        public CustomerDetailsNotMatchedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
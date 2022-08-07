namespace Bookings.Shared.CustomExceptions
{
    public class HttpStatusNotFoundException : Exception
    {
        public HttpStatusNotFoundException()
        {
        }

        public HttpStatusNotFoundException(string message)
            : base(message)
        {
        }

        public HttpStatusNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
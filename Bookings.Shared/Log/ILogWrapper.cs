namespace Bookings.Shared.Log
{
    public interface ILogWrapper
    {
        void Error(Exception ex);
        void Error(string message, Exception ex);
        void Info(string info);
        void Fatal(Exception ex);
        void Debug(string message);
    }
}

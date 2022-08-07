namespace Bookings.Shared.Config
{
    public interface IConfigWrapper
    {
        string Get(string key);
        IEnumerable<string> GetSection(string key);
    }
}
namespace Bookings.Shared.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}

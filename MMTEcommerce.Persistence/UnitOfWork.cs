using Bookings.Shared.Persistence;

namespace Bookings.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RentACarDBContext _dbContext;

        public UnitOfWork(RentACarDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            if (IsDisposed) return;

            _dbContext.Dispose();

            GC.SuppressFinalize(this);

            IsDisposed = true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

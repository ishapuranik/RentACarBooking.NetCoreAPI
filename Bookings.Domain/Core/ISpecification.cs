namespace Bookings.Domain.Core
{
    public interface ISpecification<TEntity>
    {
        void EnforceRule(TEntity entity);
    }
}

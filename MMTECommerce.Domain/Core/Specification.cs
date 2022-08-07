using Bookings.Shared.Validation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Domain.Core
{
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        private readonly Error _error;

        public Specification(Error error)
        {
            _error = error;
        }

        protected abstract bool IsSatisfiedBy(TEntity entity);

        public virtual void EnforceRule(TEntity entity)
        {
            if (!IsSatisfiedBy(entity))
            {
                throw new ValidationException(
                    JsonConvert.SerializeObject(_error)
               );
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookings.Persistence.Core
{
    public abstract class EntityConfigurationBase<T, K> :
        IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            //builder.HasKey(e => e.Id);

            ConfigureMore(builder);
        }

        public abstract void ConfigureMore(EntityTypeBuilder<T> builder);
    }
}

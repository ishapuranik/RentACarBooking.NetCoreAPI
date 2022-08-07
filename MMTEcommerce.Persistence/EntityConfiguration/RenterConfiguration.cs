using Bookings.Domain;
using Bookings.Persistence.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Persistence.EntityConfiguration
{
    public class RenterConfiguration : EntityConfigurationBase<Renter, int>
    {
        public override void ConfigureMore(EntityTypeBuilder<Renter> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("Renter");
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
        }
    }
}

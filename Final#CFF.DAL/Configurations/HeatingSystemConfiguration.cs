using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final_CFF.DAL.Configurations
{
    public class HeatingSystemConfiguration : IEntityTypeConfiguration<HeatingSystem>
    {
        public void Configure(EntityTypeBuilder<HeatingSystem> builder)
        {
            builder.Property(h => h.RadiatorTemperature)
                .IsRequired();
            builder.Property(h=>h.HotWaterSupply)
                .IsRequired();
            builder.Property(h => h.IsOn);

            builder.Property(c => c.CreateTime)
              .IsRequired()
              .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);
        }
    }
}

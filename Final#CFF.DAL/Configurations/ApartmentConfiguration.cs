using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final_CFF.DAL.Configurations;

public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.Property(a => a.HouseNo)
            .IsRequired();

        builder.HasMany(a => a.Users)
            .WithOne(a => a.Apartment)
            .HasForeignKey(a => a.ApertmentId);

        builder.HasOne(a => a.Building)
            .WithMany(a => a.Apartments)
            .HasForeignKey(a => a.BuildingId);
        builder.Property(c => c.CreateTime)
              .IsRequired()
              .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);
    }
}

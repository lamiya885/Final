﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final_CFF.DAL.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.Property(b => b.BuildingName)
            .IsRequired()
            .HasMaxLength(64);

        //builder.HasMany(a => a.Users)
        //  .WithOne(a => a.Building)
        //  .HasForeignKey(a => a.BuildingId);


        builder.HasMany(b => b.Apartments)
            .WithOne(b => b.Building)
            .HasForeignKey(b => b.BuildingId);

        builder.Property(c => c.CreateTime)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);
    }
}

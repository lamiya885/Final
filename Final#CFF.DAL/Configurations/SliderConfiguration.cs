using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final_CFF.DAL.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(s => s.Title)
            .IsRequired();
        builder.Property(s=>s.Subtitle) 
            .IsRequired();
        builder.Property(s=>s.ImageUrl)
            .IsRequired();

        builder.Property(c => c.CreateTime)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);
    }
}

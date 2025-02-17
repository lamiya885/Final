using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final_CFF.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FullName)
            .IsRequired();
        builder.Property(u => u.UserName)
            .IsRequired();
        builder.Property(u => u.PasswordHash)
            .IsRequired();
        builder.Property(u => u.ImageUrl)
            .IsRequired();

        builder.HasOne(u => u.Apartment)
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.ApertmentId);
    }
}

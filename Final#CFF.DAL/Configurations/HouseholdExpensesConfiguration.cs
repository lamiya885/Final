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
    public class HouseholdExpensesConfiguration : IEntityTypeConfiguration<HouseholdExpenses>
    {
        public void Configure(EntityTypeBuilder<HouseholdExpenses> builder)
        {
            builder.Property(h => h.Price)
            .IsRequired()
            .HasMaxLength(100000);

        }
    }
}

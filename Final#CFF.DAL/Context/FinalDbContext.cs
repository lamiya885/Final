using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Final_CFF.DAL.Context;

public class FinalDbContext : DbContext
{
    public FinalDbContext(DbContextOptions options) : base(options)
    {

    }

    DbSet<Building> Buildings { get; set; }
    DbSet<Apartment> Residents { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Slider> Sliders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

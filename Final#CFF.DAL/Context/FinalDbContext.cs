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
    public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options)
    {

    }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Apartment> Residents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

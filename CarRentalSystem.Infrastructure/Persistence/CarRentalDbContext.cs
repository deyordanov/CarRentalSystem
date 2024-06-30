namespace CarRentalSystem.Infrastructure.Persistance;

using System.Reflection;

using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;using CarRentalSystem.Infrastructure.Identity;using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

public class CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<CarAd> CarAds { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Manufacturer> Manufacturers { get; set; } = null!;

    public DbSet<Dealer> Dealers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}
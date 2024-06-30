namespace CarRentalSystem.Infrastructure.Persistence;

using CarRentalSystem.Infrastructure.Persistance;

using Microsoft.EntityFrameworkCore;

public class CarRentalDbInitializer : IInitializer
{
    private readonly CarRentalDbContext dbContext;

    public CarRentalDbInitializer(CarRentalDbContext dbContext)
        => this.dbContext = dbContext;

    public void Initialize()
        => this.dbContext.Database.Migrate();
}
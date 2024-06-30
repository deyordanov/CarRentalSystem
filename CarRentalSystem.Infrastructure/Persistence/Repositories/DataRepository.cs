namespace CarRentalSystem.Infrastructure.Persistence.Repositories;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;
using CarRentalSystem.Infrastructure.Persistance;

internal class DataRepository<TEntity>(CarRentalDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    public IQueryable<TEntity> GetAll()
        => dbContext.Set<TEntity>();

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        => await dbContext.SaveChangesAsync(cancellationToken);
}
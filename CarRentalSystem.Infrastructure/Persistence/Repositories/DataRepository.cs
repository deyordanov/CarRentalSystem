namespace CarRentalSystem.Infrastructure.Persistence.Repositories;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;
using CarRentalSystem.Infrastructure.Persistance;

using Microsoft.EntityFrameworkCore;

internal class DataRepository<TEntity>(CarRentalDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    private readonly CarRentalDbContext dbContext = dbContext;

    public IQueryable<TEntity> GetAll()
        => this.dbContext.Set<TEntity>();

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        => await this.dbContext.SaveChangesAsync(cancellationToken);
}
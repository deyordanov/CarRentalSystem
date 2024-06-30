namespace CarRentalSystem.Application.Contracts;

using CarRentalSystem.Domain.Common;

public interface IRepository<TEntity>
    where TEntity : IAggregateRoot
{
    // TODO: Refactor to not use IQueryable - this is a leaky abstraction.
    IQueryable<TEntity> GetAll();

    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}
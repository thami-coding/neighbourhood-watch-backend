using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Application.Abstractions.Persistence;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(TEntity entity);

    void Remove(TEntity entity);
}
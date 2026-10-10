using Microsoft.EntityFrameworkCore;
using NeighbourhoodWatch.Application.Abstractions.Persistence;
using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Repositories;

public class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected AppDbContext DbContext { get; } = dbContext;

    protected DbSet<TEntity> Entities => DbContext.Set<TEntity>();

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        Entities.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default) =>
        Entities.AnyAsync(entity => entity.Id == id, cancellationToken);

    public void Add(TEntity entity) => Entities.Add(entity);

    public void Remove(TEntity entity) => Entities.Remove(entity);
}
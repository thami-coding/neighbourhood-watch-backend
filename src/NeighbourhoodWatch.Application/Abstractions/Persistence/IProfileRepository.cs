using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Application.Abstractions.Persistence;

public interface IProfileRepository : IRepository<Profile>
{
    Task<Profile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}
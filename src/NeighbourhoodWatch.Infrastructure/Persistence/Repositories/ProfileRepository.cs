using Microsoft.EntityFrameworkCore;
using NeighbourhoodWatch.Application.Abstractions.Persistence;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Repositories;

public class ProfileRepository(AppDbContext dbContext) : Repository<Profile>(dbContext), IProfileRepository
{
    public Task<Profile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        Entities.FirstOrDefaultAsync(profile => profile.UserId == userId, cancellationToken);
}
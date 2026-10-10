using Microsoft.EntityFrameworkCore;
using NeighbourhoodWatch.Application.Abstractions.Persistence;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
    public Task<User?> GetByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        var normalizedEmailAddress = User.NormalizeEmailAddress(emailAddress);

        return Entities.FirstOrDefaultAsync(user => user.EmailAddress == normalizedEmailAddress, cancellationToken);
    }

    public Task<bool> EmailAddressExistsAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        var normalizedEmailAddress = User.NormalizeEmailAddress(emailAddress);

        return Entities.AnyAsync(user => user.EmailAddress == normalizedEmailAddress, cancellationToken);
    }
}
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Application.Abstractions.Persistence;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default);

    Task<bool> EmailAddressExistsAsync(string emailAddress, CancellationToken cancellationToken = default);
}
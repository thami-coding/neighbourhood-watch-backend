using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Application.Abstractions.Persistence;

public interface IPostRepository : IRepository<Post>
{
    Task<Post?> GetByIdWithMediaAsync(Guid postId, CancellationToken cancellationToken = default);
}
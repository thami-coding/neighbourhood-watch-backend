using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Application.Abstractions.Persistence;

public interface IPostLikeRepository : IRepository<PostLike>
{
    Task<PostLike?> GetByPostAndUserAsync(Guid postId, Guid likedByUserId, CancellationToken cancellationToken = default);
}
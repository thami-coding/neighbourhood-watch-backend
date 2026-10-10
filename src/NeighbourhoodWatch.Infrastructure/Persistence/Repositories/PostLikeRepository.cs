using Microsoft.EntityFrameworkCore;
using NeighbourhoodWatch.Application.Abstractions.Persistence;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Repositories;

public class PostLikeRepository(AppDbContext dbContext) : Repository<PostLike>(dbContext), IPostLikeRepository
{
    public Task<PostLike?> GetByPostAndUserAsync(
        Guid postId,
        Guid likedByUserId,
        CancellationToken cancellationToken = default) =>
        Entities.FirstOrDefaultAsync(
            like => like.PostId == postId && like.LikedByUserId == likedByUserId,
            cancellationToken);
}
using Microsoft.EntityFrameworkCore;
using NeighbourhoodWatch.Application.Abstractions.Persistence;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Repositories;

public class PostRepository(AppDbContext dbContext) : Repository<Post>(dbContext), IPostRepository
{
    public Task<Post?> GetByIdWithMediaAsync(Guid postId, CancellationToken cancellationToken = default) =>
        Entities
            .Include(post => post.Media)
            .FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
}
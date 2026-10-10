using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Domain.Entities;

public class PostLike : BaseEntity
{
    public Guid PostId { get; private set; }

    public Post Post { get; private set; } = null!;

    public Guid LikedByUserId { get; private set; }

    public User LikedByUser { get; private set; } = null!;

    private PostLike() { }

    public static PostLike Create(Guid postId, Guid likedByUserId) => new()
    {
        PostId = DomainGuard.RequiredId(postId, nameof(PostId)),
        LikedByUserId = DomainGuard.RequiredId(likedByUserId, nameof(LikedByUserId))
    };
}
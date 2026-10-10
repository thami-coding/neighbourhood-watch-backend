using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class PostLikeConfiguration : BaseEntityConfiguration<PostLike>
{
    public override void Configure(EntityTypeBuilder<PostLike> builder)
    {
        base.Configure(builder);

        builder.ToTable("PostLikes");

        builder.HasOne(l => l.Post)
            .WithMany()
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.LikedByUser)
            .WithMany()
            .HasForeignKey(l => l.LikedByUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(l => new { l.PostId, l.LikedByUserId }).IsUnique();
    }
}
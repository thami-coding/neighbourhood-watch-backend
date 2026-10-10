using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class PostConfiguration : BaseEntityConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);

        builder.ToTable("Posts");

        builder.Property(p => p.Content).HasMaxLength(Post.ContentMaxLength);

        builder.HasOne(p => p.Author)
            .WithMany()
            .HasForeignKey(p => p.AuthorUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Neighbourhood)
            .WithMany()
            .HasForeignKey(p => p.NeighbourhoodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PostCategory)
            .WithMany()
            .HasForeignKey(p => p.PostCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Media)
            .WithOne()
            .HasForeignKey(m => m.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(p => p.Media).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(p => new { p.NeighbourhoodId, p.CreatedAtUtc }).IsDescending(false, true);
    }
}
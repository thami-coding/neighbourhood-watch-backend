using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Entities;
using NeighbourhoodWatch.Infrastructure.Persistence.Seeding;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class PostCategoryConfiguration : BaseEntityConfiguration<PostCategory>
{
    public override void Configure(EntityTypeBuilder<PostCategory> builder)
    {
        base.Configure(builder);

        builder.ToTable("PostCategories");

        builder.Property(c => c.PostCategoryName).HasMaxLength(PostCategory.PostCategoryNameMaxLength);

        builder.HasIndex(c => c.PostCategoryName).IsUnique();

        builder.HasData(PostCategorySeedData.All);
    }
}
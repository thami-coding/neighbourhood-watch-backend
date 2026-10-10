using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Common;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class PostMediaConfiguration : BaseEntityConfiguration<PostMedia>
{
    public override void Configure(EntityTypeBuilder<PostMedia> builder)
    {
        base.Configure(builder);

        builder.ToTable("PostMedia");

        builder.Property(m => m.MediaType)
            .HasConversion<string>()
            .HasMaxLength(PostMedia.MediaTypeMaxLength);

        builder.Property(m => m.StorageObjectKey).HasMaxLength(StorageConstraints.ObjectKeyMaxLength);
    }
}
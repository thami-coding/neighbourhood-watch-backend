using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Common;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class ProfileConfiguration : BaseEntityConfiguration<Profile>
{
    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        base.Configure(builder);

        builder.ToTable("Profiles");

        builder.Property(p => p.DisplayName).HasMaxLength(Profile.DisplayNameMaxLength);
        builder.Property(p => p.Biography).HasMaxLength(Profile.BiographyMaxLength);
        builder.Property(p => p.ProfilePictureObjectKey).HasMaxLength(StorageConstraints.ObjectKeyMaxLength);

        builder.HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<Profile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.HomeNeighbourhood)
            .WithMany()
            .HasForeignKey(p => p.HomeNeighbourhoodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
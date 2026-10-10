using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users");

        builder.Property(u => u.EmailAddress).HasMaxLength(User.EmailAddressMaxLength);
        builder.Property(u => u.PasswordHash).HasMaxLength(User.PasswordHashMaxLength);

        builder.HasIndex(u => u.EmailAddress).IsUnique();
    }
}
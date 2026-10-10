using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Configurations;

public class NeighbourhoodConfiguration : BaseEntityConfiguration<Neighbourhood>
{
    public override void Configure(EntityTypeBuilder<Neighbourhood> builder)
    {
        base.Configure(builder);

        builder.ToTable("Neighbourhoods");

        builder.Property(n => n.NeighbourhoodName).HasMaxLength(Neighbourhood.NeighbourhoodNameMaxLength);
        builder.Property(n => n.CityName).HasMaxLength(Neighbourhood.CityNameMaxLength);

        builder.HasIndex(n => new { n.NeighbourhoodName, n.CityName }).IsUnique();
    }
}
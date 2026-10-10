using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence;

public static class DatabaseInitialiser
{
    public static async Task InitialiseDevelopmentDatabaseAsync(
        this IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await dbContext.Database.MigrateAsync(cancellationToken);
        await SeedSampleNeighbourhoodsAsync(dbContext, cancellationToken);
    }

    private static async Task SeedSampleNeighbourhoodsAsync(AppDbContext dbContext, CancellationToken cancellationToken)
    {
        if (await dbContext.Neighbourhoods.AnyAsync(cancellationToken))
            return;

        dbContext.Neighbourhoods.AddRange(
            Neighbourhood.Create("Greenfield", "Sample City"),
            Neighbourhood.Create("Riverside", "Sample City"),
            Neighbourhood.Create("Hillcrest", "Sample City"));

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
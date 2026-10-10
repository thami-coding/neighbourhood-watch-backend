using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Infrastructure.Persistence.Interceptors;

public class AuditTimestampInterceptor(TimeProvider timeProvider) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplyAuditTimestamps(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditTimestamps(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void ApplyAuditTimestamps(DbContext? dbContext)
    {
        if (dbContext is null)
            return;

        var utcNow = timeProvider.GetUtcNow();

        foreach (var entry in dbContext.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Property(entity => entity.CreatedAtUtc).CurrentValue = utcNow;

            if (entry is { State: EntityState.Modified, Entity: AuditableEntity })
                entry.Property(nameof(AuditableEntity.UpdatedAtUtc)).CurrentValue = utcNow;
        }
    }
}
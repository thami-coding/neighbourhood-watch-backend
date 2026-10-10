
namespace NeighbourhoodWatch.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();

    public DateTimeOffset CreatedAtUtc { get; private set; }
}

namespace NeighbourhoodWatch.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTimeOffset? UpdatedAtUtc { get; private set; }
}

using NeighbourhoodWatch.Domain.Entities;
using NeighbourhoodWatch.Domain.Exceptions;

namespace NeighbourhoodWatch.Domain.Common;

public abstract class AuthoredEntity : AuditableEntity
{
    public Guid AuthorUserId { get; protected set; }

    public User Author { get; private set; } = null!;

    public bool IsAuthoredBy(Guid userId) => AuthorUserId == userId;

    protected void EnsureAuthoredBy(Guid userId)
    {
        if (!IsAuthoredBy(userId))
            throw new ForbiddenDomainException("Only the author can modify this item.");
    }
}
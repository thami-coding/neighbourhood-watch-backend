using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Domain.Entities;

public class Profile : AuditableEntity
{
    public const int DisplayNameMaxLength = 50;
    public const int BiographyMaxLength = 500;

    public Guid UserId { get; private set; }

    public User User { get; private set; } = null!;

    public Guid HomeNeighbourhoodId { get; private set; }

    public Neighbourhood HomeNeighbourhood { get; private set; } = null!;

    public string DisplayName { get; private set; } = null!;

    public string? Biography { get; private set; }

    public string? ProfilePictureObjectKey { get; private set; }

    private Profile() { }

    public static Profile Create(Guid userId, Guid homeNeighbourhoodId, string displayName, string? biography) => new()
    {
        UserId = DomainGuard.RequiredId(userId, nameof(UserId)),
        HomeNeighbourhoodId = DomainGuard.RequiredId(homeNeighbourhoodId, nameof(HomeNeighbourhoodId)),
        DisplayName = DomainGuard.RequiredText(displayName, nameof(DisplayName), DisplayNameMaxLength),
        Biography = DomainGuard.OptionalText(biography, nameof(Biography), BiographyMaxLength)
    };

    public void UpdateDetails(string displayName, string? biography, Guid homeNeighbourhoodId)
    {
        DisplayName = DomainGuard.RequiredText(displayName, nameof(DisplayName), DisplayNameMaxLength);
        Biography = DomainGuard.OptionalText(biography, nameof(Biography), BiographyMaxLength);
        HomeNeighbourhoodId = DomainGuard.RequiredId(homeNeighbourhoodId, nameof(HomeNeighbourhoodId));
    }

    public void SetProfilePicture(string objectKey) =>
        ProfilePictureObjectKey = DomainGuard.RequiredText(objectKey, nameof(ProfilePictureObjectKey), StorageConstraints.ObjectKeyMaxLength);

    public void RemoveProfilePicture() => ProfilePictureObjectKey = null;
}
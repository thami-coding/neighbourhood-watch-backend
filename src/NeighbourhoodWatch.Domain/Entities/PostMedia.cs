using NeighbourhoodWatch.Domain.Common;
using NeighbourhoodWatch.Domain.Enums;
using NeighbourhoodWatch.Domain.Exceptions;

namespace NeighbourhoodWatch.Domain.Entities;

public class PostMedia : BaseEntity
{
    public const int MediaTypeMaxLength = 20;

    public Guid PostId { get; private set; }

    public MediaType MediaType { get; private set; }

    public string StorageObjectKey { get; private set; } = null!;

    public int DisplayOrder { get; private set; }

    private PostMedia() { }

    internal static PostMedia Create(Guid postId, MediaType mediaType, string storageObjectKey, int displayOrder) => new()
    {
        PostId = DomainGuard.RequiredId(postId, nameof(PostId)),
        MediaType = Enum.IsDefined(mediaType)
            ? mediaType
            : throw new DomainException("The media type is not supported."),
        StorageObjectKey = DomainGuard.RequiredText(storageObjectKey, nameof(StorageObjectKey), StorageConstraints.ObjectKeyMaxLength),
        DisplayOrder = displayOrder
    };
}
using NeighbourhoodWatch.Domain.Common;
using NeighbourhoodWatch.Domain.Enums;
using NeighbourhoodWatch.Domain.Exceptions;

namespace NeighbourhoodWatch.Domain.Entities;

public class Post : AuthoredEntity
{
    public const int ContentMaxLength = 5000;
    public const int MaxMediaPerPost = 10;
    public const int MaxVideosPerPost = 1;

    private readonly List<PostMedia> _media = [];

    public Guid NeighbourhoodId { get; private set; }

    public Neighbourhood Neighbourhood { get; private set; } = null!;

    public Guid PostCategoryId { get; private set; }

    public PostCategory PostCategory { get; private set; } = null!;

    public string Content { get; private set; } = null!;

    public IReadOnlyCollection<PostMedia> Media => _media.AsReadOnly();

    private Post() { }

    public static Post Create(Guid authorUserId, Guid neighbourhoodId, Guid postCategoryId, string content) => new()
    {
        AuthorUserId = DomainGuard.RequiredId(authorUserId, nameof(AuthorUserId)),
        NeighbourhoodId = DomainGuard.RequiredId(neighbourhoodId, nameof(NeighbourhoodId)),
        PostCategoryId = DomainGuard.RequiredId(postCategoryId, nameof(PostCategoryId)),
        Content = DomainGuard.RequiredText(content, nameof(Content), ContentMaxLength)
    };

    public void Edit(Guid editorUserId, string content, Guid postCategoryId)
    {
        EnsureAuthoredBy(editorUserId);

        Content = DomainGuard.RequiredText(content, nameof(Content), ContentMaxLength);
        PostCategoryId = DomainGuard.RequiredId(postCategoryId, nameof(PostCategoryId));
    }

    public PostMedia AddMedia(Guid requestingUserId, MediaType mediaType, string storageObjectKey)
    {
        EnsureAuthoredBy(requestingUserId);

        if (_media.Count >= MaxMediaPerPost)
            throw new DomainException($"A post cannot have more than {MaxMediaPerPost} media items.");

        if (mediaType == MediaType.Video && _media.Count(media => media.MediaType == MediaType.Video) >= MaxVideosPerPost)
            throw new DomainException($"A post cannot have more than {MaxVideosPerPost} video.");

        var nextDisplayOrder = _media.Count == 0 ? 0 : _media.Max(media => media.DisplayOrder) + 1;
        var postMedia = PostMedia.Create(Id, mediaType, storageObjectKey, nextDisplayOrder);

        _media.Add(postMedia);
        return postMedia;
    }

    public string RemoveMedia(Guid requestingUserId, Guid postMediaId)
    {
        EnsureAuthoredBy(requestingUserId);

        var postMedia = _media.FirstOrDefault(media => media.Id == postMediaId)
            ?? throw new DomainException("The media item does not belong to this post.");

        _media.Remove(postMedia);
        return postMedia.StorageObjectKey;
    }
}
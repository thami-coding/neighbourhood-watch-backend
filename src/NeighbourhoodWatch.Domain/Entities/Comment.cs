using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Domain.Entities;

public class Comment : AuthoredEntity
{
    public const int ContentMaxLength = 2000;

    public Guid PostId { get; private set; }

    public Post Post { get; private set; } = null!;

    public string Content { get; private set; } = null!;

    private Comment() { }

    public static Comment Create(Guid postId, Guid authorUserId, string content) => new()
    {
        PostId = DomainGuard.RequiredId(postId, nameof(PostId)),
        AuthorUserId = DomainGuard.RequiredId(authorUserId, nameof(AuthorUserId)),
        Content = DomainGuard.RequiredText(content, nameof(Content), ContentMaxLength)
    };

    public void Edit(Guid editorUserId, string content)
    {
        EnsureAuthoredBy(editorUserId);
        Content = DomainGuard.RequiredText(content, nameof(Content), ContentMaxLength);
    }
}
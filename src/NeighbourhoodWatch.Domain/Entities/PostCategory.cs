using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Domain.Entities;

public class PostCategory : BaseEntity
{
    public const int PostCategoryNameMaxLength = 50;

    public string PostCategoryName { get; private set; } = null!;

    private PostCategory() { }

    public static PostCategory Create(string postCategoryName) => new()
    {
        PostCategoryName = DomainGuard.RequiredText(postCategoryName, nameof(PostCategoryName), PostCategoryNameMaxLength)
    };
}
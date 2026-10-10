using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Domain.Entities;

public class User : AuditableEntity
{
    public const int EmailAddressMaxLength = 254;
    public const int PasswordHashMaxLength = 255;

    public string EmailAddress { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public Profile? Profile { get; private set; }

    private User() { }

    public static User Create(string emailAddress, string passwordHash) => new()
    {
        EmailAddress = NormalizeEmailAddress(emailAddress),
        PasswordHash = DomainGuard.RequiredText(passwordHash, nameof(PasswordHash), PasswordHashMaxLength)
    };

    public void ChangePasswordHash(string newPasswordHash) =>
        PasswordHash = DomainGuard.RequiredText(newPasswordHash, nameof(PasswordHash), PasswordHashMaxLength);

    public static string NormalizeEmailAddress(string emailAddress) =>
        DomainGuard.RequiredText(emailAddress, nameof(EmailAddress), EmailAddressMaxLength).ToLowerInvariant();
}
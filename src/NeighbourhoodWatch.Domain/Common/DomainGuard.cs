using NeighbourhoodWatch.Domain.Exceptions;

namespace NeighbourhoodWatch.Domain.Common;

internal static class DomainGuard
{
    public static string RequiredText(string? value, string fieldName, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{fieldName} is required.");

        var trimmedValue = value.Trim();

        if (trimmedValue.Length > maxLength)
            throw new DomainException($"{fieldName} must not exceed {maxLength} characters.");

        return trimmedValue;
    }

    public static string? OptionalText(string? value, string fieldName, int maxLength) =>
        string.IsNullOrWhiteSpace(value) ? null : RequiredText(value, fieldName, maxLength);

    public static Guid RequiredId(Guid value, string fieldName) =>
        value == Guid.Empty
            ? throw new DomainException($"{fieldName} is required.")
            : value;
}
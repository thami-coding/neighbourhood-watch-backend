namespace NeighbourhoodWatch.Infrastructure.Persistence.Seeding;

internal static class PostCategorySeedData
{
    private static readonly DateTimeOffset SeededAtUtc = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static readonly Guid GeneralId = Guid.Parse("0199a1b2-0001-7000-8000-000000000001");
    public static readonly Guid SuspiciousActivityId = Guid.Parse("0199a1b2-0001-7000-8000-000000000002");
    public static readonly Guid CrimeAlertId = Guid.Parse("0199a1b2-0001-7000-8000-000000000003");
    public static readonly Guid LostAndFoundId = Guid.Parse("0199a1b2-0001-7000-8000-000000000004");
    public static readonly Guid CommunityEventId = Guid.Parse("0199a1b2-0001-7000-8000-000000000005");
    public static readonly Guid SafetyTipId = Guid.Parse("0199a1b2-0001-7000-8000-000000000006");

    public static IEnumerable<object> All =>
    [
        CreateRow(GeneralId, "General"),
        CreateRow(SuspiciousActivityId, "Suspicious Activity"),
        CreateRow(CrimeAlertId, "Crime Alert"),
        CreateRow(LostAndFoundId, "Lost and Found"),
        CreateRow(CommunityEventId, "Community Event"),
        CreateRow(SafetyTipId, "Safety Tip")
    ];

    private static object CreateRow(Guid id, string postCategoryName) => new
    {
        Id = id,
        PostCategoryName = postCategoryName,
        CreatedAtUtc = SeededAtUtc
    };
}
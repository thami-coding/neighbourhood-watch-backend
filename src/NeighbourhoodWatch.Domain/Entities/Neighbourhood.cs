using NeighbourhoodWatch.Domain.Common;

namespace NeighbourhoodWatch.Domain.Entities;

public class Neighbourhood : BaseEntity
{
    public const int NeighbourhoodNameMaxLength = 100;
    public const int CityNameMaxLength = 100;

    public string NeighbourhoodName { get; private set; } = null!;

    public string CityName { get; private set; } = null!;

    private Neighbourhood() { }

    public static Neighbourhood Create(string neighbourhoodName, string cityName) => new()
    {
        NeighbourhoodName = DomainGuard.RequiredText(neighbourhoodName, nameof(NeighbourhoodName), NeighbourhoodNameMaxLength),
        CityName = DomainGuard.RequiredText(cityName, nameof(CityName), CityNameMaxLength)
    };
}
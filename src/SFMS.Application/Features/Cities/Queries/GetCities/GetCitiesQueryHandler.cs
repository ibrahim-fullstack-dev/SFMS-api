using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;

namespace SFMS.Application.Features.Cities.Queries.GetCities;

public sealed class GetCitiesQueryHandler
    : IQueryHandler<GetCitiesQuery, IReadOnlyList<CityDto>>
{
    private readonly ICityRepository _cityRepository;

    public GetCitiesQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IReadOnlyList<CityDto>> Handle(
        GetCitiesQuery query,
        CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetAllAsync(
            cancellationToken);

        return cities
            .Select(city => new CityDto(
                city.Id,
                city.Code,
                city.Name,
                city.Description,
                city.IsActive,
                city.StateId,
                city.State.Name,
                city.PostalCode,
                city.DisplayOrder,
                city.ColorCode,
                city.Icon))
            .ToList();
    }
}
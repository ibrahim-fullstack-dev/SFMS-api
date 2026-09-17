using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;

namespace SFMS.Application.Features.Cities.Queries.GetCity;

public sealed class GetCityQueryHandler
    : IQueryHandler<GetCityQuery, CityDto?>
{
    private readonly ICityRepository _cityRepository;

    public GetCityQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CityDto?> Handle(
        GetCityQuery query,
        CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(
            query.Id,
            cancellationToken);

        if (city is null)
        {
            return null;
        }

        return new CityDto(
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
            city.Icon);
    }
}
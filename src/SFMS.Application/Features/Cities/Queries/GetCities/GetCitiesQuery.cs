using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;

namespace SFMS.Application.Features.Cities.Queries.GetCities;

public sealed record GetCitiesQuery
    : IQuery<IReadOnlyList<CityDto>>;
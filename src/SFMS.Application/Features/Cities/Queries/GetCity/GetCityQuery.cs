using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;

namespace SFMS.Application.Features.Cities.Queries.GetCity;

public sealed record GetCityQuery(
    int Id) : IQuery<CityDto?>;
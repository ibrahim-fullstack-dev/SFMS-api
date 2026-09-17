using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;

namespace SFMS.Application.Features.Cities.Commands.UpdateCity;

public sealed record UpdateCityCommand(
    int Id,
    string Name,
    string? Description,
    bool IsActive,
    int StateId,
    string? PostalCode,
    int DisplayOrder,
    string? ColorCode,
    string? Icon) : ICommand<CityDto>;
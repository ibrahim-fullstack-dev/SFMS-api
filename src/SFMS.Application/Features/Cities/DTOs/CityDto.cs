namespace SFMS.Application.Features.Cities.DTOs;

public sealed record CityDto(
    int Id,
    string Code,
    string Name,
    string? Description,
    bool IsActive,
    int StateId,
    string StateName,
    string? PostalCode,
    int DisplayOrder,
    string? ColorCode,
    string? Icon);
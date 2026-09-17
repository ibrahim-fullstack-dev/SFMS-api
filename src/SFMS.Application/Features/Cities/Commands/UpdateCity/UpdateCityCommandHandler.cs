using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;

namespace SFMS.Application.Features.Cities.Commands.UpdateCity;

public sealed class UpdateCityCommandHandler
    : ICommandHandler<UpdateCityCommand, CityDto>
{
    private readonly ICityRepository _cityRepository;

    public UpdateCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CityDto> Handle(
        UpdateCityCommand command,
        CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(
            command.Id,
            cancellationToken);

        if (city is null)
        {
            throw new KeyNotFoundException(
                $"City with ID {command.Id} was not found.");
        }

        city.Name = command.Name;
        city.Description = command.Description;
        city.IsActive = command.IsActive;
        city.StateId = command.StateId;
        city.PostalCode = command.PostalCode;
        city.DisplayOrder = command.DisplayOrder;
        city.ColorCode = command.ColorCode;
        city.Icon = command.Icon;

        await _cityRepository.UpdateAsync(
            city,
            cancellationToken);

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
using MediatR;
using SFMS.Application.Common.Abstractions.Messaging;
using SFMS.Application.Features.Cities.DTOs;
using SFMS.Domain.Common;

namespace SFMS.Application.Features.Cities.Commands.CreateCity;

public sealed class CreateCityCommandHandler
    : ICommandHandler<CreateCityCommand, CityDto>
{
    private readonly ICityRepository _cityRepository;

    public CreateCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CityDto> Handle(
        CreateCityCommand command,
        CancellationToken cancellationToken)
    {
        var city = new City
        {
            Code = command.Code,
            Name = command.Name,
            Description = command.Description,
            IsActive = command.IsActive,
            StateId = command.StateId,
            PostalCode = command.PostalCode,
            DisplayOrder = command.DisplayOrder,
            ColorCode = command.ColorCode,
            Icon = command.Icon
        };

        await _cityRepository.AddAsync(city, cancellationToken);

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
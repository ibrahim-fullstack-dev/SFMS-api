using MediatR;
using SFMS.Application.Common.Abstractions.Messaging;

namespace SFMS.Application.Features.Cities.Commands.DeleteCity;

public sealed class DeleteCityCommandHandler
    : ICommandHandler<DeleteCityCommand, Unit>
{
    private readonly ICityRepository _cityRepository;

    public DeleteCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<Unit> Handle(
        DeleteCityCommand command,
        CancellationToken cancellationToken)
    {
        await _cityRepository.DeleteAsync(
            command.Id,
            cancellationToken);

        return Unit.Value;
    }
}
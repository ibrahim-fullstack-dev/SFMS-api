using MediatR;
using SFMS.Application.Common.Abstractions.Messaging;

namespace SFMS.Application.Features.Cities.Commands.DeleteCity;

public sealed record DeleteCityCommand(
    int Id) : ICommand<Unit>;
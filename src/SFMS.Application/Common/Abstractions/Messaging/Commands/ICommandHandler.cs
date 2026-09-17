using MediatR;

namespace SFMS.Application.Common.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResult>
    : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}
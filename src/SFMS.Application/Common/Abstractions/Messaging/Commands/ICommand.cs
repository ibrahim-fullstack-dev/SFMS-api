using MediatR;

namespace SFMS.Application.Common.Abstractions.Messaging;

public interface ICommand<out TResult> : IRequest<TResult>
{
}
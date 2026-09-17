using MediatR;

namespace SFMS.Application.Common.Abstractions.Messaging;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
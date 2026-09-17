using MediatR;

namespace SFMS.Application.Common.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResult>
    : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}
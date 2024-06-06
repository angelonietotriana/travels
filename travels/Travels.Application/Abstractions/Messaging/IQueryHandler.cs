using MediatR;
using Travels.Domain.Abstractions;

namespace Travels.Application.Abstractions.Messaging
{

    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {

    }
}
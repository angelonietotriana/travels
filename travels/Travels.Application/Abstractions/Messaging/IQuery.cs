using MediatR;
using Travels.Domain.Abstractions;

namespace Travels.Application.Abstractions.Messaging
{

    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
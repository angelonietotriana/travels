using Travels.Domain.Abstractions;
using MediatR;

namespace Travels.Application.Abstractions.Messaging
{

    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
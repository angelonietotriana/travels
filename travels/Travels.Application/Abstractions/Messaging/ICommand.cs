using MediatR;
using Travels.Domain.Abstractions;

namespace Travels.Application.Abstractions.Messaging
{

    public interface ICommand : IRequest<Result>, IBaseCommand
    {

    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }

    public interface IBaseCommand
    { }
}
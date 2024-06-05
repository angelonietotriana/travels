using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Users;

namespace Travels.Application.User.Commands
{
    public record UserCommand(
        Nombre nombre,
        Apellido apellido,
        Email email,
        UserType type
    ) : ICommand<Guid>;
}




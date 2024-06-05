using Travels.Domain.Users;

namespace Travels.Api.Controllers.User
{

    public sealed record UserRequest(
        string Nombre,
        string Apellido,
        string Email,
        UserType type
    );
}

using Travels.Domain.Abstractions;
using Travels.Domain.Users.Events;

namespace Travels.Domain.Users
{



    public sealed class UserEntity : Entity
    {
        private UserEntity()
        {

        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }
        public UserType? Type { get; private set; }

        private UserEntity(Guid id,
                            Nombre nombre,
                            Apellido apellido,
                            Email email,
                            UserType type) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Type = type;
        }

        public static UserEntity Create(
            Nombre nombre,
            Apellido apellido,
            Email email,
            UserType type
        )
        {
            var user = new UserEntity(Guid.NewGuid(), nombre, apellido, email, type);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }

    }

}
using Travels.Domain.Abstractions;
using Travels.Domain.Users.Events;

namespace Travels.Domain.Users {



    public sealed class UserEntity : Entity
    {
        private UserEntity()
        {

        }

        private UserEntity(
            Guid id,
            Nombre nombre,
            Apellido apellido,
            Email email
            ) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }

        public static UserEntity Create(
            Nombre nombre,
            Apellido apellido,
            Email email
        )
        {
            var user = new UserEntity(Guid.NewGuid(), nombre, apellido, email);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }

    }

}
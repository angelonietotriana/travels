using FluentValidation;

namespace Travels.Application.User.Commands
{

    public class UserCommandValidator : AbstractValidator<UserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(c => c.nombre).NotEmpty();
            RuleFor(c => c.apellido).NotEmpty();
            RuleFor(c => c.email).NotEmpty();
            RuleFor(c => c.type).NotEmpty();
        }
    }
}
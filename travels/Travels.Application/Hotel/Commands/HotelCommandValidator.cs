using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace Travels.Application.Hotel.Commands
{

    public class HotelCommandValidator : AbstractValidator<HotelCommand>
    {
        public HotelCommandValidator()
        {
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Capacity).NotEmpty();
            RuleFor(c => c.Business).NotEmpty();
            RuleFor(c => c.Starts).NotEmpty();
            RuleFor(c => c.State).NotEmpty();            
        }
    }
}
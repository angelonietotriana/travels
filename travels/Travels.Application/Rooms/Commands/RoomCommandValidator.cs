using FluentValidation;

namespace Travels.Application.Rooms.Commands
{

    public class RoomCommandValidator : AbstractValidator<RoomCommand>
    {
        public RoomCommandValidator()
        {
            RuleFor(c => c.localization).NotEmpty();
            RuleFor(c => c.numberOfBeds).NotEmpty();
            RuleFor(c => c.capacity).NotEmpty();
            RuleFor(c => c.features).NotEmpty();
            RuleFor(c => c.roomType).NotEmpty();
            RuleFor(c => c.pricePerPeriod).NotEmpty();
            RuleFor(c => c.maintenance).NotEmpty();
            RuleFor(c => c.totalPrice).NotEmpty();
            RuleFor(c => c.featuresPrice).NotEmpty();
            RuleFor(c => c.price).NotEmpty();
        }
    }
}



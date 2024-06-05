using FluentValidation;

namespace Travels.Application.Rooms.Commands
{

    public class RoomCommandValidator : AbstractValidator<RoomCommand>
    {
        public RoomCommandValidator()
        {
            RuleFor(c => c.Localization).NotEmpty();
            RuleFor(c => c.NumberOfBeds).NotEmpty();
            RuleFor(c => c.Capacity).NotEmpty();
            RuleFor(c => c.Features).NotEmpty();
            RuleFor(c => c.RoomType).NotEmpty();
            RuleFor(c => c.PricePerPeriod).NotEmpty();
            RuleFor(c => c.Maintenance).NotEmpty();
            RuleFor(c => c.TotalPrice).NotEmpty();
            RuleFor(c => c.FeaturesPrice).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
        }
    }
}



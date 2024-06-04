using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Rooms;
using Travels.Domain.Shared;

namespace Travels.Application.Rooms.Commands
{
    public record RoomCommand(
        Localization localization,
        NumberOfBeds numberOfBeds,
        Capacity capacity,
        List<Features>? features,
        RoomType roomType,
        Currency pricePerPeriod,
        Currency maintenance,
        Currency totalPrice,
        Currency featuresPrice,
        Currency price
    ) : ICommand<Guid>;
}



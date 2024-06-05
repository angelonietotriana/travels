using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Rooms;
using Travels.Domain.Shared;

namespace Travels.Application.Rooms.Commands
{
    public record RoomCommandUpdate(
        Guid RoomId,
        Localization Localization,
        NumberOfBeds NumberOfBeds,
        Capacity Capacity,
        List<Features>? Features,
        RoomType RoomType,
        Currency PricePerPeriod,
        Currency Maintenance,
        Currency TotalPrice,
        Currency FeaturesPrice,
        Currency Price
    ) : ICommand<Guid>;
}



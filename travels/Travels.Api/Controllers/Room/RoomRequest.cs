using Travels.Domain.Hotels;
using Travels.Domain.Rooms;
using Travels.Domain.Shared;

namespace Travels.Api.Controllers.Room
{

    public sealed record RoomRequest(Localization Localization,
                                    NumberOfBeds NumberOfBeds,
                                    Domain.Rooms.Capacity Capacity,
                                    List<Features> Features,
                                    RoomType RoomType,
                                    Currency PricePerPeriod,
                                    Currency Maintenance,
                                    Currency TotalPrice,
                                    Currency FeaturesPrice,
                                    Currency Price);
}

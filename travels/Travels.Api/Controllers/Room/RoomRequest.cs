using Travels.Domain.Rooms;

namespace Travels.Api.Controllers.Room
{

    public sealed record RoomRequest(int Floor,
                                    View View,
                                    int NumberOfBeds,
                                    int Capacity,
                                    List<Features> Features,
                                    RoomType RoomType,
                                    decimal PricePerPeriod,
                                    decimal Maintenance,
                                    decimal TotalPrice,
                                    decimal FeaturesPrice,
                                    decimal Price);
}

using Travels.Domain.Rooms;
using Travels.Domain.Shared;

namespace Travels.Application.Rooms.GetRoom
{

    public sealed class RoomResponse
    {
        Guid Id { get; set; }
        int Floor {  get; set; }    
        int View {  get; set; } 
        int NumberOfBeds { get; set; }
        int Capacity { get; set; }
        List<int>? Features { get; set; }
        int RoomType { get; set; }
        decimal PricePerPeriod { get; set; }
        decimal Maintenance { get; set; }
        decimal TotalPrice { get; set; }
        decimal FeaturesPrice { get; set; }
        decimal Price { get; set; }

    }
}
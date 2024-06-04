using Travels.Domain.Shared;

namespace Travels.Application.Rooms.SearchRooms;

public sealed class RoomResponse
{

    public Guid Id { get; init; }

    public int? Floor { get; init; }
    public string? View { get; init; }
    public int? NumberOfBeds {  get; init; }
    public int? Capacity { get; init; }

    public List<int>? Features {  get; init; }

    public int? RoomType { get; init; }

    public decimal PricePerPeriod { get; init; }
    public decimal Maintenance { get; init; }
    public decimal TotalPrice { get; init; }
    public decimal FeaturesPrice { get; init; }

}
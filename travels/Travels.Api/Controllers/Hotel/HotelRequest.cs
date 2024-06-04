using Travels.Domain.Hotels;

namespace Travels.Api.Controllers.Hotel
{

    public sealed record HotelRequest(
        Business Business,
        Address Address,
        TotalCapacity Capacity,
        Stars Starts,
        HotelStatus State
    );
}

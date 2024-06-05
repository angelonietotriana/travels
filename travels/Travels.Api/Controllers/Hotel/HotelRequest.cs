using Travels.Domain.Hotels;

namespace Travels.Api.Controllers.Hotel
{

    public sealed record HotelRequest(
        String BusinessName,
        String Nit,
        String City,
        String Neighborhood,
        String Zone,
        String Numeration,
        int TotalCapacity,
        int Stars,
        HotelStatus State,
        Guid RoomId
    );
}

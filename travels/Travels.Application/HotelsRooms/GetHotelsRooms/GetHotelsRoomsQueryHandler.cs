using Dapper;
using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Abstractions;

namespace Travels.Application.HotelsRooms.GetHotelsRooms
{

    internal sealed class GetHotelsRoomsQueryHandler : IQueryHandler<GetHotelRoomQuery, HotelsRoomsResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetHotelsRoomsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<HotelsRoomsResponse>> Handle(GetHotelRoomQuery request, CancellationToken cancellationToken)
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """ 
                    SELECT
                      id AS Id
                    , hotel_id AS HotelId
                    , room_id AS RoomId
                    FROM hotels_rooms 
                    WHERE id=@Id
                """;


            var hotelsRooms = await connection.QueryFirstOrDefaultAsync<HotelsRoomsResponse>(
                sql,
                new
                {
                    request.Id
                }
            );

            return hotelsRooms!;
        }
    }
}
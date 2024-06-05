using Dapper;
using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Abstractions;

namespace Travels.Application.HotelsRooms.GetHotelsRooms
{

    internal sealed class GetHotelsRoomsQueryByHandler : IQueryHandler<GetHotelsRoomsQuery, HotelsRoomsResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetHotelsRoomsQueryByHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<Result<HotelsRoomsResponse>> Handle(GetHotelsRoomsQuery request, CancellationToken cancellationToken )
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """ 
                    SELECT
                      id AS Id
                    , hotel_id AS HotelId
                    , room_id AS RoomId
                    FROM hotels_rooms 
                    WHERE hotel_id=@HotelId  
                    and room_id=@RoomId
                """;

            var hotelsRooms = await connection.QueryFirstOrDefaultAsync<HotelsRoomsResponse>(
                sql,
                new
                {
                    request.HotelId,
                    request.RoomId
                }
            );

            return hotelsRooms!;
        }
       
    }
}
using Dapper;
using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Abstractions;

namespace Travels.Application.Rooms.GetRoom
{

    internal sealed class GetRoomQueryHandler : IQueryHandler<GetRoomQuery, RoomResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRoomQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<RoomResponse>> Handle(GetRoomQuery request,
                                                        CancellationToken cancellationToken)
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
           SELECT
                 id AS Id
                ,localization_floor AS LocalizationFloor
                ,localization_view AS LocalizationView
                ,number_of_beds AS NumberOfBeds
                ,capacity AS Capacity
                ,features AS Features
                ,room_type AS RoomType
                ,price_per_period AS PricePerPeriod
                ,maintenance AS Maintenance
                ,total_price AS TotalPrice
                ,features_price AS FeaturesPrice
                ,price AS Price
           FROM rooms 
           WHERE id=@RoomId  
        """;

            var parameter = new { request.RoomId };

            return await connection.QueryFirstOrDefaultAsync<RoomResponse>(sql, parameter);
        }
    }
}
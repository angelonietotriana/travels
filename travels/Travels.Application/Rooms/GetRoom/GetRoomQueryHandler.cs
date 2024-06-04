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
                *
           FROM rooms WHERE id=@Id  
        """;




            var room = await connection.QueryFirstOrDefaultAsync<RoomResponse>(
                sql,
                new
                {
                    request.RoomId
                }
            );

            return room!;
        }
    }
}
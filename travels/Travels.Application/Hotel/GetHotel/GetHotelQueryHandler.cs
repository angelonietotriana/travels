using Dapper;
using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Application.Hotel.GetHotel;
using Travels.Domain.Abstractions;

namespace Travels.Application.Booking.GetBooking
{

    internal sealed class GetHotelQueryHandler : IQueryHandler<GetHotelQuery, HotelResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetHotelQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<HotelResponse>> Handle(
            GetHotelQuery request,
            CancellationToken cancellationToken
            )
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
           SELECT
                *
           FROM hotels WHERE id=@Id  
        """;




            var hotel = await connection.QueryFirstOrDefaultAsync<HotelResponse>(
                sql,
                new
                {
                    request.HotelId
                }
            );

            return hotel!;
        }
    }
}
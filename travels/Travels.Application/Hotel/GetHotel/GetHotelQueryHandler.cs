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

        public async Task<Result<HotelResponse>> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """ 
                    SELECT
                      id AS Id
                    , business_business_name AS BusinessName
                    , business_nit AS Nit
                    , address_city AS City
                    , address_neighborhood AS Neighborhood
                    , address_zone AS Zone
                    , address_numeration AS Numeration
                    , capacity_value AS Capacity
                    , starts AS Starts
                    , state AS State
                    , date_created AS DateCreated
                    FROM hotels 
                    WHERE id=@HotelId  
                    and state != 5
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
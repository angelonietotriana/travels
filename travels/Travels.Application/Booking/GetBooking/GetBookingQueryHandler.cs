using Dapper;
using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Abstractions;

namespace Travels.Application.Booking.GetBooking
{

    internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<BookingResponse>> Handle(
            GetBookingQuery request,
            CancellationToken cancellationToken
            )
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
           SELECT
                id AS Id,
                room_id AS RoomId,
                user_id_booking AS UserIdBooking,
                user_id_vendor AS UserIdVendor,
                status AS Status,
                price_per_booking AS BookingPrice,
                currency_type AS CurrencyType,
                maintenance_price AS MaintenancePrice,
                maintenance_currency_type AS MaintenanceCurrentyType,
                features_price AS FeaturesPrice,
                features_currency_type AS FeaturesCurrencyType,
                total_price AS TotalPrice,
                total_price_currency_type AS TotalPriceCurrencyType,
                start_duration AS StartDuration,
                end_duration AS EndDuration,
                creation_date AS CreationDate
           FROM booking WHERE id=@Id  
        """;




            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
                sql,
                new
                {
                    request.BookingId
                }
            );

            return booking!;
        }
    }
}
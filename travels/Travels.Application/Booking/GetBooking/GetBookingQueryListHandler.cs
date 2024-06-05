using Dapper;
using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Abstractions;

namespace Travels.Application.Booking.GetBooking
{

    internal sealed class GetBookingQueryListHandler : IQueryHandler<GetBookingQueryAll, List<BookingResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookingQueryListHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<List<BookingResponse>>> Handle(GetBookingQueryAll request, CancellationToken cancellationToken)
        {

            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
           SELECT
                id AS Id
                ,hotel_id AS HotelId
                ,room_id AS  RoomId
                ,user_id_booking AS UserIdBooking
                ,user_id_sells AS UserIdSells
                ,status AS Status
                ,duration_start AS StartDate
                ,duration_end AS EndDate
                ,creation_date AS CreationDate
                ,confirm_date AS ConfirmDate
                ,reject_date AS RejectDate
                ,complete_date AS CompleteDate
                ,cancelation_date AS CancelationDate
           FROM bookings  
        """;




            var booking = await connection.QueryAsync<BookingResponse>(sql);

            return booking.ToList();
        }
    }
}
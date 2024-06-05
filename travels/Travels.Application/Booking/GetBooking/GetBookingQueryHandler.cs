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
           FROM bookings WHERE id=@BookingId  
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
namespace Travels.Application.Booking.GetBooking
{

    public sealed class BookingResponse
    {
        public Guid Id { get; init; }
        public Guid UserIdBooking { get; init; }
        public Guid UserIdSells { get; init; }

        public Guid RoomId { get; init; }

        public Guid HotelId { get; init; }

        public int Status { get; init; }

        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }

        public DateTime CreationDate { get; init; }

        public DateOnly ConfirmDate { get; init; }
        public DateOnly RejectDate { get; init; }
        public DateOnly CompleteDate { get; init; }
        public DateOnly CancelationDate { get; init; }



    }
}
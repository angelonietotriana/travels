using Travels.Domain.Abstractions;
using Travels.Domain.Bookings.Events;


namespace Travels.Domain.Bookings
{
    public sealed class BookingEntity : Entity
    {
        public Guid HotelId { get; set; }

        public Guid RoomId { get; set; }

        public Guid UserIdBooking { get; set; }
        public Guid UserIdSells { get; set; }

        public BookingStatus Status { get; set; }

        public DateRange? Duration { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ConfirmDate { get; set; }

        public DateTime? RejectDate { get; set; }
        public DateTime? CompleteDate { get; set; }

        public DateTime? CancelationDate { get; set; }

        internal BookingEntity()
        {
            
        }

        internal BookingEntity(Guid hotelId, 
                             Guid roomId, 
                             Guid userIdBooking,
                             Guid userIdVendor, 
                             BookingStatus status, 
                             DateRange? duration, 
                             DateTime? creationDate)
        {
            Id = Guid.NewGuid();
            HotelId = hotelId;
            RoomId = roomId;
            UserIdBooking = userIdBooking;
            UserIdSells = userIdVendor;
            Status = status;
            Duration = duration;
            CreationDate = creationDate;
            ConfirmDate = null;
            RejectDate = null;
            CompleteDate = null;
            CancelationDate = null;
        }


        public static BookingEntity create(Guid hotelId,
                                           Guid roomId,
                                           Guid userIdBooking,
                                           Guid userIdVendor,
                                           BookingStatus status,
                                           DateRange? duration,
                                           DateTime? creationDate)
        {
            var booking = new BookingEntity(hotelId,
                                           roomId,
                                           userIdBooking,
                                           userIdVendor,
                                           status,
                                           duration,
                                           creationDate);

            booking.RaiseDomainEvent(new BookingConfirmDomainEvent(booking.Id!));
            booking.CreationDate = creationDate;

            return booking;
        }


        public Result Confirmar(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirm)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }

            Status = BookingStatus.Confirm;
            ConfirmDate = utcNow;

            RaiseDomainEvent(new BookingConfirmDomainEvent(Id));
            return Result.Success();
        }


        public Result Rechazar(DateTime utcNow)
        {
            if (Status != BookingStatus.Booking)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }

            Status = BookingStatus.Reject;
            RejectDate = utcNow;
            RaiseDomainEvent(new BookingRejectDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancelar(DateTime utcNow)
        {
            if (Status != BookingStatus.Booking)
            {
                return Result.Failure(BookingErrors.NotConfirmado);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration!.Start)
            {
                return Result.Failure(BookingErrors.AlreadyStarted);
            }


            Status = BookingStatus.Cancell;
            CancelationDate = utcNow;
            RaiseDomainEvent(new BookingCacelledDomainEvent(Id));

            return Result.Success();
        }


        public Result Completar(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirm)
            {
                return Result.Failure(BookingErrors.NotConfirmado);
            }

            Status = BookingStatus.Complete;
            CompleteDate = utcNow;
            RaiseDomainEvent(new BookingCompleteDomainEvent(Id));


            return Result.Success();
        }

    }
}

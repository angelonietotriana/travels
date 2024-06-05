using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings {


    public static class BookingErrors
    {

        public static Error NotFound = new Error(
            "Bookin.NotFound",
            "La reserva con el Id especificado no fue encontrada"
        );

        public static Error NotFoundRoom = new Error(
            "Bookin.NotFoundRoom",
            "La reserva con el Id especificado no fue encontrada"
        );

        public static Error NotFoundHotel = new Error(
            "Bookin.NotFoundHotel",
            "La reserva con el Id especificado no fue encontrada"
        );

        public static Error Overlap = new Error(
        "Bookin.Overlap",
        "La Reserva esta siendo tomado por 2 o mas clientes al mismo tiempo en la misma fecha"
        );


        public static Error NotReserved = new Error(
            "Bookin.NotReserved",
            "La reserva no esta realizada"
        );

        public static Error NotConfirmado = new Error(
            "Bookin.NotConfirmed",
            "La reserva no esta confirmada"
        );

        public static Error AlreadyStarted = new Error(
            "Bookin.AlreadyStarted",
            "la reserva ya ha comenzado"
        );

        public static Error CreatedRoom = new Error(
            "Room.Created",
            "La creación de la habitación falló"
        );

        public static Error CreatedHotel = new Error(
            "Hotel.Created",
            "La creación del hotel falló"
        );

        public static Error CreatedUser = new Error(
            "User.Created",
            "La creación del usuario falló"
        );

        public static Error CreatedRelatedHotelRoom = new Error(
            "RelatedHotelRooom.Created",
            "La creación de la relación entre hotel y habitación falló"
        );

    }

}
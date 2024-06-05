using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings {


    public static class HotelErrors
    {

        public static Error NotFound = new Error(
            "Hotel.NotFound",
            "El hotel con el Id especificado no fue encontrado"
        );

        public static Error NotFoundRooom = new Error(
            "Hotel.NotFoundRoom",
            "La habitación con el Id especificado no fue encontrada"
        );

    }

}
using Travels.Domain.Bookings;
using Travels.Domain.Shared;

namespace Travels.Domain.Rooms
{

    public class PriceService
    {
        public DetailPrice CalcularPrecio(RoomEntity room, DateRange period)
        {
            var precioPorPeriodo = new Currency(period.CantidadDias * room.Price.Amount);

            decimal porcentageChange = 0;

            foreach (var feature in room.Features!)
            {
                porcentageChange += feature switch
                {

                    Features.Wifi => 0.05m,
                    Features.AirConditioning => 0.02m,
                    Features.Balcony => 0.07m,
                    Features.Cooler => 0.03m,
                    _ => 0
                };
            }


            var accesorioCharges = Currency.Zero();

            if (porcentageChange > 0)
                accesorioCharges = new Currency(precioPorPeriodo.Amount * porcentageChange);


            var precioTotal = Currency.Zero();
            precioTotal += precioPorPeriodo;

            if (!room!.Maintenance!.IsZero())
                precioTotal += room.Maintenance;


            precioTotal += accesorioCharges;


            return new DetailPrice(
                precioPorPeriodo,
                room.Maintenance,
                accesorioCharges,
                precioTotal
                );
        }
    }
}
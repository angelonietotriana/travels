using Travels.Application.Abstractions.Data;
using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Dapper;
using CleanArchitecture.Application.Vehiculos.SearchVehiculos;

namespace Travels.Application.Rooms.SearchRooms
{

    internal sealed class SearchRoomQueryHandler
     : IQueryHandler<SearchRoomQuery, IReadOnlyList<RoomResponse>>
    {

        private static readonly int[] ActiveBookingStatuses =
        {
        (int)BookingStatus.Booking,
        (int)BookingStatus.Confirm,
        (int)BookingStatus.Complete
    };


        private readonly ISqlConnectionFactory _sqlConectionFactory;

        public SearchRoomQueryHandler(ISqlConnectionFactory sqlConectionFactory)
        {
            _sqlConectionFactory = sqlConectionFactory;
        }

        public async Task<Result<IReadOnlyList<RoomResponse>>> Handle(
            SearchRoomQuery request,
            CancellationToken cancellationToken
        )
        {
            if (request.startDate > request.endDate)
            {
                return new List<RoomResponse>();
            }

            using var connection = _sqlConectionFactory.CreateConnection();

            const string sql = """
               SELECT
                a.id as Id,
                a.modelo as Modelo,
                a.vin as Vin,
                a.precio_monto as Precio,
                a.precio_tipo_moneda as TipoMoneda,
                a.direccion_pais as Pais,
                a.direccion_departamento as Departamento,
                a.direccion_provincia as Provincia,
                a.direccion_ciudad as Ciudad,
                a.direccion_calle as Calle
             FROM rooms AS a
             WHERE NOT EXISTS
             (
                    SELECT 1 
                    FROM bookings AS b
                    WHERE 
                        b.vehiculo_id = a.id  AND
                        b.duracion_inicio <= @EndDate AND
                        b.duracion_fin  >= @StartDate AND
                        b.status = ANY(@ActiveAlquilerStatuses)
             )      
        """;


            var rooms = await connection
                .QueryAsync<RoomResponse, AddressResponse, RoomResponse>
                (
                    sql,
                    (room, direccion) =>
                    {
                      return room;
                    },
                    new
                    {
                        StartDate = request.startDate,
                        EndDate = request.endDate,
                        ActiveBookingStatuses
                    },
                    splitOn: "Pais"
                );

            return rooms.ToList();
        }
    }
}
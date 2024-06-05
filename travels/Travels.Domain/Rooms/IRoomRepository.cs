using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;

namespace Travels.Domain.Rooms
{
    public  interface IRoomRepository
    {
        Task<RoomEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(RoomEntity room);
        void Update(RoomEntity room);
    }
}

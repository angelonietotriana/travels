using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.Domain.Hotels
{
    public enum HotelStatus
    {
        init = 1,
        room_available = 2,
        room_not_available = 3,
        close = 4
    }
}

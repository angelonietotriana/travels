using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.Domain.Hotels
{
    public record Address(String City,
                        String Neighborhood,
                        String Zone,
                        String Numeration);
    
}

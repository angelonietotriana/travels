using System.Data;

namespace Travels.Application.Abstractions.Data
{

    public interface ISqlConnectionFactory
    {

        IDbConnection CreateConnection();

    }
}
using Bogus;
using Travels.Application.Abstractions.Data;
using Travels.Domain.Rooms;
using Dapper;

namespace Travels.Api.Extensions {

    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using var connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            List<object> objects = new();

            for (var i = 0; i < 100; i++)
            {   
               // creación room
            }

            const string sql = ""; /*"""
            INSERT INTO         """;*/

            connection.Execute(sql, objects);
        }

    }
}
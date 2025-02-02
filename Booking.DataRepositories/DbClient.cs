using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net.WebSockets;

namespace Booking.DataRepositories
{
    internal static class DbClient
    {
        public static IMongoDatabase GetDatabase()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config["ConnectionString"];
            var db = config["Database"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(db);

            return database;
        }
    }
}

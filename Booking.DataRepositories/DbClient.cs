using MongoDB.Bson;
using MongoDB.Driver;

namespace Booking.DataRepositories
{
    internal static class DbClient
    {
        public static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("booking");

            return database;
        }
    }
}

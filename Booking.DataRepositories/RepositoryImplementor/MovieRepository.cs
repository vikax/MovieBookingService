using Booking.DataRepositories.Entities;
using Booking.DataRepositories.RepositoryInterfaces;
using MongoDB.Driver;

namespace Booking.DataRepositories.RepositoryImplementor
{
    public class MovieRepository : IMovieRepository
    {
        private const string TableName = "Movies";
        IMongoDatabase database { get; set; }

        IMongoCollection<MovieEntity> collection { get; set; }


        public MovieRepository()
        {
            database = DbClient.GetDatabase();
            collection = database.GetCollection<MovieEntity>(TableName);
        }

        public async Task AddAsync(MovieEntity movieEntity)
        {
            await collection.InsertOneAsync(movieEntity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<MovieEntity>.Filter.Eq(x => x.Id, id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<MovieEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieEntity> GetByIdAsnc(string id)
        {
            var filter = Builders<MovieEntity>.Filter.Eq(x => x.Id, id);
            var movie = await collection.FindAsync<MovieEntity>(filter);
            return movie.FirstOrDefault();
        }

        public async Task UpdateAsync(MovieEntity movieEntity)
        {
            throw new NotImplementedException();
        }
    }
}

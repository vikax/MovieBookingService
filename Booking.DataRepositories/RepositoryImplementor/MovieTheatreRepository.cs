using Booking.DataRepositories.Entities;
using Booking.DataRepositories.RepositoryInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.RepositoryImplementor
{
    public class MovieTheatreRepository : IMovieTheatreRepository
    {
        private const string TableName = "MovieTheatres";

        IMongoDatabase database { get; set; }

        IMongoCollection<MovieTheatreEntity> collection { get; set; }


        public MovieTheatreRepository()
        {
            database = DbClient.GetDatabase();
            collection = database.GetCollection<MovieTheatreEntity>(TableName);
        }

        public async Task AddAsync(MovieTheatreEntity movieEntity)
        {
            await collection.InsertOneAsync(movieEntity);
        }

        public async Task DeleteAsync(string id)
        {
            await collection.DeleteOneAsync(id);
        }

        public async Task<List<MovieTheatreEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieTheatreEntity> GetByIdAsnc(string id)
        {
            var filter = Builders<MovieTheatreEntity>.Filter.Eq(x => x.Id, id);
            var movie = await collection.FindAsync<MovieTheatreEntity>(filter);
            return movie.FirstOrDefault();
        }

        public async Task UpdateAsync(MovieTheatreEntity movieTheatreEntity)
        {
            var filters = Builders<MovieTheatreEntity>.Filter.Eq(x => x.Id, movieTheatreEntity.Id);
            var update = Builders<MovieTheatreEntity>.Update
                .Set(x => x.ScreeningRoomsId, movieTheatreEntity.ScreeningRoomsId)
                .Set(x => x.MoviesId, movieTheatreEntity.MoviesId);

            await collection.UpdateOneAsync(filters, update);
        }
    }
}

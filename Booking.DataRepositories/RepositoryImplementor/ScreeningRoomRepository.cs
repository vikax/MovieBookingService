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

    public class ScreeningRoomRepository : IScreeningRoomRepository
    {
        private const string TableName = "ScreeningRooms";

        IMongoDatabase database { get; set; }

        IMongoCollection<ScreeningRoomEntity> collection { get; set; }


        public ScreeningRoomRepository()
        {
            database = DbClient.GetDatabase();
            collection = database.GetCollection<ScreeningRoomEntity>(TableName);
        }

        public async Task AddAsync(ScreeningRoomEntity screeningRoomEntity)
        {
            await collection.InsertOneAsync(screeningRoomEntity);
        }

        public async Task DeleteAsync(string id)
        {
            await collection.DeleteOneAsync(id);
        }

        public async Task<List<ScreeningRoomEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ScreeningRoomEntity> GetByIdAsnc(string id)
        {
            var filter = Builders<ScreeningRoomEntity>.Filter.Eq(x => x.Id, id);
            var movie = await collection.FindAsync<ScreeningRoomEntity>(filter);
            return movie.FirstOrDefault();
        }

        public async Task UpdateAsync(ScreeningRoomEntity screeningRoomEntity)
        {
            var filters = Builders<ScreeningRoomEntity>.Filter.Eq(x => x.Id, screeningRoomEntity.Id);
            var update = Builders<ScreeningRoomEntity>.Update
                .Set(x => x.BookedSeats, screeningRoomEntity.BookedSeats);

            await collection.UpdateOneAsync(filters, update);
        }
    }
}

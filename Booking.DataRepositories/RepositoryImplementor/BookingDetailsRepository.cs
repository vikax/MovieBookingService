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
    public class BookingDetailsRepository : IBookingDetailsRepository
    {
        private const string TableName = "BookingDetails";

        IMongoDatabase database { get; set; }

        IMongoCollection<BookingDetailsEntity> collection { get; set; }


        public BookingDetailsRepository()
        {
            database = DbClient.GetDatabase();
            collection = database.GetCollection<BookingDetailsEntity>(TableName);
        }

        public async Task AddAsync(BookingDetailsEntity bookingDetailsEntity)
        {
            await collection.InsertOneAsync(bookingDetailsEntity);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDetailsEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookingDetailsEntity> GetByIdAsnc(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BookingDetailsEntity movieEntity)
        {
            throw new NotImplementedException();
        }
    }
}

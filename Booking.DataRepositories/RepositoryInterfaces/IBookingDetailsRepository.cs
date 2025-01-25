using Booking.DataRepositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.RepositoryInterfaces
{
    public interface IBookingDetailsRepository
    {
        public Task AddAsync(BookingDetailsEntity movieEntity);

        public Task<BookingDetailsEntity> GetByIdAsnc(string id);

        public Task<List<BookingDetailsEntity>> GetAllAsync();

        public Task UpdateAsync(BookingDetailsEntity movieEntity);

        public Task DeleteAsync(string id);
    }
}

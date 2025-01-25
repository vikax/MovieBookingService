using Booking.DataRepositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.RepositoryInterfaces
{
    public interface IScreeningRoomRepository
    {
        public Task AddAsync(ScreeningRoomEntity movieEntity);

        public Task<ScreeningRoomEntity> GetByIdAsnc(string id);

        public Task<List<ScreeningRoomEntity>> GetAllAsync();

        public Task UpdateAsync(ScreeningRoomEntity movieEntity);

        public Task DeleteAsync(string id);
    }
}

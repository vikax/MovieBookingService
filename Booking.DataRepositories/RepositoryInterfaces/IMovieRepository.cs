
using Booking.DataRepositories.Entities;

namespace Booking.DataRepositories.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        public Task AddAsync(MovieEntity movieEntity);

        public Task<MovieEntity> GetByIdAsnc(string id);

        internal Task<List<MovieEntity>> GetAllAsync();

        internal Task UpdateAsync(MovieEntity movieEntity);

        internal Task DeleteAsync(string id);
        
    }
}

using Booking.DataRepositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.RepositoryInterfaces
{
    public interface IMovieTheatreRepository
    {
        public Task AddAsync(MovieTheatreEntity movieEntity);

        public Task<MovieTheatreEntity> GetByIdAsnc(string id);

        public Task<List<MovieTheatreEntity>> GetAllAsync();

        public Task UpdateAsync(MovieTheatreEntity movieEntity);

        public Task DeleteAsync(string id);
    }
}

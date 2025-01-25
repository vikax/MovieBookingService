using Booking.Common.Contracts;

namespace Booking.Service.Interfaces
{
    public interface IMovieManager
    {
        public Task AddMovieAsync(Movie movie);

        public Task<Movie> GetMovieAsync(string id);
    }
}

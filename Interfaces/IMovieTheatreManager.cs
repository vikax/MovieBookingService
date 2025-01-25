using Booking.Common.Contracts;

namespace Booking.Service.Interfaces
{
    public interface IMovieTheatreManager
    {
        Task AddMovieTheatreAsync(MovieTheatre movieTheatre);

        Task<MovieTheatre> GetMovieTheatreById(string id);

        Task UpdateMovieTheatre(MovieTheatre movieTheatre);
    }
}

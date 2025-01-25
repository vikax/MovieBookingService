using Booking.Common.Contracts;
using Booking.DataRepositories.Entities;
using Booking.DataRepositories.RepositoryInterfaces;
using Booking.Service.Interfaces;

namespace Booking.Service.Managers
{
    public class MovieManager : IMovieManager
    {
        private IMovieRepository movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;    
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await movieRepository.AddAsync(ToMovieEntity(movie));
        }

        public async Task<Movie> GetMovieAsync(string id)
        {
            var movieEntity = await this.movieRepository.GetByIdAsnc(id);
            return ToMovie(movieEntity);
        }

        private static MovieEntity ToMovieEntity(Movie movie)
        {
            return new MovieEntity
            {
                Actors = movie.Actors,
                Description = movie.Description,
                Id = movie.Id,
                Title = movie.Title,
            };
        }

        private static Movie ToMovie(MovieEntity movieEntity)
        {
            return new Movie
            {
                Actors = movieEntity.Actors,
                Description = movieEntity.Description,
                Id = movieEntity.Id,
                Title = movieEntity.Title,
            };
        }
    }
}

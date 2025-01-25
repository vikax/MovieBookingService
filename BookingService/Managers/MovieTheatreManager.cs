using Booking.Common.Contracts;
using Booking.DataRepositories.Entities;
using Booking.DataRepositories.RepositoryInterfaces;
using Booking.Service.Interfaces;
using MongoDB.Driver;

namespace Booking.Service.Managers
{
    public class MovieTheatreManager : IMovieTheatreManager
    {
        private IMovieTheatreRepository movieTheatreRepository;
        public MovieTheatreManager(IMovieTheatreRepository movieTheatreRepository)
        {
            this.movieTheatreRepository = movieTheatreRepository;
        }

        public async Task AddMovieTheatreAsync(MovieTheatre movieTheatre)
        {
            if(movieTheatre == null || movieTheatre.Id == null)
            {
                throw new ArgumentException("invalid movie theatre");
            }

            await this.movieTheatreRepository.AddAsync(ToMovieTheatreEntity(movieTheatre));
        }

        public async Task<MovieTheatre> GetMovieTheatreById(string id)
        {
            var theatre = await this.movieTheatreRepository.GetByIdAsnc(id);
            return ToMovieTheatre(theatre);

        }

        private static MovieTheatreEntity ToMovieTheatreEntity(MovieTheatre movieTheatre)
        {
            return new MovieTheatreEntity()
            {
                Id = movieTheatre.Id,
                Location = movieTheatre.Location,
                MoviesId = movieTheatre.MoviesId,
                ScreeningRoomsId = movieTheatre.ScreeningRoomsId
            };

        }

        private static MovieTheatre ToMovieTheatre(MovieTheatreEntity movieTheatreEntity)
        {
            return new MovieTheatre()
            {
                Id = movieTheatreEntity.Id,
                Location = movieTheatreEntity.Location,
                MoviesId = movieTheatreEntity.MoviesId,
                ScreeningRoomsId = movieTheatreEntity.ScreeningRoomsId
            };

        }

        public async Task UpdateMovieTheatre(MovieTheatre movieTheatre)
        {
            var entity = ToMovieTheatreEntity(movieTheatre);
            await this.movieTheatreRepository.UpdateAsync(entity);
        }
    }
}

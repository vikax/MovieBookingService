using Booking.Common.Contracts;
using Booking.DataRepositories.Entities;
using Booking.DataRepositories.RepositoryInterfaces;
using Booking.Service.Interfaces;

namespace Booking.Service.Managers
{
    public class ScreeningRoomManager : IScreeningRoomManager
    {
        private readonly IScreeningRoomRepository screeningRoomRepository;
        private readonly IMovieTheatreRepository movieTheatreRepository;

        public ScreeningRoomManager(IScreeningRoomRepository screeningRoomRepository, IMovieTheatreRepository movieTheatreRepository)
        {
            this.screeningRoomRepository = screeningRoomRepository;
            this.movieTheatreRepository = movieTheatreRepository;

        }

        public async Task AddScreeningRoomAsync(ScreeningRoom screeningRoom)
        {
            if (screeningRoom == null || screeningRoom.Id == null) 
            {
                throw new ArgumentNullException("invalid screening room details");
            }

            //if(screeningRoom.MovieTheatreId == null)
            //{
                //throw new ArgumentNullException(nameof(screeningRoom.MovieTheatreId));
            //}

            //var movieTheatre = await movieTheatreRepository.GetByIdAsnc(screeningRoom.MovieTheatreId);
            //if(movieTheatre == null) 
            //{
                //throw new ArgumentException("Movie theatre is not valid");
            //}

            await this.screeningRoomRepository.AddAsync(ToScreenRoomEntity(screeningRoom));
        }

        public async Task<ScreeningRoom> GetScreeningRoomByIdAsync(string id)
        {
            var screeningRoomEntity = await this.screeningRoomRepository.GetByIdAsnc(id);
            return ToScreenRoom(screeningRoomEntity);
        }

        private static ScreeningRoomEntity ToScreenRoomEntity(ScreeningRoom screeningRoom)
        {
            return new ScreeningRoomEntity
            {
                Description = screeningRoom.Description,
                Id = screeningRoom.Id,
                MovieTheatreId = screeningRoom.MovieTheatreId,
                Name = screeningRoom.Name,
                TotalColumnsCapacity = screeningRoom.TotalColumnsCapacity,
                TotalRowsCapacity = screeningRoom.TotalRowsCapacity,
                BookedSeats = screeningRoom.BookedSeats ?? new List<string>(),
            };
        }

        private static ScreeningRoom ToScreenRoom(ScreeningRoomEntity room)
        {
            return new ScreeningRoom
            {
                Description = room.Description,
                Id = room.Id,
                MovieTheatreId = room.MovieTheatreId,
                Name = room.Name,
                TotalColumnsCapacity = room.TotalColumnsCapacity,
                TotalRowsCapacity = room.TotalRowsCapacity,
            };
        }

        public async Task UpdateScreeningRoomAsync(ScreeningRoom screeningRoom)
        {
            var screeningRoomEntity = ToScreenRoomEntity(screeningRoom);
            await this.screeningRoomRepository.UpdateAsync(screeningRoomEntity);
        }
    }
}

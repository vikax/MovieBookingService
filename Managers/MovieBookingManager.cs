using Booking.Common.Contracts;
using Booking.DataRepositories.Entities;
using Booking.DataRepositories.RepositoryInterfaces;
using Booking.Service.Interfaces;
using MovieBookingService.Interfaces;
using System.Linq;

namespace MovieBookingService.Managers
{
    public class MovieBookingManager : IMovieBookingManager
    {
        private IMovieManager movieManager;
        private IMovieTheatreManager movieTheatreManager;
        private IScreeningRoomManager screeningRoomManager;
        private IBookingDetailsRepository bookingDetailsRepository;
        

        public MovieBookingManager(IMovieManager movieManager,
            IMovieTheatreManager movieTheatreManager, 
            IScreeningRoomManager screeningRoomManager,
            IBookingDetailsRepository bookingDetailsRepository)
        {
            this.movieManager = movieManager;
            this.movieTheatreManager = movieTheatreManager;
            this.screeningRoomManager = screeningRoomManager;
            this.bookingDetailsRepository = bookingDetailsRepository;
        }

        public async Task<bool> TryBookMovieAsync(BookingDetails bookingDetails)
        {
            try
            {
                if(bookingDetails == null || 
                    bookingDetails.MovieId == null || 
                    bookingDetails.MovieTheatreId == null ||
                    bookingDetails.ScreeningRoomId == null)
                {
                    throw new ArgumentException("booking details is null or movied id is null");
                }

                var movie = await this.movieManager.GetMovieAsync(bookingDetails.MovieId);
                if(movie == null)
                {
                    throw new ArgumentNullException(nameof(movie));
                }

                var movieTheatre = await this.movieTheatreManager.GetMovieTheatreById(bookingDetails.MovieTheatreId);
                if (movieTheatre == null)
                {
                    throw new ArgumentNullException(nameof(movieTheatre));
                }

                var screeningRoom = await screeningRoomManager.GetScreeningRoomByIdAsync(bookingDetails.ScreeningRoomId);
                if (screeningRoom == null)
                {
                    throw new ArgumentNullException(nameof(screeningRoom));
                }

                //if(screeningRoom.MovieTheatreId != bookingDetails.MovieTheatreId)
                //{
                    //throw new Exception("screening room is in dfferent theatre");
                //}

                var isMovieScreeningInTheatre = IsMovieScreeningInTheatre(movieTheatre, movie.Id);
                if(!isMovieScreeningInTheatre)
                {
                    throw new Exception("movie is not yet available to screen in this theatre");
                }

                var bookedSeats = screeningRoom.BookedSeats ?? new List<string>();
                var totalCapacity = screeningRoom.TotalRowsCapacity * screeningRoom.TotalColumnsCapacity;

                if(bookingDetails.TotalTickets > (totalCapacity - bookedSeats.Count))
                {
                    return false;
                }

                bookedSeats = BookSeats(screeningRoom.TotalRowsCapacity, 
                    screeningRoom.TotalColumnsCapacity, 
                    bookedSeats, 
                    bookingDetails.TotalTickets);
                screeningRoom.BookedSeats = bookedSeats;

                await this.screeningRoomManager.UpdateScreeningRoomAsync(screeningRoom);

                await this.bookingDetailsRepository.AddAsync(ToEntity(bookingDetails));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> BookSeats(int rows, int columns, List<string> bookedSeats, int ticketsCount)
        {
            var roomMatrix = new int[rows, columns];
            var seats = new List<string>();

            for(int i=  0;i<rows; i++)
            {
                for(int j = 0;j<columns;j++)
                {
                    if (bookedSeats.Contains($"{i}-{j}"))
                        roomMatrix[i, j] = 1;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(ticketsCount == 0)
                    {
                        break;
                    }
                    if (roomMatrix[i, j] == 0)
                    {
                        ticketsCount--;
                        bookedSeats.Add($"{i}-{j}");
                    }                  
                }
            }

            return bookedSeats;
        }

        private bool IsMovieScreeningInTheatre(MovieTheatre movieTheatre, string movieId)
        {
            var movies = movieTheatre.MoviesId;

            return movies.Contains(movieId);
        }

        private BookingDetailsEntity ToEntity(BookingDetails bookingDetails)
        {
            var random = new Random();
            return new BookingDetailsEntity
            {
                Id = bookingDetails.Id,
                MovieId = bookingDetails.MovieId,
                MovieTheatreId = bookingDetails.MovieTheatreId,
                ScreeningRoomId = bookingDetails.ScreeningRoomId,
                TotalPrice = random.Next(100, 1200),
                TotalTickets = bookingDetails.TotalTickets,
                UpdatedUtc = DateTime.UtcNow,
            };
        }
    }
}

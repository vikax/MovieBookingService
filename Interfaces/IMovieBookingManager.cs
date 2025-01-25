using Booking.Common.Contracts;

namespace MovieBookingService.Interfaces
{
    public interface IMovieBookingManager
    {
        public Task<bool> TryBookMovieAsync(BookingDetails bookingDetails);
    }
}

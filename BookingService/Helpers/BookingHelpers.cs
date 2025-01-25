using Booking.Common.Contracts;
using MovieBookingService.Exceptions;

namespace MovieBookingService.Helpers
{
    public static class BookingHelpers
    {
        public static void ValidateBookingDetails(BookingDetails bookingDetails)
        {
            if(bookingDetails == null)
            {
                throw new BookingExceptions(BookingExceptionType.InvalidBookingDetails);
            }

            if(bookingDetails.MovieTheatreId == null) 
            {
                throw new BookingExceptions(BookingExceptionType.InvalidMovieTheatre);
            }

            if (bookingDetails.MovieId == null)
            {
                throw new BookingExceptions(BookingExceptionType.InvalidMovieTheatre);
            }
        }
    }
}

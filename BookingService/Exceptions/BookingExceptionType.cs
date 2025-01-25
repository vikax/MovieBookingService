namespace MovieBookingService.Exceptions
{
    public enum BookingExceptionType
    {
        Unknown = 0,

        InvalidBookingDetails,
        
        InvalidMovie,

        InvalidMovieTheatre,

        InvalidScreeningRoom,

        NotEnoughTickets
    }
}

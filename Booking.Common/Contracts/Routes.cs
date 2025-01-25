namespace Booking.Common.Contracts
{
    /// <summary>
    /// routes class will contain all the service api endpoints
    /// </summary>
    public static class Routes
    {
        public const string Book = "/book";

        public const string Movie = "/movie";

        public const string MovieById = "/movie/{id}";

        public const string MovieTheatre = "/movie-theatre";

        public const string MovieTheatreById = "/movie-theatre/{id}";

        public const string ScreeningRoom = "/screening-room";
    }
}

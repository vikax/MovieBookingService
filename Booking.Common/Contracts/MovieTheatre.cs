namespace Booking.Common.Contracts
{
    public class MovieTheatre
    {
        public string? Id { get; set; }

        public Location? Location { get; set; }

        public List<string>? ScreeningRoomsId { get; set; }

        public List<string>? MoviesId { get; set; }
    }
}

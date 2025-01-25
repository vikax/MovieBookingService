namespace Booking.Common.Contracts
{
    public class ScreeningRoom
    {
        public string? Id { get; set; }

        public string? MovieTheatreId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int TotalRowsCapacity { get; set; }

        public int TotalColumnsCapacity { get; set; }

        public List<string> BookedSeats { get; set; } = new List<string>();

        private int[][]? Seats { get; set; }

        private int TotalSeatsCapacity { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace Booking.Common.Contracts
{
    /// <summary>
    /// Contract class for booking details
    /// </summary>
    public class BookingDetails
    {
        public string? Id { get; set; }

        public string? MovieId { get; set; }

        public string? MovieTheatreId { get; set; }

        public string? ScreeningRoomId { get; set; }

        public int TotalTickets { get; set;}

    }
}

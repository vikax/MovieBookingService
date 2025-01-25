using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.Entities
{
    public class BookingDetailsEntity
    {
        public string? Id { get; set; }

        public string? MovieId { get; set; }

        public string? MovieTheatreId { get; set; }

        public string? ScreeningRoomId { get; set; }

        public int TotalTickets { get; set; }

        public float TotalPrice { get; set; }

        public DateTime? UpdatedUtc { get; set; }
    }
}

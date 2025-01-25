using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.Entities
{
    public class ScreeningRoomEntity
    {
        public string? Id { get; set; }

        public string? MovieTheatreId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int TotalRowsCapacity { get; set; }

        public int TotalColumnsCapacity { get; set; }

        public List<string> BookedSeats { get; set; } = new List<string>();
    }
}

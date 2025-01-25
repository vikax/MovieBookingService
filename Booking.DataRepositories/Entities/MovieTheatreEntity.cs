using Booking.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.Entities
{
    public class MovieTheatreEntity
    {
        public string Id { get; set; }

        public Location? Location { get; set; }

        public List<string>? ScreeningRoomsId { get; set; }

        public List<string>? MoviesId { get; set; }
    }
}

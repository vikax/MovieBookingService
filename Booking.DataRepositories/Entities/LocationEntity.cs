using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.Entities
{
    internal class LocationEntity
    {
        public string Id { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

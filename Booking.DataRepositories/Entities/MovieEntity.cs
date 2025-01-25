using Booking.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataRepositories.Entities
{
    public class MovieEntity
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Actor> Actors { get; set; }
    }
}

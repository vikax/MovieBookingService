using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Booking.Common.Contracts
{
    /// <summary>
    /// contract class for movie details
    /// </summary>
    public class Movie
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public List<Actor>? Actors { get; set; }

        public bool IsScreening { get; set; }
    }
}

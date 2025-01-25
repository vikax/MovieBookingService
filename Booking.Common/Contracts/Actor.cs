namespace Booking.Common.Contracts
{
    /// <summary>
    /// contract class for actor
    /// </summary>
    public class Actor
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Awards { get; set; }
    }
}

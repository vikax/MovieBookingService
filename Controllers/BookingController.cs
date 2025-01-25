using Booking.Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBookingService.Helpers;
using MovieBookingService.Interfaces;

namespace MovieBookingService.Controllers
{
    /// <summary>
    /// Controller for booking movie tickets
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    public class BookingController : ControllerBase
    {
        private IMovieBookingManager movieBookingManager;

        public BookingController(IMovieBookingManager movieBookingManager)
        {
            this.movieBookingManager = movieBookingManager;
        }

        [HttpPost(Routes.Book)]
        public async Task<IActionResult> BookMovieTicketsAsync([FromBody]BookingDetails bookingDetails)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                bookingDetails.Id = id; 
                BookingHelpers.ValidateBookingDetails(bookingDetails);

                var isBooked = await this.movieBookingManager.TryBookMovieAsync(bookingDetails);

                if (isBooked)
                {
                    return Ok(bookingDetails);
                }
                else
                {
                    return Ok("Cannot book ticket");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }          
        }
    }
}

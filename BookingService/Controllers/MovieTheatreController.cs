using Booking.Common.Contracts;
using Booking.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Service.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class MovieTheatreController : ControllerBase
    {
        private IMovieTheatreManager movieTheatreManager;

        public MovieTheatreController(IMovieTheatreManager movieTheatreManager)
        {
            this.movieTheatreManager = movieTheatreManager;
        }

        [HttpPost(Routes.MovieTheatre)]
        public async Task<ObjectResult> AddTheatreAsync([FromBody]MovieTheatre movieTheatre)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                movieTheatre.Id = id;   
                await this.movieTheatreManager.AddMovieTheatreAsync(movieTheatre);
                return Ok(movieTheatre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut(Routes.MovieTheatreById)]
        public async Task<ObjectResult> UpdateTheatreAsync(string id, [FromBody] MovieTheatre movieTheatre)
        {
            try
            {
                movieTheatre.Id = id;
                await this.movieTheatreManager.UpdateMovieTheatre(movieTheatre);
                return Ok(movieTheatre);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

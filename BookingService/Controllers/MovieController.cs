using Booking.Common.Contracts;
using Booking.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Service.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class MovieController : ControllerBase
    {
        private IMovieManager movieManager;

        public MovieController(IMovieManager movieManager)
        {
            this.movieManager = movieManager;
        }

        [HttpPost(Routes.Movie)]
        public async Task<ObjectResult> AddMovieAsync([FromBody]Movie movie)
        {
            var id = Guid.NewGuid().ToString();
            movie.Id = id;
            await this.movieManager.AddMovieAsync(movie);
            return Ok(movie);
        }
    }
}

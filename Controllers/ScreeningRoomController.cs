using Booking.Common.Contracts;
using Booking.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Service.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ScreeningRoomController : ControllerBase
    {
        IScreeningRoomManager screeningRoomManager;

        public ScreeningRoomController(IScreeningRoomManager screeningRoomManager)
        {
            this.screeningRoomManager = screeningRoomManager;
        }

        [HttpPost(Routes.ScreeningRoom)]
        public async Task<ObjectResult> AddScreenAsync([FromBody] ScreeningRoom screeningRoom)
        {
            try
            {
                if(screeningRoom == null)
                {
                    return BadRequest("invalid screening room");
                }

                var id = Guid.NewGuid().ToString();
                screeningRoom.Id = id;
               
                await this.screeningRoomManager.AddScreeningRoomAsync(screeningRoom);
                return Ok(screeningRoom);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

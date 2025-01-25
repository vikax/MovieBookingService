using Booking.Common.Contracts;

namespace Booking.Service.Interfaces
{
    public interface IScreeningRoomManager
    {
        Task AddScreeningRoomAsync(ScreeningRoom screeningRoom);

        Task<ScreeningRoom> GetScreeningRoomByIdAsync(string id);

        Task UpdateScreeningRoomAsync(ScreeningRoom screeningRoom);
    }
}

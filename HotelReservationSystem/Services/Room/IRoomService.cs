using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Services.Room
{
    public interface IRoomService
    {
        Task<ResponseViewModel<RoomViewModel>> Create(CreateRoomDTO roomDto);
        Task<ResponseViewModel<List<RoomViewModel>>> GetAll();
        Task<ResponseViewModel<RoomViewModel>> GetByIdAsync(int id);
        Task<ResponseViewModel<RoomViewModel>> UpdateAsync(int id, UpdateRoomDTO roomDto);
        Task<ResponseViewModel<string>> DeleteAsync(int id);
    }
}

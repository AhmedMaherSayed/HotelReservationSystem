using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Services.Room
{
    public interface IRoomService
    {
        Task<ResponseViewModel<Data.Entities.Room>> Create(CreateRoomDTO roomDto);
        Task<ResponseViewModel<RoomResponseDTO>> GetByIdAsync(int id);
        Task<ResponseViewModel<RoomResponseDTO>> UpdateAsync(int id, UpdateRoomDTO roomDto);
        Task<ResponseViewModel<string>> DeleteAsync(int id);
    }
}

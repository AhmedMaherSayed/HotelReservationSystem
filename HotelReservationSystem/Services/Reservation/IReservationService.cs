using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservation;

namespace HotelReservationSystem.Services.Reservation
{
    public interface IReservationService
    {
        Task<ResponseViewModel<List<RoomResponseDTO>>> GetAvailableRooms();
        Task<ReservationViewModel?> GetReservationDetails(int ReservationId);
        Task<List<ReservationViewModel>> GetCustomerReservations(int customerId);
        Task<ResponseViewModel<ReservationViewModel>> CreateReservation(ReservationCreateViewModel model);
        Task<ResponseViewModel<ReservationViewModel>> UpdateReservation(int reservationId, ReservationUpdateViewModel model);
        Task<ResponseViewModel<ReservationViewModel>> ConfirmReservation(int ReservationId);
        Task<ResponseViewModel<string>> CancelReservation(int reservationId);
        Task<ResponseViewModel<string>> DeleteAsync(int id);
    }
}

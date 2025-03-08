using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Services;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ResponseViewModel<IEnumerable<RoomResponseDTO>>> RoomSearch(RoomSearchDTO roomSearch)
        {
            var rooms = await _reservationService.GetAvailableRoomsAsync(roomSearch);

            return ResponseViewModel<IEnumerable<RoomResponseDTO>>.Success(rooms);
        }

        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> BookReservation(ReservationCreateViewModel reservationCreate)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ResponseViewModel<ReservationViewModel>> ViewReservationDetails(int ReservationId)
        {
            var reservation = await _reservationService.GetReservationDetails(ReservationId);

            if (reservation == null)
            {
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.NotFound, "Reservation Is Not Found.");
            }

            return ResponseViewModel<ReservationViewModel>.Success(reservation);
        }

        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> EditReservation(ReservationUpdateViewModel reservationUpdate)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> ConfirmReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ResponseViewModel<string>> CancelReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }
    }
}

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


        [HttpGet("customer/{customerId}")]
        public async Task<ResponseViewModel<List<ReservationViewModel>>> GetCustomerReservations(int customerId)
        {
            return await _reservationService.GetCustomerReservations(customerId);
        }



        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> BookReservation(ReservationCreateViewModel reservationCreate)
        {
            if (reservationCreate == null)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.BadRequest, "Reservation details are required.");

            if (reservationCreate.CheckInDate < DateTime.UtcNow.Date)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.InvalidOperation, "Check-in date cannot be in the past.");

            if (reservationCreate.CheckOutDate.HasValue && reservationCreate.CheckOutDate <= reservationCreate.CheckInDate)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.InvalidOperation, "Check-out date must be after the check-in date.");

            return await _reservationService.CreateReservation(reservationCreate);
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

      

        // Update a reservation (only if status is Pending)
        [HttpPut("{id}")]
        public async Task<ResponseViewModel<ReservationViewModel>> EditReservation(int id, [FromBody] ReservationUpdateViewModel reservationUpdate)
        {
            if (id != reservationUpdate.ReservationId)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.InvalidOperation, "Reservation ID mismatch");

            return await _reservationService.UpdateReservation(reservationUpdate);
        }



        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> ConfirmReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }


        [HttpPut("cancel/{reservationId}")]
        public async Task<ResponseViewModel<string>> CancelReservation(int reservationId)
        {
            if (reservationId <= 0)
                return ResponseViewModel<string>.Failure(ErrorCode.BadRequest, "Invalid reservation ID.");

            return await _reservationService.CancelReservation(reservationId);
        }

        [HttpDelete("{reservationId}")]
        public async Task<ResponseViewModel<string>> DeleteReservation(int reservationId)
        {
          
           return await _reservationService.DeleteReservation(reservationId);

        }


    }
}

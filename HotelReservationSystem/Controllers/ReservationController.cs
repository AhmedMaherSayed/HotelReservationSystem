using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Helpers;
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
            var reservations = await _reservationService.GetCustomerReservations(customerId);
            if (reservations == null || reservations.Count == 0)
                return ResponseViewModel<List<ReservationViewModel>>.Failure(ErrorCode.NotFound, "No reservations found for this customer.");

            return ResponseViewModel<List<ReservationViewModel>>.Success(reservations);
        }


        [HttpPost("book")]
        public async Task<ResponseViewModel<ReservationViewModel>> BookReservation([FromBody] ReservationCreateViewModel reservationCreate)
        {
            if (reservationCreate == null)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.BadRequest, "Reservation details are required.");

            if (reservationCreate.CheckInDate < DateTime.UtcNow.Date)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.InvalidOperation, "Check-in date cannot be in the past.");

            if (reservationCreate.CheckOutDate.HasValue && reservationCreate.CheckOutDate <= reservationCreate.CheckInDate)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.InvalidOperation, "Check-out date must be after the check-in date.");

            var reservation = await _reservationService.CreateReservation(reservationCreate);
            if (reservation == null)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.RoomNotAvailable, "Room is not available for the selected dates.");

            return ResponseViewModel<ReservationViewModel>.Success(reservation.Map<ReservationViewModel>());
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

            var success = await _reservationService.EditReservation(reservationUpdate);
            if (!success)
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.InvalidOperation, "Cannot update this reservation.");

            return ResponseViewModel<ReservationViewModel>.Success(reservationUpdate.Map<ReservationViewModel>());
        }


     


        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> ConfirmReservation(int ReservationId)
        {
            return await _reservationService.ConfirmReservation(ReservationId);
        }


        [HttpPut("cancel/{reservationId}")]
        public async Task<ResponseViewModel<string>> CancelReservation(int reservationId)
        {
            if (reservationId <= 0)
                return ResponseViewModel<string>.Failure(ErrorCode.BadRequest, "Invalid reservation ID.");

            var success = await _reservationService.CancelReservation(reservationId);
            if (!success)
                return ResponseViewModel<string>.Failure(ErrorCode.InvalidOperation, "Reservation cannot be canceled.");

            return ResponseViewModel<string>.Success("Reservation canceled successfully.");
        }



        [HttpDelete("{reservationId}")]
        public async Task<ResponseViewModel<string>> DeleteReservation(int reservationId)
        {
            var success = await _reservationService.DeleteReservation(reservationId);
            if (!success)
                return ResponseViewModel<string>.Failure(ErrorCode.NotFound, "Reservation not found.");

            return ResponseViewModel<string>.Success("Reservation deleted successfully.");
        }


    


    }
}

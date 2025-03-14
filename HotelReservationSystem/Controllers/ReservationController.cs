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

      


        [HttpGet("available-rooms")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var response = await _reservationService.GetAvailableRooms();

            if (!response.IsSucsess)
                return BadRequest(response);

            return Ok(response);
        }



        [HttpGet("customer/{customerId}")]
        public async Task<ResponseViewModel<List<ReservationViewModel1>>> GetCustomerReservations(int customerId)
        {
            var reservations = await _reservationService.GetCustomerReservations(customerId);
            if (reservations == null || reservations.Count == 0)
                return ResponseViewModel<List<ReservationViewModel1>>.Failure(ErrorCode.NotFound, "No reservations found for this customer.");

            return ResponseViewModel<List<ReservationViewModel1>>.Success(reservations);
        }


     

        public async Task<IActionResult> BookReservation([FromBody] ReservationCreateViewModel model)
        {
            var response = await _reservationService.CreateReservation(model);

            if (!response.IsSucsess)
                return BadRequest(response);

            return Ok(response);
        }



        [HttpGet]
        public async Task<ResponseViewModel<ReservationViewModel1>> ViewReservationDetails(int ReservationId)
        {
            var reservation = await _reservationService.GetReservationDetails(ReservationId);

            if (reservation == null)
            {
                return ResponseViewModel<ReservationViewModel1>.Failure(ErrorCode.NotFound, "Reservation Is Not Found.");
            }

            return ResponseViewModel<ReservationViewModel1>.Success(reservation);
        }




        // Update a reservation (only if status is Pending)
    
        [HttpPut("{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId, [FromBody] ReservationUpdateViewModel model)
        {
            var response = await _reservationService.UpdateReservation(reservationId, model);

            if (!response.IsSucsess)
                return BadRequest(response);

            return Ok(response);
        }


        //[HttpPost]
        //public async Task<ResponseViewModel<ReservationViewModel1>> ConfirmReservation(int ReservationId)
        //{
        //    return await _reservationService.ConfirmReservation(ReservationId);
        //}




        [HttpPut("cancel/{reservationId}")]
        public async Task<ResponseViewModel<string>> CancelReservation(int reservationId)
        {
            if (reservationId <= 0)
                return ResponseViewModel<string>.Failure(ErrorCode.BadRequest, "Invalid reservation ID.");

            return await _reservationService.CancelReservationAsync(reservationId);
        }



      


        [HttpDelete("Delete/{reservationId}")]
        public async Task<ResponseViewModel<string>> DeleteReservation(int reservationId)
        {
            return await _reservationService.DeleteAsync(reservationId);
        }




    }
}

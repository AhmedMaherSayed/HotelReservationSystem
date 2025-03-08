using HotelReservationSystem.Data.Entities;
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
        [HttpGet]
        public async Task<ResponseViewModel<Room>> RoomSearch()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> BookReservation(ReservationCreateViewModel reservationCreate)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ResponseViewModel<ReservationViewModel>> ViewReservationDetails(int ReservationId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ResponseViewModel<ReservationViewModel>> EditReservation(ReservationUpdateViewModel reservationUpdate)
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

using HotelReservationSystem.Services.PaymentService;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentService paymentService) : ControllerBase
    {
        [HttpPost("CreateOrUpdatePaymentIntent/{reservationId:int}")]
        public async Task<ResponseViewModel<ReservationViewModel>> CreateOrUpdatePaymentIntentAsync(int reservationId)
         => await paymentService.CreateOrUpdatePaymentIntentAsync(reservationId);
    }
}

using HotelReservationSystem.DTOs;
using HotelReservationSystem.Services.PaymentService;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("CreatePaymentIntent/{reservationId:int}")]
        public async Task<ResponseViewModel<PaymentIntentDTO>> CreatePaymentIntentAsync(int reservationId)
        {
            return await _paymentService.CreatePaymentIntentAsync(reservationId);
        }

        [HttpPost("UpdatePaymentIntent/{reservationId:int}")]
        public async Task<ResponseViewModel<bool>> UpdatePaymentIntentAsync(int reservationId)
        {
            return await _paymentService.UpdatePaymentIntentAsync(reservationId);
        }
    }
}

using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ResponseViewModel<PaymentIntentDTO>> CreatePaymentIntentAsync(int reservationId);
        Task<ResponseViewModel<bool>> UpdatePaymentIntentAsync(int reservationId);
    }
}

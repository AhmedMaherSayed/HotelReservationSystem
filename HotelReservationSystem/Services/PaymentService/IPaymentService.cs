using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.ReservationViewModels;

namespace HotelReservationSystem.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ResponseViewModel<ReservationViewModel>> CreateOrUpdatePaymentIntentAsync(int reservationId);
    }
}

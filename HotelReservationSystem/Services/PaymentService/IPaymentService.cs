using HotelReservationSystem.Data.Entities;

namespace HotelReservationSystem.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Reservation> CreateOrUpdatePaymentIntentAsync(int reservationId);
    }
}

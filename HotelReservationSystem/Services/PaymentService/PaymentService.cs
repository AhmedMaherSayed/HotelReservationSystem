
global using Stripe;
using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
namespace HotelReservationSystem.Services.PaymentService
{
    public class PaymentService(IGenericRepository<Reservation> reservationRepository, IMapper mapper, IConfiguration configuration) : IPaymentService
    {
        public async Task<ResponseViewModel<Reservation>> CreateOrUpdatePaymentIntentAsync(int reservationId)
        {
            StripeConfiguration.ApiKey = configuration.GetRequiredSection("StripeSettings")["SecretKey"];
            // Get price

            var reservation = await reservationRepository.GetByIdAsync(reservationId);
            if (reservation is null)
                return ResponseViewModel<Reservation>.Failure(errorCode: ErrorCode.NotFound);
            throw new Exception();
        }
    }
}

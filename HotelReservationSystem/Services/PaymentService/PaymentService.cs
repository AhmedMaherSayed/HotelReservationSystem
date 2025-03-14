
global using Stripe;
using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.ReservationViewModels;
namespace HotelReservationSystem.Services.PaymentService
{
    public class PaymentService(IGenericRepository<Reservation> reservationRepository, IGenericRepository<ReservationRoom> roomReservationRepo, IMapper mapper, IConfiguration configuration) : IPaymentService
    {
        public async Task<ResponseViewModel<ReservationViewModel1>> CreateOrUpdatePaymentIntentAsync(int reservationId)
        {
            StripeConfiguration.ApiKey = configuration.GetRequiredSection("StripeSettings")["SecretKey"];
            // Get price

            var reservation = await reservationRepository.GetByIdAsync(reservationId);
            if (reservation is null)
                return ResponseViewModel<ReservationViewModel1>.Failure(errorCode: ErrorCode.NotFound);

            if (reservation.TotalPrice <= 0)
                return ResponseViewModel<ReservationViewModel1>.Failure(ErrorCode.BadRequest);

            var amount = (long)(reservation.TotalPrice * 100);

            var service = new PaymentIntentService();
            if(string.IsNullOrWhiteSpace(reservation.PaymentIntentId))
            {
                // Create PaymentIntent
                var createOption = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card"}

                };
                var paymentIntent =  await service.CreateAsync(createOption);

                    reservation.PaymentIntentId = paymentIntent?.Id ?? null;
                    reservation.ClientSecret = paymentIntent?.ClientSecret ?? null;

            }
            else
            {
                // Update
                var updateOptions = new PaymentIntentUpdateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                await service.UpdateAsync(reservation.PaymentIntentId, updateOptions);
            }
            reservationRepository.UpdateInclude(reservation, nameof(reservation.PaymentIntentId), nameof(reservation.ClientSecret));

            var response = mapper.Map<ReservationViewModel1>(reservation);

            return ResponseViewModel<ReservationViewModel1>.Success(response);
        }
    }
}

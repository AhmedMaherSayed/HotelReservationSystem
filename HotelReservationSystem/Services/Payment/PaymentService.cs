
global using Stripe;
using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using Stripe.V2;
namespace HotelReservationSystem.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public IGenericRepository<Data.Entities.Reservation> _reservationRepository;
        public IGenericRepository<Data.Entities.Invoice> _invoiceRepository;
        public IGenericRepository<ReservationRoom> _roomReservationRepo;
        public IMapper _mapper;
        public IConfiguration _configuration;

        public PaymentService(
            IGenericRepository<Data.Entities.Reservation> reservationRepository,
            IGenericRepository<Data.Entities.Invoice> invoiceRepository,
            IGenericRepository<ReservationRoom> roomReservationRepo,
            IMapper mapper,
            IConfiguration configuration)
        {
            _reservationRepository = reservationRepository;
            _invoiceRepository = invoiceRepository;
            _roomReservationRepo = roomReservationRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ResponseViewModel<PaymentIntentDTO>> CreatePaymentIntentAsync(int reservationId)
        {
            StripeConfiguration.ApiKey = _configuration.GetRequiredSection("StripeSettings")["SecretKey"];

            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            if (reservation is null)
                return ResponseViewModel<PaymentIntentDTO>.Failure(errorCode: ErrorCode.NotFound);

            if (reservation.TotalPrice <= 0)
                return ResponseViewModel<PaymentIntentDTO>.Failure(ErrorCode.BadRequest);

            var amount = (long)(reservation.TotalPrice * 100);

            var service = new PaymentIntentService();

            var createOption = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = "USD",
                PaymentMethodTypes = new List<string> {"card"}

            };

            var paymentIntent =  await service.CreateAsync(createOption);

            return ResponseViewModel<PaymentIntentDTO>.Success(_mapper.Map<PaymentIntentDTO>(paymentIntent));
        }

        public async Task<ResponseViewModel<bool>> UpdatePaymentIntentAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);

            if (reservation is null)
            {
                return ResponseViewModel<bool>.Failure(errorCode: ErrorCode.NotFound, "Reservation not found.");
            }
                
            if (reservation.TotalPrice <= 0)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, "Invalid reservation total price.");
            }

            if (reservation.Invoice is null || string.IsNullOrWhiteSpace(reservation.Invoice.PaymentIntentId))
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, "No valid PaymentIntentId found.");
            }

            var amount = (long)(reservation.TotalPrice * 100);

            var service = new PaymentIntentService();

            var updateOptions = new PaymentIntentUpdateOptions
            {
                Amount = amount,
                Currency = "USD",
                PaymentMethodTypes = new List<string> {"card"}
            };

            await service.UpdateAsync(reservation.Invoice.PaymentIntentId, updateOptions);

            return ResponseViewModel<bool>.Success(true);
        }
    }
}

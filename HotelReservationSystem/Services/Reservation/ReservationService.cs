using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.PaymentService;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservation;
using HotelReservationSystem.ViewModels.ReservationRoom;
using Microsoft.EntityFrameworkCore;


namespace HotelReservationSystem.Services.Reservation
{
    public class ReservationService : IReservationService
    {
        public IGenericRepository<Data.Entities.Reservation> _reservationRepository;
        public IGenericRepository<ReservationRoom> _reservationRoomRepo;
        public IGenericRepository<Data.Entities.Invoice> _invoiceRepository;
        public IGenericRepository<Data.Entities.Room> _roomRepository;

        public IPaymentService _paymentService;

        public ReservationService(
            IGenericRepository<Data.Entities.Reservation> reservationRepository,
            IGenericRepository<ReservationRoom> reservationRoomRepo,
            IGenericRepository<Data.Entities.Invoice> invoiceRepository,
            IGenericRepository<Data.Entities.Room> roomRepository,
            IPaymentService paymentService
            )
        {
            _reservationRepository = reservationRepository;
            _reservationRoomRepo = reservationRoomRepo;
            _invoiceRepository = invoiceRepository;
            _roomRepository = roomRepository;
            _paymentService = paymentService;
        }



        public async Task<ResponseViewModel<List<RoomResponseDTO>>> GetAvailableRooms()
        {
            var availableRooms = await _reservationRoomRepo
                .Get(rr => rr.Status == ReservationRoomStatus.Available)
                .Select(rr => rr.Room)
                .GroupBy(r => r.Id)  // Group by Room Id to remove duplicates
                .Select(g => g.FirstOrDefault())
                .ToListAsync();

            var roomResponseDtos = availableRooms
                .Select(r => r.Map<RoomResponseDTO>())
                .ToList();

            return ResponseViewModel<List<RoomResponseDTO>>.Success(roomResponseDtos);
        }



        public async Task<ReservationViewModel?> GetReservationDetails(int ReservationId)
        {
            var reservation = await _reservationRepository
                .Get(x => x.Id == ReservationId)
                .Select(x => new ReservationViewModel
                {
                    ReservationId = ReservationId,
                    CheckInDate = x.CheckInDate,
                    CheckOutDate = x.CheckOutDate,
                    TotalPrice = x.TotalPrice,
                    Status = x.Status,
                    Rooms = x.Rooms.Select(x => new ReservationRoomViewModel
                    {
                        RoomId = x.RoomId,
                        NumberOfNights = x.NumberOfNights,
                        PricePerNight = x.PricePerNight,
                    })
                    .ToList()
                })
                .SingleOrDefaultAsync();

            return reservation;
        }




        public async Task<List<ReservationViewModel>> GetCustomerReservations(int customerId)
        {
            var reservations = await _reservationRepository.Get(r => r.CustomerId == customerId && !r.IsDeleted)
                .Select(r => r.Map<ReservationViewModel>())
                .ToListAsync();

            return reservations;
        }




        // Create a new reservation ensuring that there is no double booking.
        #region is Correct

        //public async Task<Reservation?> CreateReservation(ReservationCreateViewModel model)
        //{
        //    foreach (var roomVm in model.Rooms)
        //    {
        //        var room = await _roomRepository.Get(r => r.Id == roomVm.RoomId).FirstOrDefaultAsync();
        //        if (room == null) return null; 

        //        var overlappingReservations = _reservationRepository.Get(r =>
        //            r.Rooms.Any(rr => rr.RoomId == roomVm.RoomId) &&
        //            !r.IsDeleted &&
        //            (r.CheckInDate < model.CheckOutDate &&
        //            (r.CheckOutDate ?? r.CheckInDate.AddDays(roomVm.NumberOfNights)) > model.CheckInDate)
        //        );

        //        if (overlappingReservations.Any()) return null;
        //    }

        //    var reservation = model.Map<Reservation>();
        //    reservation.Status = ReservationStatus.Pending;

        //    await _reservationRepository.AddAsync(reservation);
        //    return reservation;
        //} 

        #endregion

        public async Task<ResponseViewModel<ReservationViewModel>> CreateReservation(ReservationCreateViewModel model)
        {
            var availableRoomsResponse = await GetAvailableRooms();
            var availableRoomIds = availableRoomsResponse.Data.Select(r => r.Id).ToList();

            foreach (var roomVm in model.Rooms)
            {
                if (!availableRoomIds.Contains(roomVm.RoomId))
                {
                    return ResponseViewModel<ReservationViewModel>
                        .Failure(ErrorCode.RoomAlreadyBooked, $"Room {roomVm.RoomId} is not available for booking");
                }
            }

            var reservation = model.Map<Data.Entities.Reservation>();
            reservation.Status = ReservationStatus.Pending;

            reservation.Rooms = model.Rooms.Select(rvm => new ReservationRoom
            {
                RoomId = rvm.RoomId,
                NumberOfNights = rvm.NumberOfNights,
                PricePerNight = rvm.PricePerNight,
                Status = ReservationRoomStatus.Reserved
            }).ToList();

            await _reservationRepository.AddAsync(reservation);



            var resultViewModel = reservation.Map<ReservationViewModel>();
            return ResponseViewModel<ReservationViewModel>.Success(resultViewModel);
        }


        // NOTE : Update Operation Only Applied On (Pending) Reservations
        #region IS Correct

        //public async Task<bool> EditReservation(ReservationUpdateViewModel model)
        //{
        //    var reservation = await _reservationRepository.Get(r => r.Id == model.ReservationId)
        //                                                   .FirstOrDefaultAsync();
        //    if (reservation == null) return false;

        //    if (reservation.Status != ReservationStatus.Pending) return false;

        //    foreach (var roomVm in model.Rooms)
        //    {
        //        var overlappingReservations = _reservationRepository.Get(r =>
        //            r.Id != reservation.Id &&
        //            r.Rooms.Any(rr => rr.RoomId == roomVm.RoomId) &&
        //            !r.IsDeleted &&
        //            (r.CheckInDate < model.CheckOutDate &&
        //            (r.CheckOutDate ?? r.CheckInDate.AddDays(roomVm.NumberOfNights)) > model.CheckInDate)
        //        );

        //        if (overlappingReservations.Any()) return false;
        //    }

        //    reservation.CheckInDate = model.CheckInDate;
        //    reservation.CheckOutDate = model.CheckOutDate;
        //    reservation.TotalPrice = model.TotalPrice;
        //    reservation.Rooms = model.Rooms.Select(r => new ReservationRoom
        //    {
        //        RoomId = r.RoomId,
        //        NumberOfNights = r.NumberOfNights,
        //        PricePerNight = r.PricePerNight
        //    }).ToList();

        //    _reservationRepository.UpdateInclude(
        //        reservation,
        //        nameof(reservation.CheckInDate),
        //        nameof(reservation.CheckOutDate),
        //        nameof(reservation.TotalPrice),
        //        nameof(reservation.Rooms)
        //    );

        //    return true;
        //} 

        #endregion

        public async Task<ResponseViewModel<ReservationViewModel>> UpdateReservation(int reservationId, ReservationUpdateViewModel model)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            if (reservation == null)
                return ResponseViewModel<ReservationViewModel>
                    .Failure(ErrorCode.ReservationNotFound, "Reservation not found");

            if (reservation.Status != ReservationStatus.Pending)
                return ResponseViewModel<ReservationViewModel>
                    .Failure(ErrorCode.InvalidOperation, "Only pending reservations can be updated");

            var availableRoomsResponse = await GetAvailableRooms();
            var availableRoomIds = availableRoomsResponse.Data.Select(r => r.Id).ToList();

            foreach (var roomVm in model.Rooms)
            {
                if (!availableRoomIds.Contains(roomVm.RoomId))
                {
                    return ResponseViewModel<ReservationViewModel>
                        .Failure(ErrorCode.RoomAlreadyBooked, $"Room {roomVm.RoomId} is not available for booking");
                }
            }

            reservation.CheckInDate = model.CheckInDate;
            reservation.CheckOutDate = model.CheckOutDate;
            reservation.TotalPrice = model.TotalPrice;

            // For simplicity, clear and recreate ReservationRoom entries.
            reservation.Rooms.Clear();
            reservation.Rooms = model.Rooms.Select(rvm => new ReservationRoom
            {
                RoomId = rvm.RoomId,
                NumberOfNights = rvm.NumberOfNights,
                PricePerNight = rvm.PricePerNight,
                Status = ReservationRoomStatus.Reserved
            }).ToList();

            _reservationRepository.UpdateInclude(
                reservation,
                nameof(reservation.CheckInDate),
                nameof(reservation.CheckOutDate),
                nameof(reservation.TotalPrice),
                nameof(reservation.Rooms)
            );

            var updatedViewModel = reservation.Map<ReservationViewModel>();
            return ResponseViewModel<ReservationViewModel>.Success(updatedViewModel);
        }




        // NOTE : Confirmation => Payment Option => Add Invoice
        public async Task<ResponseViewModel<ReservationViewModel>> ConfirmReservation(int ReservationId)
        {
            var reservation = await _reservationRepository
                .GetByIdWithTrackingAsync(ReservationId);

            if (reservation is null)
            {
                return ResponseViewModel<ReservationViewModel>.Failure(ErrorCode.NotFound, "Reservation Not Found.");
            }

            var paymentResponse = await _paymentService.CreatePaymentIntentAsync(ReservationId);

            if (!paymentResponse.IsSucsess)
            {
                return ResponseViewModel<ReservationViewModel>.Failure(paymentResponse.ErrorCode, paymentResponse.Message);
            }

            var invoice = new Data.Entities.Invoice
            {
                ReservationId = reservation.Id,
                Amount = reservation.TotalPrice,
                InvoiceDate = DateTime.UtcNow,
                PaymentIntentId = paymentResponse.Data.PaymentIntentID,
                ClientSecret = paymentResponse.Data.ClientSecret,
                Method = Data.Enums.PaymentMethod.CreditCard,
                Status = PaymentStatus.Pending
            };

            await _invoiceRepository.AddAsync(invoice);

            reservation.Status = ReservationStatus.Confirmed;
            _reservationRepository.UpdateInclude(reservation, nameof(reservation.Status));

            return ResponseViewModel<ReservationViewModel>.Success(reservation.Map<ReservationViewModel>());
        }


        public async Task<ResponseViewModel<string>> CancelReservation(int reservationId)
        {
            var reservation = await _reservationRepository.Get(x => x.Id == reservationId)
                .FirstOrDefaultAsync();

            if (reservation == null)
                return ResponseViewModel<string>.Failure(ErrorCode.ReservationNotFound, "Reservation not found.");

            if (reservation.Status != ReservationStatus.Pending)
                return ResponseViewModel<string>.Failure(ErrorCode.InvalidOperation, "Only pending reservations can be canceled.");

            reservation.Status = ReservationStatus.Cancelled;
            _reservationRepository.UpdateInclude(reservation, nameof(reservation.Status));

            return ResponseViewModel<string>.Success("Reservation canceled successfully.");
        }


        public async Task<ResponseViewModel<string>> DeleteAsync(int id)
        {
            var reservation = await _reservationRepository.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (reservation == null)
                return ResponseViewModel<string>.Failure(ErrorCode.ReservationNotFound, "Reservation not found");

            reservation.IsDeleted = true;
            _reservationRepository.UpdateInclude(reservation, nameof(reservation.IsDeleted));

            return ResponseViewModel<string>.Success("Reservation deleted successfully");
        }

    }
}

using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservation;
using HotelReservationSystem.ViewModels.ReservationRoom;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Invoice = HotelReservationSystem.Data.Entities.Invoice;

namespace HotelReservationSystem.Services
{
    public class ReservationService
    {
        public IGenericRepository<Reservation> _reservationRepository;
        public IGenericRepository<Invoice> _invoiceRepository;
        public IGenericRepository<Room> _roomRepository;

        public ReservationService(IGenericRepository<Reservation> reservationRepository, IGenericRepository<Invoice> invoiceRepository, IGenericRepository<Room> roomRepository)
        { 
            _reservationRepository = reservationRepository; 
            _invoiceRepository = invoiceRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomResponseDTO>> GetAvailableRoomsAsync(RoomSearchDTO roomSearch)
        {
            var availableRooms = await _roomRepository
                .Get(r => r.Status == RoomStatus.Available && r.Type == roomSearch.RoomType)
                .Select(r => r.Map<RoomResponseDTO>())
                .ToListAsync();

            return availableRooms;
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
        public async Task<Reservation?> CreateReservation(ReservationCreateViewModel model)
        {
            foreach (var roomVm in model.Rooms)
            {
                var room = await _roomRepository.Get(r => r.Id == roomVm.RoomId).FirstOrDefaultAsync();
                if (room == null) return null; 

                var overlappingReservations = _reservationRepository.Get(r =>
                    r.Rooms.Any(rr => rr.RoomId == roomVm.RoomId) &&
                    !r.IsDeleted &&
                    (r.CheckInDate < model.CheckOutDate &&
                    (r.CheckOutDate ?? r.CheckInDate.AddDays(roomVm.NumberOfNights)) > model.CheckInDate)
                );

                if (overlappingReservations.Any()) return null;
            }

            var reservation = model.Map<Reservation>();
            reservation.Status = ReservationStatus.Pending;

            await _reservationRepository.AddAsync(reservation);
            return reservation;
        }





        // NOTE : Update Operation Only Applied On (Pending) Reservations
        public async Task<bool> EditReservation(ReservationUpdateViewModel model)
        {
            var reservation = await _reservationRepository.Get(r => r.Id == model.ReservationId)
                                                           .FirstOrDefaultAsync();
            if (reservation == null) return false; 

            if (reservation.Status != ReservationStatus.Pending) return false; 

            foreach (var roomVm in model.Rooms)
            {
                var overlappingReservations = _reservationRepository.Get(r =>
                    r.Id != reservation.Id &&
                    r.Rooms.Any(rr => rr.RoomId == roomVm.RoomId) &&
                    !r.IsDeleted &&
                    (r.CheckInDate < model.CheckOutDate &&
                    (r.CheckOutDate ?? r.CheckInDate.AddDays(roomVm.NumberOfNights)) > model.CheckInDate)
                );

                if (overlappingReservations.Any()) return false; 
            }

            reservation.CheckInDate = model.CheckInDate;
            reservation.CheckOutDate = model.CheckOutDate;
            reservation.TotalPrice = model.TotalPrice;
            reservation.Rooms = model.Rooms.Select(r => new ReservationRoom
            {
                RoomId = r.RoomId,
                NumberOfNights = r.NumberOfNights,
                PricePerNight = r.PricePerNight
            }).ToList();

            _reservationRepository.UpdateInclude(
                reservation,
                nameof(reservation.CheckInDate),
                nameof(reservation.CheckOutDate),
                nameof(reservation.TotalPrice),
                nameof(reservation.Rooms)
            );

            return true;
        }


      



        // NOTE : Confirmation => Payment Option => Add Invoice
        public async Task<ReservationViewModel> ConfirmReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (reservation == null) return false; 

            reservation.IsDeleted = true;
            _reservationRepository.UpdateInclude(reservation, nameof(reservation.IsDeleted));
            return true;
        }


        public async Task<bool> CancelReservation(int reservationId)
        {
            var reservation = await _reservationRepository.Get(x => x.Id == reservationId)
                                                          .FirstOrDefaultAsync();

            if (reservation == null) return false; 

            if (reservation.Status != ReservationStatus.Pending) return false; 

            reservation.Status = ReservationStatus.Cancelled;
            _reservationRepository.UpdateInclude(reservation, nameof(reservation.Status));
            return true;
        }



    }
}

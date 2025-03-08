using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservation;
using HotelReservationSystem.ViewModels.ReservationRoom;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ReservationViewModel>> GetCustomerReservations(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReservationViewModel> AddReservation(ReservationCreateViewModel reservationCreate)
        {
            throw new NotImplementedException();
        }

        // NOTE : Update Operation Only Applied On (Pending) Reservations
        public async Task<ReservationViewModel> UpdateReservation(ReservationUpdateViewModel reservationUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }

        // NOTE : Confirmation => Payment Option => Add Invoice
        public async Task<ReservationViewModel> ConfirmReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CancelReservation(int ReservationId)
        {
            throw new NotImplementedException();
        }
    }
}

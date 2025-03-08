using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels.Reservation;

namespace HotelReservationSystem.Services
{
    public class ReservationService
    {
        public IGenericRepository<Reservation> _reservationRepository;
        public IGenericRepository<Invoice> _invoiceRepository;

        public ReservationService(IGenericRepository<Reservation> reservationRepository, IGenericRepository<Invoice> invoiceRepository)
        { 
            _reservationRepository = reservationRepository; 
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ReservationViewModel> GetReservationDetails(int ReservationId)
        {
            throw new NotImplementedException();
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

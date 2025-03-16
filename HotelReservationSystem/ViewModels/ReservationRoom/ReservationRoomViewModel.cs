using HotelReservationSystem.Data.Entities;

namespace HotelReservationSystem.ViewModels.ReservationRoom
{
    public class ReservationRoomViewModel
    {
        public int RoomId { get; set; }
        public int NumberOfNights { get; set; }
        public decimal PricePerNight { get; set; }
    }
}

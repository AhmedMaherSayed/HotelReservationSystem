using HotelReservationSystem.ViewModels.ReservationRoom;

namespace HotelReservationSystem.ViewModels.Reservation
{
    public class ReservationUpdateViewModel
    {
        public int ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }

        public IEnumerable<ReservationRoomViewModel> Rooms { get; set; }
    }
}

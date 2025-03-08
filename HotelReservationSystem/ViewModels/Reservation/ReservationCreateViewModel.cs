using HotelReservationSystem.ViewModels.ReservationRoom;

namespace HotelReservationSystem.ViewModels.Reservation
{
    public class ReservationCreateViewModel
    {
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }

        public IEnumerable<ReservationRoomViewModel> Rooms { get; set; }
    }
}

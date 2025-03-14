using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        
        public RoomType RoomType { get; set; }
        public decimal CurrentPricePerNight { get; set; }
        public RoomStatus Status { get; set; }
        public List<RoomFacilityViewModel> Facilities { get; set; }
    }
}

using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.DTOs.RoomDTOs
{
    public class RoomSearchDTO
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public RoomType RoomType { get; set; }
    }
}

using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.DTOs.RoomDTOs
{
    public class UpdateRoomDTO
    {
        //public int EmployeeId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal CurrentPricePerNight { get; set; }
        public RoomStatus Status { get; set; }
    }
}

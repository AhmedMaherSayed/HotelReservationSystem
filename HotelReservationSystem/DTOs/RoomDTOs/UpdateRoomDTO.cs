using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.DTOs.RoomDTOs
{
    public class UpdateRoomDTO
    {
        //public int EmployeeId { get; set; }
        public RoomType Type { get; set; }
        public decimal CurrentPricePerNight { get; set; }
        public RoomStatus Status { get; set; }
    }
}

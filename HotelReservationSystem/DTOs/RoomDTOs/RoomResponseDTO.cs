using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.DTOs.RoomDTOs
{
    public class RoomResponseDTO
    {
        public int Id { get; set; }
        //public int EmployeeId { get; set; }
        public RoomType Type { get; set; }
        public decimal CurrentPricePerNight { get; set; }
        public RoomStatus Status { get; set; }
    }
}

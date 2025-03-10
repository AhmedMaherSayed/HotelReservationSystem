using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.DTOs.RoomDTOs
{
    public class CreateRoomDTO
    {
        //public int EmployeeId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal CurrentPricePerNight { get; set; }
        public RoomStatus Status { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<int>? Facilities { get; set; }
    }
}

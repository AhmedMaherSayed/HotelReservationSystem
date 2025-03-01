using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Data.Entities
{
    public class Room : BaseModel
    {
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        public RoomType Type { get; set; }
        public decimal CurrentPricePerNight { get; set; }
        public RoomStatus Status { get; set; }

        public ICollection<ReservationRoom> Reservations { get; set; }
        public ICollection<RoomFacility> Facilities { get; set; }
        public ICollection<RoomOffer> Offers { get; set; }
    }
}

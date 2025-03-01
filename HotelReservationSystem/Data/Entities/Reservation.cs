using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Data.Entities
{
    public class Reservation : BaseModel
    {
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }

        public ICollection<ReservationRoom> Rooms { get; set; }
        public Feedback? Feedback { get; set; }
        public Invoice? Invoice { get; set; }
    }
}

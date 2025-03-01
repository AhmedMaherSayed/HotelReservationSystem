namespace HotelReservationSystem.Data.Entities
{
    public class ReservationRoom : BaseModel
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int NumberOfNights { get; set; }
        public decimal PricePerNight { get; set; }
    }
}

using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Data.Entities
{
    public class Invoice : BaseModel
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
    }
}

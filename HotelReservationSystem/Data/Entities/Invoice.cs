using HotelReservationSystem.Data.Enums;

namespace HotelReservationSystem.Data.Entities
{
    public class Invoice : BaseModel
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Enums.PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
    }
}

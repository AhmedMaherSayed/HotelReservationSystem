using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Data.Entities
{
    public class Feedback : BaseModel
    {
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        [Range(0, 10)]
        public int Rate { get; set; }
        public string? Comment { get; set; }
    }
}

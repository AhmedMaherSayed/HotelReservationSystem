using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.DTOs.FeedBackDTOs
{
    public class DisplayFeedbackDto
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }
        [Range(0, 10)]
        public int Rate { get; set; }
        public string? Comment { get; set; }
    }
}

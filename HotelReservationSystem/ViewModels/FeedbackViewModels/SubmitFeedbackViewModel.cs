using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModels.FeedbackViewModels
{
    public class SubmitFeedbackViewModel
    {
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }
        [Range(0, 10)]
        public int Rate { get; set; }
        public string? Comment { get; set; }
    }
}

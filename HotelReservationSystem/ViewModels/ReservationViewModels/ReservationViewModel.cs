namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationViewModel1
    {
        public int ResrvationID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? PaymentIntentID { get; set; }
        public string? ClientSecret { get; set; }
        public ICollection<ReservationRoomViewModel> Rooms { get; set; }    
    }
}

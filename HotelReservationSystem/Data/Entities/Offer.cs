namespace HotelReservationSystem.Data.Entities
{
    public class Offer : BaseModel
    {
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }

        public ICollection<RoomOffer> Rooms { get; set; }
    }
}

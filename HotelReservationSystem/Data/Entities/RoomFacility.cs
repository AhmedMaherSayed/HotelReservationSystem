namespace HotelReservationSystem.Data.Entities
{
    public class RoomFacility : BaseModel
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        public int? FacilityCount { get; set; }
        public decimal? FacilityPrice { get; set; }
    }
}

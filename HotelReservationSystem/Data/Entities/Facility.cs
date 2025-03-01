namespace HotelReservationSystem.Data.Entities
{
    public class Facility : BaseModel
    {
        public string Name { get; set; }

        public ICollection<RoomFacility> Rooms { get; set; }
    }
}

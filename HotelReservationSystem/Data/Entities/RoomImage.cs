namespace HotelReservationSystem.Data.Entities
{
    public class RoomImage : BaseModel
    {
        public string ImageURL { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}

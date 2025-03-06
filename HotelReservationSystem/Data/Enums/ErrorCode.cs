namespace HotelReservationSystem.Data.Enums
{
    public enum ErrorCode
    {
        None=0,
        RoomNotFound=100,
        InvalidRoomRequest=101,

        Ok = 200,

        Unauthorized = 401,
        Forbidden = 403,
        BadRequest = 400,
        NotFound = 404,


    }
}

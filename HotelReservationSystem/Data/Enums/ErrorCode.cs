namespace HotelReservationSystem.Data.Enums
{
    public enum ErrorCode
    {
        None=0,
        RoomNotFound=100,
        InvalidRoomRequest=101,
        RoomNotAvailable=102,
        ReservationNotFound=103,
        InvalidOperation=104,
        PaymentError=105,

        Ok = 200,

        Unauthorized = 401,
        Forbidden = 403,
        BadRequest = 400,
        NotFound = 404,


    }
}

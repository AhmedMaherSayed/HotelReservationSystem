using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.RoomDTOs;

namespace HotelReservationSystem.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Room,CreateRoomDTO>();
            CreateMap<Room, RoomResponseDTO>();
            CreateMap<Room, UpdateRoomDTO>();
        }
    }
}

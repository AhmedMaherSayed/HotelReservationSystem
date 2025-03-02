using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.ViewModels.AuthenticationViewModels;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationSystem.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Room
            CreateMap<Room, CreateRoomDTO>();
            CreateMap<Room, RoomResponseDTO>();
            CreateMap<Room, UpdateRoomDTO>();
            #endregion

            #region Authentication
            CreateMap<RegisterViewModel, IdentityUser>();
            #endregion
        }
    }
}

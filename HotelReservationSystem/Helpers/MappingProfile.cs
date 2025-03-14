using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.ViewModels.AuthenticationViewModels;
using HotelReservationSystem.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationSystem.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Room,CreateRoomDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Type));
            CreateMap<Room, RoomResponseDTO>()
                .ForMember(dest=>dest.RoomType,opt=>opt.MapFrom(src=>src.Type));
            CreateMap<Room, UpdateRoomDTO>()
                .ForMember(dest=>dest.RoomType,opt=>opt.MapFrom(src=>src.Type));
            CreateMap<CreateRoomDTO, Room>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RoomType));

            CreateMap<UpdateRoomDTO, Room>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RoomType));
            ;

            #region Authentication
            CreateMap<RegisterViewModel, IdentityUser>();
            #endregion

            #region Payment
            CreateMap<Reservation, ReservationViewModel1>();
            #endregion
        }
    }
}

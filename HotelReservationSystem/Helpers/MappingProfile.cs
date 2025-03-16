using AutoMapper;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.FeedBackDTOs;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.ViewModels.AuthenticationViewModels;
using HotelReservationSystem.ViewModels.FeedbackViewModels;
using Microsoft.AspNetCore.Identity;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Room
            CreateMap<Room,CreateRoomDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Type));
            CreateMap<Room, RoomResponseDTO>()
                .ForMember(dest=>dest.RoomType,opt=>opt.MapFrom(src=>src.Type));
            CreateMap<Room, UpdateRoomDTO>()
                .ForMember(dest=>dest.RoomType,opt=>opt.MapFrom(src=>src.Type));
            CreateMap<Room, RoomViewModel>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Type));
            CreateMap<CreateRoomDTO, Room>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RoomType));

            CreateMap<UpdateRoomDTO, Room>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RoomType));
            #endregion

            #region Authentication
            CreateMap<RegisterViewModel, IdentityUser>();
            #endregion

            #region Payment
            CreateMap<PaymentIntent, PaymentIntentDTO>();
            #endregion

            #region Feedback
            CreateMap<SubmitFeedbackViewModel, SubmitFeedbackDto>();
            CreateMap<SubmitFeedbackDto, Feedback>();
            CreateMap<Feedback, DisplayFeedbackDto>();
            CreateMap<DisplayFeedbackDto, DisplayFeebackViewModel>();
            CreateMap<Feedback, DisplayFeebackViewModel>();
            #endregion
        }
    }
}

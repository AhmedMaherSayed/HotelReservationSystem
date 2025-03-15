using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.FeedBackDTOs;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.FeedbackViewModels;

namespace HotelReservationSystem.Services.FeedbackServ
{
    public interface IFeedbackService
    {
        public Task<ResponseViewModel<bool>> SubmitFeedback(SubmitFeedbackDto dto);
        public Task<ResponseViewModel<DisplayFeebackViewModel>> ViewFeedBackAsync(int reservationID);
    }
}

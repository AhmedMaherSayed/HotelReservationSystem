using AutoMapper;
using HotelReservationSystem.Data;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.FeedBackDTOs;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.FeedbackViewModels;

namespace HotelReservationSystem.Services.FeedbackServ
{
    public class FeedBackService(GenericRepository<Feedback> repository, IMapper mapper) : IFeedbackService
    {
        public async Task<ResponseViewModel<bool>> SubmitFeedback(SubmitFeedbackDto dto)
        {
            var feedbackEntity = mapper.Map<Feedback>(dto);

            await repository.AddAsync(feedbackEntity);
            return ResponseViewModel<bool>.Success(true);
        }

        public async Task<ResponseViewModel<DisplayFeebackViewModel>> ViewFeedBackAsync(int reservationID)
        {
            var entity = repository.Get(f => f.ReservationId == reservationID);

            if (entity is null)
                return ResponseViewModel<DisplayFeebackViewModel>.Failure(ErrorCode.NotFound);
            var viewModel = mapper.Map<DisplayFeebackViewModel>(entity);

            return ResponseViewModel<DisplayFeebackViewModel>.Success(viewModel);
        }
    }
}

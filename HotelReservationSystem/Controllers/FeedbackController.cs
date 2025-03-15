using AutoMapper;
using HotelReservationSystem.DTOs.FeedBackDTOs;
using HotelReservationSystem.Services.FeedbackServ;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.FeedbackViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController(IFeedbackService service, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ResponseViewModel<bool>> SubmitFeedbackDto(SubmitFeedbackViewModel viewModel)
        {
            var dto = mapper.Map<SubmitFeedbackDto>(viewModel);

            var result = await service.SubmitFeedback(dto);
            return result;
        }

        [HttpGet]
        public async Task<ResponseViewModel<DisplayFeebackViewModel>> DisplayFeedback(int reservationID)
        {
            var result = await service.ViewFeedBackAsync(reservationID);
            return result;
        }
    }
}

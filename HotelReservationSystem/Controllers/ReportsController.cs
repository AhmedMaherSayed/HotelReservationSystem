using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.Report;
using HotelReservationSystem.ViewModels.ReportViewModels;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportService _reportService;
        private readonly IMapper _mapper;


        public ReportsController(IReportService reportService , IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

    


        [HttpGet("booking")]
        public async Task<IActionResult> GetBookingReport([FromQuery] DateTime startDate,[FromQuery] DateTime endDate,[FromQuery] int pageIndex = 1,[FromQuery] int pageSize = 10)
        {
            var reportDtoResponse = await _reportService.GetBookingReportAsync(startDate, endDate, pageIndex, pageSize);
            if (!reportDtoResponse.IsSucsess)
                return BadRequest(reportDtoResponse);

            var reportViewModel = _mapper.Map<BookingReportViewModel>(reportDtoResponse.Data);
            return Ok(ResponseViewModel<BookingReportViewModel>.Success(reportViewModel));
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport([FromQuery] DateTime startDate,[FromQuery] DateTime endDate,[FromQuery] int pageIndex = 1,[FromQuery] int pageSize = 10)
        {
            var reportDtoResponse = await _reportService.GetRevenueReportAsync(startDate, endDate, pageIndex, pageSize);
            if (!reportDtoResponse.IsSucsess)
                return BadRequest(reportDtoResponse);

            var reportViewModel = _mapper.Map<RevenueReportViewModel>(reportDtoResponse.Data);
            return Ok(ResponseViewModel<RevenueReportViewModel>.Success(reportViewModel));
        }


    }
}

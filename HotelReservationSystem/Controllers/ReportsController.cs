using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.Report;
using HotelReservationSystem.ViewModels.ReportViewModels;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("booking")]
        public async Task<IActionResult> GetBookingReport([FromQuery] DateTime startDate,[FromQuery] DateTime endDate)
        {
            var reportDtoResponse = await _reportService.GetBookingReportAsync(startDate, endDate);
            if (!reportDtoResponse.IsSucsess)
                return BadRequest(reportDtoResponse);

            var reportViewModel = reportDtoResponse.Data.Map<BookingReportViewModel>();

            return Ok(ResponseViewModel<BookingReportViewModel>.Success(reportViewModel));
        }


        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport([FromQuery] DateTime startDate,[FromQuery] DateTime endDate)
        {
            var reportDtoResponse = await _reportService.GetRevenueReportAsync(startDate, endDate);
            if (!reportDtoResponse.IsSucsess)
                return BadRequest(reportDtoResponse);

            var reportViewModel = reportDtoResponse.Data.Map<RevenueReportViewModel>();

            return Ok(ResponseViewModel<RevenueReportViewModel>.Success(reportViewModel));
        }


    }
}

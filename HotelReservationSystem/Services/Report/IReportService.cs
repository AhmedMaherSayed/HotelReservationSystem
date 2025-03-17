using HotelReservationSystem.DTOs.ReportDto;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Services.Report
{
    public interface IReportService
    {
        Task<ResponseViewModel<BookingReportDTO>> GetBookingReportAsync(DateTime startDate, DateTime endDate);
        Task<ResponseViewModel<RevenueReportDTO>> GetRevenueReportAsync(DateTime startDate, DateTime endDate);

    }
}

using HotelReservationSystem.Helpers;

namespace HotelReservationSystem.DTOs.ReportDto
{
    public class RevenueReportDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public Pagination<RevenueTrendDTO> RevenueTrends { get; set; }
    }
}

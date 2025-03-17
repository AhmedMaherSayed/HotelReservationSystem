namespace HotelReservationSystem.ViewModels.ReportViewModels
{
    public class RevenueReportViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<RevenueTrendViewModel> RevenueTrends { get; set; }
    }
}

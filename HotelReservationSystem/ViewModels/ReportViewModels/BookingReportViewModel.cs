namespace HotelReservationSystem.ViewModels.ReportViewModels
{
    public class BookingReportViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalReservations { get; set; }
        public List<OccupancyTrendViewModel> OccupancyTrends { get; set; }

    }
}

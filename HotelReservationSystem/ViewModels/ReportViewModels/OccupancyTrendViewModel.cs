namespace HotelReservationSystem.ViewModels.ReportViewModels
{
    public class OccupancyTrendViewModel
    {
        public DateTime Date { get; set; }
        public int BookedRooms { get; set; }
        public int TotalRooms { get; set; }
        public double OccupancyPercentage { get; set; }
    }
}

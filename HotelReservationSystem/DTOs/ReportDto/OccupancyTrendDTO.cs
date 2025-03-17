namespace HotelReservationSystem.DTOs.ReportDto
{
    public class OccupancyTrendDTO
    {
        public DateTime Date { get; set; }
        public int BookedRooms { get; set; }
        public int TotalRooms { get; set; }
        public double OccupancyPercentage => TotalRooms > 0 ? (double)BookedRooms / TotalRooms * 100 : 0;

    }
}

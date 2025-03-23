using HotelReservationSystem.Helpers;

namespace HotelReservationSystem.DTOs.ReportDto
{
    public class BookingReportDTO
    {


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalReservations { get; set; }
        public Pagination<OccupancyTrendDTO> OccupancyTrends { get; set; }

    }
}

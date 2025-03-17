using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.ReportDto;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Services.Report
{
    public class ReportService : IReportService
    {


        private readonly IGenericRepository<Data.Entities.Reservation> _reservationRepository;
        private readonly IGenericRepository<Data.Entities.Room> _roomRepository;

        public ReportService(IGenericRepository<Data.Entities.Reservation> reservationRepository,
                             IGenericRepository<Data.Entities.Room> roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }


        public async Task<ResponseViewModel<BookingReportDTO>> GetBookingReportAsync(DateTime startDate,DateTime endDate)
        {
            var reservations = await _reservationRepository
                .Get(r => !r.IsDeleted && r.CheckInDate >= startDate && r.CheckInDate <= endDate)
                .ToListAsync();

            int totalReservations = reservations.Count;
            int totalRooms = await _roomRepository.GetAll().CountAsync();

            var occupancyTrends = new List<OccupancyTrendDTO>();
            for (var day = startDate.Date; day <= endDate.Date; day = day.AddDays(1))
            {
                int bookedRooms = reservations.Count(r =>
                    r.CheckInDate.Date <= day &&
                    (r.CheckOutDate == null || r.CheckOutDate.Value.Date > day));

                occupancyTrends.Add(new OccupancyTrendDTO
                {
                    Date = day,
                    BookedRooms = bookedRooms,
                    TotalRooms = totalRooms
                });
            }

            var reportDto = new BookingReportDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalReservations = totalReservations,
                OccupancyTrends = occupancyTrends
            };

            return ResponseViewModel<BookingReportDTO>.Success(reportDto);
        }


        public async Task<ResponseViewModel<RevenueReportDTO>> GetRevenueReportAsync(DateTime startDate,DateTime endDate)
        {
            var reservations = await _reservationRepository
                .Get(r => !r.IsDeleted && r.CheckInDate >= startDate && r.CheckInDate <= endDate)
                .ToListAsync();

            decimal totalRevenue = reservations.Sum(r => r.TotalPrice);

            var revenueTrends = new List<RevenueTrendDTO>();
            for (var day = startDate.Date; day <= endDate.Date; day = day.AddDays(1))
            {
                decimal dailyRevenue = reservations
                    .Where(r => r.CheckInDate.Date == day)
                    .Sum(r => r.TotalPrice);

                revenueTrends.Add(new RevenueTrendDTO
                {
                    Date = day,
                    DailyRevenue = dailyRevenue
                });
            }

            var reportDto = new RevenueReportDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalRevenue = totalRevenue,
                RevenueTrends = revenueTrends
            };

            return ResponseViewModel<RevenueReportDTO>.Success(reportDto);
        }






    }
}

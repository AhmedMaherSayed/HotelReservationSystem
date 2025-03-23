using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.DTOs.ReportDto;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Specifications;
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

        

        public async Task<ResponseViewModel<BookingReportDTO>> GetBookingReportAsync(DateTime startDate, DateTime endDate, int pageIndex, int pageSize)
        {
            var spec = new ReservationSpecification(startDate, endDate, (pageIndex - 1) * pageSize, pageSize);
            var reservations = await SpecificationEvalutor<Data.Entities.Reservation>.GetQuery(_reservationRepository.GetAll(), spec).ToListAsync();

            int totalReservations = await _reservationRepository.Get(r => !r.IsDeleted && r.CheckInDate >= startDate && r.CheckInDate <= endDate).CountAsync();
            int totalRooms = await _roomRepository.GetAll().CountAsync();

            var occupancyTrends = new List<OccupancyTrendDTO>();
            foreach (var reservation in reservations)
            {
                occupancyTrends.Add(new OccupancyTrendDTO
                {
                    Date = reservation.CheckInDate.Date,
                    BookedRooms = reservations.Count(r => r.CheckInDate.Date <= reservation.CheckInDate.Date &&
                                                         (r.CheckOutDate == null || r.CheckOutDate.Value.Date > reservation.CheckInDate.Date)),
                    TotalRooms = totalRooms
                });
            }

            var paginatedOccupancyTrends = new Pagination<OccupancyTrendDTO>(pageIndex, pageSize, occupancyTrends, totalReservations);

            var reportDto = new BookingReportDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalReservations = totalReservations,
                OccupancyTrends = paginatedOccupancyTrends
            };

            return ResponseViewModel<BookingReportDTO>.Success(reportDto);
        }



        public async Task<ResponseViewModel<RevenueReportDTO>> GetRevenueReportAsync(DateTime startDate, DateTime endDate, int pageIndex, int pageSize)
        {
            var spec = new ReservationSpecification(startDate, endDate, (pageIndex - 1) * pageSize, pageSize);
            var reservations = await SpecificationEvalutor<Data.Entities.Reservation>.GetQuery(_reservationRepository.GetAll(), spec).ToListAsync();

            decimal totalRevenue = await _reservationRepository.Get(r => !r.IsDeleted && r.CheckInDate >= startDate && r.CheckInDate <= endDate).SumAsync(r => r.TotalPrice);

            var revenueTrends = new List<RevenueTrendDTO>();
            foreach (var reservation in reservations)
            {
                revenueTrends.Add(new RevenueTrendDTO
                {
                    Date = reservation.CheckInDate.Date,
                    DailyRevenue = reservations.Where(r => r.CheckInDate.Date == reservation.CheckInDate.Date).Sum(r => r.TotalPrice)
                });
            }

            var paginatedRevenueTrends = new Pagination<RevenueTrendDTO>(pageIndex, pageSize, revenueTrends, reservations.Count);

            var reportDto = new RevenueReportDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalRevenue = totalRevenue,
                RevenueTrends = paginatedRevenueTrends
            };

            return ResponseViewModel<RevenueReportDTO>.Success(reportDto);
        }





    }
}

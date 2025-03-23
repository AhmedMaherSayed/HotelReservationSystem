using AutoMapper;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.FeedbackServ;
using HotelReservationSystem.Services.PaymentService;
using HotelReservationSystem.Services.Report;
using HotelReservationSystem.Services.Reservation;
using HotelReservationSystem.Services.Room;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IFeedbackService, FeedBackService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReportService, ReportService>();

        }
    }
}

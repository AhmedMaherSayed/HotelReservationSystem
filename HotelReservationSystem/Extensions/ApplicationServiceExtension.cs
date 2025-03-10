using AutoMapper;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.PaymentService;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPaymentService, PaymentService>();

        }
    }
}

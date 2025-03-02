using AutoMapper;
using HotelReservationSystem.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}

using HotelReservationSystem.Helpers;

namespace HotelReservationSystem.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}

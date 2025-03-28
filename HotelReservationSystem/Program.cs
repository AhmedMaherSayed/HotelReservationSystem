
using AutoMapper;
using HotelReservationSystem.Data;
using HotelReservationSystem.Extensions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Middelwares;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.PaymentService;
using HotelReservationSystem.Services.Report;
using HotelReservationSystem.Services.Reservation;
using HotelReservationSystem.Services.Room;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();



            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection"))
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging()
            );

            builder.Services.AddServices();

            var app = builder.Build();
          

            AutoMapperHelper.Mapper = app.Services.GetService<IMapper>();

            //app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            //app.UseMiddleware<TransactionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

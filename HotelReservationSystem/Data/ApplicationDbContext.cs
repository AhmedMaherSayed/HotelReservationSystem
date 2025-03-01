using HotelReservationSystem.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HotelReservationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationRoom> ReservationRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomOffer> RoomOffers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

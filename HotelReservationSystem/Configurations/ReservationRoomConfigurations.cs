using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class ReservationRoomConfigurations : BaseModelConfigurations<ReservationRoom>
    {
        public override void Configure(EntityTypeBuilder<ReservationRoom> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.PricePerNight)
                .HasPrecision(10, 2);

            builder.HasOne(x => x.Reservation)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

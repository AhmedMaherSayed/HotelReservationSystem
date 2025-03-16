using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class RoomConfigurations : BaseModelConfigurations<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CurrentPricePerNight)
                .HasPrecision(10, 2);

            //builder.Property(x => x.Status)
            //    .HasDefaultValue(RoomStatus.Available);

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId);

            builder.HasMany(x => x.Facilities)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId);

            builder.HasMany(x => x.Offers)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId);
        }
    }
}

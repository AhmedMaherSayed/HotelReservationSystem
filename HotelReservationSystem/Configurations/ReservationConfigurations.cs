using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class ReservationConfigurations : BaseModelConfigurations<Reservation>
    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TotalPrice)
                .HasPrecision(10, 2);

            builder.Property(x => x.Status)
                .HasDefaultValue(ReservationStatus.Pending);

            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.Reservation)
                .HasForeignKey(x => x.ReservationId);
        }
    }
}

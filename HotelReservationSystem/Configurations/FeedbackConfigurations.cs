using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class FeedbackConfigurations : BaseModelConfigurations<Feedback>
    {
        public override void Configure(EntityTypeBuilder<Feedback> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Comment)
                .HasMaxLength(50);

            builder.HasOne(x => x.Reservation)
                .WithOne(x => x.Feedback)
                .HasForeignKey<Feedback>(x => x.ReservationId);
        }
    }
}

using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class RoomFacilityConfigurations : BaseModelConfigurations<RoomFacility>
    {
        public override void Configure(EntityTypeBuilder<RoomFacility> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Facilities)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Facility)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.FacilityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

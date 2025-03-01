using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class FacilityConfigurations : BaseModelConfigurations<Facility>
    {
        public override void Configure(EntityTypeBuilder<Facility> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.Facility)
                .HasForeignKey(x => x.FacilityId);
        }
    }
}

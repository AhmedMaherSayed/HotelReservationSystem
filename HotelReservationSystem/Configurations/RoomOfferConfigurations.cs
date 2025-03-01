using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class RoomOfferConfigurations : BaseModelConfigurations<RoomOffer>
    {
        public override void Configure(EntityTypeBuilder<RoomOffer> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Offer)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.OfferId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

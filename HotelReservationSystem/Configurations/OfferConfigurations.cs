using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class OfferConfigurations : BaseModelConfigurations<Offer>
    {
        public override void Configure(EntityTypeBuilder<Offer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DiscountPercentage)
                .HasPrecision(3, 2);

            builder.Property(x => x.Description)
                .HasMaxLength(100);

            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.Offer)
                .HasForeignKey(x => x.OfferId);
        }
    }
}

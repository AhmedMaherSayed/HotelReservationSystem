using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Configurations
{
    public class InvoiceConfigurations : BaseModelConfigurations<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Amount)
                .HasPrecision(10, 2);

            builder.HasOne(x => x.Reservation)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(x => x.ReservationId);
        }
    }
}

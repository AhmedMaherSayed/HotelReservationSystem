using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using invoiceEntity = HotelReservationSystem.Data.Entities.Invoice;
namespace HotelReservationSystem.Configurations
{
    public class InvoiceConfigurations : BaseModelConfigurations<invoiceEntity>
    {
        public override void Configure(EntityTypeBuilder<invoiceEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Amount)
                .HasPrecision(10, 2);

            builder.HasOne(x => x.Reservation)
                .WithOne(x => x.Invoice)
                .HasForeignKey<invoiceEntity>(x => x.ReservationId);
        }
    }
}

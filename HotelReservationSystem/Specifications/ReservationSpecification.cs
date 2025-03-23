using HotelReservationSystem.Data.Entities;

namespace HotelReservationSystem.Specifications
{
    public class ReservationSpecification:BaseSpecification<Reservation>
    {

        public ReservationSpecification(DateTime startDate, DateTime endDate, int skip, int take)
        : base(r => !r.IsDeleted && r.CheckInDate >= startDate && r.CheckInDate <= endDate)
        {
            ApplyPagination(skip, take);
        }

    }
}

using HotelReservationSystem.Data.Entities;
using System.Linq.Expressions;

namespace HotelReservationSystem.Specifications
{
    public interface ISpecification<T> where T :BaseModel
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; }


    }
}

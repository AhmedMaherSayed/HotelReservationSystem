using HotelReservationSystem.Data.Entities;
using System.Linq.Expressions;

namespace HotelReservationSystem.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public int Take { get ; set; }
        public int Skip { get ; set ; }
        public bool IsPaginationEnabled { get ; set ; }

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;

        }
        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}

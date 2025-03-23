using HotelReservationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Specifications
{
    public static class SpecificationEvalutor<T> where T :BaseModel
    {

        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecification<T> Spec)
        {
            var Query = InputQuery;
            if (Spec.Criteria is not null)
            {
                Query = Query.Where(Spec.Criteria);
            }
        
            if (Spec.IsPaginationEnabled)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }

            Query = Spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            return Query;
        }

    }
}

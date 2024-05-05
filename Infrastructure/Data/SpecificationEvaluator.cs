using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Core.Specification
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Predicate is not null)
            {
                query = query.Where(spec.Predicate);
            }

            query = spec.Includes.Aggregate(query, (query, includeExpression) => query.Include(includeExpression));

            return query;
        }
    }
}

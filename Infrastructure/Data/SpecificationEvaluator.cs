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

            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDesc is not null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            query = spec.Includes.Aggregate(query, (query, includeExpression) => query.Include(includeExpression));

            return query;
        }
    }
}

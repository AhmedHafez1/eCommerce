using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Predicate { get; set; }
        List<Expression<Func<T, BaseEntity>>> Includes { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool PaginationEnabled { get; }
    }
}

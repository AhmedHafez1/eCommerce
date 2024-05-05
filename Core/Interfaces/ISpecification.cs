using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Predicate { get; set; }
        List<Expression<Func<T, BaseEntity>>> Includes { get; }
    }
}

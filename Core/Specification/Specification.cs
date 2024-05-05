using Core.Entities;
using Core.Interfaces;
using System.Linq.Expressions;

namespace Core.Specification
{
    public abstract class Specification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>>? Predicate { get; set; }
        public List<Expression<Func<T, BaseEntity>>> Includes { get; }
            = new List<Expression<Func<T, BaseEntity>>>();

        public void AddInclude(Expression<Func<T, BaseEntity>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}

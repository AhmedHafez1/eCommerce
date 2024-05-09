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

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDesc { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool PaginationEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, BaseEntity>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void SetOrderBy(Expression<Func<T, object>>? OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        protected void SetOrderByDesc(Expression<Func<T, object>>? OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }

        protected void ApplyPagination(int take, int skip)
        {
            Take = take;
            Skip = skip;
            PaginationEnabled = true;
        }
    }
}

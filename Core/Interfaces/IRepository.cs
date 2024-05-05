using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListWithSpecAsync(ISpecification<T> specification);
        Task<T?> FindWithSpecAsync(ISpecification<T> specification);
    }
}

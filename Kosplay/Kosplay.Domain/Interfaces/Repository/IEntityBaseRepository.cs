
using System.Linq.Expressions;

namespace Kosplay.Domain.Interfaces.Repository
{
    public interface IEntityBaseRepository<T> where T : class
    {
        Task<bool> ExistsAsync(int id);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

    }
}

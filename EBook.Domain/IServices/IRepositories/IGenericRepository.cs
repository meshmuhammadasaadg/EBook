using System.Linq.Expressions;

namespace EBook.Domain.IServices.IRepositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> FindAync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(T entity, int id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(T entity, int id, CancellationToken cancellationToken = default);

    Task<int> Count(CancellationToken cancellationToken = default);
}

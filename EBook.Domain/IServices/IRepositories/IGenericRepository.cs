using System.Linq.Expressions;

namespace EBook.Domain.IServices.IRepositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(string[] includes = null!, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllByPredicateAsync(Expression<Func<T, bool>> predicate, string[] includes = null!, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate, string[] includes = null!, CancellationToken cancellationToken = default);
    Task<int> Count(CancellationToken cancellationToken = default);
}

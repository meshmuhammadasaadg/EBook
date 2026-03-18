using EBook.Domain.IServices.IRepositories;
using EBook.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EBook.Infrastructure.Services.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) =>
        await _context.Set<T>().ToListAsync(cancellationToken);

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Set<T>().FindAsync(id, cancellationToken);

    public async Task<T?> FindAync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) =>
        await _context.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddRangeAsync(entity);
        return entity;
    }

    public Task<bool> UpdateAsync(T entity, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(T entity, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> Count(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

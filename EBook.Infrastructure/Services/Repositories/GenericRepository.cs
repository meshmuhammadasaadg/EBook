using EBook.Domain.IServices.IRepositories;
using EBook.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EBook.Infrastructure.Services.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync(string[] includes = null!, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        if (query is null)
            return null!;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllByPredicateAync(Expression<Func<T, bool>> predicate, string[] includes = null!, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        if (query is null)
            return null!;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Set<T>().FindAsync(id, cancellationToken);

    public async Task<T?> GetByPredicateAync(Expression<Func<T, bool>> predicate, string[] includes = null!, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        if (query is null)
            return null!;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<int> Count(CancellationToken cancellationToken = default) =>
        await _context.Set<T>().CountAsync(cancellationToken);
}

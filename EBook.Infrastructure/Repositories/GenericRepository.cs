using EBook.Domain.IRepositories;
using EBook.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) =>
        await _context.Set<T>().ToListAsync(cancellationToken);
}

using EBook.Domain.Entities;
using EBook.Domain.IServices;
using EBook.Domain.IServices.IRepositories;
using EBook.Infrastructure.Presistence;
using EBook.Infrastructure.Services.Repositories;

namespace EBook.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IBooksServices Books { get; private set; }
    public IGenericRepository<Author> Authors { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Authors = new GenericRepository<Author>(_context);
        Books = new BooksServices(context);
    }
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}

using EBook.Domain.Entities;
using EBook.Domain.IServices.IRepositories;

namespace EBook.Domain.IServices;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Book> Books { get; }
    IGenericRepository<Author> Authors { get; }
    Task<int> SaveChangesAsync();
}

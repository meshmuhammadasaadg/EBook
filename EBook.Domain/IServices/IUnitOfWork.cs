using EBook.Domain.Entities;
using EBook.Domain.IServices.IRepositories;

namespace EBook.Domain.IServices;

public interface IUnitOfWork : IDisposable
{
    IBooksServices Books { get; }
    IGenericRepository<Author> Authors { get; }
    Task<int> SaveChangesAsync();
}

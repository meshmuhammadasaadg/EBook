using EBook.Domain.Abstractions;
using EBook.Domain.Contracts.Books;
using EBook.Domain.Entities;
using EBook.Domain.IServices.IRepositories;

namespace EBook.Domain.IServices;

public interface IBooksServices : IGenericRepository<Book>
{
    Task<Result<BookResponse>> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
}

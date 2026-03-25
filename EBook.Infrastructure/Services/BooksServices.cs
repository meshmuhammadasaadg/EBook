using EBook.Domain.Abstractions;
using EBook.Domain.Contracts.Books;
using EBook.Domain.Entities;
using EBook.Domain.Errors;
using EBook.Domain.IServices;
using EBook.Infrastructure.Persistence;
using EBook.Infrastructure.Services.Repositories;
using Mapster;

namespace EBook.Infrastructure.Services;

public class BooksServices(ApplicationDbContext context) : GenericRepository<Book>(context), IBooksServices
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<BookResponse>> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var book = await GetByIdAsync(id, cancellationToken: cancellationToken);

        if (book is null)
            return Result.Failure<BookResponse>(BookErrors.BookNotFound);

        return Result.Success(book.Adapt<BookResponse>());
    }
}

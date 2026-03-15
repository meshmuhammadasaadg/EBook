using EBook.Domain.Entities;
using EBook.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IGenericRepository<Book> booksRepository) : ControllerBase
{
    private readonly IGenericRepository<Book> _booksRepository = booksRepository;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _booksRepository.GetAllAsync(cancellationToken);

        return Ok(result);
    }
}

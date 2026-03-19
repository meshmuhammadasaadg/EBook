using EBook.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IUnitOfWork booksServices) : ControllerBase
{
    private readonly IUnitOfWork _booksServices = booksServices;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _booksServices.Books.GetBookByIdAsync(id, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    //{
    //    var books = await _unitOfWork.Books.GetByIdAsync(id, cancellationToken);

    //    return books is not null ? Ok(books) : NotFound();
    //}

    //[HttpGet("by-name/{name}")]
    //public async Task<IActionResult> GetAsync([FromRoute] string name, CancellationToken cancellationToken)
    //{
    //    var book = await _unitOfWork.Books.FindAync(c => c.Title == name, cancellationToken: cancellationToken);

    //    return book is not null ? Ok(book) : NotFound();
    //}
    //[HttpPost("")]
    //public async Task<IActionResult> AddAsync([FromBody] Book request, CancellationToken cancellationToken)
    //{
    //    var book = await _unitOfWork.Books.AddAsync(request, cancellationToken);
    //    await _unitOfWork.SaveChangesAsync();

    //    return book is not null ? Ok(book) : NotFound();
    //}
}

using EBook.Domain.Entities;
using EBook.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Books.GetAllAsync(cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.Books.GetByIdAsync(id, cancellationToken);

        return books is not null ? Ok(books) : NotFound();
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetAsync([FromRoute] string name, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.FindAync(c => c.Title == name, cancellationToken: cancellationToken);

        return book is not null ? Ok(book) : NotFound();
    }
    [HttpPost("")]
    public async Task<IActionResult> AddAsync([FromBody] Book request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.AddAsync(request, cancellationToken);
        await _unitOfWork.CompleteAsync();

        return book is not null ? Ok(book) : NotFound();
    }
}

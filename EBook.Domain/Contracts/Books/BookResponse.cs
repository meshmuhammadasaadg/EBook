namespace EBook.Domain.Contracts.Books;

public record BookResponse(
    int Id,
    string Title,
    string? Description,
    decimal PhysicalPrice,
    decimal Discount,
    int AvailableQuantity,
    string BookFilePath,
    string BookCoverImage,
    DateOnly Published_at,
    int AuthorId
);

namespace EBook.Domain.Contracts.Books;

public record BookRequest(
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

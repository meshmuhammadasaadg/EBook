namespace EBook.Domain.Entities;

public class Book : AuditableEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal PhysicalPrice { get; set; }
    public decimal Discount { get; set; }
    public int AvailableQuantity { get; set; }
    public string BookFilePath { get; set; } = string.Empty;
    public string BookCoverImage { get; set; } = string.Empty;
    public DateOnly Published_at { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = default!;
}

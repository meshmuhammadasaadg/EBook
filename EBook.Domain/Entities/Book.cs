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
    public DateOnly PublishedAt { get; set; }

    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public Category Category { get; set; } = default!;
    public Author Author { get; set; } = default!;

    public ICollection<Review>? Reviews { get; set; } = [];
    // Has Many BookOrders
    public ICollection<BookOrder>? BookOrders { get; set; } = [];
    // Has Many Orders
    public ICollection<Order>? Orders { get; set; } = [];

    // ---> M Users can Download N Books <---
    // Has Many downloads
    public ICollection<BookDownload>? BookDownloads { get; set; } = [];
}

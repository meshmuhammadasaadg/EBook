namespace EBook.Domain.Entities;

public class Category : AuditableEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    // Has Many Books
    public ICollection<Book> Books { get; set; } = [];
}

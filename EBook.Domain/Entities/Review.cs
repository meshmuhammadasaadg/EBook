namespace EBook.Domain.Entities;

public class Review : AuditableEntity
{
    public int Id { get; set; }
    public int Rate { get; set; }
    public string Comment { get; set; } = null!;

    // Has One Book
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}

namespace EBook.Domain.Entities;

public sealed class Author : AuditableEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public byte[]? ProfilePic { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}

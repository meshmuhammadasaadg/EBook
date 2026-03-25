namespace EBook.Domain.Entities;

public class BookDownload
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
    public DateTime Downloaded_at { get; set; }
}

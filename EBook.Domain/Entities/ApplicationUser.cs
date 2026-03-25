using Microsoft.AspNetCore.Identity;

namespace EBook.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public byte[]? ProfilePic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<BookDownload>? BookDownloads { get; set; } = [];
}

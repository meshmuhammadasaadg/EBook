namespace EBook.Domain.Entities;

public class AuditableEntity
{
    public string CreatedById { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? UpdatedById { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }

    public ApplicationUser CreatedBy { get; set; } = default!;
    public ApplicationUser? UpdatedBy { get; set; } = default!;
}

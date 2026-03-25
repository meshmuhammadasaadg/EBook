using EBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBook.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(c => c.Title).HasMaxLength(255);
        builder.Property(c => c.Description).HasMaxLength(255);
        builder.Property(c => c.BookCoverImage).HasMaxLength(255);
        builder.Property(c => c.BookFilePath).HasMaxLength(255);

        builder.Property(c => c.PhysicalPrice).HasPrecision(7, 2);
        builder.Property(c => c.Discount).HasPrecision(7, 2);

        builder.Property(x => x.AvailableQuantity)
       .HasColumnType("TINYINT")
       .IsRequired();
    }
}

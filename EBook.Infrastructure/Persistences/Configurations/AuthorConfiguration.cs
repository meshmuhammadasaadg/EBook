using EBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBook.Infrastructure.Persistences.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(c => c.FullName).HasMaxLength(255);
        builder.Property(c => c.Bio).HasMaxLength(255);
    }
}

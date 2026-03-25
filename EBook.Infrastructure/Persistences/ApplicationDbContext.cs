using EBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Persistences; 

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        var cascadeFks = builder.Model.GetEntityTypes()
                   .SelectMany(t => t.GetForeignKeys())
                   .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

        foreach (var fk in cascadeFks)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(builder);
    }
}

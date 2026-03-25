using EBook.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookOrder> BookOrders { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<BookDownload> BookDownloads { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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

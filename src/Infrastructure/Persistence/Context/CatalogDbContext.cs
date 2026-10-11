using Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class CatalogDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<BookCategory> BookCategories => Set<BookCategory>();
    public DbSet<IndustryIdentifier> IndustryIdentifiers => Set<IndustryIdentifier>();
    public DbSet<BookImageLinks> BookImageLinks => Set<BookImageLinks>();
    public DbSet<PanelizationSummary> PanelizationSummaries => Set<PanelizationSummary>();

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

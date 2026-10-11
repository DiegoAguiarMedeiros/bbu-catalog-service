using Application.Interfaces;
using Domain.Books;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly CatalogDbContext _context;

    public BookRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
    {
        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Author> GetOrCreateAuthorAsync(string name, CancellationToken cancellationToken = default)
    {
        var normalizedName = name.Trim();
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Name == normalizedName, cancellationToken);

        if (author is not null)
            return author;

        author = Author.Create(normalizedName);
        await _context.Authors.AddAsync(author, cancellationToken);
        return author;
    }

    public async Task<Category> GetOrCreateCategoryAsync(string name, CancellationToken cancellationToken = default)
    {
        var normalizedName = name.Trim();
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == normalizedName, cancellationToken);

        if (category is not null)
            return category;

        category = Category.Create(normalizedName);
        await _context.Categories.AddAsync(category, cancellationToken);
        return category;
    }

    public async Task<Publisher> GetOrCreatePublisherAsync(string name, CancellationToken cancellationToken = default)
    {
        var normalizedName = name.Trim();
        var publisher = await _context.Publishers.FirstOrDefaultAsync(x => x.Name == normalizedName, cancellationToken);

        if (publisher is not null)
            return publisher;

        publisher = Publisher.Create(normalizedName);
        await _context.Publishers.AddAsync(publisher, cancellationToken);
        return publisher;
    }
}

using Domain.Books;

namespace Application.Interfaces;

public interface IBookRepository
{
    Task AddAsync(Book book, CancellationToken cancellationToken = default);
    Task<Author> GetOrCreateAuthorAsync(string name, CancellationToken cancellationToken = default);
    Task<Category> GetOrCreateCategoryAsync(string name, CancellationToken cancellationToken = default);
    Task<Publisher> GetOrCreatePublisherAsync(string name, CancellationToken cancellationToken = default);
}

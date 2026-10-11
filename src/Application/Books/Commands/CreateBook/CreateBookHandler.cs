using Application.DTOs;
using Application.Interfaces;
using Domain.Books;
using MediatR;

namespace Application.Books.Commands.CreateBook;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookDto>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var publisher = await _bookRepository.GetOrCreatePublisherAsync(request.Publisher, cancellationToken);

        var book = Book.Create(
            request.Title,
            publisher,
            request.PublishedDate,
            request.Description,
            request.PageCount,
            request.PrintedPageCount,
            request.PrintType,
            request.MaturityRating,
            request.AllowAnonLogging,
            request.ContentVersion,
            request.Language);

        foreach (var authorName in request.Authors.Where(value => !string.IsNullOrWhiteSpace(value)).Distinct(StringComparer.OrdinalIgnoreCase))
        {
            var author = await _bookRepository.GetOrCreateAuthorAsync(authorName, cancellationToken);
            book.AddAuthor(author);
        }

        foreach (var categoryName in request.Categories.Where(value => !string.IsNullOrWhiteSpace(value)).Distinct(StringComparer.OrdinalIgnoreCase))
        {
            var category = await _bookRepository.GetOrCreateCategoryAsync(categoryName, cancellationToken);
            book.AddCategory(category);
        }

        foreach (var identifier in request.IndustryIdentifiers.Where(value => !string.IsNullOrWhiteSpace(value.Type) && !string.IsNullOrWhiteSpace(value.Identifier)))
        {
            book.AddIndustryIdentifier(identifier.Type, identifier.Identifier);
        }

        if (request.ImageLinks is not null)
        {
            book.SetImageLinks(BookImageLinks.Create(
                book,
                request.ImageLinks.SmallThumbnail,
                request.ImageLinks.Thumbnail,
                request.ImageLinks.Small,
                request.ImageLinks.Medium,
                request.ImageLinks.Large,
                request.ImageLinks.ExtraLarge));
        }

        if (request.PanelizationSummary is not null)
        {
            book.SetPanelizationSummary(PanelizationSummary.Create(
                book,
                request.PanelizationSummary.ContainsEpubBubbles,
                request.PanelizationSummary.ContainsImageBubbles));
        }

        await _bookRepository.AddAsync(book, cancellationToken);

        return new BookDto(
            book.CatalogId,
            book.Title,
            book.Authors.Select(author => author.Author.Name).ToArray(),
            book.Publisher.Name,
            book.PublishedDate,
            book.Description,
            book.IndustryIdentifiers.Select(identifier => new IndustryIdentifierDto(identifier.Type, identifier.Identifier)).ToArray(),
            book.PageCount,
            book.PrintedPageCount,
            book.PrintType,
            book.Categories.Select(category => category.Category.Name).ToArray(),
            book.MaturityRating,
            book.AllowAnonLogging,
            book.ContentVersion,
            book.PanelizationSummary is null
                ? null
                : new PanelizationSummaryDto(book.PanelizationSummary.ContainsEpubBubbles, book.PanelizationSummary.ContainsImageBubbles),
            book.ImageLinks is null
                ? null
                : new ImageLinksDto(
                    book.ImageLinks.SmallThumbnail,
                    book.ImageLinks.Thumbnail,
                    book.ImageLinks.Small,
                    book.ImageLinks.Medium,
                    book.ImageLinks.Large,
                    book.ImageLinks.ExtraLarge),
            book.Language,
            book.CreatedAt);
    }
}

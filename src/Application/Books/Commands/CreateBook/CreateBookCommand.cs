using Application.DTOs;
using MediatR;

namespace Application.Books.Commands.CreateBook;

public record CreateBookCommand(
    string Title,
    IReadOnlyCollection<string> Authors,
    string Publisher,
    DateOnly? PublishedDate,
    string? Description,
    IReadOnlyCollection<IndustryIdentifierInput> IndustryIdentifiers,
    int? PageCount,
    int? PrintedPageCount,
    string? PrintType,
    IReadOnlyCollection<string> Categories,
    string? MaturityRating,
    bool? AllowAnonLogging,
    string? ContentVersion,
    PanelizationSummaryInput? PanelizationSummary,
    ImageLinksInput? ImageLinks,
    string? Language) : IRequest<BookDto>;

public record IndustryIdentifierInput(string Type, string Identifier);

public record PanelizationSummaryInput(bool ContainsEpubBubbles, bool ContainsImageBubbles);

public record ImageLinksInput(
    string? SmallThumbnail,
    string? Thumbnail,
    string? Small,
    string? Medium,
    string? Large,
    string? ExtraLarge);

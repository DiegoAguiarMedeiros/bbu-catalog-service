namespace Application.DTOs;

public record BookDto(
    Guid CatalogId,
    string Title,
    string[] Authors,
    string Publisher,
    DateOnly? PublishedDate,
    string? Description,
    IReadOnlyCollection<IndustryIdentifierDto> IndustryIdentifiers,
    int? PageCount,
    int? PrintedPageCount,
    string? PrintType,
    string[] Categories,
    string? MaturityRating,
    bool? AllowAnonLogging,
    string? ContentVersion,
    PanelizationSummaryDto? PanelizationSummary,
    ImageLinksDto? ImageLinks,
    string? Language,
    DateTime CreatedAt);

public record IndustryIdentifierDto(string Type, string Identifier);

public record PanelizationSummaryDto(bool ContainsEpubBubbles, bool ContainsImageBubbles);

public record ImageLinksDto(
    string? SmallThumbnail,
    string? Thumbnail,
    string? Small,
    string? Medium,
    string? Large,
    string? ExtraLarge);

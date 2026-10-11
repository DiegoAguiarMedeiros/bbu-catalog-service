namespace Api.Contracts;

public record CreateBookRequest(
    string Title,
    IReadOnlyCollection<string>? Authors,
    string Publisher,
    DateOnly? PublishedDate,
    string? Description,
    IReadOnlyCollection<IndustryIdentifierRequest>? IndustryIdentifiers,
    int? PageCount,
    int? PrintedPageCount,
    string? PrintType,
    IReadOnlyCollection<string>? Categories,
    string? MaturityRating,
    bool? AllowAnonLogging,
    string? ContentVersion,
    PanelizationSummaryRequest? PanelizationSummary,
    ImageLinksRequest? ImageLinks,
    string? Language);

public record IndustryIdentifierRequest(string Type, string Identifier);

public record PanelizationSummaryRequest(bool ContainsEpubBubbles, bool ContainsImageBubbles);

public record ImageLinksRequest(
    string? SmallThumbnail,
    string? Thumbnail,
    string? Small,
    string? Medium,
    string? Large,
    string? ExtraLarge);

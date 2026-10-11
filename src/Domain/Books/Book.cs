using Domain.Common;

namespace Domain.Books;

public class Book
{
    public Id Id { get; private set; } = null!;
    public Guid CatalogId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public Id PublisherId { get; private set; } = null!;
    public Publisher Publisher { get; private set; } = null!;
    public DateOnly? PublishedDate { get; private set; }
    public string? Description { get; private set; }
    public int? PageCount { get; private set; }
    public int? PrintedPageCount { get; private set; }
    public string? PrintType { get; private set; }
    public string? MaturityRating { get; private set; }
    public bool? AllowAnonLogging { get; private set; }
    public string? ContentVersion { get; private set; }
    public string? Language { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public ICollection<BookAuthor> Authors { get; private set; } = new List<BookAuthor>();
    public ICollection<BookCategory> Categories { get; private set; } = new List<BookCategory>();
    public ICollection<IndustryIdentifier> IndustryIdentifiers { get; private set; } = new List<IndustryIdentifier>();
    public BookImageLinks? ImageLinks { get; private set; }
    public PanelizationSummary? PanelizationSummary { get; private set; }

    private Book() { }

    private Book(
        Id id,
        string title,
        Publisher publisher,
        DateOnly? publishedDate,
        string? description,
        int? pageCount,
        int? printedPageCount,
        string? printType,
        string? maturityRating,
        bool? allowAnonLogging,
        string? contentVersion,
        string? language)
    {
        Id = id;
        CatalogId = Guid.NewGuid();
        Title = title.Trim();
        Publisher = publisher;
        PublisherId = publisher.Id;
        PublishedDate = publishedDate;
        Description = description;
        PageCount = pageCount;
        PrintedPageCount = printedPageCount;
        PrintType = printType;
        MaturityRating = maturityRating;
        AllowAnonLogging = allowAnonLogging;
        ContentVersion = contentVersion;
        Language = language;
        CreatedAt = DateTime.UtcNow;
    }

    public static Book Create(
        string title,
        Publisher publisher,
        DateOnly? publishedDate,
        string? description,
        int? pageCount,
        int? printedPageCount,
        string? printType,
        string? maturityRating,
        bool? allowAnonLogging,
        string? contentVersion,
        string? language)
    {
        return new Book(
            Id.New(),
            title,
            publisher,
            publishedDate,
            description,
            pageCount,
            printedPageCount,
            printType,
            maturityRating,
            allowAnonLogging,
            contentVersion,
            language);
    }

    public void AddAuthor(Author author)
    {
        Authors.Add(BookAuthor.Create(this, author));
    }

    public void AddCategory(Category category)
    {
        Categories.Add(BookCategory.Create(this, category));
    }

    public void AddIndustryIdentifier(string type, string identifier)
    {
        IndustryIdentifiers.Add(IndustryIdentifier.Create(this, type, identifier));
    }

    public void SetImageLinks(BookImageLinks imageLinks)
    {
        ImageLinks = imageLinks;
    }

    public void SetPanelizationSummary(PanelizationSummary panelizationSummary)
    {
        PanelizationSummary = panelizationSummary;
    }
}

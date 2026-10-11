using Domain.Common;

namespace Domain.Books;

public class IndustryIdentifier
{
    public Id Id { get; private set; } = null!;
    public Id BookId { get; private set; } = null!;
    public Book Book { get; private set; } = null!;
    public string Type { get; private set; } = string.Empty;
    public string Identifier { get; private set; } = string.Empty;

    private IndustryIdentifier() { }

    private IndustryIdentifier(Book book, string type, string identifier)
    {
        Id = Id.New();
        Book = book;
        BookId = book.Id;
        Type = type.Trim();
        Identifier = identifier.Trim();
    }

    public static IndustryIdentifier Create(Book book, string type, string identifier) => new(book, type, identifier);
}

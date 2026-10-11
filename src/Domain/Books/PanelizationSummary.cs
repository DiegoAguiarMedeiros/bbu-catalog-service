using Domain.Common;

namespace Domain.Books;

public class PanelizationSummary
{
    public Id BookId { get; private set; } = null!;
    public Book Book { get; private set; } = null!;
    public bool ContainsEpubBubbles { get; private set; }
    public bool ContainsImageBubbles { get; private set; }

    private PanelizationSummary() { }

    private PanelizationSummary(Book book, bool containsEpubBubbles, bool containsImageBubbles)
    {
        Book = book;
        BookId = book.Id;
        ContainsEpubBubbles = containsEpubBubbles;
        ContainsImageBubbles = containsImageBubbles;
    }

    public static PanelizationSummary Create(Book book, bool containsEpubBubbles, bool containsImageBubbles)
    {
        return new(book, containsEpubBubbles, containsImageBubbles);
    }
}

using Domain.Common;

namespace Domain.Books;

public class BookImageLinks
{
    public Id BookId { get; private set; } = null!;
    public Book Book { get; private set; } = null!;
    public string? SmallThumbnail { get; private set; }
    public string? Thumbnail { get; private set; }
    public string? Small { get; private set; }
    public string? Medium { get; private set; }
    public string? Large { get; private set; }
    public string? ExtraLarge { get; private set; }

    private BookImageLinks() { }

    private BookImageLinks(
        Book book,
        string? smallThumbnail,
        string? thumbnail,
        string? small,
        string? medium,
        string? large,
        string? extraLarge)
    {
        Book = book;
        BookId = book.Id;
        SmallThumbnail = smallThumbnail;
        Thumbnail = thumbnail;
        Small = small;
        Medium = medium;
        Large = large;
        ExtraLarge = extraLarge;
    }

    public static BookImageLinks Create(
        Book book,
        string? smallThumbnail,
        string? thumbnail,
        string? small,
        string? medium,
        string? large,
        string? extraLarge)
    {
        return new(book, smallThumbnail, thumbnail, small, medium, large, extraLarge);
    }
}

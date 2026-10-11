using Domain.Common;

namespace Domain.Books;

public class BookAuthor
{
    public Id BookId { get; private set; } = null!;
    public Book Book { get; private set; } = null!;
    public Id AuthorId { get; private set; } = null!;
    public Author Author { get; private set; } = null!;

    private BookAuthor() { }

    private BookAuthor(Book book, Author author)
    {
        Book = book;
        BookId = book.Id;
        Author = author;
        AuthorId = author.Id;
    }

    public static BookAuthor Create(Book book, Author author) => new(book, author);
}

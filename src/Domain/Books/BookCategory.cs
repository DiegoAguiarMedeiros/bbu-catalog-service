using Domain.Common;

namespace Domain.Books;

public class BookCategory
{
    public Id BookId { get; private set; } = null!;
    public Book Book { get; private set; } = null!;
    public Id CategoryId { get; private set; } = null!;
    public Category Category { get; private set; } = null!;

    private BookCategory() { }

    private BookCategory(Book book, Category category)
    {
        Book = book;
        BookId = book.Id;
        Category = category;
        CategoryId = category.Id;
    }

    public static BookCategory Create(Book book, Category category) => new(book, category);
}

using Domain.Common;

namespace Domain.Books;

public class Author
{
    public Id Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public ICollection<BookAuthor> Books { get; private set; } = new List<BookAuthor>();

    private Author() { }

    private Author(Id id, string name)
    {
        Id = id;
        Name = name.Trim();
    }

    public static Author Create(string name) => new(Id.New(), name);
}

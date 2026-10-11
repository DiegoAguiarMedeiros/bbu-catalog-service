using Domain.Common;

namespace Domain.Books;

public class Category
{
    public Id Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public ICollection<BookCategory> Books { get; private set; } = new List<BookCategory>();

    private Category() { }

    private Category(Id id, string name)
    {
        Id = id;
        Name = name.Trim();
    }

    public static Category Create(string name) => new(Id.New(), name);
}

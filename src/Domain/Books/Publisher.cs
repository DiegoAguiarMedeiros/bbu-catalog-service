using Domain.Common;

namespace Domain.Books;

public class Publisher
{
    public Id Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public ICollection<Book> Books { get; private set; } = new List<Book>();

    private Publisher() { }

    private Publisher(Id id, string name)
    {
        Id = id;
        Name = name.Trim();
    }

    public static Publisher Create(string name) => new(Id.New(), name);
}

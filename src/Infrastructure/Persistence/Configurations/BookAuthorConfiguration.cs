using Domain.Books;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("BookAuthors");

        builder.HasKey(x => new { x.BookId, x.AuthorId });

        builder.Property(x => x.BookId)
            .HasConversion(id => id.Value, value => Id.From(value));

        builder.Property(x => x.AuthorId)
            .HasConversion(id => id.Value, value => Id.From(value));

        builder.HasOne(x => x.Book)
            .WithMany(x => x.Authors)
            .HasForeignKey(x => x.BookId);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);
    }
}

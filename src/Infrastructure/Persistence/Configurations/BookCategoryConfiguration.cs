using Domain.Books;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.ToTable("BookCategories");

        builder.HasKey(x => new { x.BookId, x.CategoryId });

        builder.Property(x => x.BookId)
            .HasConversion(id => id.Value, value => Id.From(value));

        builder.Property(x => x.CategoryId)
            .HasConversion(id => id.Value, value => Id.From(value));

        builder.HasOne(x => x.Book)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.BookId);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.CategoryId);
    }
}

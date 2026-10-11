using Domain.Books;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookImageLinksConfiguration : IEntityTypeConfiguration<BookImageLinks>
{
    public void Configure(EntityTypeBuilder<BookImageLinks> builder)
    {
        builder.ToTable("BookImageLinks");

        builder.HasKey(x => x.BookId);

        builder.Property(x => x.BookId)
            .HasConversion(id => id.Value, value => Id.From(value));

        builder.HasOne(x => x.Book)
            .WithOne(x => x.ImageLinks)
            .HasForeignKey<BookImageLinks>(x => x.BookId);

        builder.Property(x => x.SmallThumbnail).HasColumnType("text");
        builder.Property(x => x.Thumbnail).HasColumnType("text");
        builder.Property(x => x.Small).HasColumnType("text");
        builder.Property(x => x.Medium).HasColumnType("text");
        builder.Property(x => x.Large).HasColumnType("text");
        builder.Property(x => x.ExtraLarge).HasColumnType("text");
    }
}

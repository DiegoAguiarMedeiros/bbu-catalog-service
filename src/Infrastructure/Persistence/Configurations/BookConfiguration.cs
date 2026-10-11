using Domain.Books;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => Id.From(value))
            .IsRequired();

        builder.Property(x => x.CatalogId)
            .IsRequired();

        builder.HasIndex(x => x.CatalogId).IsUnique();

        builder.Property(x => x.Title)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.PublisherId)
            .HasConversion(id => id.Value, value => Id.From(value))
            .IsRequired();

        builder.HasOne(x => x.Publisher)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description).HasColumnType("text");
        builder.Property(x => x.PrintType).HasMaxLength(50);
        builder.Property(x => x.MaturityRating).HasMaxLength(80);
        builder.Property(x => x.ContentVersion).HasMaxLength(80);
        builder.Property(x => x.Language).HasMaxLength(20);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}

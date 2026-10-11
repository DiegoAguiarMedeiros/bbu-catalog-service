using Domain.Books;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class IndustryIdentifierConfiguration : IEntityTypeConfiguration<IndustryIdentifier>
{
    public void Configure(EntityTypeBuilder<IndustryIdentifier> builder)
    {
        builder.ToTable("IndustryIdentifiers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => Id.From(value))
            .IsRequired();

        builder.Property(x => x.BookId)
            .HasConversion(id => id.Value, value => Id.From(value))
            .IsRequired();

        builder.HasOne(x => x.Book)
            .WithMany(x => x.IndustryIdentifiers)
            .HasForeignKey(x => x.BookId);

        builder.Property(x => x.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Identifier)
            .HasMaxLength(80)
            .IsRequired();

        builder.HasIndex(x => new { x.BookId, x.Type, x.Identifier }).IsUnique();
    }
}

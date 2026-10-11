using Domain.Books;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PanelizationSummaryConfiguration : IEntityTypeConfiguration<PanelizationSummary>
{
    public void Configure(EntityTypeBuilder<PanelizationSummary> builder)
    {
        builder.ToTable("PanelizationSummaries");

        builder.HasKey(x => x.BookId);

        builder.Property(x => x.BookId)
            .HasConversion(id => id.Value, value => Id.From(value));

        builder.HasOne(x => x.Book)
            .WithOne(x => x.PanelizationSummary)
            .HasForeignKey<PanelizationSummary>(x => x.BookId);
    }
}

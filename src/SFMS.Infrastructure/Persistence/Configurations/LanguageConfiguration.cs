using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages");

        builder.HasKey(x => x.Id);

        // BaseEntity
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.RowVersion)
            .IsRowVersion();

        // BaseLookupEntity
        builder.Property(x => x.ColorCode)
            .HasMaxLength(20);

        builder.Property(x => x.Icon)
            .HasMaxLength(100);

        // Language
        builder.Property(x => x.Culture)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.IsDefault)
            .IsRequired();

        builder.Property(x => x.IsRightToLeft)
            .IsRequired();
    }
}
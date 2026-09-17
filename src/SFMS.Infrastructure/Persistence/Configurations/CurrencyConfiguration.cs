using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Currencies");

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

        // Currency
        builder.Property(x => x.Symbol)
            .HasMaxLength(10);

        builder.Property(x => x.DecimalPlaces)
            .IsRequired();

        builder.Property(x => x.Culture)
            .HasMaxLength(20);

        builder.Property(x => x.ExchangeRate)
            .IsRequired()
            .HasPrecision(18, 6);

        builder.Property(x => x.ExchangeRateDate)
            .IsRequired();
    }
}
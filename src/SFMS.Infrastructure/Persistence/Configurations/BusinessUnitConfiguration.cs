using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
{
    public void Configure(EntityTypeBuilder<BusinessUnit> builder)
    {
        builder.ToTable("BusinessUnits");

        builder.HasKey(x => x.Id);

        // BaseEntity properties
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

        // BusinessUnit properties
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.EmailAddress)
            .IsRequired()
            .HasMaxLength(254);

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.IsProfitCenter)
            .IsRequired();

        builder.Property(x => x.AnnualBudget)
            .HasPrecision(18, 2);

        // Parent BusinessUnit relationship
        builder.HasOne(x => x.ParentBusinessUnit)
            .WithMany()
            .HasForeignKey(x => x.ParentBusinessUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
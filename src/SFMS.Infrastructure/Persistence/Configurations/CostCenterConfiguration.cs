using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>
{
    public void Configure(EntityTypeBuilder<CostCenter> builder)
    {
        builder.ToTable("CostCenters");

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

        // CostCenter
        builder.Property(x => x.BudgetAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.ActualAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.CommittedAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.ExpiryDate)
            .IsRequired(false);

        builder.Property(x => x.AllowOverBudget)
            .IsRequired();

        // Business Unit relationship
        builder.HasOne(x => x.BusinessUnit)
            .WithMany()
            .HasForeignKey(x => x.BusinessUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        // Department relationship
        builder.HasOne(x => x.Department)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
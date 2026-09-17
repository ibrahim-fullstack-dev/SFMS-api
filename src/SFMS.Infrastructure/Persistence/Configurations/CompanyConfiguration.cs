using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(x => x.Id);

        // Company is the tenant root.
        // It does not belong to another Company or Branch.
        builder.Ignore(x => x.CompanyId);
        builder.Ignore(x => x.Company);
        builder.Ignore(x => x.BranchId);
        builder.Ignore(x => x.Branch);

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

        // Company
        builder.Property(x => x.RegistrationNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.TaxNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(30);

        builder.Property(x => x.AlternatePhoneNumber)
            .HasMaxLength(30);

        builder.Property(x => x.EmailAddress)
            .HasMaxLength(254);

        builder.Property(x => x.Website)
            .HasMaxLength(500);

        builder.Property(x => x.LogoUrl)
            .HasMaxLength(500);

        builder.Property(x => x.Address)
            .HasMaxLength(500);

        builder.Property(x => x.PostalCode)
            .HasMaxLength(20);

        builder.Property(x => x.CurrencyCode)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(x => x.TimeZone)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.FinancialYearStartMonth)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Notes)
            .HasMaxLength(2000);

        // Country relationship
        builder.HasOne(x => x.Country)
           .WithMany()
           .HasForeignKey(x => x.CountryId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
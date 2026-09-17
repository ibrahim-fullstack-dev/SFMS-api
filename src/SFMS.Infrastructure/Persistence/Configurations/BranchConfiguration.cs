using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");

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

        // Branch properties
        builder.Property(x => x.BranchCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Address)
            .HasMaxLength(500);

        builder.Property(x => x.PostCode)
            .HasMaxLength(20);

        // Parent Branch relationship
        builder.HasOne(x => x.ParentBranch)
            .WithMany()
            .HasForeignKey(x => x.ParentBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        // Country relationship
        builder.HasOne<Country>()
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
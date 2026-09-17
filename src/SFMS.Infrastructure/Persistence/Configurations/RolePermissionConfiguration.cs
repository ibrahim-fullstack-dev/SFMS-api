using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Authentication;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");

        builder.HasKey(x => x.Id);

        // Role relationship
        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Permission relationship
        builder.HasOne(x => x.Permission)
            .WithMany()
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Permission actions
        builder.Property(x => x.CanCreate)
            .IsRequired();

        builder.Property(x => x.CanRead)
            .IsRequired();

        builder.Property(x => x.CanUpdate)
            .IsRequired();

        builder.Property(x => x.CanDelete)
            .IsRequired();

        builder.Property(x => x.CanApprove)
            .IsRequired();

        builder.Property(x => x.CanExport)
            .IsRequired();

        builder.Property(x => x.CanImport)
            .IsRequired();

        builder.Property(x => x.CanPrint)
            .IsRequired();

        builder.Property(x => x.CanUpload)
            .IsRequired();

        builder.Property(x => x.CanDownload)
            .IsRequired();

        // A role can have a permission only once.
        builder.HasIndex(x => new
        {
            x.RoleId,
            x.PermissionId
        })
        .IsUnique();
    }
}
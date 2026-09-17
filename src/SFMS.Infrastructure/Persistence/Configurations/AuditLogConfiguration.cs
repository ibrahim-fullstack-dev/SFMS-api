using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");

        builder.HasKey(x => x.Id);

        // Record information
        builder.Property(x => x.RecordId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.TableName)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.Action)
            .IsRequired()
            .HasMaxLength(50);

        // Changed values
        builder.Property(x => x.OldValues)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.NewValues)
            .HasColumnType("nvarchar(max)");

        // User relationship
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Request information
        builder.Property(x => x.IPAddress)
            .IsRequired()
            .HasMaxLength(45);

        builder.Property(x => x.Browser)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Timestamp)
            .IsRequired();
    }
}
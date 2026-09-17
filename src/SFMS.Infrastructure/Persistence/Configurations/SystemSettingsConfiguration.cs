using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class SystemSettingsConfiguration : IEntityTypeConfiguration<SystemSettings>
{
    public void Configure(EntityTypeBuilder<SystemSettings> builder)
    {
        builder.ToTable("SystemSettings");

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

        // SystemSettings
        builder.Property(x => x.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.SettingsKey)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.SettingsValue)
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(x => x.DataType)
            .IsRequired();

        builder.Property(x => x.IsActive).IsRequired();

        builder.Property(x => x.IsEncrypted)
            .IsRequired();
    }
}
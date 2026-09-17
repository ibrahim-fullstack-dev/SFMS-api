using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Authentication;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class PasswordHistoryConfiguration : IEntityTypeConfiguration<PasswordHistory>
{
    public void Configure(EntityTypeBuilder<PasswordHistory> builder)
    {
        builder.ToTable("PasswordHistories");

        builder.HasKey(x => x.Id);

        // Password information
        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.ChangedOn)
            .IsRequired();

        builder.Property(x => x.ExpiryDate)
            .IsRequired();

        builder.Property(x => x.IsCurrentPassword)
            .IsRequired();

        // User relationship
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
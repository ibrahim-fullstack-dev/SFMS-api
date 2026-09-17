using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFMS.Domain.Authentication;

namespace SFMS.Infrastructure.Persistence.Configurations;

public class LoginHistoryConfiguration : IEntityTypeConfiguration<LoginHistory>
{
    public void Configure(EntityTypeBuilder<LoginHistory> builder)
    {
        builder.ToTable("LoginHistories");

        builder.HasKey(x => x.Id);

        // Login information
        builder.Property(x => x.IPAddress)
            .HasMaxLength(45);

        builder.Property(x => x.Browser)
            .HasMaxLength(500);

        builder.Property(x => x.OperatingSystem)
            .HasMaxLength(100);

        builder.Property(x => x.Device)
            .HasMaxLength(100);

        builder.Property(x => x.LoginTime)
            .IsRequired();

        builder.Property(x => x.LogoutTime)
            .IsRequired(false);

        builder.Property(x => x.Location)
            .HasMaxLength(200);

        builder.Property(x => x.LoginSuccessful)
            .IsRequired();

        builder.Property(x => x.FailureReason)
            .HasMaxLength(500);

        // User relationship
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
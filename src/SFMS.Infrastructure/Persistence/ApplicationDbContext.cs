using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SFMS.Domain.Authentication;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Apply common relationships inherited from BaseEntity
        // and AuditableEntity.
        ConfigureBaseEntityRelationships(modelBuilder);
        ConfigureAuditableEntityRelationships(modelBuilder);

        // Apply entity-specific configurations.
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

    }

    private static void ConfigureBaseEntityRelationships(
        ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                continue;

            // Company is the tenant root.
            // Its CompanyId and BranchId are ignored in CompanyConfiguration.
            if (entityType.ClrType == typeof(Company))
                continue;

            var entity = modelBuilder.Entity(entityType.ClrType);

            entity
                .HasOne(typeof(Company), nameof(BaseEntity.Company))
                .WithMany()
                .HasForeignKey(nameof(BaseEntity.CompanyId))
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(typeof(Branch), nameof(BaseEntity.Branch))
                .WithMany()
                .HasForeignKey(nameof(BaseEntity.BranchId))
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    private static void ConfigureAuditableEntityRelationships(
        ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
                continue;

            var entity = modelBuilder.Entity(entityType.ClrType);

            entity
                .HasOne(typeof(ApplicationUser), nameof(AuditableEntity.CreatedBy))
                .WithMany()
                .HasForeignKey(nameof(AuditableEntity.CreatedById))
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(typeof(ApplicationUser), nameof(AuditableEntity.UpdatedBy))
                .WithMany()
                .HasForeignKey(nameof(AuditableEntity.UpdatedById))
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(typeof(ApplicationUser), nameof(AuditableEntity.DeletedBy))
                .WithMany()
                .HasForeignKey(nameof(AuditableEntity.DeletedById))
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
    public DbSet<ApplicationRole> ApplicationRoles { get; set; } = null!;

    public DbSet<LoginHistory> LoginHistories { get; set; } = null!;
    public DbSet<PasswordHistory> PasswordHistories { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<RolePermission> RolePermissions { get; set; } = null!;

    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Branch> Branches { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<BusinessUnit> BusinessUnits { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<State> States { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<CostCenter> CostCenters { get; set; } = null!;
    public DbSet<Attachment> Attachments { get; set; } = null!;
    public DbSet<AuditLog> AuditLogs { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<SystemSettings> SystemSettings { get; set; } = null!;
}
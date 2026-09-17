using Microsoft.EntityFrameworkCore;

using SFMS.Domain.Authentication;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // foreach (var entity in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        // {
        //     entity.DeleteBehavior = DeleteBehavior.Restrict;
        // }

        // modelBuilder.Entity<Branch>()
        //     .HasOne(b => b.ParentBranch)
        //     .WithMany()
        //     .HasForeignKey(b => b.ParentBranchId).IsRequired(false);

        // modelBuilder.Entity<Branch>()
        // .HasOne(b => b.Company)
        // .WithMany()
        // .HasForeignKey(b => b.CompanyId).IsRequired(false);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<BusinessUnit> BusinessUnits { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<City> Cities { get; set; }

}
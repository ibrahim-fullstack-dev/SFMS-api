
using Microsoft.AspNetCore.Identity;

namespace SFMS.Domain.Authentication;

public class ApplicationUser : IdentityUser<int>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string? Address { get; set; }

    public string? Country { get; set; }

    public string? Gender { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? NationalId { get; set; }

    public string? PassportNumber { get; set; }

    public int? CompanyId { get; set; }

    public int? CreatedById { get; set; }

    public ApplicationUser? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedById { get; set; }

    public ApplicationUser? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? DeletedById { get; set; }

    public ApplicationUser? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

}
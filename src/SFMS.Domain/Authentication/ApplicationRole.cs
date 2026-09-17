using Microsoft.AspNetCore.Identity;
using SFMS.Domain.Common;



namespace SFMS.Domain.Authentication;

public class ApplicationRole : IdentityRole<int>
{
    public string? Description { get; set; }

    public int? CompanyId { get; set; }

    public Company? Company { get; set; }

    public bool IsActive { get; set; }

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
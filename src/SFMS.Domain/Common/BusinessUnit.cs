namespace SFMS.Domain.Common;

public class BusinessUnit : AuditableEntity
{
    public int? ParentBusinessUnitId { get; set; }

    public BusinessUnit? ParentBusinessUnit { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public bool IsProfitCenter { get; set; }

}
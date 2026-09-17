namespace SFMS.Domain.Common;

public class Department : AuditableEntity
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public int? ParentDepartmentId { get; set; }
    public Department? ParentDepartment { get; set; }

    public bool IsOperational { get; set; } = true;
}
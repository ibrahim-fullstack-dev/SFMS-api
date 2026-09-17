namespace SFMS.Domain.Authentication;

public class Permission
{
    public int Id { get; set; }

    public string Module { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string PermissionCode { get; set; } = null!;
    public string Description { get; set; } = null!;

    public bool IsSystemPermission { get; set; }

    public bool IsActive { get; set; }
}
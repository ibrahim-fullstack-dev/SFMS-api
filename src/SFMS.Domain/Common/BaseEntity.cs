namespace SFMS.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int CompanyId { get; set; }

    public Company Company { get; set; } = null!;

    public int BranchId { get; set; }

    public Branch Branch { get; set; } = null!;

    public byte[] RowVersion { get; set; } = [];
}
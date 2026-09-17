namespace SFMS.Domain.Common;

public class Location : AuditableEntity
{
    public int? ParentLocationId { get; set; }
    public Location? ParentLocation { get; set; }

    public string? Address { get; set; }
    public string? PostalCode { get; set; }

    public LocationType Type { get; set; }
}
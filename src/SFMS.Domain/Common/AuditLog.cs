using SFMS.Domain.Authentication;

namespace SFMS.Domain.Common;

public class AuditLog
{
    public int Id { get; set; }

    public string RecordId { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string Action { get; set; } = string.Empty;

    public string? OldValues { get; set; }
    public string? NewValues { get; set; }

    public int? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public string IPAddress { get; set; } = string.Empty;

    public string Browser { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }

}
namespace SFMS.Domain.Common;

public class Attachment : AuditableEntity
{
    public string FileName { get; set; } = null!;
    public string OriginalFileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string FileType { get; set; } = null!;
    public long FileSize { get; set; }
    public string Extension { get; set; } = null!;
    public string? Checksum { get; set; }
}
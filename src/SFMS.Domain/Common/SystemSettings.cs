namespace SFMS.Domain.Common;

public class SystemSettings : AuditableEntity
{
    public string Category { get; set; } = null!;
    public string SettingsKey { get; set; } = null!;
    public string SettingsValue { get; set; } = null!;
    public SettingDataType DataType { get; set; }
    public bool IsEncrypted { get; set; }
}
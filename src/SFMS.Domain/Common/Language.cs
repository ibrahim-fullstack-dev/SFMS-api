namespace SFMS.Domain.Common;

public class Language : BaseLookupEntity
{
    public string Culture { get; set; } = null!;

    public bool IsDefault { get; set; }

    public bool IsRightToLeft { get; set; }
}
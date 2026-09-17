namespace SFMS.Domain.Common;

public class State : BaseLookupEntity
{
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public string? Capital { get; set; }
}
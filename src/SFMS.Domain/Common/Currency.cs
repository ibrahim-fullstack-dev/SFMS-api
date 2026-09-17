namespace SFMS.Domain.Common;

public class Currency : BaseLookupEntity
{
    public string? Symbol { get; set; }

    public int DecimalPlaces { get; set; }

    public string? Culture { get; set; }

    public decimal ExchangeRate { get; set; }

    public DateTime ExchangeRateDate { get; set; }
}
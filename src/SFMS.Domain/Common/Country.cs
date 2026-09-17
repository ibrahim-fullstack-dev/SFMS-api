namespace SFMS.Domain.Common
{
    public class Country : BaseLookupEntity
    {

        public string CurrencyCode { get; set; } = null!;

        public string TimeZone { get; set; } = null!;

        public string PhoneCode { get; set; } = null!;

        public string Nationality { get; set; } = null!;


    }
}
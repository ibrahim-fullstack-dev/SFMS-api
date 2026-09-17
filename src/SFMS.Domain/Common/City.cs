namespace SFMS.Domain.Common
{
    public class City : BaseLookupEntity
    {
        public int StateId { get; set; }

        public State State { get; set; } = null!;

        public string? PostalCode { get; set; }

    }
}
namespace SFMS.Domain.Common
{
    public class BaseLookupEntity : AuditableEntity
    {
        public int DisplayOrder { get; set; }

        public string? ColorCode { get; set; }

        public string? Icon { get; set; }

        public bool IsSystem { get; set; } = false;
    }
}
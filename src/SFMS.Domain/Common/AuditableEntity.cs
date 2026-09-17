using SFMS.Domain.Authentication;

namespace SFMS.Domain.Common
{
    public class AuditableEntity : BaseEntity
    {

        public int CreatedById { get; set; }

        public ApplicationUser? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UpdatedById { get; set; }

        public ApplicationUser? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? DeletedById { get; set; }

        public ApplicationUser? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
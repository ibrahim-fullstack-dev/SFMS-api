namespace SFMS.Domain.Common
{
    public class CostCenter : AuditableEntity
    {
        public int? BusinessUnitId { get; set; }
        public BusinessUnit? BusinessUnit { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public decimal? BudgetAmount { get; set; }

        public decimal ActualAmount { get; set; } = 0;

        public decimal CommittedAmount { get; set; } = 0;

        public DateTime? ExpiryDate { get; set; }

        public bool AllowOverBudget { get; set; } = false;

    }
}
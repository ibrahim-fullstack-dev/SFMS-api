namespace SFMS.Domain.Authentication;

public class PasswordHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime ChangedOn { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool IsCurrentPassword { get; set; }
}
namespace SFMS.Domain.Authentication;

public class RefreshToken
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? RevokedOn { get; set; }

    public string? ReplacedByToken { get; set; }

    public bool IsRevoked { get; set; }

    public int UserId { get; set; }

    public ApplicationUser User { get; set; } = null!;

    public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
}
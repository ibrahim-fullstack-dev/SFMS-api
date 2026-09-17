namespace SFMS.Domain.Authentication;

public class LoginHistory
{
    public int Id { get; set; }

    public string? IPAddress { get; set; }
    public string? Browser { get; set; }
    public string? OperatingSystem { get; set; }
    public string? Device { get; set; }

    public DateTime LoginTime { get; set; }
    public DateTime? LogoutTime { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public string? Location { get; set; }

    public bool LoginSuccessful { get; set; }

    public string? FailureReason { get; set; }
}
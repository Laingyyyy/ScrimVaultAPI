namespace ScrimVaultAPI.Models;

public class BaseEntity
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; } // Always in UTC
    public DateTime UpdatedAt { get; set; } // Always in UTC
}
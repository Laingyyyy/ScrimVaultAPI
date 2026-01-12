namespace ScrimVaultAPI.Models;

public class Team : BaseEntity
{
    public int TeamId { get; set; }
    public string Name { get; set; } = null!;
    public int OwnerUserId { get; set; }
}
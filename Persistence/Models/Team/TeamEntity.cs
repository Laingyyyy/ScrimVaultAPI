namespace Persistence.Models.Team;

public class TeamEntity : BaseEntity
{
    public int TeamId { get; set; }

    public string Name { get; set; } = null!;
    
    public int OwnerPlayerId { get; set; }
}
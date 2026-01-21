namespace Persistence.Models.Team;

public class TeamEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public int OwnerPlayerId { get; set; }
}
namespace Persistence.Models.Team.Repository;

public interface ITeamRepository
{
    Task<TeamEntity> GetTeamById(int id);
}